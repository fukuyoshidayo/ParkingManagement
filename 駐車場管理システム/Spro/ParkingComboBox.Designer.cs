namespace Spro
{
    partial class ParkingComboBox
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.cmb_ParkngList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmb_ParkngList
            // 
            this.cmb_ParkngList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ParkngList.FormattingEnabled = true;
            this.cmb_ParkngList.Location = new System.Drawing.Point(3, 3);
            this.cmb_ParkngList.Name = "cmb_ParkngList";
            this.cmb_ParkngList.Size = new System.Drawing.Size(185, 26);
            this.cmb_ParkngList.TabIndex = 0;
            // 
            // ParkingComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmb_ParkngList);
            this.Name = "ParkingComboBox";
            this.Size = new System.Drawing.Size(217, 32);
            this.Load += new System.EventHandler(this.ParkingComboBox_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_ParkngList;
    }
}
