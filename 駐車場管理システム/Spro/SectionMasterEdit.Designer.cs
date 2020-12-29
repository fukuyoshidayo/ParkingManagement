namespace Spro
{
    partial class SectionMasterEdit
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
            this.cmb_ParkingList = new System.Windows.Forms.ComboBox();
            this.bt_regist = new System.Windows.Forms.Button();
            this.txt_SectionName = new System.Windows.Forms.TextBox();
            this.txt_Price = new System.Windows.Forms.TextBox();
            this.txt_Remarks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_EditMode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmb_ParkingList
            // 
            this.cmb_ParkingList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ParkingList.FormattingEnabled = true;
            this.cmb_ParkingList.Location = new System.Drawing.Point(125, 80);
            this.cmb_ParkingList.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_ParkingList.Name = "cmb_ParkingList";
            this.cmb_ParkingList.Size = new System.Drawing.Size(158, 26);
            this.cmb_ParkingList.TabIndex = 1;
            // 
            // bt_regist
            // 
            this.bt_regist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_regist.Location = new System.Drawing.Point(257, 11);
            this.bt_regist.Name = "bt_regist";
            this.bt_regist.Size = new System.Drawing.Size(75, 36);
            this.bt_regist.TabIndex = 5;
            this.bt_regist.Text = "登録";
            this.bt_regist.UseVisualStyleBackColor = true;
            this.bt_regist.Click += new System.EventHandler(this.bt_regist_Click);
            // 
            // txt_SectionName
            // 
            this.txt_SectionName.Location = new System.Drawing.Point(125, 128);
            this.txt_SectionName.Name = "txt_SectionName";
            this.txt_SectionName.Size = new System.Drawing.Size(127, 25);
            this.txt_SectionName.TabIndex = 2;
            // 
            // txt_Price
            // 
            this.txt_Price.Location = new System.Drawing.Point(125, 176);
            this.txt_Price.Name = "txt_Price";
            this.txt_Price.Size = new System.Drawing.Size(100, 25);
            this.txt_Price.TabIndex = 3;
            // 
            // txt_Remarks
            // 
            this.txt_Remarks.Location = new System.Drawing.Point(125, 223);
            this.txt_Remarks.Multiline = true;
            this.txt_Remarks.Name = "txt_Remarks";
            this.txt_Remarks.Size = new System.Drawing.Size(158, 66);
            this.txt_Remarks.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "駐車場";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "区画名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "料金";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "備考";
            // 
            // lbl_EditMode
            // 
            this.lbl_EditMode.AutoSize = true;
            this.lbl_EditMode.Location = new System.Drawing.Point(100, 20);
            this.lbl_EditMode.Name = "lbl_EditMode";
            this.lbl_EditMode.Size = new System.Drawing.Size(44, 18);
            this.lbl_EditMode.TabIndex = 13;
            this.lbl_EditMode.Text = "新規";
            // 
            // SectionMasterEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 341);
            this.Controls.Add(this.lbl_EditMode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Remarks);
            this.Controls.Add(this.txt_Price);
            this.Controls.Add(this.txt_SectionName);
            this.Controls.Add(this.bt_regist);
            this.Controls.Add(this.cmb_ParkingList);
            this.Name = "SectionMasterEdit";
            this.ShowReturn = true;
            this.Text = "SectionMasterEdit";
            this.Load += new System.EventHandler(this.SectionMasterEdit_Load);
            this.Controls.SetChildIndex(this.cmb_ParkingList, 0);
            this.Controls.SetChildIndex(this.bt_regist, 0);
            this.Controls.SetChildIndex(this.txt_SectionName, 0);
            this.Controls.SetChildIndex(this.txt_Price, 0);
            this.Controls.SetChildIndex(this.txt_Remarks, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lbl_EditMode, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_ParkingList;
        private System.Windows.Forms.Button bt_regist;
        private System.Windows.Forms.TextBox txt_SectionName;
        private System.Windows.Forms.TextBox txt_Price;
        private System.Windows.Forms.TextBox txt_Remarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_EditMode;
    }
}