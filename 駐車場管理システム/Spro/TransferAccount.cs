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
    public partial class TransferAccount : BsForm
    {
        public TransferAccount()
        {
            InitializeComponent();
        }

        private void TransferAccount_Load(object sender, EventArgs e)
        {
            disp();
        }

        private void Calculation()
        {
            int sum = 0;
            for (int i = 0; i < dgv_TransferAccount.RowCount; i++)
            {
                bool b = bool.Parse(dgv_TransferAccount.Rows[i].Cells[0].Value.ToString());
                if (b)
                {
                    sum = sum + int.Parse(dgv_TransferAccount.Rows[i].Cells[5].Value.ToString());
                }
            }

            txt_SumPay.Text = sum.ToString();
        }

        private void disp()
        {
            Header();

            int year = (int)dateCmb_TargetMonth.cmbYear.SelectedValue;
            int month = (int)dateCmb_TargetMonth.cmbMonth.SelectedValue;

            DateTime targetdate = new DateTime(year, month, 1);

            StringBuilder query = new StringBuilder();
            DataTable dt = new DataTable();

            query.AppendLine("select ");
            query.AppendLine("  a.AgreeID, ");
            query.AppendLine("  cm.ClientName, ");
            query.AppendLine("  am.AccountName, ");
            query.AppendLine("  am.AccountNo, ");
            query.AppendLine("  sum(pm.Price) as sum ");
            query.AppendLine("  from Agreement a ");
            query.AppendLine(" inner join AgreeParking ap ");
            query.AppendLine("    on a.AgreeID = ap.AgreeID ");
            query.AppendLine(" inner join SectionMaster sm ");
            query.AppendLine("    on ap.SectionID = sm.SectionID ");
            query.AppendLine("   and ap.ParkingID = sm.ParkingID ");
            query.AppendLine(" inner join ParkingMaster pm ");
            query.AppendLine("    on sm.ParkingID = pm.ParkingID ");
            query.AppendLine(" inner join ClientMaster cm ");
            query.AppendLine("    on a.ClientID = cm.ClientID ");
            query.AppendLine(" inner join AccountMaster am ");
            query.AppendLine("    on am.ClientID = cm.ClientID ");
            query.AppendLine("   and am.AccountID = 1 ");
            query.AppendLine("  where  ");
            query.AppendLine(string.Format("   a.AgreeTo >= '{0}'", Util.ConvDateFormat(targetdate)));
            query.AppendLine(" group by a.AgreeID");

            //dgv_TransferAccount.DataSource = Util.QueryExecuteReturn(query.ToString());
            dt = Util.QueryExecuteReturn(query.ToString());

            foreach(DataRow dr in dt.Rows)
            {
                dgv_TransferAccount.Rows.Add(new string[] {"true",dr["AgreeID"].ToString(),
                                                            dr["ClientName"].ToString(),
                                                            dr["AccountName"].ToString(),
                                                            dr["AccountNo"].ToString(),
                                                            dr["sum"].ToString() });
            }

            Calculation();

        }


        private void bt_back_Click(object sender, EventArgs e)
        {
            Bye();
        }


        private void Header()
        {
            dgv_TransferAccount.Rows.Clear();
            dgv_TransferAccount.Columns.Clear();

            DataGridViewTextBoxColumn col;
            DataGridViewCheckBoxColumn check;

            check = new DataGridViewCheckBoxColumn();
            check.Name = "入金";
            check.Width = 30;
            check.ReadOnly = false;
            check.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            check.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_TransferAccount.Columns.Add(check);


            col = new DataGridViewTextBoxColumn();
            col.Name = "契約ID";
            col.Width = 50;
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_TransferAccount.Columns.Add(col);


            col = new DataGridViewTextBoxColumn();
            col.Name = "顧客名";
            col.Width = 100;
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_TransferAccount.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "口座名";
            col.Width = 80;
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_TransferAccount.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "口座番号";
            col.Width = 80;
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_TransferAccount.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "合計金額";
            col.Width = 80;
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_TransferAccount.Columns.Add(col);


            //col = new DataGridViewTextBoxColumn();
            //col.Name = "駐車場名";
            //col.Width = 100;
            //col.ReadOnly = true;
            //col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_TransferAccount.Columns.Add(col);


            //col = new DataGridViewTextBoxColumn();
            //col.Name = "区画名";
            //col.Width = 100;
            //col.ReadOnly = true;
            //col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_TransferAccount.Columns.Add(col);


        }

        private void bt_Regist_Click(object sender, EventArgs e)
        {
            if(txt_SumPay.Text != txt_SumTransfer.Text)
            {
                MessageBox.Show("口振額と料金の合計が一致しません。");
                return;
            }
            StringBuilder query = new StringBuilder();
            StringBuilder value = new StringBuilder();

            int year = (int)dateCmb_TargetMonth.cmbYear.SelectedValue;
            int month = (int)dateCmb_TargetMonth.cmbMonth.SelectedValue;
            int pm = (year * 100) + month;

            query.AppendLine("select");
            query.AppendLine("  count(*) as count");
            query.AppendLine(" FROM TransferClosing");
            query.AppendLine(string.Format(" Where ProcessMonth = {0};", pm));

            DataTable dt = Util.QueryExecuteReturn(query.ToString());
            int cnt = int.Parse(dt.Rows[0]["count"].ToString());

            if (cnt != 0)
            {
                MessageBox.Show("対象年月の口振は登録済みです");
                return;
            }

            query.Clear();
            query.AppendLine("Insert Into TransferClosing");
            query.AppendLine("(ProcessMonth,PayMonth,SumMoney,CreateDate,UpdateDate)");
            query.AppendLine(" VALUES ");
            query.AppendLine(string.Format("({0},'{1}',{2},datetime('now'),datetime('now'));",
                             pm,
                             Util.ConvDateFormat(dtp_RegistDate.Value),
                             txt_SumPay.Text));

            query.AppendLine("Insert Into Payment");
            query.AppendLine("(AgreeID,PayMonth,Money,PaymentID,CreateDate,UpdateDate)");
            query.AppendLine(" VALUES ");

            for (int i = 0; i < dgv_TransferAccount.RowCount; i++)
            {
                bool b = bool.Parse(dgv_TransferAccount.Rows[i].Cells[0].Value.ToString());
                if (b)
                {
                    if (value.ToString().Length != 0) value.Append(",");
                    value.AppendLine(string.Format("({0},'{1}',{2},{3},datetime('now'),datetime('now'))",
                                     dgv_TransferAccount.Rows[i].Cells[1].Value.ToString(),
                                     Util.ConvDateFormat(dtp_RegistDate.Value),
                                     dgv_TransferAccount.Rows[i].Cells[5].Value.ToString(),
                                     1));

                }
            }


            //string str = query.ToString().Substring(0, query.ToString().Length - 1);

            Util.QueryExecuteReturn(query.ToString() + value.ToString());

            MessageBox.Show("登録完了");

        }

        private void dgv_TransferAccount_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Calculation();
        }

        private void dgv_TransferAccount_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if(dgv_TransferAccount.CurrentCellAddress.X ==0 && dgv_TransferAccount.IsCurrentCellDirty)
            {
                dgv_TransferAccount.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dateCmb_TargetMonth_SelectedChange(object sender, EventArgs e)
        {
            disp();
        }

    }
}
