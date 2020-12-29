namespace Spro
{
    partial class AgreeToClient
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
            this.dgv_Client = new System.Windows.Forms.DataGridView();
            this.dgv_Section = new System.Windows.Forms.DataGridView();
            this.dtp_ReferDate = new System.Windows.Forms.DateTimePicker();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.bt_Search = new System.Windows.Forms.Button();
            this.cb_SarchType = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Client)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Section)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_ParkingList
            // 
            this.cmb_ParkingList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ParkingList.FormattingEnabled = true;
            this.cmb_ParkingList.Location = new System.Drawing.Point(354, 52);
            this.cmb_ParkingList.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_ParkingList.Name = "cmb_ParkingList";
            this.cmb_ParkingList.Size = new System.Drawing.Size(176, 26);
            this.cmb_ParkingList.TabIndex = 3;
            this.cmb_ParkingList.SelectedIndexChanged += new System.EventHandler(this.cmb_ParkingList_SelectedIndexChanged);
            // 
            // dgv_Client
            // 
            this.dgv_Client.AllowUserToAddRows = false;
            this.dgv_Client.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv_Client.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Client.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_Client.Location = new System.Drawing.Point(22, 96);
            this.dgv_Client.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_Client.MultiSelect = false;
            this.dgv_Client.Name = "dgv_Client";
            this.dgv_Client.ReadOnly = true;
            this.dgv_Client.RowHeadersVisible = false;
            this.dgv_Client.RowHeadersWidth = 51;
            this.dgv_Client.RowTemplate.Height = 27;
            this.dgv_Client.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Client.Size = new System.Drawing.Size(548, 494);
            this.dgv_Client.TabIndex = 6;
            this.dgv_Client.SelectionChanged += new System.EventHandler(this.dgv_Client_SelectionChanged);
            // 
            // dgv_Section
            // 
            this.dgv_Section.AllowUserToAddRows = false;
            this.dgv_Section.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Section.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Section.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_Section.Location = new System.Drawing.Point(600, 96);
            this.dgv_Section.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_Section.MultiSelect = false;
            this.dgv_Section.Name = "dgv_Section";
            this.dgv_Section.ReadOnly = true;
            this.dgv_Section.RowHeadersVisible = false;
            this.dgv_Section.RowHeadersWidth = 51;
            this.dgv_Section.RowTemplate.Height = 27;
            this.dgv_Section.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Section.Size = new System.Drawing.Size(658, 422);
            this.dgv_Section.TabIndex = 7;
            // 
            // dtp_ReferDate
            // 
            this.dtp_ReferDate.CustomFormat = "yyyy-MM-dd";
            this.dtp_ReferDate.Location = new System.Drawing.Point(111, 50);
            this.dtp_ReferDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtp_ReferDate.Name = "dtp_ReferDate";
            this.dtp_ReferDate.Size = new System.Drawing.Size(200, 25);
            this.dtp_ReferDate.TabIndex = 1;
            // 
            // txt_Search
            // 
            this.txt_Search.Location = new System.Drawing.Point(564, 53);
            this.txt_Search.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(224, 25);
            this.txt_Search.TabIndex = 4;
            // 
            // bt_Search
            // 
            this.bt_Search.Location = new System.Drawing.Point(792, 50);
            this.bt_Search.Margin = new System.Windows.Forms.Padding(2);
            this.bt_Search.Name = "bt_Search";
            this.bt_Search.Size = new System.Drawing.Size(75, 30);
            this.bt_Search.TabIndex = 5;
            this.bt_Search.Text = "検索";
            this.bt_Search.UseVisualStyleBackColor = true;
            this.bt_Search.Click += new System.EventHandler(this.bt_Search_Click);
            // 
            // cb_SarchType
            // 
            this.cb_SarchType.AutoSize = true;
            this.cb_SarchType.Checked = true;
            this.cb_SarchType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_SarchType.Location = new System.Drawing.Point(354, 21);
            this.cb_SarchType.Margin = new System.Windows.Forms.Padding(2);
            this.cb_SarchType.Name = "cb_SarchType";
            this.cb_SarchType.Size = new System.Drawing.Size(151, 22);
            this.cb_SarchType.TabIndex = 2;
            this.cb_SarchType.Text = "駐車場から検索";
            this.cb_SarchType.UseVisualStyleBackColor = true;
            this.cb_SarchType.CheckedChanged += new System.EventHandler(this.cb_SarchType_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(561, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "顧客名";
            // 
            // AgreeToClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 625);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_SarchType);
            this.Controls.Add(this.bt_Search);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.dtp_ReferDate);
            this.Controls.Add(this.dgv_Section);
            this.Controls.Add(this.dgv_Client);
            this.Controls.Add(this.cmb_ParkingList);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "AgreeToClient";
            this.ShowReturn = true;
            this.Text = "AgreeToClient";
            this.Load += new System.EventHandler(this.AgreeToClient_Load);
            this.Controls.SetChildIndex(this.cmb_ParkingList, 0);
            this.Controls.SetChildIndex(this.dgv_Client, 0);
            this.Controls.SetChildIndex(this.dgv_Section, 0);
            this.Controls.SetChildIndex(this.dtp_ReferDate, 0);
            this.Controls.SetChildIndex(this.txt_Search, 0);
            this.Controls.SetChildIndex(this.bt_Search, 0);
            this.Controls.SetChildIndex(this.cb_SarchType, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Client)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Section)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_ParkingList;
        private System.Windows.Forms.DataGridView dgv_Client;
        private System.Windows.Forms.DataGridView dgv_Section;
        private System.Windows.Forms.DateTimePicker dtp_ReferDate;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Button bt_Search;
        private System.Windows.Forms.CheckBox cb_SarchType;
        private System.Windows.Forms.Label label1;
    }
}