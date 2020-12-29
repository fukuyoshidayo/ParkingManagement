namespace Spro
{
    partial class TransferAccount
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
            this.dgv_TransferAccount = new System.Windows.Forms.DataGridView();
            this.dtp_RegistDate = new System.Windows.Forms.DateTimePicker();
            this.bt_Regist = new System.Windows.Forms.Button();
            this.txt_SumTransfer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_SumPay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateCmb_TargetMonth = new Spro.DateComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TransferAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_TransferAccount
            // 
            this.dgv_TransferAccount.AllowUserToAddRows = false;
            this.dgv_TransferAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_TransferAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TransferAccount.Location = new System.Drawing.Point(30, 136);
            this.dgv_TransferAccount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_TransferAccount.MultiSelect = false;
            this.dgv_TransferAccount.Name = "dgv_TransferAccount";
            this.dgv_TransferAccount.RowHeadersVisible = false;
            this.dgv_TransferAccount.RowHeadersWidth = 51;
            this.dgv_TransferAccount.RowTemplate.Height = 24;
            this.dgv_TransferAccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_TransferAccount.Size = new System.Drawing.Size(702, 412);
            this.dgv_TransferAccount.TabIndex = 11;
            this.dgv_TransferAccount.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_TransferAccount_CellValueChanged);
            this.dgv_TransferAccount.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgv_TransferAccount_CurrentCellDirtyStateChanged);
            // 
            // dtp_RegistDate
            // 
            this.dtp_RegistDate.Location = new System.Drawing.Point(30, 84);
            this.dtp_RegistDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtp_RegistDate.Name = "dtp_RegistDate";
            this.dtp_RegistDate.Size = new System.Drawing.Size(213, 25);
            this.dtp_RegistDate.TabIndex = 2;
            // 
            // bt_Regist
            // 
            this.bt_Regist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Regist.Location = new System.Drawing.Point(676, 11);
            this.bt_Regist.Margin = new System.Windows.Forms.Padding(2);
            this.bt_Regist.Name = "bt_Regist";
            this.bt_Regist.Size = new System.Drawing.Size(75, 36);
            this.bt_Regist.TabIndex = 4;
            this.bt_Regist.Text = "登録";
            this.bt_Regist.UseVisualStyleBackColor = true;
            this.bt_Regist.Click += new System.EventHandler(this.bt_Regist_Click);
            // 
            // txt_SumTransfer
            // 
            this.txt_SumTransfer.Location = new System.Drawing.Point(270, 84);
            this.txt_SumTransfer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_SumTransfer.Name = "txt_SumTransfer";
            this.txt_SumTransfer.Size = new System.Drawing.Size(144, 25);
            this.txt_SumTransfer.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "登録日";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "口振額合計";
            // 
            // txt_SumPay
            // 
            this.txt_SumPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_SumPay.Enabled = false;
            this.txt_SumPay.Location = new System.Drawing.Point(588, 571);
            this.txt_SumPay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_SumPay.Name = "txt_SumPay";
            this.txt_SumPay.Size = new System.Drawing.Size(144, 25);
            this.txt_SumPay.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(478, 575);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 17;
            this.label3.Text = "料金合計";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(344, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 19;
            this.label4.Text = "分口振登録";
            // 
            // dateCmb_TargetMonth
            // 
            this.dateCmb_TargetMonth.Location = new System.Drawing.Point(109, 11);
            this.dateCmb_TargetMonth.Margin = new System.Windows.Forms.Padding(2);
            this.dateCmb_TargetMonth.Name = "dateCmb_TargetMonth";
            this.dateCmb_TargetMonth.Size = new System.Drawing.Size(241, 38);
            this.dateCmb_TargetMonth.TabIndex = 1;
            // 
            // TransferAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 640);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateCmb_TargetMonth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_SumPay);
            this.Controls.Add(this.txt_SumTransfer);
            this.Controls.Add(this.bt_Regist);
            this.Controls.Add(this.dtp_RegistDate);
            this.Controls.Add(this.dgv_TransferAccount);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "TransferAccount";
            this.ShowReturn = true;
            this.Text = "TransferAccount";
            this.Load += new System.EventHandler(this.TransferAccount_Load);
            this.Controls.SetChildIndex(this.dgv_TransferAccount, 0);
            this.Controls.SetChildIndex(this.dtp_RegistDate, 0);
            this.Controls.SetChildIndex(this.bt_Regist, 0);
            this.Controls.SetChildIndex(this.txt_SumTransfer, 0);
            this.Controls.SetChildIndex(this.txt_SumPay, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.dateCmb_TargetMonth, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TransferAccount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_TransferAccount;
        private System.Windows.Forms.DateTimePicker dtp_RegistDate;
        private System.Windows.Forms.Button bt_Regist;
        private System.Windows.Forms.TextBox txt_SumTransfer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_SumPay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DateComboBox dateCmb_TargetMonth;
    }
}