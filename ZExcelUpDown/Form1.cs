using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.OleDb; //...ExcelFileupload 관련.

namespace ZExcelUpDown
{
    public partial class Form1 : Form
    {
        DataTable g_sqlDtbl = new DataTable();
        DataTable g_sqlDtbl2 = new DataTable();
        OleDbConnection g_oleconXls = null;
        OleDbDataAdapter g_dataAdapter = null;
        OleDbDataAdapter g_dataAdapter2 = null;

        int g_nSelectedIndex = 0;
        string g_strcmbSheet_Val = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnXlsUp_Click(object sender, EventArgs e)
        {
            string strFilePath = string.Empty;
            OpenFileDialog dlgOpenFile = new OpenFileDialog();
            dlgOpenFile.InitialDirectory = @"D:\";
            dlgOpenFile.Filter = "Excel File (*.xlsx)|*.xlsx|Excel file (*.xls)|*.xls";

            if(dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                strFilePath = dlgOpenFile.FileName.ToString();
                //g_sqlDtbl = readExcelFile(strFilePath);
                g_sqlDtbl = readExcelFile2(strFilePath);
                this.Cursor = Cursors.Default;
            }
            
                
        }
        

        /// <summary>
        /// 'Microsoft.ACE.OLEDB.12.0' provider is not registered on the local machine solution
        /// https://youtu.be/uzLA_z7tDPs
        /// Import Excel To DatagridView
        /// https://www.youtube.com/watch?v=o2lzV9MKGBk
        /// </summary>
        /// <param name="p_strFilePath"></param>
        /// <returns></returns>
        private DataTable readExcelFile(string p_strFilePath)
        {
            DataTable sqlDtblResult = new DataTable();

            try
            {
                string strProvider = string.Empty;
                strProvider = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + p_strFilePath + @";Extended Properties=""Excel 12.0 Xml;HDR=Yes""";
                OleDbConnection xlsConn = new OleDbConnection(strProvider);
                xlsConn.Open();
                DataTable Sheets = xlsConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                string strQuery = "select * from [" + Sheets.Rows[0]["TABLE_NAME"].ToString() + "]";

                g_dataAdapter = new OleDbDataAdapter(strQuery, xlsConn);
                sqlDtblResult.Columns.Clear();
                sqlDtblResult.Rows.Clear();
                g_dataAdapter.Fill(sqlDtblResult);
                xlsConn.Close();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return sqlDtblResult;
        }

        private DataTable readExcelFile2(string p_strFilePath)
        {
            DataTable sqlDtblResult = new DataTable();
            DataTable sqlDtblSheets = new DataTable();
            DataTable sqlDtblCombo = new DataTable();

            try
            {
                string strProvider = string.Empty;
                strProvider = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + p_strFilePath + @";Extended Properties=""Excel 12.0 Xml;HDR=Yes""";
                g_oleconXls = new OleDbConnection(strProvider);
                g_oleconXls.Open();
                sqlDtblSheets = g_oleconXls.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                sqlDtblCombo.Columns.Add("Name");
                sqlDtblCombo.Columns.Add("Value");

                IEnumerable<DataRow> query =
                    from temp_row in sqlDtblSheets.AsEnumerable()
                    select temp_row;

                if(!query.Any())
                {
                    MessageBox.Show("해당 데이터가 없습니다.");
                    return sqlDtblResult;
                }

                sqlDtblCombo.Rows.Add(string.Empty, string.Empty);

                int nRow = 0;
                string strTmp = string.Empty;
                int nTmp = 0;
                decimal decTmp = 0;
                foreach(DataRow temp_row in query)
                {
                    //...주의 : 순서를 컬럼과 맞춰줘야 함.
                    var strArray = new String[] { temp_row.Field<string>("TABLE_NAME")
                                                };

                    string strSheetName = temp_row.Field<string>("TABLE_NAME");
                    string[] arrstrSheetName = strSheetName.Split(new Char[]{'$'});

                    sqlDtblCombo.Rows.Add(arrstrSheetName[0], arrstrSheetName[0]);
                }

                cmbSheet.Visible = true;
                lblCmbBox.Visible = true;

                this.cmbSheet.DataSource = sqlDtblCombo;
                this.cmbSheet.DisplayMember = "Name";
                this.cmbSheet.ValueMember = "Value";
                this.cmbSheet.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return sqlDtblResult;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbSheet.Visible = false;
            lblCmbBox.Visible = false;
        }


        private void cmbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            g_nSelectedIndex = 0;
            g_nSelectedIndex = this.cmbSheet.SelectedIndex;
            if (g_nSelectedIndex != 0)
            {
                g_strcmbSheet_Val = this.cmbSheet.SelectedValue.ToString();
                //string strTxt = this.cmbColorCar.SelectedText.ToString();
                //string strItm = this.cmbColorCar.SelectedItem.ToString();            
                //MessageBox.Show("strVal = " + g_strcmbColorCar_Val + "/ strTxt = " + strTxt + "/ strItm = " + strItm + "/ nIdx = " + g_nSelectedIndex);

                if (MessageBox.Show(g_strcmbSheet_Val + "시트를 업로드 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                //string strQuery = "select * from [" + Sheets.Rows[0]["TABLE_NAME"].ToString() + "]";
                string strQuery = "select * from [" + g_strcmbSheet_Val + "$]";

                g_dataAdapter2 = new OleDbDataAdapter(strQuery, g_oleconXls);
                g_sqlDtbl2 = new DataTable();
                g_sqlDtbl2.Columns.Clear();
                g_sqlDtbl2.Rows.Clear();
                g_dataAdapter2.Fill(g_sqlDtbl2);

                dataGridView1.DataSource = g_sqlDtbl2;

                g_oleconXls.Close();                

            }
        }
    }
}
