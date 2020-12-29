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
    public partial class PayConfirm : BsForm
    {
        int AgreeID = 0;
        string AgreeFrom = "";
        string AgreeTo = "";
        public PayConfirm(int AgreeID, string AgreeFrom, string AgreeTo)
        {
            InitializeComponent();
            this.AgreeID = AgreeID;
            this.AgreeFrom = AgreeFrom;
            this.AgreeTo = AgreeTo;
        }

        private void Header()
        {
            dgv_PayConfirm.Rows.Clear();
            dgv_PayConfirm.Columns.Clear();

            DataGridViewTextBoxColumn col;


            col = new DataGridViewTextBoxColumn();
            col.Name = "年月";
            col.Width = 90;
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_PayConfirm.Columns.Add(col);


            col = new DataGridViewTextBoxColumn();
            col.Name = "料金";
            col.Width = 60;
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_PayConfirm.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "入金・残額";
            col.Width = 50;
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_PayConfirm.Columns.Add(col);

        }



        private void PayConfirm_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Header();


            StringBuilder query = new StringBuilder();
            
            int Price = Util.MonthlyPrice(this.AgreeID);

            query.Clear();
            query.AppendLine("select");
            query.AppendLine(string.Format("  (select case strftime('%d', AgreeFrom) when '16' then '1' else '0' end from Agreement where AgreeID = {0}) as a16niti,", AgreeID));
            query.AppendLine("  PayMonth,");
            query.AppendLine("  Money");
            query.AppendLine(" FROM Payment");
            query.AppendLine(string.Format(" where AgreeID = {0}", AgreeID));

            dt = Util.QueryExecuteReturn(query.ToString());

            DateTime StartDate = DateTime.Parse(this.AgreeFrom);
            DateTime EndDate = DateTime.Parse(this.AgreeTo);
            double moneytmp = 0;

            bool first = true;

            foreach (DataRow dr in dt.Rows)
            {
                double money = int.Parse(dr["money"].ToString());
                string date = dr["PayMonth"].ToString();
                dgv_PayConfirm.Rows.Add(new string[] { date,"",money.ToString() });

                moneytmp = money + moneytmp;

                while (true)
                {
                    // 16日入会対応
                    if (first)
                    {
                        if(dr["a16niti"].ToString() == "1")
                        {
                            date = StartDate.Year + "/" + StartDate.Month;
                            moneytmp = moneytmp - (Price * 0.5);
                            dgv_PayConfirm.Rows.Add(new string[] { date + "/" +"16", (Price * 0.5).ToString(), moneytmp.ToString() });

                            StartDate = StartDate.AddMonths(1);

                        }

                        first = false;

                    }

                    moneytmp = moneytmp - Price;
                    dgv_PayConfirm.Rows.Add(new string[] { StartDate.ToString(), Price.ToString(), moneytmp.ToString() });
                    if (StartDate > EndDate)
                    {
                        dgv_PayConfirm.Rows[dgv_PayConfirm.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGray;
                    }

                    StartDate = StartDate.AddMonths(1);

                    if (moneytmp < Price) break;
                }
            }
        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            Bye();
        }
    }
}
