namespace Spro
{
    partial class PaymentEdit
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
            this.bt_NewRegist = new System.Windows.Forms.Button();
            this.dgv_PaymentList = new System.Windows.Forms.DataGridView();
            this.bt_Regist = new System.Windows.Forms.Button();
            this.grb_AgreeInfo = new System.Windows.Forms.GroupBox();
            this.lbl_Monthly = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_AgreeID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_ParkingList = new System.Windows.Forms.DataGridView();
            this.txt_ClientName = new System.Windows.Forms.TextBox();
            this.txt_ClientAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.住所 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_RegistDate = new System.Windows.Forms.DateTimePicker();
            this.txt_Money = new System.Windows.Forms.TextBox();
            this.lbl_EditMode = new System.Windows.Forms.Label();
            this.grb_PayRegist = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_Payment = new System.Windows.Forms.ComboBox();
            this.bt_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PaymentList)).BeginInit();
            this.grb_AgreeInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ParkingList)).BeginInit();
            this.grb_PayRegist.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_NewRegist
            // 
            this.bt_NewRegist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_NewRegist.Location = new System.Drawing.Point(918, 464);
            this.bt_NewRegist.Margin = new System.Windows.Forms.Padding(2);
            this.bt_NewRegist.Name = "bt_NewRegist";
            this.bt_NewRegist.Size = new System.Drawing.Size(75, 36);
            this.bt_NewRegist.TabIndex = 7;
            this.bt_NewRegist.Text = "新規";
            this.bt_NewRegist.UseVisualStyleBackColor = true;
            this.bt_NewRegist.Click += new System.EventHandler(this.bt_NewRegist_Click);
            // 
            // dgv_PaymentList
            // 
            this.dgv_PaymentList.AllowUserToAddRows = false;
            this.dgv_PaymentList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_PaymentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PaymentList.Location = new System.Drawing.Point(12, 53);
            this.dgv_PaymentList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_PaymentList.MultiSelect = false;
            this.dgv_PaymentList.Name = "dgv_PaymentList";
            this.dgv_PaymentList.ReadOnly = true;
            this.dgv_PaymentList.RowHeadersVisible = false;
            this.dgv_PaymentList.RowHeadersWidth = 51;
            this.dgv_PaymentList.RowTemplate.Height = 24;
            this.dgv_PaymentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_PaymentList.Size = new System.Drawing.Size(429, 447);
            this.dgv_PaymentList.TabIndex = 1;
            this.dgv_PaymentList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_PaymentList_CellDoubleClick);
            // 
            // bt_Regist
            // 
            this.bt_Regist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Regist.Location = new System.Drawing.Point(828, 464);
            this.bt_Regist.Margin = new System.Windows.Forms.Padding(2);
            this.bt_Regist.Name = "bt_Regist";
            this.bt_Regist.Size = new System.Drawing.Size(75, 36);
            this.bt_Regist.TabIndex = 5;
            this.bt_Regist.Text = "登録";
            this.bt_Regist.UseVisualStyleBackColor = true;
            this.bt_Regist.Click += new System.EventHandler(this.bt_Regist_Click);
            // 
            // grb_AgreeInfo
            // 
            this.grb_AgreeInfo.Controls.Add(this.lbl_Monthly);
            this.grb_AgreeInfo.Controls.Add(this.label7);
            this.grb_AgreeInfo.Controls.Add(this.lbl_AgreeID);
            this.grb_AgreeInfo.Controls.Add(this.label3);
            this.grb_AgreeInfo.Controls.Add(this.dgv_ParkingList);
            this.grb_AgreeInfo.Controls.Add(this.txt_ClientName);
            this.grb_AgreeInfo.Controls.Add(this.txt_ClientAddress);
            this.grb_AgreeInfo.Controls.Add(this.label2);
            this.grb_AgreeInfo.Controls.Add(this.住所);
            this.grb_AgreeInfo.Controls.Add(this.label1);
            this.grb_AgreeInfo.Location = new System.Drawing.Point(462, 50);
            this.grb_AgreeInfo.Margin = new System.Windows.Forms.Padding(2);
            this.grb_AgreeInfo.Name = "grb_AgreeInfo";
            this.grb_AgreeInfo.Padding = new System.Windows.Forms.Padding(2);
            this.grb_AgreeInfo.Size = new System.Drawing.Size(512, 229);
            this.grb_AgreeInfo.TabIndex = 14;
            this.grb_AgreeInfo.TabStop = false;
            this.grb_AgreeInfo.Text = "契約情報";
            // 
            // lbl_Monthly
            // 
            this.lbl_Monthly.AutoSize = true;
            this.lbl_Monthly.Location = new System.Drawing.Point(80, 160);
            this.lbl_Monthly.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Monthly.Name = "lbl_Monthly";
            this.lbl_Monthly.Size = new System.Drawing.Size(62, 18);
            this.lbl_Monthly.TabIndex = 24;
            this.lbl_Monthly.Text = "8000円";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 160);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 18);
            this.label7.TabIndex = 23;
            this.label7.Text = "月額";
            // 
            // lbl_AgreeID
            // 
            this.lbl_AgreeID.AutoSize = true;
            this.lbl_AgreeID.Location = new System.Drawing.Point(95, 28);
            this.lbl_AgreeID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_AgreeID.Name = "lbl_AgreeID";
            this.lbl_AgreeID.Size = new System.Drawing.Size(60, 18);
            this.lbl_AgreeID.TabIndex = 22;
            this.lbl_AgreeID.Text = "契約ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 18);
            this.label3.TabIndex = 21;
            this.label3.Text = "契約ID";
            // 
            // dgv_ParkingList
            // 
            this.dgv_ParkingList.AllowUserToAddRows = false;
            this.dgv_ParkingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ParkingList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_ParkingList.Enabled = false;
            this.dgv_ParkingList.Location = new System.Drawing.Point(224, 50);
            this.dgv_ParkingList.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_ParkingList.Name = "dgv_ParkingList";
            this.dgv_ParkingList.ReadOnly = true;
            this.dgv_ParkingList.RowHeadersVisible = false;
            this.dgv_ParkingList.RowHeadersWidth = 51;
            this.dgv_ParkingList.RowTemplate.Height = 27;
            this.dgv_ParkingList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ParkingList.Size = new System.Drawing.Size(272, 169);
            this.dgv_ParkingList.TabIndex = 20;
            // 
            // txt_ClientName
            // 
            this.txt_ClientName.Enabled = false;
            this.txt_ClientName.Location = new System.Drawing.Point(84, 59);
            this.txt_ClientName.Margin = new System.Windows.Forms.Padding(2);
            this.txt_ClientName.Name = "txt_ClientName";
            this.txt_ClientName.Size = new System.Drawing.Size(122, 25);
            this.txt_ClientName.TabIndex = 2;
            this.txt_ClientName.TabStop = false;
            // 
            // txt_ClientAddress
            // 
            this.txt_ClientAddress.Enabled = false;
            this.txt_ClientAddress.Location = new System.Drawing.Point(84, 91);
            this.txt_ClientAddress.Margin = new System.Windows.Forms.Padding(2);
            this.txt_ClientAddress.Name = "txt_ClientAddress";
            this.txt_ClientAddress.Size = new System.Drawing.Size(122, 25);
            this.txt_ClientAddress.TabIndex = 3;
            this.txt_ClientAddress.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "駐車場";
            // 
            // 住所
            // 
            this.住所.AutoSize = true;
            this.住所.Location = new System.Drawing.Point(28, 94);
            this.住所.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.住所.Name = "住所";
            this.住所.Size = new System.Drawing.Size(44, 18);
            this.住所.TabIndex = 10;
            this.住所.Text = "住所";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "名前";
            // 
            // dtp_RegistDate
            // 
            this.dtp_RegistDate.Location = new System.Drawing.Point(158, 49);
            this.dtp_RegistDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtp_RegistDate.Name = "dtp_RegistDate";
            this.dtp_RegistDate.Size = new System.Drawing.Size(200, 25);
            this.dtp_RegistDate.TabIndex = 2;
            // 
            // txt_Money
            // 
            this.txt_Money.Location = new System.Drawing.Point(158, 80);
            this.txt_Money.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Money.Name = "txt_Money";
            this.txt_Money.Size = new System.Drawing.Size(100, 25);
            this.txt_Money.TabIndex = 3;
            // 
            // lbl_EditMode
            // 
            this.lbl_EditMode.AutoSize = true;
            this.lbl_EditMode.Location = new System.Drawing.Point(29, 26);
            this.lbl_EditMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_EditMode.Name = "lbl_EditMode";
            this.lbl_EditMode.Size = new System.Drawing.Size(44, 18);
            this.lbl_EditMode.TabIndex = 17;
            this.lbl_EditMode.Text = "新規";
            // 
            // grb_PayRegist
            // 
            this.grb_PayRegist.Controls.Add(this.label6);
            this.grb_PayRegist.Controls.Add(this.label5);
            this.grb_PayRegist.Controls.Add(this.label4);
            this.grb_PayRegist.Controls.Add(this.cmb_Payment);
            this.grb_PayRegist.Controls.Add(this.lbl_EditMode);
            this.grb_PayRegist.Controls.Add(this.txt_Money);
            this.grb_PayRegist.Controls.Add(this.dtp_RegistDate);
            this.grb_PayRegist.Location = new System.Drawing.Point(462, 294);
            this.grb_PayRegist.Margin = new System.Windows.Forms.Padding(2);
            this.grb_PayRegist.Name = "grb_PayRegist";
            this.grb_PayRegist.Padding = new System.Windows.Forms.Padding(2);
            this.grb_PayRegist.Size = new System.Drawing.Size(388, 150);
            this.grb_PayRegist.TabIndex = 18;
            this.grb_PayRegist.TabStop = false;
            this.grb_PayRegist.Text = "支払登録";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 53);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 18);
            this.label6.TabIndex = 21;
            this.label6.Text = "登録日";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 80);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = "金額";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 112);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 19;
            this.label4.Text = "支払方法";
            // 
            // cmb_Payment
            // 
            this.cmb_Payment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Payment.FormattingEnabled = true;
            this.cmb_Payment.Location = new System.Drawing.Point(158, 110);
            this.cmb_Payment.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_Payment.Name = "cmb_Payment";
            this.cmb_Payment.Size = new System.Drawing.Size(125, 26);
            this.cmb_Payment.TabIndex = 4;
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Cancel.Location = new System.Drawing.Point(734, 464);
            this.bt_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(75, 36);
            this.bt_Cancel.TabIndex = 6;
            this.bt_Cancel.Text = "取消";
            this.bt_Cancel.UseVisualStyleBackColor = true;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // PaymentEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 536);
            this.Controls.Add(this.bt_Cancel);
            this.Controls.Add(this.grb_PayRegist);
            this.Controls.Add(this.grb_AgreeInfo);
            this.Controls.Add(this.bt_Regist);
            this.Controls.Add(this.dgv_PaymentList);
            this.Controls.Add(this.bt_NewRegist);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "PaymentEdit";
            this.ShowReturn = true;
            this.Text = "PaymentEdit";
            this.Load += new System.EventHandler(this.PaymentEdit_Load);
            this.Controls.SetChildIndex(this.bt_NewRegist, 0);
            this.Controls.SetChildIndex(this.dgv_PaymentList, 0);
            this.Controls.SetChildIndex(this.bt_Regist, 0);
            this.Controls.SetChildIndex(this.grb_AgreeInfo, 0);
            this.Controls.SetChildIndex(this.grb_PayRegist, 0);
            this.Controls.SetChildIndex(this.bt_Cancel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PaymentList)).EndInit();
            this.grb_AgreeInfo.ResumeLayout(false);
            this.grb_AgreeInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ParkingList)).EndInit();
            this.grb_PayRegist.ResumeLayout(false);
            this.grb_PayRegist.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bt_NewRegist;
        private System.Windows.Forms.DataGridView dgv_PaymentList;
        private System.Windows.Forms.Button bt_Regist;
        private System.Windows.Forms.GroupBox grb_AgreeInfo;
        private System.Windows.Forms.TextBox txt_ClientName;
        private System.Windows.Forms.TextBox txt_ClientAddress;
        private System.Windows.Forms.Label 住所;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_RegistDate;
        private System.Windows.Forms.TextBox txt_Money;
        private System.Windows.Forms.Label lbl_EditMode;
        private System.Windows.Forms.DataGridView dgv_ParkingList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_AgreeID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grb_PayRegist;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_Payment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bt_Cancel;
        private System.Windows.Forms.Label lbl_Monthly;
        private System.Windows.Forms.Label label7;
    }
}