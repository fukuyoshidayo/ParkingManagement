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
using Spro;

namespace Spro
{
    public partial class PaymentEdit : BsForm
    {
        int AgreeID = 0;
        public PaymentEdit(int AgreeID)
        {
            InitializeComponent();
            this.AgreeID = AgreeID;
        }

        private void PaymentEdit_Load(object sender, EventArgs e)
        {
            // 契約者情報等セット
            AgreeInfo ai = new AgreeInfo(this.AgreeID);

            txt_ClientAddress.Text = ai.ClientAddress;
            txt_ClientName.Text = ai.ClientName;
            lbl_AgreeID.Text = AgreeID.ToString();

            dgv_ParkingList.DataSource = ai.dtParkingInfo;

            dgv_ParkingList.Columns[0].Visible = false;
            dgv_ParkingList.Columns[1].Visible = false;
            dgv_ParkingList.Columns[2].Width = 100;
            dgv_ParkingList.Columns[3].Width = 100;


            // 支払履歴セット
            SetPayHistory();

            // 支払方法ドロップダウンセット
            Util.SetPaymentComboBox(cmb_Payment);

            lbl_Monthly.Text = Util.MonthlyPrice(AgreeID).ToString();



            Reset();
            grb_PayRegist.Enabled = false;

        }

        private void SetPayHistory()
        {
            PaymentInfo pi = new PaymentInfo(this.AgreeID);

            dgv_PaymentList.DataSource = pi.dt;

            dgv_PaymentList.Columns[0].Visible = false;
            dgv_PaymentList.Columns[1].Width = 100;
            dgv_PaymentList.Columns[2].Width = 100;
            dgv_PaymentList.Columns[3].Width = 100;
        }

        private void Reset()
        {
            txt_Money.Text = "";
            dtp_RegistDate.Value = DateTime.Now;
            cmb_Payment.SelectedIndex = 0;
            lbl_EditMode.Text = "";
            dgv_PaymentList.Enabled = true;
            bt_NewRegist.Enabled = true;

        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            Reset();
            grb_PayRegist.Enabled = false;
            dgv_PaymentList.Enabled = true;

        }

        private void bt_NewRegist_Click(object sender, EventArgs e)
        {
            Reset();
            lbl_EditMode.Text = "新規";
            grb_PayRegist.Enabled = true;
            dgv_PaymentList.Enabled = false;

        }

        private void dgv_PaymentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            grb_PayRegist.Enabled = true;

            lbl_EditMode.Text = "更新";

            dgv_PaymentList.Enabled = false;
            bt_NewRegist.Enabled = false;
            dtp_RegistDate.Enabled = false;

            dtp_RegistDate.Value = DateTime.Parse(dgv_PaymentList.Rows[e.RowIndex].Cells[1].Value.ToString());
            txt_Money.Text = dgv_PaymentList.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmb_Payment.SelectedValue = int.Parse(dgv_PaymentList.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void bt_Regist_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder();
            string Month = Util.ConvDateFormat(dtp_RegistDate.Value);
            string EditMode = lbl_EditMode.Text;
            int Money = 0;
            string PayID = cmb_Payment.SelectedValue.ToString();

            if (!int.TryParse(txt_Money.Text, out Money))
            {
                MessageBox.Show("金額は数字で入力してください");
                return;
            }

            if (MessageBox.Show(string.Format("{0}で登録します　よろしいですか？",EditMode), "登録確認", MessageBoxButtons.YesNo) == DialogResult.No) return;


            query.AppendLine("select");
            query.AppendLine("  count(*) as count");
            query.AppendLine(" FROM Payment");
            query.AppendLine(string.Format(" Where AgreeID = {0} and PayMonth = '{1}';", AgreeID, Month));

            DataTable dt = Util.QueryExecuteReturn(query.ToString());
            int cnt = int.Parse(dt.Rows[0]["count"].ToString());

            query.Clear();
            if (EditMode == "更新")
            {
                if(cnt == 0)
                {
                    MessageBox.Show("登録日のデータが存在しません");
                    return;
                }

                query.AppendLine("Update Payment");
                query.AppendLine(" Set ");
                query.AppendLine(string.Format("Money = '{0}',PaymentID = {1},", Money, PayID));
                query.AppendLine("UpdateDate = datetime('now')");
                query.AppendLine(string.Format(" Where AgreeID = {0} and PayMonth = '{1}';", AgreeID, Month));
            }
            else
            {
                if (cnt != 0)
                {
                    MessageBox.Show("既に登録日のデータが存在するので新規登録できません");
                    return;
                }

                query.AppendLine("Insert Into Payment");
                query.AppendLine("(AgreeID,PayMonth,Money,PaymentID,CreateDate,UpdateDate)");
                query.AppendLine(" VALUES ");
                query.AppendLine(string.Format("({0},'{1}',{2},{3},",
                                 AgreeID, Month, Money, PayID));
                query.AppendLine("datetime('now'),datetime('now'));");

            }
            Util.QueryExecuteNoReturn(query.ToString());
            MessageBox.Show("登録完了");

            SetPayHistory();
            bt_Cancel_Click(sender, e);
        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            Bye();
        }
    }
    
}
