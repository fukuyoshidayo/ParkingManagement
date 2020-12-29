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
    public partial class SectionMaster : BsForm
    {
        AgreementEdit Ae;
        public SectionMaster()
        {
            InitializeComponent();
            bt_Add.Visible = false;
        }

        public SectionMaster(AgreementEdit ae)
        {
            InitializeComponent();
            this.Ae = ae;
            bt_Edit.Visible = false;
            bt_NewRegist.Visible = false;
            this.Ae.Visible = true;

        }


        private void SectionMaster_Load(object sender, EventArgs e)
        {
            Util.SetParkingComboBox(cmb_ParkingList);
        }

        private void cmb_ParkingList_SelectedIndexChanged(object sender, EventArgs e)
        {

            StringBuilder query = new StringBuilder();

            query.AppendLine("select");
            query.AppendLine("  SectionID as ID,");
            query.AppendLine("  SectionName as '区画名',");
            query.AppendLine("  Remarks as '備考'");
            query.AppendLine(" FROM SectionMaster");
            query.AppendLine(string.Format(" where ParkingID = {0}",cmb_ParkingList.SelectedValue));

            dgv_SectionMaster.DataSource = Util.QueryExecuteReturn(query.ToString());

            dgv_SectionMaster.Columns[0].Visible = false;
            dgv_SectionMaster.Columns[1].Width = 100;
            dgv_SectionMaster.Columns[2].Width = 150;

        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            Bye();
        }

        private void bt_Edit_Click(object sender, EventArgs e)
        {
            int row = dgv_SectionMaster.CurrentCell.RowIndex;

            int SectionID = int.Parse(dgv_SectionMaster.Rows[row].Cells[0].Value.ToString());
            int ParkingID = int.Parse(cmb_ParkingList.SelectedValue.ToString());


            OpenForm(new SectionMasterEdit((int)Util.EditMode.Edit,ParkingID,SectionID));
        }

        private void bt_Add_Click(object sender, EventArgs e)
        {
            if (dgv_SectionMaster.CurrentCell == null) return;

            int row = dgv_SectionMaster.CurrentCell.RowIndex;
            string SectionID = dgv_SectionMaster.Rows[row].Cells[0].Value.ToString();
            string SectionName = dgv_SectionMaster.Rows[row].Cells[1].Value.ToString();

            string ParkingID = cmb_ParkingList.SelectedValue.ToString();
            string ParkingName = cmb_ParkingList.Text;

            foreach (DataGridViewRow dgr in this.Ae.ParkingList.Rows)
            {
                if(ParkingID == dgr.Cells[0].Value.ToString() && SectionID == dgr.Cells[1].Value.ToString())
                {
                    MessageBox.Show("既に追加されています");
                    return;
                }
            }




            //DataRow dr = this.Ae.ParkingData.NewRow();
            //dr["ParkingID"] = ParkingID;
            //dr["SectionID"] = SectionID;
            //dr["ParkingName"] = dgv_SectionMaster.Rows[row].Cells[0].Value.ToString();
            //dr["SectionName"] = dgv_SectionMaster.Rows[row].Cells[1].Value.ToString();

            //this.Ae.ParkingData.Rows.Add(dr);


            this.Ae.ParkingList.Rows.Add(new string[] { ParkingID,SectionID,ParkingName,SectionName });

            MessageBox.Show("追加しました");

        }
    }
}
