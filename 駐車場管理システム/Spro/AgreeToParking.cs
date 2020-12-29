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
    public partial class AgreeToParking : BsForm
    {
        public AgreeToParking()
        {
            InitializeComponent();
        }

        private void AgreeToParking_Load(object sender, EventArgs e)
        {
            Util.SetParkingComboBox(cmb_ParkingList);
        }

        private void cmb_ParkingList_SelectedIndexChanged(object sender, EventArgs e)
        {

            StringBuilder query = new StringBuilder();

            query.AppendLine("select ");
            query.AppendLine("  s.ParkingID,");
            query.AppendLine("  s.SectionID,");
            query.AppendLine("  s.SectionName as '区画名',");
            query.AppendLine("  max(a.AgreeTo) as '契約終了日',");
            query.AppendLine("  pm.Price as '料金',");
            query.AppendLine("  s.Remarks as '備考'");
            query.AppendLine("from SectionMaster s");
            query.AppendLine("left join AgreeParking ap");
            query.AppendLine("  on s.ParkingID = ap.ParkingID");
            query.AppendLine(" and s.SectionID = ap.SectionID");
            query.AppendLine("left join ParkingMaster pm");
            query.AppendLine("  on s.ParkingID = pm.ParkingID");
            query.AppendLine("left join Agreement a");
            query.AppendLine("  on a.AgreeID = ap.AgreeID");
            query.AppendLine(" and a.ClientSubID = ap.SubID");
            query.AppendLine(string.Format(" and a.AgreeTo >= '{0}'", Util.ConvDateFormat(dtp_ReferDate.Value)));
            query.AppendLine(string.Format(" where s.ParkingID = {0}", cmb_ParkingList.SelectedValue));
            query.AppendLine(" group by s.ParkingID,s.SectionID,s.SectionName");

            dgv_SectionMaster.DataSource = Util.QueryExecuteReturn(query.ToString());

            dgv_SectionMaster.Columns[0].Visible = false;
            dgv_SectionMaster.Columns[1].Visible = false;
            dgv_SectionMaster.Columns[2].Width = 100;
            dgv_SectionMaster.Columns[3].Width = 100;
            dgv_SectionMaster.Columns[4].Width = 100;

        }

        private void dgv_SectionMaster_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv_SectionMaster.RowCount == 0) return;
                int row = dgv_SectionMaster.CurrentCell.RowIndex;
                int ParkingID = int.Parse(dgv_SectionMaster.Rows[row].Cells[0].Value.ToString());
                int SectionID = int.Parse(dgv_SectionMaster.Rows[row].Cells[1].Value.ToString());

                StringBuilder query = new StringBuilder();

                query.AppendLine("select ");
                query.AppendLine("  a.AgreeID as '契約ID',");
                query.AppendLine("  a.ClientID,");
                query.AppendLine("  a.ClientSubID,");
                query.AppendLine("  c.ClientName as '顧客名',");
                query.AppendLine("  a.AgreeFrom as '開始日',");
                query.AppendLine("  a.AgreeTo as '終了日'");


                //int year = dtp_ReferDate.Value.AddMonths(-3).Year;
                //int month = 4;
                //DateTime dttmp = new DateTime(year, month, 1); ;
                //for(int i = 0; i < 12; i++)
                //{
                //    month = dttmp.Month;
                //    query.AppendLine(string.Format("  ,(select Money from Payment where PayMonth = '{0}' and AgreeID = a.AgreeID) as '{1}'", dttmp.ToString("yyyy-MM-dd"),month.ToString() + "月"));
                //    //if (month != 3) query.AppendLine(",");
                //    dttmp = dttmp.AddMonths(1);
                //}


                query.AppendLine("  from Agreement a");
                query.AppendLine("  inner join AgreeParking ap");
                query.AppendLine("    on a.AgreeID = ap.AgreeID");
                query.AppendLine("   and a.ClientSubID = ap.SubID");
                query.AppendLine("  inner join ClientMaster c");
                query.AppendLine("    on a.ClientID = c.ClientID");
                query.AppendLine(string.Format("    and ap.ParkingID = {0}", ParkingID));
                query.AppendLine(string.Format("    and ap.SectionID = {0}", SectionID));
                query.AppendLine(string.Format("    and a.AgreeTo >= '{0}'", Util.ConvDateFormat(dtp_ReferDate.Value)));
                dgv_Client.DataSource = Util.QueryExecuteReturn(query.ToString());

                dgv_Client.Columns[0].Width = 60;
                dgv_Client.Columns[1].Visible = false;
                dgv_Client.Columns[2].Visible = false;
                dgv_Client.Columns[3].Width = 100;
                dgv_Client.Columns[4].Width = 100;
                dgv_Client.Columns[5].Width = 100;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            Bye();
        }

        private void bt_NewRegist_Click(object sender, EventArgs e)
        {
            int row = dgv_SectionMaster.CurrentCell.RowIndex;
            int ParkingID = int.Parse(dgv_SectionMaster.Rows[row].Cells[0].Value.ToString());
            int SectionID = int.Parse(dgv_SectionMaster.Rows[row].Cells[1].Value.ToString());
            OpenForm(new SearchClient((int)Util.EditType.Agree,ParkingID,SectionID));
        }

        private void dgv_Client_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dgv_SectionMaster.CurrentCell.RowIndex;
            int ParkingID = int.Parse(dgv_SectionMaster.Rows[row].Cells[0].Value.ToString());
            int SectionID = int.Parse(dgv_SectionMaster.Rows[row].Cells[1].Value.ToString());
            int ClietntID = int.Parse(dgv_Client.Rows[e.RowIndex].Cells[1].Value.ToString());
            int ClietntSubID = int.Parse(dgv_Client.Rows[e.RowIndex].Cells[2].Value.ToString());

            row = dgv_Client.CurrentCell.RowIndex;
            int AgreeID = int.Parse(dgv_Client.Rows[row].Cells[0].Value.ToString());

            OpenForm(new AgreementEdit((int)Util.EditMode.Edit, ClietntID, ClietntSubID, ParkingID, SectionID, AgreeID));
        }

        private void AgreeToParking_VisibleChanged(object sender, EventArgs e)
        {
            Util.SetParkingComboBox(cmb_ParkingList);
        }

        private void dtp_ReferDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bt_PayConfirm_Click(object sender, EventArgs e)
        {
            int row = dgv_Client.CurrentCell.RowIndex;

            int AgreeID = int.Parse(dgv_Client.Rows[row].Cells[0].Value.ToString());
            string AgreeFrom = dgv_Client.Rows[row].Cells[4].Value.ToString();
            string AgreeTo = dgv_Client.Rows[row].Cells[5].Value.ToString();
            OpenForm(new PayConfirm(AgreeID, AgreeFrom, AgreeTo));
        }
    }
}
