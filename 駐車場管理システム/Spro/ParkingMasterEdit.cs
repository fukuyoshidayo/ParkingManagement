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
    public partial class ParkingMasterEdit : BsForm
    {
        private int EditMode = 0;
        private int id = 0;

        public ParkingMasterEdit(int m,int id) 
        {
            InitializeComponent();
            this.EditMode = m;
            this.id = id;
            lbl_EditMode.Text = m == (int)Util.EditMode.New ? "新規" : "編集";
        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            Bye(); 
        }

        private void ParkingMasterEdit_Load(object sender, EventArgs e)
        {
            if(this.EditMode == (int)Util.EditMode.Edit)
            {
                StringBuilder query = new StringBuilder();
                DataTable dt = new DataTable();

                query.AppendLine("select");
                query.AppendLine("  ParkingName,");
                query.AppendLine("  ParkingAddress");
                query.AppendLine(" FROM ParkingMaster");
                query.AppendLine(string.Format(" where ParkingID = {0}",this.id));

                dt = Util.QueryExecuteReturn(query.ToString());
                txt_ParkingName.Text = dt.Rows[0]["ParkingName"].ToString();
                txt_ParkingAddress.Text = dt.Rows[0]["ParkingAddress"].ToString();
            }

        }

        private void bt_regist_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder();
            if (this.EditMode == (int)Util.EditMode.New)
            {
                query.AppendLine("Insert Into ParkingMaster");
                query.AppendLine("(ParkingName,ParkingAddress,CreateDate,UpdateDate)");
                query.AppendLine(" VALUES ");
                query.AppendLine(string.Format("('{0}',",txt_ParkingName.Text));
                query.AppendLine(string.Format("'{0}',", txt_ParkingAddress.Text));
                query.AppendLine("datetime('now'),datetime('now')");
            }
            else
            {
                query.AppendLine("Update ParkingMaster");
                query.AppendLine(" Set ");
                query.AppendLine(string.Format("ParkingName = '{0}',", txt_ParkingName.Text));
                query.AppendLine(string.Format("ParkingAddress = '{0}',", txt_ParkingAddress.Text));
                query.AppendLine("UpdateDate = datetime('now')");
                query.AppendLine(string.Format("Where ParkingID = {0}",this.id));
            }
            Util.QueryExecuteNoReturn(query.ToString());
            MessageBox.Show("登録完了");
        }
    }
}
