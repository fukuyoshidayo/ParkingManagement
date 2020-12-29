namespace Spro
{
    partial class SqlTestForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.bt_SAVE = new System.Windows.Forms.Button();
            this.bt_LOAD = new System.Windows.Forms.Button();
            this.bt_戻る = new System.Windows.Forms.Button();
            this.bt_実行 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            //((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.bt_SAVE);
            this.splitContainer1.Panel1.Controls.Add(this.bt_LOAD);
            this.splitContainer1.Panel1.Controls.Add(this.bt_戻る);
            this.splitContainer1.Panel1.Controls.Add(this.bt_実行);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Size = new System.Drawing.Size(581, 383);
            this.splitContainer1.SplitterDistance = 52;
            this.splitContainer1.TabIndex = 1;
            // 
            // bt_SAVE
            // 
            this.bt_SAVE.Location = new System.Drawing.Point(109, 12);
            this.bt_SAVE.Name = "bt_SAVE";
            this.bt_SAVE.Size = new System.Drawing.Size(75, 23);
            this.bt_SAVE.TabIndex = 3;
            this.bt_SAVE.Text = "Save";
            this.bt_SAVE.UseVisualStyleBackColor = true;
            this.bt_SAVE.Click += new System.EventHandler(this.bt_SAVE_Click);
            // 
            // bt_LOAD
            // 
            this.bt_LOAD.Location = new System.Drawing.Point(27, 12);
            this.bt_LOAD.Name = "bt_LOAD";
            this.bt_LOAD.Size = new System.Drawing.Size(75, 23);
            this.bt_LOAD.TabIndex = 2;
            this.bt_LOAD.Text = "Load";
            this.bt_LOAD.UseVisualStyleBackColor = true;
            this.bt_LOAD.Click += new System.EventHandler(this.bt_LOAD_Click);
            // 
            // bt_戻る
            // 
            this.bt_戻る.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_戻る.Location = new System.Drawing.Point(489, 12);
            this.bt_戻る.Name = "bt_戻る";
            this.bt_戻る.Size = new System.Drawing.Size(75, 23);
            this.bt_戻る.TabIndex = 1;
            this.bt_戻る.Text = "戻る";
            this.bt_戻る.UseVisualStyleBackColor = true;
            this.bt_戻る.Click += new System.EventHandler(this.bt_戻る_Click);
            // 
            // bt_実行
            // 
            this.bt_実行.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_実行.Location = new System.Drawing.Point(408, 12);
            this.bt_実行.Name = "bt_実行";
            this.bt_実行.Size = new System.Drawing.Size(75, 23);
            this.bt_実行.TabIndex = 0;
            this.bt_実行.Text = "実行";
            this.bt_実行.UseVisualStyleBackColor = true;
            this.bt_実行.Click += new System.EventHandler(this.bt_実行_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("ＭＳ 明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(581, 327);
            this.textBox1.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SqlTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 405);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SqlTestForm";
            this.Text = "SQLSERVER SQL　テスト";
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            //((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button bt_戻る;
        private System.Windows.Forms.Button bt_実行;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bt_SAVE;
        private System.Windows.Forms.Button bt_LOAD;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}