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
    public partial class SearchClient : BsForm
    {
        int Parkingid = 0;
        int Sectionid = 0;
        int EditType = 0;
        public SearchClient(int t, int Parkingid, int Sectionid)
        {
            InitializeComponent();

            this.EditType = t;
            this.Parkingid = Parkingid;
            this.Sectionid = Sectionid;
        }

        private void AgreeEdit_Load(object sender, EventArgs e)
        {
            if (this.EditType == (int)Util.EditType.Agree)
            {
                bt_NewRegist.Visible = false;
            }
            Search("");

        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            Bye();
        }

        private void bt_Search_Click(object sender, EventArgs e)
        {
            Search(txt_Search.Text);
        }

        private void Search(string word)
        {
            StringBuilder query = new StringBuilder();

            query.AppendLine("select");
            query.AppendLine("  ClientID as ID,");
            query.AppendLine("  ClientName as '名前',");
            query.AppendLine("  ClientAddress as '住所',");
            query.AppendLine("  ClientTEL as '電話番号'");
            query.AppendLine(" FROM ClientMaster");
            query.AppendLine(string.Format(" where ClientName like '%{0}%'", word));

            dgv_ClientList.DataSource = Util.QueryExecuteReturn(query.ToString());

            dgv_ClientList.Columns[0].Visible = false;
            dgv_ClientList.Columns[1].Width = 100;
            dgv_ClientList.Columns[2].Width = 200;
            dgv_ClientList.Columns[3].Width = 150;
        }

        private void dgv_ClientList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int Clientid = int.Parse(dgv_ClientList.Rows[e.RowIndex].Cells[0].Value.ToString());
            if(this.EditType == (int)Util.EditType.Agree)
            {
                OpenForm(new AgreementEdit((int)Util.EditMode.New, Clientid, 0, this.Parkingid, this.Sectionid, 0));
            }
            else
            {
                OpenForm(new ClientMasterEdit((int)Util.EditMode.Edit, Clientid));
            }
        }

        private void bt_NewRegist_Click(object sender, EventArgs e)
        {
            OpenForm(new ClientMasterEdit((int)Util.EditMode.New, 0));
        }
    }
}
