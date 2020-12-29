namespace Spro
{
    partial class AgreemenMenut
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
            this.bt_ToParking = new System.Windows.Forms.Button();
            this.btn_ToClient = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_ToParking
            // 
            this.bt_ToParking.Location = new System.Drawing.Point(105, 237);
            this.bt_ToParking.Margin = new System.Windows.Forms.Padding(2);
            this.bt_ToParking.Name = "bt_ToParking";
            this.bt_ToParking.Size = new System.Drawing.Size(122, 49);
            this.bt_ToParking.TabIndex = 2;
            this.bt_ToParking.Text = "駐車場から";
            this.bt_ToParking.UseVisualStyleBackColor = true;
            this.bt_ToParking.Click += new System.EventHandler(this.bt_ToParking_Click);
            // 
            // btn_ToClient
            // 
            this.btn_ToClient.Location = new System.Drawing.Point(105, 144);
            this.btn_ToClient.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ToClient.Name = "btn_ToClient";
            this.btn_ToClient.Size = new System.Drawing.Size(122, 49);
            this.btn_ToClient.TabIndex = 1;
            this.btn_ToClient.Text = "顧客から";
            this.btn_ToClient.UseVisualStyleBackColor = true;
            this.btn_ToClient.Click += new System.EventHandler(this.btn_ToClient_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.label1.Location = new System.Drawing.Point(57, 77);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = "契約管理メニュー";
            // 
            // AgreemenMenut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 389);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_ToClient);
            this.Controls.Add(this.bt_ToParking);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "AgreemenMenut";
            this.ShowReturn = true;
            this.Text = "AgreeEdit";
            this.Load += new System.EventHandler(this.AgreeEdit_Load);
            this.Controls.SetChildIndex(this.bt_ToParking, 0);
            this.Controls.SetChildIndex(this.btn_ToClient, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_ToParking;
        private System.Windows.Forms.Button btn_ToClient;
        private System.Windows.Forms.Label label1;
    }
}