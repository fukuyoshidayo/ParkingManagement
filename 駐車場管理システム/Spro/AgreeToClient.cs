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
    public partial class AgreeToClient : BsForm
    {

        private enum SearchType
        {
            Parking=0,
            Word

        }

        public AgreeToClient()
        {
            InitializeComponent();
        }

        private void AgreeToClient_Load(object sender, EventArgs e)
        {
            Util.SetParkingComboBox(cmb_ParkingList);

            txt_Search.Enabled = false;
            bt_Search.Enabled = false;
        }

        private void cmb_ParkingList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search((int)SearchType.Parking);
        }

        private void Search(int type)
        {
            StringBuilder query = new StringBuilder();

            query.AppendLine("select distinct");
            query.AppendLine("  a.ClientID,");
            query.AppendLine("  c.ClientName as '顧客名',");
            query.AppendLine("  c.ClientAddress as '顧客住所',");
            query.AppendLine("  c.Remarks as '備考'");
            query.AppendLine("from Agreement a");
            query.AppendLine("inner join ClientMaster c");
            query.AppendLine("  on a.ClientID = c.ClientID");
            query.AppendLine(string.Format(" and a.AgreeTo >= '{0}'", Util.ConvDateFormat(dtp_ReferDate.Value)));
            query.AppendLine("inner join AgreeParking ap");
            query.AppendLine("  on a.AgreeID = ap.AgreeID");
            if (type == (int)SearchType.Parking)
            {
                query.AppendLine(string.Format(" where ap.ParkingID = {0}", cmb_ParkingList.SelectedValue));
            }
            else
            {
                query.AppendLine(string.Format(" where c.ClientName like '%{0}%'", txt_Search.Text));
            }

            dgv_Client.DataSource = Util.QueryExecuteReturn(query.ToString());

            dgv_Client.Columns[0].Visible = false;
            dgv_Client.Columns[1].Width = 100;
            dgv_Client.Columns[2].Width = 150;
            dgv_Client.Columns[3].Width = 200;
        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            Bye();
        }

        private void dgv_Client_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Client.RowCount == 0) return;
                int row = dgv_Client.CurrentCell.RowIndex;
                int ClientID = int.Parse(dgv_Client.Rows[row].Cells[0].Value.ToString());

                StringBuilder query = new StringBuilder();

                query.AppendLine("select ");
                query.AppendLine("  a.AgreeID,");
                query.AppendLine("  ap.ParkingID,");
                query.AppendLine("  ap.SectionID,");
                query.AppendLine("  a.ClientID,");
                query.AppendLine("  a.ClientSubID,");
                query.AppendLine("  p.ParkingName as '駐車場名',");
                query.AppendLine("  s.SectionName as '区画名',");
                query.AppendLine("  a.AgreeFrom as '開始日',");
                query.AppendLine("  a.AgreeTo as '終了日'");
                query.AppendLine("  from Agreement a");
                query.AppendLine("  inner join AgreeParking ap");
                query.AppendLine("    on a.AgreeID = ap.AgreeID");
                query.AppendLine(" and a.ClientSubID = ap.SubID");
                query.AppendLine("  inner join SectionMaster s");
                query.AppendLine("    on ap.ParkingID = s.ParkingID");
                query.AppendLine("    and ap.SectionID = s.SectionID");
                query.AppendLine(string.Format("    and a.ClientID = {0}", ClientID));
                query.AppendLine(string.Format("    and a.AgreeTo >= '{0}'", Util.ConvDateFormat(dtp_ReferDate.Value)));
                query.AppendLine("  inner join ParkingMaster p");
                query.AppendLine("    on ap.ParkingID = p.ParkingID");
                dgv_Section.DataSource = Util.QueryExecuteReturn(query.ToString());

                dgv_Section.Columns[0].Visible = false;
                dgv_Section.Columns[1].Visible = false;
                dgv_Section.Columns[2].Visible = false;
                dgv_Section.Columns[3].Visible = false;
                dgv_Section.Columns[4].Visible = false;
                dgv_Section.Columns[5].Width = 100;
                dgv_Section.Columns[6].Width = 100;
                dgv_Section.Columns[7].Width = 100;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cb_SarchType_CheckedChanged(object sender, EventArgs e)
        {
            if(cb_SarchType.Checked)
            {
                cmb_ParkingList.Enabled = true;
                txt_Search.Enabled = false;
                bt_Search.Enabled = false;
            }
            else
            {
                cmb_ParkingList.Enabled = false;
                txt_Search.Enabled = true;
                bt_Search.Enabled = true;
            }
        }

        private void bt_Search_Click(object sender, EventArgs e)
        {
            Search((int)SearchType.Word);
        }
    }
}
