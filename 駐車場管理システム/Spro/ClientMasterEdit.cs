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
    public partial class ClientMasterEdit : BsForm
    {
        private int EditMode = 0;
        private int Clientid = 0;

        public ClientMasterEdit(int m, int Clientid)
        {
            InitializeComponent();
            this.EditMode = m;
            this.Clientid = Clientid;

            lbl_EditMode.Text = m == (int)Util.EditMode.New ? "新規" : "編集";

        }

        private void ClientMaster_Load(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder();
            DataTable dt = new DataTable();

            if (EditMode == (int)Util.EditMode.Edit)
            {
                query.Clear();
                query.AppendLine("select");
                query.AppendLine("  ClientName,");
                query.AppendLine("  ClientAddress,");
                query.AppendLine("  ClientTEL,");
                query.AppendLine("  CorpFlg,");
                query.AppendLine("  Remarks");
                query.AppendLine(" FROM ClientMaster");
                query.AppendLine(string.Format(" where ClientID = {0}", this.Clientid));

                dt = Util.QueryExecuteReturn(query.ToString());
                txt_ClientName.Text = dt.Rows[0]["ClientName"].ToString();
                txt_ClientAddress.Text = dt.Rows[0]["ClientAddress"].ToString();
                txt_ClientTEL.Text = dt.Rows[0]["ClientTEL"].ToString();
                txt_Remarks.Text = dt.Rows[0]["Remarks"].ToString();

                if (dt.Rows[0]["CorpFlg"].ToString() == "0")
                {
                    rdo_Person.Checked = true;
                }
                else
                {
                    rdo_Corp.Checked = true;
                }


                query.Clear();
                query.AppendLine("select");
                query.AppendLine("  AccountName,");
                query.AppendLine("  AccountID,");
                query.AppendLine("  AccountNo");
                query.AppendLine(" FROM AccountMaster");
                query.AppendLine(string.Format(" where ClientID = {0}", this.Clientid));
                query.AppendLine(" ORDER BY AccountID");


                dt = Util.QueryExecuteReturn(query.ToString());

                if(dt.Rows.Count ==3)
                {
                txt_AccountName1.Text = dt.Rows[0]["AccountName"].ToString();
                txt_AccountNo1.Text = dt.Rows[0]["AccountNo"].ToString();
                txt_AccountName2.Text = dt.Rows[1]["AccountName"].ToString();
                txt_AccountNo2.Text = dt.Rows[1]["AccountNo"].ToString();
                txt_AccountName3.Text = dt.Rows[2]["AccountName"].ToString();
                txt_AccountNo3.Text = dt.Rows[2]["AccountNo"].ToString();

                }

            }
        }

            private void bt_back_Click(object sender, EventArgs e)
        {
            Bye();
        }

        private void bt_Regist_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder();
            int type = rdo_Corp.Checked ? 1 : 0;

            if (EditMode == (int)Util.EditMode.New)
            {
                query.Clear();
                query.AppendLine("Insert Into ClientMaster");
                query.AppendLine("(CorpFlg,ClientName,ClientAddress,ClientTEL,Remarks,CreateDate,UpdateDate)");
                query.AppendLine(" VALUES ");
                query.AppendLine(string.Format("({0},'{1}','{2}','{3}','{4}',",
                                 type,txt_ClientName.Text,txt_ClientAddress.Text,txt_ClientTEL.Text,txt_Remarks.Text));
                query.AppendLine("datetime('now'),datetime('now'));");


                query.AppendLine("Insert Into AccountMaster");
                query.AppendLine("(ClientID ,AccountID ,AccountName ,AccountNo)");
                query.AppendLine(" VALUES ");
                query.AppendLine(string.Format("((select MAX(ClientID) FROM ClientMaster),1,'{0}','{1}'),", txt_AccountName1.Text, txt_AccountNo1.Text));
                query.AppendLine(string.Format("((select MAX(ClientID) FROM ClientMaster),2,'{0}','{1}'),", txt_AccountName2.Text, txt_AccountNo2.Text));
                query.AppendLine(string.Format("((select MAX(ClientID) FROM ClientMaster),3,'{0}','{1}')", txt_AccountName3.Text, txt_AccountNo3.Text));



            }
            else
            {
                query.AppendLine("Update ClientMaster");
                query.AppendLine(" Set ");
                query.AppendLine(string.Format("Remarks = '{0}',", txt_Remarks.Text));
                query.AppendLine(string.Format("CorpFlg = {0},", type));
                query.AppendLine(string.Format("ClientName = '{0}',", txt_ClientName.Text));
                query.AppendLine(string.Format("ClientAddress = '{0}',", txt_ClientAddress.Text));
                query.AppendLine(string.Format("ClientTEL = '{0}',", txt_ClientTEL.Text));
                query.AppendLine("UpdateDate = datetime('now')");
                query.AppendLine(string.Format("Where ClientID = {0};", this.Clientid));

                query.AppendLine("Update AccountMaster");
                query.AppendLine(" Set ");
                query.AppendLine(string.Format("AccountName = '{0}',", txt_AccountName1.Text));
                query.AppendLine(string.Format("AccountNo = '{0}'", txt_AccountNo1.Text));
                query.AppendLine(string.Format("Where ClientID = {0} and AccountID = 1;", this.Clientid));
                query.AppendLine("Update AccountMaster");
                query.AppendLine(" Set ");
                query.AppendLine(string.Format("AccountName = '{0}',", txt_AccountName2.Text));
                query.AppendLine(string.Format("AccountNo = '{0}'", txt_AccountNo2.Text));
                query.AppendLine(string.Format("Where ClientID = {0} and AccountID = 2;", this.Clientid));
                query.AppendLine("Update AccountMaster");
                query.AppendLine(" Set ");
                query.AppendLine(string.Format("AccountName = '{0}',", txt_AccountName3.Text));
                query.AppendLine(string.Format("AccountNo = '{0}'", txt_AccountNo3.Text));
                query.AppendLine(string.Format("Where ClientID = {0} and AccountID = 3;", this.Clientid));


            }



            Util.QueryExecuteNoReturn(query.ToString());

            MessageBox.Show("登録完了");

        }

        private void txt_AccountNo1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
