namespace Spro
{
    partial class ParkingMaster
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
            this.dgv_ParkingMaster = new System.Windows.Forms.DataGridView();
            this.bt_Edit = new System.Windows.Forms.Button();
            this.bt_NewRegist = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ParkingMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_ParkingMaster
            // 
            this.dgv_ParkingMaster.AllowUserToAddRows = false;
            this.dgv_ParkingMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ParkingMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ParkingMaster.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_ParkingMaster.Location = new System.Drawing.Point(12, 84);
            this.dgv_ParkingMaster.Name = "dgv_ParkingMaster";
            this.dgv_ParkingMaster.ReadOnly = true;
            this.dgv_ParkingMaster.RowHeadersVisible = false;
            this.dgv_ParkingMaster.RowTemplate.Height = 27;
            this.dgv_ParkingMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ParkingMaster.Size = new System.Drawing.Size(780, 343);
            this.dgv_ParkingMaster.TabIndex = 3;
            this.dgv_ParkingMaster.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ParkingMaster_CellDoubleClick);
            // 
            // bt_Edit
            // 
            this.bt_Edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Edit.Location = new System.Drawing.Point(636, 11);
            this.bt_Edit.Name = "bt_Edit";
            this.bt_Edit.Size = new System.Drawing.Size(75, 36);
            this.bt_Edit.TabIndex = 1;
            this.bt_Edit.Text = "編集";
            this.bt_Edit.UseVisualStyleBackColor = true;
            this.bt_Edit.Click += new System.EventHandler(this.bt_Edit_Click);
            // 
            // bt_NewRegist
            // 
            this.bt_NewRegist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_NewRegist.Location = new System.Drawing.Point(717, 11);
            this.bt_NewRegist.Name = "bt_NewRegist";
            this.bt_NewRegist.Size = new System.Drawing.Size(75, 36);
            this.bt_NewRegist.TabIndex = 2;
            this.bt_NewRegist.Text = "新規";
            this.bt_NewRegist.UseVisualStyleBackColor = true;
            this.bt_NewRegist.Click += new System.EventHandler(this.bt_NewRegist_Click);
            // 
            // ParkingMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 462);
            this.Controls.Add(this.bt_NewRegist);
            this.Controls.Add(this.bt_Edit);
            this.Controls.Add(this.dgv_ParkingMaster);
            this.Name = "ParkingMaster";
            this.ShowReturn = true;
            this.Text = "ParkingMaster";
            this.Load += new System.EventHandler(this.ParkingMaster_Load);
            this.Controls.SetChildIndex(this.dgv_ParkingMaster, 0);
            this.Controls.SetChildIndex(this.bt_Edit, 0);
            this.Controls.SetChildIndex(this.bt_NewRegist, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ParkingMaster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ParkingMaster;
        private System.Windows.Forms.Button bt_Edit;
        private System.Windows.Forms.Button bt_NewRegist;
    }
}