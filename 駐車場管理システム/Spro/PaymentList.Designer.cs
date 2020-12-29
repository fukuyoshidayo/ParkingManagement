namespace Spro
{
    partial class PaymentList
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
            this.dgv_PaymentList = new System.Windows.Forms.DataGridView();
            this.cmb_ParkingList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateCmb_AgreeMonth = new Spro.DateComboBox();
            this.pnl_Select = new System.Windows.Forms.Panel();
            this.rdo_Appo = new System.Windows.Forms.RadioButton();
            this.rdo_Payment = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PaymentList)).BeginInit();
            this.pnl_Select.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_PaymentList
            // 
            this.dgv_PaymentList.AllowUserToAddRows = false;
            this.dgv_PaymentList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_PaymentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PaymentList.Location = new System.Drawing.Point(15, 64);
            this.dgv_PaymentList.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_PaymentList.MultiSelect = false;
            this.dgv_PaymentList.Name = "dgv_PaymentList";
            this.dgv_PaymentList.ReadOnly = true;
            this.dgv_PaymentList.RowHeadersVisible = false;
            this.dgv_PaymentList.RowHeadersWidth = 51;
            this.dgv_PaymentList.RowTemplate.Height = 24;
            this.dgv_PaymentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_PaymentList.Size = new System.Drawing.Size(1109, 422);
            this.dgv_PaymentList.TabIndex = 4;
            this.dgv_PaymentList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_PaymentList_CellDoubleClick);
            this.dgv_PaymentList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_PaymentList_CellFormatting);
            this.dgv_PaymentList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_PaymentList_CellPainting);
            // 
            // cmb_ParkingList
            // 
            this.cmb_ParkingList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ParkingList.FormattingEnabled = true;
            this.cmb_ParkingList.Location = new System.Drawing.Point(415, 21);
            this.cmb_ParkingList.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_ParkingList.Name = "cmb_ParkingList";
            this.cmb_ParkingList.Size = new System.Drawing.Size(255, 26);
            this.cmb_ParkingList.TabIndex = 2;
            this.cmb_ParkingList.SelectedIndexChanged += new System.EventHandler(this.cmb_ParkingList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "度分";
            // 
            // dateCmb_AgreeMonth
            // 
            this.dateCmb_AgreeMonth.Location = new System.Drawing.Point(122, 9);
            this.dateCmb_AgreeMonth.Margin = new System.Windows.Forms.Padding(2);
            this.dateCmb_AgreeMonth.Name = "dateCmb_AgreeMonth";
            this.dateCmb_AgreeMonth.Size = new System.Drawing.Size(138, 38);
            this.dateCmb_AgreeMonth.TabIndex = 1;
            // 
            // pnl_Select
            // 
            this.pnl_Select.Controls.Add(this.rdo_Appo);
            this.pnl_Select.Controls.Add(this.rdo_Payment);
            this.pnl_Select.Location = new System.Drawing.Point(713, 15);
            this.pnl_Select.Name = "pnl_Select";
            this.pnl_Select.Size = new System.Drawing.Size(282, 36);
            this.pnl_Select.TabIndex = 3;
            // 
            // rdo_Appo
            // 
            this.rdo_Appo.AutoSize = true;
            this.rdo_Appo.Location = new System.Drawing.Point(150, 7);
            this.rdo_Appo.Name = "rdo_Appo";
            this.rdo_Appo.Size = new System.Drawing.Size(113, 22);
            this.rdo_Appo.TabIndex = 1;
            this.rdo_Appo.Text = "按分ベース";
            this.rdo_Appo.UseVisualStyleBackColor = true;
            this.rdo_Appo.CheckedChanged += new System.EventHandler(this.base_CheckedChanged);
            // 
            // rdo_Payment
            // 
            this.rdo_Payment.AutoSize = true;
            this.rdo_Payment.Checked = true;
            this.rdo_Payment.Location = new System.Drawing.Point(20, 7);
            this.rdo_Payment.Name = "rdo_Payment";
            this.rdo_Payment.Size = new System.Drawing.Size(113, 22);
            this.rdo_Payment.TabIndex = 0;
            this.rdo_Payment.TabStop = true;
            this.rdo_Payment.Text = "支払ベース";
            this.rdo_Payment.UseVisualStyleBackColor = true;
            this.rdo_Payment.CheckedChanged += new System.EventHandler(this.base_CheckedChanged);
            // 
            // PaymentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 540);
            this.Controls.Add(this.pnl_Select);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateCmb_AgreeMonth);
            this.Controls.Add(this.cmb_ParkingList);
            this.Controls.Add(this.dgv_PaymentList);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "PaymentList";
            this.ShowReturn = true;
            this.Text = "PaymentList";
            this.Load += new System.EventHandler(this.PaymentList_Load);
            this.Controls.SetChildIndex(this.dgv_PaymentList, 0);
            this.Controls.SetChildIndex(this.cmb_ParkingList, 0);
            this.Controls.SetChildIndex(this.dateCmb_AgreeMonth, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.pnl_Select, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PaymentList)).EndInit();
            this.pnl_Select.ResumeLayout(false);
            this.pnl_Select.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_PaymentList;
        private System.Windows.Forms.ComboBox cmb_ParkingList;
        private System.Windows.Forms.Label label1;
        private DateComboBox dateCmb_AgreeMonth;
        private System.Windows.Forms.Panel pnl_Select;
        private System.Windows.Forms.RadioButton rdo_Appo;
        private System.Windows.Forms.RadioButton rdo_Payment;
    }
}