namespace Spro
{
    partial class AgreementEdit
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
            this.lbl_EditMode = new System.Windows.Forms.Label();
            this.txt_ClientName = new System.Windows.Forms.TextBox();
            this.txt_ClientAddress = new System.Windows.Forms.TextBox();
            this.txt_ClientTEL = new System.Windows.Forms.TextBox();
            this.dtp_AgreeFrom = new System.Windows.Forms.DateTimePicker();
            this.dtp_AgreeTo = new System.Windows.Forms.DateTimePicker();
            this.cmb_Payment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.住所 = new System.Windows.Forms.Label();
            this.電話 = new System.Windows.Forms.Label();
            this.grb_ClientInfo = new System.Windows.Forms.GroupBox();
            this.grb_Agreement = new System.Windows.Forms.GroupBox();
            this.chk_Move = new System.Windows.Forms.CheckBox();
            this.bt_Add = new System.Windows.Forms.Button();
            this.bt_Del = new System.Windows.Forms.Button();
            this.dgv_ParkingList = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Remarks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_Regist = new System.Windows.Forms.Button();
            this.grb_ClientInfo.SuspendLayout();
            this.grb_Agreement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ParkingList)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_EditMode
            // 
            this.lbl_EditMode.AutoSize = true;
            this.lbl_EditMode.Location = new System.Drawing.Point(104, 14);
            this.lbl_EditMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_EditMode.Name = "lbl_EditMode";
            this.lbl_EditMode.Size = new System.Drawing.Size(44, 18);
            this.lbl_EditMode.TabIndex = 1;
            this.lbl_EditMode.Text = "新規";
            // 
            // txt_ClientName
            // 
            this.txt_ClientName.Enabled = false;
            this.txt_ClientName.Location = new System.Drawing.Point(112, 24);
            this.txt_ClientName.Margin = new System.Windows.Forms.Padding(2);
            this.txt_ClientName.Name = "txt_ClientName";
            this.txt_ClientName.Size = new System.Drawing.Size(324, 25);
            this.txt_ClientName.TabIndex = 1;
            this.txt_ClientName.TabStop = false;
            // 
            // txt_ClientAddress
            // 
            this.txt_ClientAddress.Enabled = false;
            this.txt_ClientAddress.Location = new System.Drawing.Point(112, 67);
            this.txt_ClientAddress.Margin = new System.Windows.Forms.Padding(2);
            this.txt_ClientAddress.Name = "txt_ClientAddress";
            this.txt_ClientAddress.Size = new System.Drawing.Size(324, 25);
            this.txt_ClientAddress.TabIndex = 2;
            this.txt_ClientAddress.TabStop = false;
            // 
            // txt_ClientTEL
            // 
            this.txt_ClientTEL.Enabled = false;
            this.txt_ClientTEL.Location = new System.Drawing.Point(112, 109);
            this.txt_ClientTEL.Margin = new System.Windows.Forms.Padding(2);
            this.txt_ClientTEL.Name = "txt_ClientTEL";
            this.txt_ClientTEL.Size = new System.Drawing.Size(324, 25);
            this.txt_ClientTEL.TabIndex = 4;
            this.txt_ClientTEL.TabStop = false;
            // 
            // dtp_AgreeFrom
            // 
            this.dtp_AgreeFrom.Location = new System.Drawing.Point(18, 102);
            this.dtp_AgreeFrom.Margin = new System.Windows.Forms.Padding(2);
            this.dtp_AgreeFrom.Name = "dtp_AgreeFrom";
            this.dtp_AgreeFrom.Size = new System.Drawing.Size(200, 25);
            this.dtp_AgreeFrom.TabIndex = 2;
            // 
            // dtp_AgreeTo
            // 
            this.dtp_AgreeTo.Checked = false;
            this.dtp_AgreeTo.Location = new System.Drawing.Point(18, 156);
            this.dtp_AgreeTo.Margin = new System.Windows.Forms.Padding(2);
            this.dtp_AgreeTo.Name = "dtp_AgreeTo";
            this.dtp_AgreeTo.ShowCheckBox = true;
            this.dtp_AgreeTo.Size = new System.Drawing.Size(200, 25);
            this.dtp_AgreeTo.TabIndex = 3;
            // 
            // cmb_Payment
            // 
            this.cmb_Payment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Payment.FormattingEnabled = true;
            this.cmb_Payment.Location = new System.Drawing.Point(112, 36);
            this.cmb_Payment.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_Payment.Name = "cmb_Payment";
            this.cmb_Payment.Size = new System.Drawing.Size(125, 26);
            this.cmb_Payment.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "名前";
            // 
            // 住所
            // 
            this.住所.AutoSize = true;
            this.住所.Location = new System.Drawing.Point(28, 70);
            this.住所.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.住所.Name = "住所";
            this.住所.Size = new System.Drawing.Size(44, 18);
            this.住所.TabIndex = 10;
            this.住所.Text = "住所";
            // 
            // 電話
            // 
            this.電話.AutoSize = true;
            this.電話.Location = new System.Drawing.Point(28, 112);
            this.電話.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.電話.Name = "電話";
            this.電話.Size = new System.Drawing.Size(44, 18);
            this.電話.TabIndex = 11;
            this.電話.Text = "電話";
            // 
            // grb_ClientInfo
            // 
            this.grb_ClientInfo.Controls.Add(this.txt_ClientName);
            this.grb_ClientInfo.Controls.Add(this.電話);
            this.grb_ClientInfo.Controls.Add(this.txt_ClientAddress);
            this.grb_ClientInfo.Controls.Add(this.住所);
            this.grb_ClientInfo.Controls.Add(this.txt_ClientTEL);
            this.grb_ClientInfo.Controls.Add(this.label1);
            this.grb_ClientInfo.Location = new System.Drawing.Point(41, 54);
            this.grb_ClientInfo.Margin = new System.Windows.Forms.Padding(2);
            this.grb_ClientInfo.Name = "grb_ClientInfo";
            this.grb_ClientInfo.Padding = new System.Windows.Forms.Padding(2);
            this.grb_ClientInfo.Size = new System.Drawing.Size(478, 186);
            this.grb_ClientInfo.TabIndex = 12;
            this.grb_ClientInfo.TabStop = false;
            this.grb_ClientInfo.Text = "顧客情報";
            // 
            // grb_Agreement
            // 
            this.grb_Agreement.Controls.Add(this.chk_Move);
            this.grb_Agreement.Controls.Add(this.bt_Add);
            this.grb_Agreement.Controls.Add(this.bt_Del);
            this.grb_Agreement.Controls.Add(this.dgv_ParkingList);
            this.grb_Agreement.Controls.Add(this.label6);
            this.grb_Agreement.Controls.Add(this.txt_Remarks);
            this.grb_Agreement.Controls.Add(this.label5);
            this.grb_Agreement.Controls.Add(this.label4);
            this.grb_Agreement.Controls.Add(this.label3);
            this.grb_Agreement.Controls.Add(this.label2);
            this.grb_Agreement.Controls.Add(this.dtp_AgreeFrom);
            this.grb_Agreement.Controls.Add(this.dtp_AgreeTo);
            this.grb_Agreement.Controls.Add(this.cmb_Payment);
            this.grb_Agreement.Location = new System.Drawing.Point(41, 246);
            this.grb_Agreement.Margin = new System.Windows.Forms.Padding(2);
            this.grb_Agreement.Name = "grb_Agreement";
            this.grb_Agreement.Padding = new System.Windows.Forms.Padding(2);
            this.grb_Agreement.Size = new System.Drawing.Size(626, 325);
            this.grb_Agreement.TabIndex = 13;
            this.grb_Agreement.TabStop = false;
            this.grb_Agreement.Text = "契約情報";
            // 
            // chk_Move
            // 
            this.chk_Move.AutoSize = true;
            this.chk_Move.Location = new System.Drawing.Point(18, 188);
            this.chk_Move.Margin = new System.Windows.Forms.Padding(4);
            this.chk_Move.Name = "chk_Move";
            this.chk_Move.Size = new System.Drawing.Size(70, 22);
            this.chk_Move.TabIndex = 4;
            this.chk_Move.Text = "移動";
            this.chk_Move.UseVisualStyleBackColor = true;
            this.chk_Move.CheckedChanged += new System.EventHandler(this.chk_Move_CheckedChanged);
            // 
            // bt_Add
            // 
            this.bt_Add.Font = new System.Drawing.Font("MS UI Gothic", 6F);
            this.bt_Add.Location = new System.Drawing.Point(492, 212);
            this.bt_Add.Margin = new System.Windows.Forms.Padding(2);
            this.bt_Add.Name = "bt_Add";
            this.bt_Add.Size = new System.Drawing.Size(50, 30);
            this.bt_Add.TabIndex = 6;
            this.bt_Add.Text = "追加";
            this.bt_Add.UseVisualStyleBackColor = true;
            this.bt_Add.Click += new System.EventHandler(this.bt_Add_Click);
            // 
            // bt_Del
            // 
            this.bt_Del.Font = new System.Drawing.Font("MS UI Gothic", 6F);
            this.bt_Del.Location = new System.Drawing.Point(558, 212);
            this.bt_Del.Margin = new System.Windows.Forms.Padding(2);
            this.bt_Del.Name = "bt_Del";
            this.bt_Del.Size = new System.Drawing.Size(50, 30);
            this.bt_Del.TabIndex = 7;
            this.bt_Del.Text = "削除";
            this.bt_Del.UseVisualStyleBackColor = true;
            this.bt_Del.Click += new System.EventHandler(this.bt_Del_Click);
            // 
            // dgv_ParkingList
            // 
            this.dgv_ParkingList.AllowUserToAddRows = false;
            this.dgv_ParkingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ParkingList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_ParkingList.Location = new System.Drawing.Point(259, 36);
            this.dgv_ParkingList.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_ParkingList.Name = "dgv_ParkingList";
            this.dgv_ParkingList.ReadOnly = true;
            this.dgv_ParkingList.RowHeadersVisible = false;
            this.dgv_ParkingList.RowHeadersWidth = 51;
            this.dgv_ParkingList.RowTemplate.Height = 27;
            this.dgv_ParkingList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ParkingList.Size = new System.Drawing.Size(349, 170);
            this.dgv_ParkingList.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 218);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 18);
            this.label6.TabIndex = 15;
            this.label6.Text = "備考";
            // 
            // txt_Remarks
            // 
            this.txt_Remarks.Location = new System.Drawing.Point(18, 242);
            this.txt_Remarks.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Remarks.Multiline = true;
            this.txt_Remarks.Name = "txt_Remarks";
            this.txt_Remarks.Size = new System.Drawing.Size(459, 65);
            this.txt_Remarks.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(256, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "駐車場";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "支払方法";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 133);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "～";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "期間";
            // 
            // bt_Regist
            // 
            this.bt_Regist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Regist.Location = new System.Drawing.Point(612, 11);
            this.bt_Regist.Margin = new System.Windows.Forms.Padding(2);
            this.bt_Regist.Name = "bt_Regist";
            this.bt_Regist.Size = new System.Drawing.Size(75, 36);
            this.bt_Regist.TabIndex = 14;
            this.bt_Regist.Text = "登録";
            this.bt_Regist.UseVisualStyleBackColor = true;
            this.bt_Regist.Click += new System.EventHandler(this.bt_Regist_Click);
            // 
            // AgreementEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 616);
            this.Controls.Add(this.bt_Regist);
            this.Controls.Add(this.lbl_EditMode);
            this.Controls.Add(this.grb_ClientInfo);
            this.Controls.Add(this.grb_Agreement);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "AgreementEdit";
            this.ShowReturn = true;
            this.Text = "AgreementEdit";
            this.Load += new System.EventHandler(this.AgreementEdit_Load);
            this.Controls.SetChildIndex(this.grb_Agreement, 0);
            this.Controls.SetChildIndex(this.grb_ClientInfo, 0);
            this.Controls.SetChildIndex(this.lbl_EditMode, 0);
            this.Controls.SetChildIndex(this.bt_Regist, 0);
            this.grb_ClientInfo.ResumeLayout(false);
            this.grb_ClientInfo.PerformLayout();
            this.grb_Agreement.ResumeLayout(false);
            this.grb_Agreement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ParkingList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_EditMode;
        private System.Windows.Forms.TextBox txt_ClientName;
        private System.Windows.Forms.TextBox txt_ClientAddress;
        private System.Windows.Forms.TextBox txt_ClientTEL;
        private System.Windows.Forms.DateTimePicker dtp_AgreeFrom;
        private System.Windows.Forms.DateTimePicker dtp_AgreeTo;
        private System.Windows.Forms.ComboBox cmb_Payment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label 住所;
        private System.Windows.Forms.Label 電話;
        private System.Windows.Forms.GroupBox grb_ClientInfo;
        private System.Windows.Forms.GroupBox grb_Agreement;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_Regist;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Remarks;
        private System.Windows.Forms.DataGridView dgv_ParkingList;
        private System.Windows.Forms.Button bt_Add;
        private System.Windows.Forms.Button bt_Del;
        private System.Windows.Forms.CheckBox chk_Move;
    }
}