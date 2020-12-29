using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ssk;

namespace Spro
{
    public partial class SectionMasterEdit : BsForm
    {
        private int EditMode = 0;
        private int pid = 0;
        private int sid = 0;

        public SectionMasterEdit(int m, int pid, int sid)
        {
            InitializeComponent();
            this.EditMode = m;
            this.pid = pid;
            this.sid = sid;
            lbl_EditMode.Text = m == (int)Util.EditMode.New ? "新規" : "編集";

        }

        private void SectionMasterEdit_Load(object sender, EventArgs e)
        {
            Util.SetParkingComboBox(cmb_ParkingList);

            if (this.EditMode == (int)Util.EditMode.Edit)
            {
                StringBuilder query = new StringBuilder();
                DataTable dt = new DataTable();

                query.AppendLine("select");
                query.AppendLine("  SectionName,");
                query.AppendLine("  Remarks");
                query.AppendLine(" FROM SectionMaster");
                query.AppendLine(string.Format(" where ParkingID = {0} and SectionID = {1}", this.pid, this.sid));

                dt = Util.QueryExecuteReturn(query.ToString());

                cmb_ParkingList.SelectedValue = pid;
                txt_SectionName.Text = dt.Rows[0]["SectionName"].ToString();
                txt_Remarks.Text = dt.Rows[0]["Remarks"].ToString();
            }

        }

        private void bt_regist_Click(object sender, EventArgs e)
        {

        }
    }
}
