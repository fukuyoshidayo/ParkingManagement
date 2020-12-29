namespace Spro
{
    partial class SectionMaster
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
            this.dgv_SectionMaster = new System.Windows.Forms.DataGridView();
            this.bt_NewRegist = new System.Windows.Forms.Button();
            this.bt_Edit = new System.Windows.Forms.Button();
            this.bt_Add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SectionMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_ParkingList
            // 
            this.cmb_ParkingList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ParkingList.FormattingEnabled = true;
            this.cmb_ParkingList.Location = new System.Drawing.Point(101, 12);
            this.cmb_ParkingList.Name = "cmb_ParkingList";
            this.cmb_ParkingList.Size = new System.Drawing.Size(255, 26);
            this.cmb_ParkingList.TabIndex = 1;
            this.cmb_ParkingList.SelectedIndexChanged += new System.EventHandler(this.cmb_ParkingList_SelectedIndexChanged);
            // 
            // dgv_SectionMaster
            // 
            this.dgv_SectionMaster.AllowUserToAddRows = false;
            this.dgv_SectionMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_SectionMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SectionMaster.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_SectionMaster.Location = new System.Drawing.Point(12, 68);
            this.dgv_SectionMaster.MultiSelect = false;
            this.dgv_SectionMaster.Name = "dgv_SectionMaster";
            this.dgv_SectionMaster.ReadOnly = true;
            this.dgv_SectionMaster.RowHeadersVisible = false;
            this.dgv_SectionMaster.RowTemplate.Height = 27;
            this.dgv_SectionMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_SectionMaster.Size = new System.Drawing.Size(609, 261);
            this.dgv_SectionMaster.TabIndex = 2;
            // 
            // bt_NewRegist
            // 
            this.bt_NewRegist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_NewRegist.Location = new System.Drawing.Point(546, 11);
            this.bt_NewRegist.Name = "bt_NewRegist";
            this.bt_NewRegist.Size = new System.Drawing.Size(75, 36);
            this.bt_NewRegist.TabIndex = 5;
            this.bt_NewRegist.Text = "新規";
            this.bt_NewRegist.UseVisualStyleBackColor = true;
            // 
            // bt_Edit
            // 
            this.bt_Edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Edit.Location = new System.Drawing.Point(465, 11);
            this.bt_Edit.Name = "bt_Edit";
            this.bt_Edit.Size = new System.Drawing.Size(75, 36);
            this.bt_Edit.TabIndex = 4;
            this.bt_Edit.Text = "編集";
            this.bt_Edit.UseVisualStyleBackColor = true;
            this.bt_Edit.Click += new System.EventHandler(this.bt_Edit_Click);
            // 
            // bt_Add
            // 
            this.bt_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Add.Location = new System.Drawing.Point(384, 11);
            this.bt_Add.Name = "bt_Add";
            this.bt_Add.Size = new System.Drawing.Size(75, 36);
            this.bt_Add.TabIndex = 3;
            this.bt_Add.Text = "追加";
            this.bt_Add.UseVisualStyleBackColor = true;
            this.bt_Add.Click += new System.EventHandler(this.bt_Add_Click);
            // 
            // SectionMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 369);
            this.Controls.Add(this.bt_Add);
            this.Controls.Add(this.bt_Edit);
            this.Controls.Add(this.bt_NewRegist);
            this.Controls.Add(this.dgv_SectionMaster);
            this.Controls.Add(this.cmb_ParkingList);
            this.Name = "SectionMaster";
            this.ShowReturn = true;
            this.Text = "SectionMaster";
            this.Load += new System.EventHandler(this.SectionMaster_Load);
            this.Controls.SetChildIndex(this.cmb_ParkingList, 0);
            this.Controls.SetChildIndex(this.dgv_SectionMaster, 0);
            this.Controls.SetChildIndex(this.bt_NewRegist, 0);
            this.Controls.SetChildIndex(this.bt_Edit, 0);
            this.Controls.SetChildIndex(this.bt_Add, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SectionMaster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_ParkingList;
        private System.Windows.Forms.DataGridView dgv_SectionMaster;
        private System.Windows.Forms.Button bt_NewRegist;
        private System.Windows.Forms.Button bt_Edit;
        private System.Windows.Forms.Button bt_Add;
    }
}