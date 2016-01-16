namespace ZExcelUpDown
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnXlsUp = new System.Windows.Forms.Button();
            this.btnXlsDown = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSheet = new System.Windows.Forms.ComboBox();
            this.lblCmbBox = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXlsUp
            // 
            this.btnXlsUp.Location = new System.Drawing.Point(13, 13);
            this.btnXlsUp.Name = "btnXlsUp";
            this.btnXlsUp.Size = new System.Drawing.Size(118, 23);
            this.btnXlsUp.TabIndex = 0;
            this.btnXlsUp.Text = "엑셀 업로드";
            this.btnXlsUp.UseVisualStyleBackColor = true;
            this.btnXlsUp.Click += new System.EventHandler(this.btnXlsUp_Click);
            // 
            // btnXlsDown
            // 
            this.btnXlsDown.Location = new System.Drawing.Point(18, 480);
            this.btnXlsDown.Name = "btnXlsDown";
            this.btnXlsDown.Size = new System.Drawing.Size(118, 23);
            this.btnXlsDown.TabIndex = 0;
            this.btnXlsDown.Text = "엑셀양식 다운로드";
            this.btnXlsDown.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 520);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Git을 이용한 엑셀업다운로드 개발중!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 560);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Git을 이용한 엑셀업다운로드 개발중!";
            // 
            // cmbSheet
            // 
            this.cmbSheet.FormattingEnabled = true;
            this.cmbSheet.Location = new System.Drawing.Point(15, 62);
            this.cmbSheet.Name = "cmbSheet";
            this.cmbSheet.Size = new System.Drawing.Size(121, 20);
            this.cmbSheet.TabIndex = 2;
            this.cmbSheet.SelectedIndexChanged += new System.EventHandler(this.cmbSheet_SelectedIndexChanged);
            // 
            // lblCmbBox
            // 
            this.lblCmbBox.AutoSize = true;
            this.lblCmbBox.Location = new System.Drawing.Point(13, 47);
            this.lblCmbBox.Name = "lblCmbBox";
            this.lblCmbBox.Size = new System.Drawing.Size(161, 12);
            this.lblCmbBox.TabIndex = 3;
            this.lblCmbBox.Text = "업로드할 시트를 선택하세요.";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 108);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(513, 300);
            this.dataGridView1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 598);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblCmbBox);
            this.Controls.Add(this.cmbSheet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnXlsDown);
            this.Controls.Add(this.btnXlsUp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnXlsUp;
        private System.Windows.Forms.Button btnXlsDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSheet;
        private System.Windows.Forms.Label lblCmbBox;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

