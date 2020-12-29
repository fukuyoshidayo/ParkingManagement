namespace Spro
{
    partial class ClientMasterEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rdo_Person = new System.Windows.Forms.RadioButton();
            this.rdo_Corp = new System.Windows.Forms.RadioButton();
            this.pnl_Type = new System.Windows.Forms.Panel();
            this.txt_ClientName = new System.Windows.Forms.TextBox();
            this.txt_ClientTEL = new System.Windows.Forms.TextBox();
            this.txt_ClientAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_Regist = new System.Windows.Forms.Button();
            this.lbl_EditMode = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Remarks = new System.Windows.Forms.TextBox();
            this.txt_AccountName1 = new System.Windows.Forms.TextBox();
            this.txt_AccountName2 = new System.Windows.Forms.TextBox();
            this.txt_AccountName3 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_AccountNo3 = new System.Windows.Forms.TextBox();
            this.txt_AccountNo1 = new System.Windows.Forms.TextBox();
            this.txt_AccountNo2 = new System.Windows.Forms.TextBox();
            this.pnl_Type.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdo_Person
            // 
            this.rdo_Person.AutoSize = true;
            this.rdo_Person.Checked = true;
            this.rdo_Person.Location = new System.Drawing.Point(12, 12);
            this.rdo_Person.Margin = new System.Windows.Forms.Padding(2);
            this.rdo_Person.Name = "rdo_Person";
            this.rdo_Person.Size = new System.Drawing.Size(69, 22);
            this.rdo_Person.TabIndex = 1;
            this.rdo_Person.TabStop = true;
            this.rdo_Person.Text = "個人";
            this.rdo_Person.UseVisualStyleBackColor = true;
            // 
            // rdo_Corp
            // 
            this.rdo_Corp.AutoSize = true;
            this.rdo_Corp.Location = new System.Drawing.Point(98, 12);
            this.rdo_Corp.Margin = new System.Windows.Forms.Padding(2);
            this.rdo_Corp.Name = "rdo_Corp";
            this.rdo_Corp.Size = new System.Drawing.Size(69, 22);
            this.rdo_Corp.TabIndex = 2;
            this.rdo_Corp.Text = "法人";
            this.rdo_Corp.UseVisualStyleBackColor = true;
            // 
            // pnl_Type
            // 
            this.pnl_Type.Controls.Add(this.rdo_Corp);
            this.pnl_Type.Controls.Add(this.rdo_Person);
            this.pnl_Type.Location = new System.Drawing.Point(114, 47);
            this.pnl_Type.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_Type.Name = "pnl_Type";
            this.pnl_Type.Size = new System.Drawing.Size(182, 48);
            this.pnl_Type.TabIndex = 1;
            // 
            // txt_ClientName
            // 
            this.txt_ClientName.Location = new System.Drawing.Point(31, 116);
            this.txt_ClientName.Margin = new System.Windows.Forms.Padding(2);
            this.txt_ClientName.Name = "txt_ClientName";
            this.txt_ClientName.Size = new System.Drawing.Size(305, 25);
            this.txt_ClientName.TabIndex = 2;
            // 
            // txt_ClientTEL
            // 
            this.txt_ClientTEL.Location = new System.Drawing.Point(31, 235);
            this.txt_ClientTEL.Margin = new System.Windows.Forms.Padding(2);
            this.txt_ClientTEL.Name = "txt_ClientTEL";
            this.txt_ClientTEL.Size = new System.Drawing.Size(305, 25);
            this.txt_ClientTEL.TabIndex = 4;
            // 
            // txt_ClientAddress
            // 
            this.txt_ClientAddress.Location = new System.Drawing.Point(31, 172);
            this.txt_ClientAddress.Margin = new System.Windows.Forms.Padding(2);
            this.txt_ClientAddress.Name = "txt_ClientAddress";
            this.txt_ClientAddress.Size = new System.Drawing.Size(305, 25);
            this.txt_ClientAddress.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "名前";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 150);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "住所";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 215);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "電話番号";
            // 
            // bt_Regist
            // 
            this.bt_Regist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Regist.Location = new System.Drawing.Point(720, 11);
            this.bt_Regist.Margin = new System.Windows.Forms.Padding(2);
            this.bt_Regist.Name = "bt_Regist";
            this.bt_Regist.Size = new System.Drawing.Size(75, 36);
            this.bt_Regist.TabIndex = 12;
            this.bt_Regist.Text = "登録";
            this.bt_Regist.UseVisualStyleBackColor = true;
            this.bt_Regist.Click += new System.EventHandler(this.bt_Regist_Click);
            // 
            // lbl_EditMode
            // 
            this.lbl_EditMode.AutoSize = true;
            this.lbl_EditMode.Location = new System.Drawing.Point(101, 13);
            this.lbl_EditMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_EditMode.Name = "lbl_EditMode";
            this.lbl_EditMode.Size = new System.Drawing.Size(44, 18);
            this.lbl_EditMode.TabIndex = 12;
            this.lbl_EditMode.Text = "新規";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 276);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "備考";
            // 
            // txt_Remarks
            // 
            this.txt_Remarks.Location = new System.Drawing.Point(31, 296);
            this.txt_Remarks.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Remarks.Multiline = true;
            this.txt_Remarks.Name = "txt_Remarks";
            this.txt_Remarks.Size = new System.Drawing.Size(760, 83);
            this.txt_Remarks.TabIndex = 5;
            // 
            // txt_AccountName1
            // 
            this.txt_AccountName1.Location = new System.Drawing.Point(8, 55);
            this.txt_AccountName1.Margin = new System.Windows.Forms.Padding(4);
            this.txt_AccountName1.Name = "txt_AccountName1";
            this.txt_AccountName1.Size = new System.Drawing.Size(173, 25);
            this.txt_AccountName1.TabIndex = 6;
            // 
            // txt_AccountName2
            // 
            this.txt_AccountName2.Location = new System.Drawing.Point(8, 89);
            this.txt_AccountName2.Margin = new System.Windows.Forms.Padding(4);
            this.txt_AccountName2.Name = "txt_AccountName2";
            this.txt_AccountName2.Size = new System.Drawing.Size(173, 25);
            this.txt_AccountName2.TabIndex = 8;
            // 
            // txt_AccountName3
            // 
            this.txt_AccountName3.Location = new System.Drawing.Point(8, 122);
            this.txt_AccountName3.Margin = new System.Windows.Forms.Padding(4);
            this.txt_AccountName3.Name = "txt_AccountName3";
            this.txt_AccountName3.Size = new System.Drawing.Size(173, 25);
            this.txt_AccountName3.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_AccountNo3);
            this.groupBox1.Controls.Add(this.txt_AccountNo1);
            this.groupBox1.Controls.Add(this.txt_AccountNo2);
            this.groupBox1.Controls.Add(this.txt_AccountName1);
            this.groupBox1.Controls.Add(this.txt_AccountName3);
            this.groupBox1.Controls.Add(this.txt_AccountName2);
            this.groupBox1.Location = new System.Drawing.Point(368, 83);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(395, 160);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "口座情報";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(204, 34);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 16;
            this.label6.Text = "口座番号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 34);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "口座名義（半角ｶﾅ）";
            // 
            // txt_AccountNo3
            // 
            this.txt_AccountNo3.Location = new System.Drawing.Point(208, 122);
            this.txt_AccountNo3.Margin = new System.Windows.Forms.Padding(4);
            this.txt_AccountNo3.Name = "txt_AccountNo3";
            this.txt_AccountNo3.Size = new System.Drawing.Size(173, 25);
            this.txt_AccountNo3.TabIndex = 11;
            // 
            // txt_AccountNo1
            // 
            this.txt_AccountNo1.Location = new System.Drawing.Point(208, 55);
            this.txt_AccountNo1.Margin = new System.Windows.Forms.Padding(4);
            this.txt_AccountNo1.Name = "txt_AccountNo1";
            this.txt_AccountNo1.Size = new System.Drawing.Size(173, 25);
            this.txt_AccountNo1.TabIndex = 7;
            this.txt_AccountNo1.TextChanged += new System.EventHandler(this.txt_AccountNo1_TextChanged);
            // 
            // txt_AccountNo2
            // 
            this.txt_AccountNo2.Location = new System.Drawing.Point(208, 89);
            this.txt_AccountNo2.Margin = new System.Windows.Forms.Padding(4);
            this.txt_AccountNo2.Name = "txt_AccountNo2";
            this.txt_AccountNo2.Size = new System.Drawing.Size(173, 25);
            this.txt_AccountNo2.TabIndex = 9;
            // 
            // ClientMasterEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 425);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_EditMode);
            this.Controls.Add(this.bt_Regist);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ClientAddress);
            this.Controls.Add(this.txt_Remarks);
            this.Controls.Add(this.txt_ClientTEL);
            this.Controls.Add(this.txt_ClientName);
            this.Controls.Add(this.pnl_Type);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "ClientMasterEdit";
            this.ShowReturn = true;
            this.Text = "ClientMaster";
            this.Load += new System.EventHandler(this.ClientMaster_Load);
            this.Controls.SetChildIndex(this.pnl_Type, 0);
            this.Controls.SetChildIndex(this.txt_ClientName, 0);
            this.Controls.SetChildIndex(this.txt_ClientTEL, 0);
            this.Controls.SetChildIndex(this.txt_Remarks, 0);
            this.Controls.SetChildIndex(this.txt_ClientAddress, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.bt_Regist, 0);
            this.Controls.SetChildIndex(this.lbl_EditMode, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.pnl_Type.ResumeLayout(false);
            this.pnl_Type.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdo_Person;
        private System.Windows.Forms.RadioButton rdo_Corp;
        private System.Windows.Forms.Panel pnl_Type;
        private System.Windows.Forms.TextBox txt_ClientName;
        private System.Windows.Forms.TextBox txt_ClientTEL;
        private System.Windows.Forms.TextBox txt_ClientAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_Regist;
        private System.Windows.Forms.Label lbl_EditMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Remarks;
        private System.Windows.Forms.TextBox txt_AccountName1;
        private System.Windows.Forms.TextBox txt_AccountName2;
        private System.Windows.Forms.TextBox txt_AccountName3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_AccountNo1;
        private System.Windows.Forms.TextBox txt_AccountNo3;
        private System.Windows.Forms.TextBox txt_AccountNo2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}