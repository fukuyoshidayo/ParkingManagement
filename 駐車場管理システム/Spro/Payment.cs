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
    public partial class Payment : BsForm
    {
        public Payment()
        {
            InitializeComponent();
            dateCmb_AgreeMonth.SelectedChange += dateCmb_AgreeMonth_SelectedChange;

        }

        private void Payment_Load(object sender, EventArgs e)
        {
            Util.SetPaymentComboBox(cmb_PaymentList);
            disp();
        }

        private void Header()
        {
            dgv_Payment.Rows.Clear();
            dgv_Payment.Columns.Clear();

            DataGridViewTextBoxColumn col;

            col = new DataGridViewTextBoxColumn();
            col.Name = "契約ID";
            col.Width = 40;
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Payment.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "顧客名";
            col.Width = 100;
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Payment.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "駐車場名";
            col.Width = 90;
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Payment.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "区画名";
            col.Width = 90;
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Payment.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "開始日";
            col.Width = 90;
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Payment.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "終了日";
            col.Width = 90;
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Payment.Columns.Add(col);

            //col = new DataGridViewTextBoxColumn();
            //col.Name = "料金";
            //col.Width = 50;
            //col.ReadOnly = true;
            //col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_Payment.Columns.Add(col);

            //col = new DataGridViewTextBoxColumn();
            //col.Name = "残額";
            //col.Width = 60;
            //col.ReadOnly = true;
            //col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_Payment.Columns.Add(col);

            //col = new DataGridViewTextBoxColumn();
            //col.Name = "入金額";
            //col.Width = 50;
            //col.ReadOnly = false;
            //col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_Payment.Columns.Add(col);

        }


        private void bt_back_Click(object sender, EventArgs e)
        {
            Bye();
        }

        private void disp()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder();
            //string date = Util.ConvDateFormat(dtp_ReferDate.Value);
            string Agreedate = Util.ConvDateFormat(new DateTime((int)dateCmb_AgreeMonth.cmbYear.SelectedValue, (int)dateCmb_AgreeMonth.cmbMonth.SelectedValue, 1));
            //string Registdate = Util.ConvDateFormat(dtp_ReferDate.Value);

            dgv_Payment.Rows.Clear();
            Header();

            query.AppendLine("select ");
            query.AppendLine("  a.AgreeID,");
            //query.AppendLine("  a.ParkingID,");
            //query.AppendLine("  a.SectionID,");
            //query.AppendLine("  a.ClientID,");
            //query.AppendLine("  a.ClientSubID,");
            query.AppendLine("  c.ClientName,");
            query.AppendLine("  p.ParkingName,");
            query.AppendLine("  s.SectionName,");
            query.AppendLine("  a.AgreeFrom,");
            query.AppendLine("  a.AgreeTo,");




            query.AppendLine("(select SUM(Price) as Price");
            query.AppendLine("  from ParkingMaster aa");
            query.AppendLine(" inner join AgreeParking bb");
            query.AppendLine("    on aa.ParkingID = bb.ParkingID");
            query.AppendLine("   and bb.AgreeID = a.AgreeID and bb.SubID = a.ClientSubID) as Price,");




            query.AppendLine("  ifnull(pa.Money,0) as Money,");
            query.AppendLine("ifnull((");
            query.AppendLine("select ");
            query.AppendLine("  SUM(Money) as sum");
            query.AppendLine("  from Payment");
            query.AppendLine(" where AgreeID = a.AgreeID");
            //query.AppendLine(string.Format(" and PayMonth <= '{0}'", Registdate));
            query.AppendLine("),0) as SumMoney");


            query.AppendLine("  from Agreement a");
            query.AppendLine("  inner join AgreeParking ap");
            query.AppendLine("    on a.AgreeID = ap.AgreeID");
            query.AppendLine("   and a.ClientSubID = ap.SubID");
            query.AppendLine("  inner join SectionMaster s");
            query.AppendLine("    on ap.ParkingID = s.ParkingID");
            query.AppendLine("    and ap.SectionID = s.SectionID");
            query.AppendLine(string.Format("    and a.AgreeFrom <= '{0}'", Agreedate));
            query.AppendLine(string.Format("    and a.AgreeTo >= '{0}'", Agreedate));
            query.AppendLine("  inner join ParkingMaster p");
            query.AppendLine("    on ap.ParkingID = p.ParkingID");
            query.AppendLine("  inner join ClientMaster c");
            query.AppendLine("    on a.ClientID = c.ClientID");
            query.AppendLine("  left join Payment pa");
            query.AppendLine("    on a.AgreeID = pa.AgreeID");
            //query.AppendLine(string.Format("    and pa.PayMonth = '{0}'", Registdate));
            query.AppendLine(string.Format(" where a.PaymentID = {0}", cmb_PaymentList.SelectedValue));
            query.AppendLine("  order by a.AgreeID");

            dt = Util.QueryExecuteReturn(query.ToString());


            string AgreeIDtmp = "";
            foreach (DataRow dr in dt.Rows)
            {
                string AgreeID = dr["AgreeID"].ToString();
                if(AgreeID == AgreeIDtmp)
                {
                    continue;
                }
                AgreeIDtmp = AgreeID;
                string ClientName = dr["ClientName"].ToString();
                string ParkingName = dr["ParkingName"].ToString();
                string SectionName = dr["SectionName"].ToString();
                string AgreeFrom = dr["AgreeFrom"].ToString().Substring(0,10);
                string AgreeTo = dr["AgreeTo"].ToString().Substring(0, 10);
                //double Price = int.Parse(dr["Price"].ToString());
                //double half = int.Parse(AgreeFrom.Substring(8,2)) == 16 ? 0.5 : 0;
                //string Money = dr["Money"].ToString();
                //int SumMoney = int.Parse(dr["SumMoney"].ToString());

                //double MonthDiff = Util.MonthDiff(DateTime.Parse(AgreeFrom), DateTime.Parse(Agreedate));

                //double sagaku = 0;
                //if (half == 0.5 && MonthDiff == 1)
                //{
                //    Price = Price * 0.5;
                //    sagaku = SumMoney - Price;
                //}
                //else if(half == 0.5 && MonthDiff != 1)
                //{
                //    sagaku = SumMoney - (Price * (MonthDiff - 1 + half));
                //}
                //else
                //{
                //    sagaku = SumMoney - (Price * MonthDiff);
                //}



                //dgv_Payment.Rows.Add(new string[] { AgreeID, ClientName, ParkingName, SectionName, 
                //                                    AgreeFrom, AgreeTo, Price.ToString(),
                //                                    sagaku.ToString("0,0;△0,0;0"), Money });

                dgv_Payment.Rows.Add(new string[] { AgreeID, ClientName, ParkingName, SectionName,
                                                    AgreeFrom, AgreeTo });

            }

        }


        private void dgv_Payment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex != dgv_Payment.Columns.Count - 1)
            {
                
            }
        }

        private void cmb_PaymentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            disp();
        }

        private void bt_Regist_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("表示中の入金情報を全て登録します　よろしいですか？", "登録確認", MessageBoxButtons.YesNo) == DialogResult.No) return;

            StringBuilder query = new StringBuilder();
            DataTable dt = new DataTable();

            //foreach (DataGridViewRow dgvr in dgv_Payment.Rows)
            //{

            //    int AgreeID = int.Parse(dgvr.Cells[0].Value.ToString());
            //    int Money = int.Parse(dgvr.Cells[8].Value.ToString());
            //    string Month = Util.ConvDateFormat(dtp_ReferDate.Value);

            //    query.Clear();
            //    query.AppendLine("select");
            //    query.AppendLine("  count(*) as count");
            //    query.AppendLine(" FROM Payment");
            //    query.AppendLine(string.Format(" where AgreeID = {0} and PayMonth = '{1}'", AgreeID,Month));

            //    dt = Util.QueryExecuteReturn(query.ToString());

            //    query.Clear();
            //    if (int.Parse(dt.Rows[0]["count"].ToString()) == 0)
            //    {
            //        query.AppendLine("Insert Into Payment");
            //        query.AppendLine("(AgreeID,PayMonth,Money,CreateDate,UpdateDate)");
            //        query.AppendLine(" VALUES ");
            //        query.AppendLine(string.Format("({0},'{1}',{2},",
            //                         AgreeID,Month,Money));
            //        query.AppendLine("datetime('now'),datetime('now'));");
            //    }
            //    else
            //    {
            //        query.AppendLine("Update Payment");
            //        query.AppendLine(" Set ");
            //        query.AppendLine(string.Format("Money = '{0}',", Money));
            //        query.AppendLine("UpdateDate = datetime('now')");
            //        query.AppendLine(string.Format(" Where AgreeID = {0} and PayMonth = '{1}';", AgreeID,Month));
            //    }
            //    Util.QueryExecuteNoReturn(query.ToString());
            //}
            //MessageBox.Show("登録完了");
        }

        private void dateCmb_AgreeMonth_SelectedChange(object sender, EventArgs e)
        {
            disp();
        }

        private void dgv_Payment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int AgreeID = int.Parse(dgv_Payment.Rows[e.RowIndex].Cells[0].Value.ToString());
            OpenForm(new PaymentEdit(AgreeID));

        }
    }
}
