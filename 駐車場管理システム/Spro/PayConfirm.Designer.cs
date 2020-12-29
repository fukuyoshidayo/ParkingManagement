namespace Spro
{
    partial class PayConfirm
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
            this.dgv_PayConfirm = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PayConfirm)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_PayConfirm
            // 
            this.dgv_PayConfirm.AllowUserToAddRows = false;
            this.dgv_PayConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_PayConfirm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PayConfirm.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_PayConfirm.Location = new System.Drawing.Point(12, 71);
            this.dgv_PayConfirm.Name = "dgv_PayConfirm";
            this.dgv_PayConfirm.ReadOnly = true;
            this.dgv_PayConfirm.RowHeadersVisible = false;
            this.dgv_PayConfirm.RowTemplate.Height = 27;
            this.dgv_PayConfirm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_PayConfirm.Size = new System.Drawing.Size(451, 266);
            this.dgv_PayConfirm.TabIndex = 1;
            // 
            // PayConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 377);
            this.Controls.Add(this.dgv_PayConfirm);
            this.Name = "PayConfirm";
            this.ShowReturn = true;
            this.Text = "PayConfirm";
            this.Load += new System.EventHandler(this.PayConfirm_Load);
            this.Controls.SetChildIndex(this.dgv_PayConfirm, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PayConfirm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_PayConfirm;
    }
}