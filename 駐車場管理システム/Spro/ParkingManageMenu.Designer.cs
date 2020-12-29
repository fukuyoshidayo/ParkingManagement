namespace Spro
{
    partial class ParkingManageMenu
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
            this.bt_Master = new System.Windows.Forms.Button();
            this.bt_Agreement = new System.Windows.Forms.Button();
            this.bt_end = new System.Windows.Forms.Button();
            this.bt_Payment = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_Master
            // 
            this.bt_Master.Location = new System.Drawing.Point(125, 164);
            this.bt_Master.Margin = new System.Windows.Forms.Padding(2);
            this.bt_Master.Name = "bt_Master";
            this.bt_Master.Size = new System.Drawing.Size(142, 61);
            this.bt_Master.TabIndex = 1;
            this.bt_Master.Text = "マスタ登録";
            this.bt_Master.UseVisualStyleBackColor = true;
            this.bt_Master.Click += new System.EventHandler(this.bt_Master_Click);
            // 
            // bt_Agreement
            // 
            this.bt_Agreement.Location = new System.Drawing.Point(125, 256);
            this.bt_Agreement.Margin = new System.Windows.Forms.Padding(2);
            this.bt_Agreement.Name = "bt_Agreement";
            this.bt_Agreement.Size = new System.Drawing.Size(142, 61);
            this.bt_Agreement.TabIndex = 2;
            this.bt_Agreement.Text = "契約管理";
            this.bt_Agreement.UseVisualStyleBackColor = true;
            this.bt_Agreement.Click += new System.EventHandler(this.bt_Agreement_Click);
            // 
            // bt_end
            // 
            this.bt_end.Location = new System.Drawing.Point(11, 11);
            this.bt_end.Margin = new System.Windows.Forms.Padding(2);
            this.bt_end.Name = "bt_end";
            this.bt_end.Size = new System.Drawing.Size(75, 36);
            this.bt_end.TabIndex = 4;
            this.bt_end.Text = "終了";
            this.bt_end.UseVisualStyleBackColor = true;
            this.bt_end.Click += new System.EventHandler(this.bt_back_Click);
            // 
            // bt_Payment
            // 
            this.bt_Payment.Location = new System.Drawing.Point(125, 344);
            this.bt_Payment.Margin = new System.Windows.Forms.Padding(2);
            this.bt_Payment.Name = "bt_Payment";
            this.bt_Payment.Size = new System.Drawing.Size(142, 61);
            this.bt_Payment.TabIndex = 3;
            this.bt_Payment.Text = "支払管理";
            this.bt_Payment.UseVisualStyleBackColor = true;
            this.bt_Payment.Click += new System.EventHandler(this.bt_Payment_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.label1.Location = new System.Drawing.Point(66, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "駐車場管理システム";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.label2.Location = new System.Drawing.Point(119, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "メインメニュー";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // ParkingManageMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 485);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_end);
            this.Controls.Add(this.bt_Payment);
            this.Controls.Add(this.bt_Agreement);
            this.Controls.Add(this.bt_Master);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "ParkingManageMenu";
            this.Text = "ParkingManageMenu";
            this.Load += new System.EventHandler(this.ParkingManageMenu_Load);
            this.Controls.SetChildIndex(this.bt_Master, 0);
            this.Controls.SetChildIndex(this.bt_Agreement, 0);
            this.Controls.SetChildIndex(this.bt_Payment, 0);
            this.Controls.SetChildIndex(this.bt_end, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_Master;
        private System.Windows.Forms.Button bt_Agreement;
        private System.Windows.Forms.Button bt_end;
        private System.Windows.Forms.Button bt_Payment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}