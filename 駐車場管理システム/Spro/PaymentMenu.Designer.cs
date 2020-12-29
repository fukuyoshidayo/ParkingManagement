namespace Spro
{
    partial class PaymentMenu
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
            this.bt_PayRegist = new System.Windows.Forms.Button();
            this.bt_Reminder = new System.Windows.Forms.Button();
            this.bt_Refund = new System.Windows.Forms.Button();
            this.bt_PaymentList = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_Koufuri = new System.Windows.Forms.Button();
            this.bt_Furikomi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_PayRegist
            // 
            this.bt_PayRegist.Location = new System.Drawing.Point(46, 126);
            this.bt_PayRegist.Margin = new System.Windows.Forms.Padding(2);
            this.bt_PayRegist.Name = "bt_PayRegist";
            this.bt_PayRegist.Size = new System.Drawing.Size(161, 60);
            this.bt_PayRegist.TabIndex = 1;
            this.bt_PayRegist.Text = "支払登録";
            this.bt_PayRegist.UseVisualStyleBackColor = true;
            this.bt_PayRegist.Click += new System.EventHandler(this.bt_PayRegist_Click);
            // 
            // bt_Reminder
            // 
            this.bt_Reminder.Location = new System.Drawing.Point(266, 126);
            this.bt_Reminder.Margin = new System.Windows.Forms.Padding(2);
            this.bt_Reminder.Name = "bt_Reminder";
            this.bt_Reminder.Size = new System.Drawing.Size(161, 60);
            this.bt_Reminder.TabIndex = 4;
            this.bt_Reminder.Text = "督促";
            this.bt_Reminder.UseVisualStyleBackColor = true;
            this.bt_Reminder.Click += new System.EventHandler(this.bt_Reminder_Click);
            // 
            // bt_Refund
            // 
            this.bt_Refund.Location = new System.Drawing.Point(266, 212);
            this.bt_Refund.Margin = new System.Windows.Forms.Padding(2);
            this.bt_Refund.Name = "bt_Refund";
            this.bt_Refund.Size = new System.Drawing.Size(161, 60);
            this.bt_Refund.TabIndex = 5;
            this.bt_Refund.Text = "返金";
            this.bt_Refund.UseVisualStyleBackColor = true;
            this.bt_Refund.Click += new System.EventHandler(this.bt_Refund_Click);
            // 
            // bt_PaymentList
            // 
            this.bt_PaymentList.Location = new System.Drawing.Point(266, 300);
            this.bt_PaymentList.Margin = new System.Windows.Forms.Padding(2);
            this.bt_PaymentList.Name = "bt_PaymentList";
            this.bt_PaymentList.Size = new System.Drawing.Size(161, 60);
            this.bt_PaymentList.TabIndex = 6;
            this.bt_PaymentList.Text = "入金リスト";
            this.bt_PaymentList.UseVisualStyleBackColor = true;
            this.bt_PaymentList.Click += new System.EventHandler(this.bt_PaymentList_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.label1.Location = new System.Drawing.Point(102, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 30);
            this.label1.TabIndex = 7;
            this.label1.Text = "支払い管理メニュー";
            // 
            // bt_Koufuri
            // 
            this.bt_Koufuri.Location = new System.Drawing.Point(46, 212);
            this.bt_Koufuri.Margin = new System.Windows.Forms.Padding(2);
            this.bt_Koufuri.Name = "bt_Koufuri";
            this.bt_Koufuri.Size = new System.Drawing.Size(161, 60);
            this.bt_Koufuri.TabIndex = 2;
            this.bt_Koufuri.Text = "口振取込";
            this.bt_Koufuri.UseVisualStyleBackColor = true;
            this.bt_Koufuri.Click += new System.EventHandler(this.bt_Koufuri_Click);
            // 
            // bt_Furikomi
            // 
            this.bt_Furikomi.Location = new System.Drawing.Point(46, 300);
            this.bt_Furikomi.Margin = new System.Windows.Forms.Padding(2);
            this.bt_Furikomi.Name = "bt_Furikomi";
            this.bt_Furikomi.Size = new System.Drawing.Size(161, 60);
            this.bt_Furikomi.TabIndex = 3;
            this.bt_Furikomi.Text = "振込取込";
            this.bt_Furikomi.UseVisualStyleBackColor = true;
            this.bt_Furikomi.Click += new System.EventHandler(this.bt_Furikomi_Click);
            // 
            // PaymentMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 415);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_PaymentList);
            this.Controls.Add(this.bt_Refund);
            this.Controls.Add(this.bt_Reminder);
            this.Controls.Add(this.bt_Furikomi);
            this.Controls.Add(this.bt_Koufuri);
            this.Controls.Add(this.bt_PayRegist);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "PaymentMenu";
            this.ShowReturn = true;
            this.Text = "Payment";
            this.Controls.SetChildIndex(this.bt_PayRegist, 0);
            this.Controls.SetChildIndex(this.bt_Koufuri, 0);
            this.Controls.SetChildIndex(this.bt_Furikomi, 0);
            this.Controls.SetChildIndex(this.bt_Reminder, 0);
            this.Controls.SetChildIndex(this.bt_Refund, 0);
            this.Controls.SetChildIndex(this.bt_PaymentList, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bt_PayRegist;
        private System.Windows.Forms.Button bt_Reminder;
        private System.Windows.Forms.Button bt_Refund;
        private System.Windows.Forms.Button bt_PaymentList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_Koufuri;
        private System.Windows.Forms.Button bt_Furikomi;
    }
}