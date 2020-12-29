using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;
using ssk;

namespace Spro
{
    public partial class ParkingMaster : BsForm
    {
        public ParkingMaster()
        {
            InitializeComponent();
        }

        private void ParkingMaster_Load(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder();

            query.AppendLine("select");
            query.AppendLine("  ParkingID as ID,");
            query.AppendLine("  ParkingName as '駐車場名',");
            query.AppendLine("  ParkingAddress as '住所'");
            query.AppendLine("FROM ParkingMaster");
            dgv_ParkingMaster.DataSource = Util.QueryExecuteReturn(query.ToString());

            dgv_ParkingMaster.Columns[0].Visible = false;
            dgv_ParkingMaster.Columns[1].Width = 150;
            dgv_ParkingMaster.Columns[2].Width = 300;
        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            Bye();
        }

        private void bt_NewRegist_Click(object sender, EventArgs e)
        {
            OpenForm(new ParkingMasterEdit((int)Util.EditMode.New,0));
        }

        private void dgv_ParkingMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dgv_ParkingMaster.Rows[e.RowIndex].Cells[0].Value.ToString());
            OpenForm(new ParkingMasterEdit((int)Util.EditMode.Edit,id));
        }

        private void bt_Edit_Click(object sender, EventArgs e)
        {

        }
    }
}
