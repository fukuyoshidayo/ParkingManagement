namespace Spro
{
    partial class AgreeToParking
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
            this.dtp_ReferDate = new System.Windows.Forms.DateTimePicker();
            this.dgv_Client = new System.Windows.Forms.DataGridView();
            this.bt_NewRegist = new System.Windows.Forms.Button();
            this.bt_PayConfirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SectionMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Client)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_ParkingList
            // 
            this.cmb_ParkingList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ParkingList.FormattingEnabled = true;
            this.cmb_ParkingList.Location = new System.Drawing.Point(410, 15);
            this.cmb_ParkingList.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_ParkingList.Name = "cmb_ParkingList";
            this.cmb_ParkingList.Size = new System.Drawing.Size(255, 26);
            this.cmb_ParkingList.TabIndex = 2;
            this.cmb_ParkingList.SelectedIndexChanged += new System.EventHandler(this.cmb_ParkingList_SelectedIndexChanged);
            // 
            // dgv_SectionMaster
            // 
            this.dgv_SectionMaster.AllowUserToAddRows = false;
            this.dgv_SectionMaster.AllowUserToDeleteRows = false;
            this.dgv_SectionMaster.AllowUserToResizeColumns = false;
            this.dgv_SectionMaster.AllowUserToResizeRows = false;
            this.dgv_SectionMaster.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv_SectionMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SectionMaster.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_SectionMaster.Location = new System.Drawing.Point(12, 50);
            this.dgv_SectionMaster.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_SectionMaster.MultiSelect = false;
            this.dgv_SectionMaster.Name = "dgv_SectionMaster";
            this.dgv_SectionMaster.ReadOnly = true;
            this.dgv_SectionMaster.RowHeadersVisible = false;
            this.dgv_SectionMaster.RowHeadersWidth = 51;
            this.dgv_SectionMaster.RowTemplate.Height = 27;
            this.dgv_SectionMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_SectionMaster.Size = new System.Drawing.Size(607, 551);
            this.dgv_SectionMaster.TabIndex = 3;
            this.dgv_SectionMaster.SelectionChanged += new System.EventHandler(this.dgv_SectionMaster_SelectionChanged);
            // 
            // dtp_ReferDate
            // 
            this.dtp_ReferDate.CustomFormat = "yyyy-MM-dd";
            this.dtp_ReferDate.Location = new System.Drawing.Point(176, 15);
            this.dtp_ReferDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtp_ReferDate.Name = "dtp_ReferDate";
            this.dtp_ReferDate.Size = new System.Drawing.Size(200, 25);
            this.dtp_ReferDate.TabIndex = 1;
            this.dtp_ReferDate.ValueChanged += new System.EventHandler(this.dtp_ReferDate_ValueChanged);
            // 
            // dgv_Client
            // 
            this.dgv_Client.AllowUserToAddRows = false;
            this.dgv_Client.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Client.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Client.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_Client.Location = new System.Drawing.Point(639, 50);
            this.dgv_Client.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_Client.Name = "dgv_Client";
            this.dgv_Client.RowHeadersVisible = false;
            this.dgv_Client.RowHeadersWidth = 51;
            this.dgv_Client.RowTemplate.Height = 27;
            this.dgv_Client.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Client.Size = new System.Drawing.Size(638, 510);
            this.dgv_Client.TabIndex = 4;
            this.dgv_Client.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Client_CellDoubleClick);
            // 
            // bt_NewRegist
            // 
            this.bt_NewRegist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_NewRegist.Location = new System.Drawing.Point(1170, 565);
            this.bt_NewRegist.Margin = new System.Windows.Forms.Padding(2);
            this.bt_NewRegist.Name = "bt_NewRegist";
            this.bt_NewRegist.Size = new System.Drawing.Size(75, 36);
            this.bt_NewRegist.TabIndex = 6;
            this.bt_NewRegist.Text = "新規";
            this.bt_NewRegist.UseVisualStyleBackColor = true;
            this.bt_NewRegist.Click += new System.EventHandler(this.bt_NewRegist_Click);
            // 
            // bt_PayConfirm
            // 
            this.bt_PayConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_PayConfirm.Location = new System.Drawing.Point(1046, 564);
            this.bt_PayConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.bt_PayConfirm.Name = "bt_PayConfirm";
            this.bt_PayConfirm.Size = new System.Drawing.Size(102, 36);
            this.bt_PayConfirm.TabIndex = 5;
            this.bt_PayConfirm.Text = "支払確認";
            this.bt_PayConfirm.UseVisualStyleBackColor = true;
            this.bt_PayConfirm.Click += new System.EventHandler(this.bt_PayConfirm_Click);
            // 
            // AgreeToParking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 640);
            this.Controls.Add(this.bt_PayConfirm);
            this.Controls.Add(this.bt_NewRegist);
            this.Controls.Add(this.dgv_Client);
            this.Controls.Add(this.dtp_ReferDate);
            this.Controls.Add(this.dgv_SectionMaster);
            this.Controls.Add(this.cmb_ParkingList);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "AgreeToParking";
            this.ShowReturn = true;
            this.Text = "AgreeToParking";
            this.Load += new System.EventHandler(this.AgreeToParking_Load);
            this.VisibleChanged += new System.EventHandler(this.AgreeToParking_VisibleChanged);
            this.Controls.SetChildIndex(this.cmb_ParkingList, 0);
            this.Controls.SetChildIndex(this.dgv_SectionMaster, 0);
            this.Controls.SetChildIndex(this.dtp_ReferDate, 0);
            this.Controls.SetChildIndex(this.dgv_Client, 0);
            this.Controls.SetChildIndex(this.bt_NewRegist, 0);
            this.Controls.SetChildIndex(this.bt_PayConfirm, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SectionMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Client)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_ParkingList;
        private System.Windows.Forms.DataGridView dgv_SectionMaster;
        private System.Windows.Forms.DateTimePicker dtp_ReferDate;
        private System.Windows.Forms.DataGridView dgv_Client;
        private System.Windows.Forms.Button bt_NewRegist;
        private System.Windows.Forms.Button bt_PayConfirm;
    }
}