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
    public partial class PaymentList : BsForm
    {
        public PaymentList()
        {
            InitializeComponent();
        }

        private void PaymentList_Load(object sender, EventArgs e)
        {
            Util.SetParkingComboBox(cmb_ParkingList);
            disp();
        }

        private void disp()
        {
            int year = (int)dateCmb_AgreeMonth.cmbYear.SelectedValue;

            try
            {
                //if (dgv_PaymentList.RowCount == 0) return;

                StringBuilder query = new StringBuilder();

                query.AppendLine("select ");
                query.AppendLine("  a.AgreeID as '契約番号',");
                query.AppendLine("  p.ParkingID,");
                query.AppendLine("  a.ClientID,");
                query.AppendLine("  a.ClientSubID,");
                query.AppendLine("  c.ClientName as '顧客名',");
                query.AppendLine("  s.SectionName as '区画名',");
                query.AppendLine("  a.AgreeFrom as '開始日',");
                query.AppendLine("  a.AgreeTo as '終了日'");


                int month = 4;
                DateTime dt = new DateTime(year, month, 1);

                if (rdo_Payment.Checked)
                {
                    DateTime dttmp = new DateTime(year, month, 1);
                    for (int i = 0; i < 12; i++)
                    {
                        month = dttmp.Month;
                        query.AppendLine(string.Format("  ,(select '\\'||SUM(Money) from Payment where PayMonth >= '{0}' and PayMonth <= '{1}' and AgreeID = a.AgreeID) as '{2}'",
                                                        dttmp.ToString("yyyy-MM-dd"), dttmp.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd"), month.ToString() + "月"));
                        dttmp = dttmp.AddMonths(1);
                    }
                }
                query.AppendLine("  from ParkingMaster p");
                query.AppendLine("  inner join SectionMaster s");
                query.AppendLine("    on p.ParkingID = s.ParkingID");
                query.AppendLine("  left join AgreeParking ap");
                query.AppendLine("    on ap.ParkingID = s.ParkingID");
                query.AppendLine("   and ap.SectionID = s.SectionID");
                query.AppendLine("  inner join Agreement a");
                query.AppendLine("    on ap.AgreeID = a.AgreeID");
                query.AppendLine("   and a.ClientSubID = ap.SubID");
                query.AppendLine(string.Format("    and a.AgreeTo >= '{0}'", dt));

                query.AppendLine("  inner join ClientMaster c");
                query.AppendLine("    on c.ClientID = a.ClientID");
                query.AppendLine(string.Format("   where p.ParkingID = {0}", cmb_ParkingList.SelectedValue));
                query.AppendLine("  order by s.SectionName,a.AgreeFrom");
                //query.AppendLine("  order by s.SectionID,a.AgreeTo");


                if (rdo_Payment.Checked)
                {
                    dgv_PaymentList.DataSource = Util.QueryExecuteReturn(query.ToString());
                }
                else
                {
                    DataTable tmpdt = new DataTable();
                    tmpdt.Columns.Add("契約番号", Type.GetType("System.String"));
                    tmpdt.Columns.Add("ParkingID", Type.GetType("System.String"));
                    tmpdt.Columns.Add("ClientID", Type.GetType("System.String"));
                    tmpdt.Columns.Add("ClientSubID", Type.GetType("System.String"));
                    tmpdt.Columns.Add("顧客名", Type.GetType("System.String"));
                    tmpdt.Columns.Add("区画名", Type.GetType("System.String"));
                    tmpdt.Columns.Add("開始日", Type.GetType("System.String"));
                    tmpdt.Columns.Add("終了日", Type.GetType("System.String"));
                    tmpdt.Columns.Add("4月", Type.GetType("System.String"));
                    tmpdt.Columns.Add("5月", Type.GetType("System.String"));
                    tmpdt.Columns.Add("6月", Type.GetType("System.String"));
                    tmpdt.Columns.Add("7月", Type.GetType("System.String"));
                    tmpdt.Columns.Add("8月", Type.GetType("System.String"));
                    tmpdt.Columns.Add("9月", Type.GetType("System.String"));
                    tmpdt.Columns.Add("10月", Type.GetType("System.String"));
                    tmpdt.Columns.Add("11月", Type.GetType("System.String"));
                    tmpdt.Columns.Add("12月", Type.GetType("System.String"));
                    tmpdt.Columns.Add("1月", Type.GetType("System.String"));
                    tmpdt.Columns.Add("2月", Type.GetType("System.String"));
                    tmpdt.Columns.Add("3月", Type.GetType("System.String"));


                    DataTable dta = Util.QueryExecuteReturn(query.ToString());
                    foreach (DataRow dr in dta.Rows)
                    {
                        int AgreeID = int.Parse(dr["契約番号"].ToString());
                        int SubID = int.Parse(dr["ClientSubID"].ToString());
                        string[] pay = Util.GetApportPay(AgreeID,SubID, year);

                        DataRow tmpdr = tmpdt.NewRow();

                        tmpdr["契約番号"] = dr["契約番号"].ToString();
                        tmpdr["ParkingID"] =dr["ParkingID"].ToString();
                        tmpdr["ClientID"] = dr["ClientID"].ToString();
                        tmpdr["ClientSubID"] = dr["ClientSubID"].ToString();
                        tmpdr["顧客名"] = dr["顧客名"].ToString();
                        tmpdr["区画名"] = dr["区画名"].ToString();
                        tmpdr["開始日"] = dr["開始日"].ToString().Substring(0,10);
                        tmpdr["終了日"] = dr["終了日"].ToString().Substring(0, 10);
                        tmpdr["4月"] = pay[0];
                        tmpdr["5月"] = pay[1];
                        tmpdr["6月"] = pay[2];
                        tmpdr["7月"] = pay[3];
                        tmpdr["8月"] = pay[4];
                        tmpdr["9月"] = pay[5];
                        tmpdr["10月"] = pay[6];
                        tmpdr["11月"] = pay[7];
                        tmpdr["12月"] = pay[8];
                        tmpdr["1月"] = pay[9];
                        tmpdr["2月"] = pay[10];
                        tmpdr["3月"] = pay[11];

                        tmpdt.Rows.Add(tmpdr);
                    }

                    dgv_PaymentList.DataSource = tmpdt;
                }

                dgv_PaymentList.Columns[1].Visible = false;
                dgv_PaymentList.Columns[2].Visible = false;
                dgv_PaymentList.Columns[3].Visible = false;

                dgv_PaymentList.Columns[0].Width = 60;
                for (int i = 8; i < 20; i++)
                {
                    dgv_PaymentList.Columns[i].Width = 60;
                }



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

        private void cmb_ParkingList_SelectedIndexChanged(object sender, EventArgs e)
        {
            disp();
        }

        private void dgv_PaymentList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;

            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true; // 以降の書式設定は不要

            }
        }

        bool IsTheSameCellValue(int column, int row)
        {
            if (column != 5 && column != 4)
            {
                return false;
            }


            DataGridViewCell cell1 = dgv_PaymentList[column, row];
            DataGridViewCell cell2 = dgv_PaymentList[column, row - 1];

            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }

            // ここでは文字列としてセルの値を比較
            if (cell1.Value.ToString() == cell2.Value.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void dgv_PaymentList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // セルの下側の境界線を「境界線なし」に設定
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;

            // 1行目や列ヘッダ、行ヘッダの場合は何もしない
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;

            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                // セルの上側の境界線を「境界線なし」に設定
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                // セルの上側の境界線を既定の境界線に設定
                e.AdvancedBorderStyle.Top = dgv_PaymentList.AdvancedCellBorderStyle.Top;
            }
        }

        private void base_CheckedChanged(object sender, EventArgs e)
        {
            dgv_PaymentList.DataSource = "";
            disp();
        }

        private void dgv_PaymentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dgv_PaymentList.CurrentCell.RowIndex;

            int AgreeID = int.Parse(dgv_PaymentList.Rows[row].Cells[0].Value.ToString());
            string AgreeFrom = dgv_PaymentList.Rows[row].Cells[6].Value.ToString();
            string AgreeTo = dgv_PaymentList.Rows[row].Cells[7].Value.ToString();
            OpenForm(new PayConfirm(AgreeID, AgreeFrom, AgreeTo));
        }


        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            disp();
        }

    }
}
