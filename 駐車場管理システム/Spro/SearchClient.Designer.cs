namespace Spro
{
    partial class SearchClient
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
            this.dgv_ClientList = new System.Windows.Forms.DataGridView();
            this.bt_Search = new System.Windows.Forms.Button();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.bt_NewRegist = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ClientList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_ClientList
            // 
            this.dgv_ClientList.AllowUserToAddRows = false;
            this.dgv_ClientList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ClientList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ClientList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_ClientList.Location = new System.Drawing.Point(12, 79);
            this.dgv_ClientList.Name = "dgv_ClientList";
            this.dgv_ClientList.ReadOnly = true;
            this.dgv_ClientList.RowTemplate.Height = 27;
            this.dgv_ClientList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ClientList.Size = new System.Drawing.Size(848, 439);
            this.dgv_ClientList.TabIndex = 4;
            this.dgv_ClientList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ClientList_CellDoubleClick);
            // 
            // bt_Search
            // 
            this.bt_Search.Location = new System.Drawing.Point(503, 15);
            this.bt_Search.Name = "bt_Search";
            this.bt_Search.Size = new System.Drawing.Size(75, 28);
            this.bt_Search.TabIndex = 2;
            this.bt_Search.Text = "検索";
            this.bt_Search.UseVisualStyleBackColor = true;
            this.bt_Search.Click += new System.EventHandler(this.bt_Search_Click);
            // 
            // txt_Search
            // 
            this.txt_Search.Location = new System.Drawing.Point(107, 17);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(390, 25);
            this.txt_Search.TabIndex = 1;
            // 
            // bt_NewRegist
            // 
            this.bt_NewRegist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_NewRegist.Location = new System.Drawing.Point(785, 11);
            this.bt_NewRegist.Name = "bt_NewRegist";
            this.bt_NewRegist.Size = new System.Drawing.Size(75, 36);
            this.bt_NewRegist.TabIndex = 3;
            this.bt_NewRegist.Text = "新規";
            this.bt_NewRegist.UseVisualStyleBackColor = true;
            this.bt_NewRegist.Click += new System.EventHandler(this.bt_NewRegist_Click);
            // 
            // SearchClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 558);
            this.Controls.Add(this.bt_NewRegist);
            this.Controls.Add(this.dgv_ClientList);
            this.Controls.Add(this.bt_Search);
            this.Controls.Add(this.txt_Search);
            this.Name = "SearchClient";
            this.ShowReturn = true;
            this.Text = "AgreeEdit";
            this.Load += new System.EventHandler(this.AgreeEdit_Load);
            this.Controls.SetChildIndex(this.txt_Search, 0);
            this.Controls.SetChildIndex(this.bt_Search, 0);
            this.Controls.SetChildIndex(this.dgv_ClientList, 0);
            this.Controls.SetChildIndex(this.bt_NewRegist, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ClientList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_ClientList;
        private System.Windows.Forms.Button bt_Search;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Button bt_NewRegist;
    }
}