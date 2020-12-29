namespace Spro
{
    partial class PayRefund
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
            this.label1 = new System.Windows.Forms.Label();
            this.dateCmb_TargetMonth = new Spro.DateComboBox();
            this.dgv_PayRefundList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PayRefundList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(363, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "時点で契約無し";
            // 
            // dateCmb_TargetMonth
            // 
            this.dateCmb_TargetMonth.Location = new System.Drawing.Point(128, 11);
            this.dateCmb_TargetMonth.Margin = new System.Windows.Forms.Padding(2);
            this.dateCmb_TargetMonth.Name = "dateCmb_TargetMonth";
            this.dateCmb_TargetMonth.Size = new System.Drawing.Size(241, 38);
            this.dateCmb_TargetMonth.TabIndex = 3;
            // 
            // dgv_PayRefundList
            // 
            this.dgv_PayRefundList.AllowUserToAddRows = false;
            this.dgv_PayRefundList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_PayRefundList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PayRefundList.Location = new System.Drawing.Point(15, 83);
            this.dgv_PayRefundList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_PayRefundList.MultiSelect = false;
            this.dgv_PayRefundList.Name = "dgv_PayRefundList";
            this.dgv_PayRefundList.ReadOnly = true;
            this.dgv_PayRefundList.RowHeadersVisible = false;
            this.dgv_PayRefundList.RowHeadersWidth = 51;
            this.dgv_PayRefundList.RowTemplate.Height = 24;
            this.dgv_PayRefundList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_PayRefundList.Size = new System.Drawing.Size(682, 467);
            this.dgv_PayRefundList.TabIndex = 8;
            // 
            // PayRefund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 606);
            this.Controls.Add(this.dgv_PayRefundList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateCmb_TargetMonth);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "PayRefund";
            this.ShowReturn = true;
            this.Text = "PayRefund";
            this.Load += new System.EventHandler(this.PayRefund_Load);
            this.Controls.SetChildIndex(this.dateCmb_TargetMonth, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dgv_PayRefundList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PayRefundList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DateComboBox dateCmb_TargetMonth;
        private System.Windows.Forms.DataGridView dgv_PayRefundList;
    }
}