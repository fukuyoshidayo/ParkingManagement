namespace Spro
{
    partial class ParkingMasterEdit
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
            this.txt_ParkingName = new System.Windows.Forms.TextBox();
            this.txt_ParkingAddress = new System.Windows.Forms.TextBox();
            this.bt_regist = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_EditMode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_ParkingName
            // 
            this.txt_ParkingName.Location = new System.Drawing.Point(26, 77);
            this.txt_ParkingName.Name = "txt_ParkingName";
            this.txt_ParkingName.Size = new System.Drawing.Size(238, 25);
            this.txt_ParkingName.TabIndex = 1;
            // 
            // txt_ParkingAddress
            // 
            this.txt_ParkingAddress.Location = new System.Drawing.Point(26, 147);
            this.txt_ParkingAddress.Name = "txt_ParkingAddress";
            this.txt_ParkingAddress.Size = new System.Drawing.Size(398, 25);
            this.txt_ParkingAddress.TabIndex = 2;
            // 
            // bt_regist
            // 
            this.bt_regist.Location = new System.Drawing.Point(374, 11);
            this.bt_regist.Name = "bt_regist";
            this.bt_regist.Size = new System.Drawing.Size(75, 36);
            this.bt_regist.TabIndex = 3;
            this.bt_regist.Text = "登録";
            this.bt_regist.UseVisualStyleBackColor = true;
            this.bt_regist.Click += new System.EventHandler(this.bt_regist_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "駐車場名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "住所";
            // 
            // lbl_EditMode
            // 
            this.lbl_EditMode.AutoSize = true;
            this.lbl_EditMode.Location = new System.Drawing.Point(105, 20);
            this.lbl_EditMode.Name = "lbl_EditMode";
            this.lbl_EditMode.Size = new System.Drawing.Size(44, 18);
            this.lbl_EditMode.TabIndex = 6;
            this.lbl_EditMode.Text = "新規";
            // 
            // ParkingMasterEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 242);
            this.Controls.Add(this.lbl_EditMode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_regist);
            this.Controls.Add(this.txt_ParkingAddress);
            this.Controls.Add(this.txt_ParkingName);
            this.Name = "ParkingMasterEdit";
            this.ShowReturn = true;
            this.Text = "ParkingMasterEdit";
            this.Load += new System.EventHandler(this.ParkingMasterEdit_Load);
            this.Controls.SetChildIndex(this.txt_ParkingName, 0);
            this.Controls.SetChildIndex(this.txt_ParkingAddress, 0);
            this.Controls.SetChildIndex(this.bt_regist, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lbl_EditMode, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_ParkingName;
        private System.Windows.Forms.TextBox txt_ParkingAddress;
        private System.Windows.Forms.Button bt_regist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_EditMode;
    }
}