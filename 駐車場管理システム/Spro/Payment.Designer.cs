namespace Spro
{
    partial class Payment
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
            this.dgv_Payment = new System.Windows.Forms.DataGridView();
            this.cmb_PaymentList = new System.Windows.Forms.ComboBox();
            this.bt_Regist = new System.Windows.Forms.Button();
            this.dateCmb_AgreeMonth = new Spro.DateComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Payment)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Payment
            // 
            this.dgv_Payment.AllowUserToAddRows = false;
            this.dgv_Payment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Payment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Payment.Location = new System.Drawing.Point(11, 77);
            this.dgv_Payment.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_Payment.Name = "dgv_Payment";
            this.dgv_Payment.RowHeadersVisible = false;
            this.dgv_Payment.RowHeadersWidth = 51;
            this.dgv_Payment.RowTemplate.Height = 27;
            this.dgv_Payment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Payment.Size = new System.Drawing.Size(899, 356);
            this.dgv_Payment.TabIndex = 1;
            this.dgv_Payment.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Payment_CellDoubleClick);
            // 
            // cmb_PaymentList
            // 
            this.cmb_PaymentList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_PaymentList.FormattingEnabled = true;
            this.cmb_PaymentList.Location = new System.Drawing.Point(613, 34);
            this.cmb_PaymentList.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_PaymentList.Name = "cmb_PaymentList";
            this.cmb_PaymentList.Size = new System.Drawing.Size(160, 26);
            this.cmb_PaymentList.TabIndex = 2;
            this.cmb_PaymentList.SelectedIndexChanged += new System.EventHandler(this.cmb_PaymentList_SelectedIndexChanged);
            // 
            // bt_Regist
            // 
            this.bt_Regist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Regist.Location = new System.Drawing.Point(835, 11);
            this.bt_Regist.Margin = new System.Windows.Forms.Padding(2);
            this.bt_Regist.Name = "bt_Regist";
            this.bt_Regist.Size = new System.Drawing.Size(75, 36);
            this.bt_Regist.TabIndex = 3;
            this.bt_Regist.Text = "登録";
            this.bt_Regist.UseVisualStyleBackColor = true;
            this.bt_Regist.Click += new System.EventHandler(this.bt_Regist_Click);
            // 
            // dateCmb_AgreeMonth
            // 
            this.dateCmb_AgreeMonth.Location = new System.Drawing.Point(106, 11);
            this.dateCmb_AgreeMonth.Margin = new System.Windows.Forms.Padding(2);
            this.dateCmb_AgreeMonth.Name = "dateCmb_AgreeMonth";
            this.dateCmb_AgreeMonth.Size = new System.Drawing.Size(230, 38);
            this.dateCmb_AgreeMonth.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(346, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "時点での契約者";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(609, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "支払方法";
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 482);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateCmb_AgreeMonth);
            this.Controls.Add(this.bt_Regist);
            this.Controls.Add(this.cmb_PaymentList);
            this.Controls.Add(this.dgv_Payment);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "Payment";
            this.ShowReturn = true;
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.Payment_Load);
            this.Controls.SetChildIndex(this.dgv_Payment, 0);
            this.Controls.SetChildIndex(this.cmb_PaymentList, 0);
            this.Controls.SetChildIndex(this.bt_Regist, 0);
            this.Controls.SetChildIndex(this.dateCmb_AgreeMonth, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Payment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Payment;
        private System.Windows.Forms.ComboBox cmb_PaymentList;
        private System.Windows.Forms.Button bt_Regist;
        private DateComboBox dateCmb_AgreeMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}