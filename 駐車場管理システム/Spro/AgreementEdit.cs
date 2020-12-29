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
    public partial class AgreementEdit : BsForm
    {


        // 駐車場リストを別画面から取得、設定するためのプロパティ
        public DataGridView ParkingList
        {
            get
            {
                return dgv_ParkingList;
            }
            set
            {
                dgv_ParkingList = value;
            }
        }


        private int EditMode = 0;
        private int Clientid = 0;
        private int ClientSubid = 0;
        private int Parkingid = 0;
        private int Sectionid = 0;
        private int Agreeid = 0;

        public AgreementEdit(int m, int Clientid,int ClientSubid, int Parkingid, int Sectionid, int AgreeID)
        {
            InitializeComponent();
            this.EditMode = m;
            this.Clientid = Clientid;
            this.ClientSubid = ClientSubid;
            this.Parkingid = Parkingid;
            this.Sectionid = Sectionid;
            this.Agreeid = AgreeID;
            lbl_EditMode.Text = m == (int)Util.EditMode.New ? "新規" : "編集";
        }

        private void Header()
        {

            dgv_ParkingList.Rows.Clear();
            dgv_ParkingList.Columns.Clear();

            DataGridViewTextBoxColumn col;

            col = new DataGridViewTextBoxColumn();
            col.Name = "ParkinggID";
            col.Visible = false;
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ParkingList.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "SectionID";
            col.Visible = false;
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ParkingList.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "駐車場名";
            col.Width = 90;
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ParkingList.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "区画名";
            col.Width = 90;
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ParkingList.Columns.Add(col);

        }


        private void AgreementEdit_Load(object sender, EventArgs e)
        {
            Header();
            StringBuilder query = new StringBuilder();
            DataTable dt = new DataTable();

            Util.SetPaymentComboBox(cmb_Payment);

            // 顧客情報を表示
            query.Clear();
            query.AppendLine("select");
            query.AppendLine("  ClientName,");
            query.AppendLine("  ClientAddress,");
            query.AppendLine("  ClientTEL");
            query.AppendLine(" FROM ClientMaster");
            query.AppendLine(string.Format(" where ClientID = {0}", this.Clientid));

            dt = Util.QueryExecuteReturn(query.ToString());
            txt_ClientName.Text = dt.Rows[0]["ClientName"].ToString();
            txt_ClientAddress.Text = dt.Rows[0]["ClientAddress"].ToString();
            txt_ClientTEL.Text = dt.Rows[0]["ClientTEL"].ToString();


            // 駐車場情報を表示
            query.Clear();
            query.AppendLine("select");
            query.AppendLine("  p.ParkingID,");
            query.AppendLine("  s.SectionID,");
            query.AppendLine("  p.ParkingName,");
            query.AppendLine("  s.SectionName");

            if (EditMode == (int)Util.EditMode.Edit)
            {
                query.AppendLine(" FROM AgreeParking ap");
                query.AppendLine(" inner join ParkingMaster p");
                query.AppendLine("  on ap.ParkingID = p.ParkingID");
                query.AppendLine(" inner join SectionMaster s");
                query.AppendLine("  on ap.ParkingID = s.ParkingID");
                query.AppendLine("  and ap.SectionID = s.SectionID");
                query.AppendLine(string.Format(" where ap.AgreeID = {0} and ap.SubID = {1}", this.Agreeid,this.ClientSubid));
            }
            else
            {
                query.AppendLine(" FROM SectionMaster s");
                query.AppendLine(" inner join ParkingMaster p");
                query.AppendLine("  on s.ParkingID = p.ParkingID");
                query.AppendLine(string.Format(" where s.SectionID = {0} and s.ParkingID = {1}", this.Sectionid, this.Parkingid));
            }

            dt = Util.QueryExecuteReturn(query.ToString());

            foreach (DataRow dr in dt.Rows)
            {
                string ParkingID = dr["ParkingID"].ToString();
                string SectionID = dr["SectionID"].ToString();
                string ParkingName = dr["ParkingName"].ToString();
                string SectionName = dr["SectionName"].ToString();

                dgv_ParkingList.Rows.Add(new string[] { ParkingID, SectionID, ParkingName, SectionName});
            }

            dgv_ParkingList.Columns[0].Visible = false;
            dgv_ParkingList.Columns[1].Visible = false;
            dgv_ParkingList.Columns[2].Width = 100;
            dgv_ParkingList.Columns[3].Width = 100;



            if (EditMode == (int)Util.EditMode.Edit)
            {
                query.Clear();
                query.AppendLine("select");
                query.AppendLine("  PaymentID,");
                query.AppendLine("  AgreeFrom,");
                query.AppendLine("  AgreeTo,");
                query.AppendLine("  Remarks");
                query.AppendLine(" FROM Agreement");
                query.AppendLine(string.Format(" where ClientID = {0} and ClientSubID = {1}", this.Clientid,this.ClientSubid));

                dt = Util.QueryExecuteReturn(query.ToString());
                cmb_Payment.SelectedValue = dt.Rows[0]["PaymentID"].ToString();
                dtp_AgreeFrom.Value = DateTime.Parse(dt.Rows[0]["AgreeFrom"].ToString());


                DateTime date = DateTime.Parse(dt.Rows[0]["AgreeTo"].ToString());
                if(date != dtp_AgreeTo.MaxDate)
                {
                    dtp_AgreeTo.Value = DateTime.Parse(dt.Rows[0]["AgreeTo"].ToString());
                }
                txt_Remarks.Text = dt.Rows[0]["Remarks"].ToString();

                bt_Del.Visible = false;
                bt_Add.Visible = false;

                dtp_AgreeFrom.Enabled = false;

                chk_Move.Visible = true;
            }
            else
            {
                chk_Move.Visible = false;
            }
        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            Bye();
        }

        private void bt_Regist_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder();
            StringBuilder queryMoney = new StringBuilder();
            DataTable dt = new DataTable();
            string From = Util.ConvDateFormat(dtp_AgreeFrom.Value);
            string To = dtp_AgreeTo.Checked ? Util.ConvDateFormat(dtp_AgreeTo.Value) : Util.ConvDateFormat(dtp_AgreeFrom.MaxDate);

            // 契約期間重複チェック
            foreach (DataGridViewRow dgvr in dgv_ParkingList.Rows)
            {
                string ParkingID = dgvr.Cells[0].Value.ToString();
                string SectionID = dgvr.Cells[1].Value.ToString();
                string ParkingName = dgvr.Cells[2].Value.ToString();
                string SectionName = dgvr.Cells[3].Value.ToString();

                query.Clear();
                query.AppendLine("select");
                query.AppendLine(" * from Agreement a");
                query.AppendLine(" inner join AgreeParking ap");
                query.AppendLine("    on a.AgreeID = ap.AgreeID");
                query.AppendLine("   and a.ClientSubID = ap.SubID");
                query.AppendLine(string.Format(" where ('{0}' between a.AgreeFrom and a.AgreeTo", From));
                query.AppendLine(string.Format(" or '{0}' between a.AgreeFrom and a.AgreeTo)", To));
                query.AppendLine(string.Format(" and ParkingID = {0}", ParkingID));
                query.AppendLine(string.Format(" and SectionID = {0}", SectionID));
                query.AppendLine(string.Format(" and NOT (ClientID = {0} and ClientSubID = {1})", this.Clientid, this.ClientSubid));

                dt = Util.QueryExecuteReturn(query.ToString());
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show(string.Format("駐車場：{0}/区画：{1}\r\nの契約期間が重複しています",ParkingName,SectionName));
                    return;
                }

            }


            int pay = int.Parse(cmb_Payment.SelectedValue.ToString());
            //int selParking = int.Parse(cmb_ParkingList.SelectedValue.ToString());
            //int selSection = int.Parse(cmb_SectionList.SelectedValue.ToString());
            bool a16niti = Util.From16toString(From);

            query.Clear();

            if (this.EditMode == (int)Util.EditMode.New)
            {
                string message = string.Format("新規登録を行います。\r\n同時に開始日付で{0}カ月分の支払登録を行います",
                                                (a16niti ? "2.5" : "2"));
                if (MessageBox.Show(message, "登録確認", MessageBoxButtons.YesNo) == DialogResult.No) return;

                // 契約IDを新規取得
                query.AppendLine("select");
                query.AppendLine(" max(AgreeID)+1 as newid from Agreement");
                dt = Util.QueryExecuteReturn(query.ToString());

                int AgreeID = int.Parse(dt.Rows[0]["newid"].ToString());

                // 顧客サブIDを新規取得
                query.Clear();
                query.AppendLine("select");
                query.AppendLine(" ifnull(max(ClientSubID)+1,1) as newid from Agreement");
                query.AppendLine(string.Format(" where ClientID = {0}", this.Clientid));
                dt = Util.QueryExecuteReturn(query.ToString());

                int ClientSubID = int.Parse(dt.Rows[0]["newid"].ToString());


                // 基本情報をInsert クエリ実行は後で
                query.Clear();
                query.AppendLine("Insert Into Agreement");
                query.AppendLine("(AgreeID,ClientID,ClientSubID,PaymentID,AgreeFrom,AgreeTo,Remarks,CreateDate,UpdateDate)");
                query.AppendLine(" VALUES ");
                query.AppendLine(string.Format("({0},{1},{2},{3},'{4}','{5}','{6}',",
                                 AgreeID, this.Clientid, ClientSubID, pay, From, To, txt_Remarks.Text));
                query.AppendLine("datetime('now'),datetime('now'));");

                // 1カ月分の合計金額を求める　行数分回すので、駐車場情報Insertと一緒にクエリ作る
                queryMoney.Clear();
                queryMoney.AppendLine("select");
                queryMoney.AppendLine("  SUM(Price) as Price from ParkingMaster");
                queryMoney.AppendLine(" where ");


                // 駐車場情報をInsert
                query.AppendLine("Insert Into AgreeParking");
                query.AppendLine("(AgreeID,ParkingID,SectionID)");
                query.AppendLine(" VALUES ");

                int i = 0;
                foreach (DataGridViewRow dgvr in dgv_ParkingList.Rows)
                {
                    if (i != 0)
                    {
                        query.Append(",");
                        queryMoney.Append(" or ");
                    }
                    i++;
                    string ParkingID = dgvr.Cells[0].Value.ToString();
                    string SectionID = dgvr.Cells[1].Value.ToString();

                    query.AppendLine(string.Format("({0},{1},{2},{3})",
                                     AgreeID, ClientSubID, ParkingID, SectionID));

                    queryMoney.AppendLine(string.Format(" (ParkingID = {0})", ParkingID));
                }
                query.Append(";");

                dt = Util.QueryExecuteReturn(queryMoney.ToString());
                double Money = int.Parse(dt.Rows[0]["Price"].ToString());




                // 支払情報をInsert
                if (a16niti)
                {
                    Money = Money * 2.5;
                }
                else
                {
                    Money = Money * 2;
                }

                query.AppendLine("Insert Into Payment");
                query.AppendLine("(AgreeID,PayMonth,Money,CreateDate,UpdateDate)");
                query.AppendLine(" VALUES ");
                query.AppendLine(string.Format("({0},'{1}',{2},",
                                 AgreeID, From, Money));
                query.AppendLine("datetime('now'),datetime('now'));");

            }
            else
            {
                if(chk_Move.Checked)
                {

                }

                query.AppendLine("Update Agreement");
                query.AppendLine(" Set ");
                query.AppendLine(string.Format(" Remarks = '{0}',", txt_Remarks.Text));
                query.AppendLine(string.Format(" PaymentID = {0},", pay));
                query.AppendLine(string.Format(" AgreeTo = '{0}',", To));
                query.AppendLine(" UpdateDate = datetime('now')");
                query.AppendLine(string.Format(" Where ClientID = {0} and ClientSubID = {1}", this.Clientid, this.ClientSubid));
            }
            Util.QueryExecuteNoReturn(query.ToString());
        }



        private void bt_Add_Click(object sender, EventArgs e)
        {
            OpenForm(new SectionMaster(this),true);
        }

        private void bt_Del_Click(object sender, EventArgs e)
        {
            int row = dgv_ParkingList.CurrentCell.RowIndex;

            dgv_ParkingList.Rows.RemoveAt(row);

        }

        private void chk_Move_CheckedChanged(object sender, EventArgs e)
        {
            dtp_AgreeFrom.Enabled = chk_Move.Checked;
        }
    }
}
