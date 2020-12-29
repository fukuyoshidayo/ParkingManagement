namespace Spro
{
    partial class MasterMenu
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
            this.bt_ParkingMaster = new System.Windows.Forms.Button();
            this.bt_SectionMaster = new System.Windows.Forms.Button();
            this.bt_ClientMaster = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_ParkingMaster
            // 
            this.bt_ParkingMaster.Location = new System.Drawing.Point(136, 126);
            this.bt_ParkingMaster.Margin = new System.Windows.Forms.Padding(2);
            this.bt_ParkingMaster.Name = "bt_ParkingMaster";
            this.bt_ParkingMaster.Size = new System.Drawing.Size(160, 77);
            this.bt_ParkingMaster.TabIndex = 1;
            this.bt_ParkingMaster.Text = "駐車場マスタ";
            this.bt_ParkingMaster.UseVisualStyleBackColor = true;
            this.bt_ParkingMaster.Click += new System.EventHandler(this.bt_ParkingMaster_Click);
            // 
            // bt_SectionMaster
            // 
            this.bt_SectionMaster.Location = new System.Drawing.Point(136, 236);
            this.bt_SectionMaster.Margin = new System.Windows.Forms.Padding(2);
            this.bt_SectionMaster.Name = "bt_SectionMaster";
            this.bt_SectionMaster.Size = new System.Drawing.Size(160, 77);
            this.bt_SectionMaster.TabIndex = 2;
            this.bt_SectionMaster.Text = "区画マスタ";
            this.bt_SectionMaster.UseVisualStyleBackColor = true;
            this.bt_SectionMaster.Click += new System.EventHandler(this.bt_SectionMaster_Click);
            // 
            // bt_ClientMaster
            // 
            this.bt_ClientMaster.Location = new System.Drawing.Point(136, 341);
            this.bt_ClientMaster.Margin = new System.Windows.Forms.Padding(2);
            this.bt_ClientMaster.Name = "bt_ClientMaster";
            this.bt_ClientMaster.Size = new System.Drawing.Size(160, 77);
            this.bt_ClientMaster.TabIndex = 3;
            this.bt_ClientMaster.Text = "顧客マスタ";
            this.bt_ClientMaster.UseVisualStyleBackColor = true;
            this.bt_ClientMaster.Click += new System.EventHandler(this.bt_ClientMaster_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.label1.Location = new System.Drawing.Point(98, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "マスタ管理メニュー";
            // 
            // MasterMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 498);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_ClientMaster);
            this.Controls.Add(this.bt_SectionMaster);
            this.Controls.Add(this.bt_ParkingMaster);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "MasterMenu";
            this.ShowReturn = true;
            this.Text = "MasterEdit";
            this.Controls.SetChildIndex(this.bt_ParkingMaster, 0);
            this.Controls.SetChildIndex(this.bt_SectionMaster, 0);
            this.Controls.SetChildIndex(this.bt_ClientMaster, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_ParkingMaster;
        private System.Windows.Forms.Button bt_SectionMaster;
        private System.Windows.Forms.Button bt_ClientMaster;
        private System.Windows.Forms.Label label1;
    }
}