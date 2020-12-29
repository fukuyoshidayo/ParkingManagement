namespace Spro
{
    partial class PayReminder
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
            this.dateCmb_TargetMonth = new Spro.DateComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_PayReminderList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PayReminderList)).BeginInit();
            this.SuspendLayout();
            // 
            // dateCmb_TargetMonth
            // 
            this.dateCmb_TargetMonth.Location = new System.Drawing.Point(102, 11);
            this.dateCmb_TargetMonth.Margin = new System.Windows.Forms.Padding(2);
            this.dateCmb_TargetMonth.Name = "dateCmb_TargetMonth";
            this.dateCmb_TargetMonth.Size = new System.Drawing.Size(241, 38);
            this.dateCmb_TargetMonth.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(337, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "分までの不足分";
            // 
            // dgv_PayReminderList
            // 
            this.dgv_PayReminderList.AllowUserToAddRows = false;
            this.dgv_PayReminderList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_PayReminderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PayReminderList.Location = new System.Drawing.Point(25, 79);
            this.dgv_PayReminderList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_PayReminderList.MultiSelect = false;
            this.dgv_PayReminderList.Name = "dgv_PayReminderList";
            this.dgv_PayReminderList.ReadOnly = true;
            this.dgv_PayReminderList.RowHeadersVisible = false;
            this.dgv_PayReminderList.RowHeadersWidth = 51;
            this.dgv_PayReminderList.RowTemplate.Height = 24;
            this.dgv_PayReminderList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_PayReminderList.Size = new System.Drawing.Size(661, 513);
            this.dgv_PayReminderList.TabIndex = 7;
            // 
            // PayReminder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 640);
            this.Controls.Add(this.dgv_PayReminderList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateCmb_TargetMonth);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "PayReminder";
            this.ShowReturn = true;
            this.Text = "PayReminder";
            this.Load += new System.EventHandler(this.PayReminder_Load);
            this.Controls.SetChildIndex(this.dateCmb_TargetMonth, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dgv_PayReminderList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PayReminderList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DateComboBox dateCmb_TargetMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_PayReminderList;
    }
}