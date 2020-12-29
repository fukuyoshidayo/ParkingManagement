using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Data.SQLite;

using OfficeOpenXml;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlLocalDb;

namespace ssk
{
   public static class Util
   {
        public enum EditMode
        {
            New = 0,
            Edit
        }

        public enum EditType
        {
            Agree = 0,
            Client
        }
        public enum Remode
        {
            Reminder = 0,
            Refund
        }

       public static string logpath = @"err.log";
       public static string logpath2 = @"sousa.log";

       public static int sibucode =-1;
       public static string userID = string.Empty;
       public static int userLev = -1;
       public static string sibuname = string.Empty;
       public static string sqlitefile = string.Empty;
       public static string masterconstr = string.Empty;

       public static string ConnectionStr()
       {
            sqlitefile = System.Configuration.ConfigurationManager.AppSettings["DB"];
            string fullPath = System.IO.Path.GetFullPath(sqlitefile);
            return sqlitefile;
       }

       public static void log2(string txt)
       {
           StreamWriter wr = new StreamWriter(new FileStream(logpath2, File.Exists(logpath2) ? FileMode.Append : FileMode.Create), Encoding.Default);
           wr.WriteLine(string.Format("{0:yyyy/MM/dd HH:mm:ss} {1}", DateTime.Now, txt));
           wr.Close();
       }
        
       public static string md5str(string s)
       {
           byte[] data = System.Text.Encoding.UTF8.GetBytes(s);
           System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
           byte[] bs = md5.ComputeHash(data);
           md5.Clear();
           return BitConverter.ToString(bs).ToLower().Replace("-", "");
       }

       public static string md5(string id, string pass)
       {
           return md5str("<" + id + "><" + pass + ">");
       }
        
       public static DataTable QueryExecuteReturn(string query)
       {
            DataTable dataTable = new DataTable();

            using (SQLiteConnection con = new SQLiteConnection("Data Source=" + Util.ConnectionStr()))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query.Replace("/","-"), con))
            {
                adapter.Fill(dataTable);
            }

            return dataTable;

       }


        public static void QueryExecuteNoReturn(string query)
        {
            try
            {
                var sqlConnectionSb = new SQLiteConnectionStringBuilder { DataSource = Util.ConnectionStr() };
                using (var cn = new SQLiteConnection(sqlConnectionSb.ToString()))
                {
                    cn.Open();

                    using (var transaction = cn.BeginTransaction())
                    {
                        using (var cmd = new SQLiteCommand(cn))
                        {
                            //テーブル作成
                            cmd.CommandText = query;
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        public static string ConvDateFormat(DateTime datetime)
        {
            return datetime.ToString("yyyy-MM-dd");
        }

        public static void SetParkingComboBox(ComboBox cmb)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("select");
            query.AppendLine("  ParkingID,");
            query.AppendLine("  ParkingName");
            query.AppendLine(" FROM ParkingMaster");

            cmb.DisplayMember = "ParkingName";
            cmb.ValueMember = "ParkingID";
            cmb.DataSource = Util.QueryExecuteReturn(query.ToString());

        }


        public static void SetSectionComboBox(ComboBox cmb,object ParkingID)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("select");
            query.AppendLine("  SectionID,");
            query.AppendLine("  SectionName");
            query.AppendLine(" FROM SectionMaster");
            query.AppendLine(string.Format(" Where ParkingID = {0}", ParkingID.ToString()));

            cmb.DisplayMember = "SectionName";
            cmb.ValueMember = "SectionID";
            cmb.DataSource = Util.QueryExecuteReturn(query.ToString());

        }

        public static void SetPaymentComboBox(ComboBox cmb)
        {
            StringBuilder query = new StringBuilder();
            query.Clear();
            query.AppendLine("select");
            query.AppendLine("  PaymentID,");
            query.AppendLine("  PaymentName");
            query.AppendLine(" FROM PayMaster");

            cmb.DisplayMember = "PaymentName";
            cmb.ValueMember = "PaymentID";
            cmb.DataSource = Util.QueryExecuteReturn(query.ToString());

        }



        /// <summary>
        /// 経過月数を求める
        /// </summary>
        /// <param name="dTime1"></param>
        /// <param name="dTime2"></param>
        /// <returns></returns>
        public static int MonthDiff(DateTime dTime1, DateTime dTime2)
        {
            int iRet = 0;
            DateTime dtFrom = DateTime.MinValue;
            DateTime dtTo = DateTime.MaxValue;

            if (dTime1 < dTime2)
            {
                dtFrom = dTime1;
                dtTo = dTime2;
            }
            else
            {
                dtFrom = dTime2;
                dtTo = dTime1;
            }

            // 月差計算（年差考慮(差分1年 → 12(ヶ月)加算)）
            iRet = (dtTo.Month + (dtTo.Year - dtFrom.Year) * 12) - dtFrom.Month;

            return iRet + 1;
        }

        public static int MonthlyPrice(int AgreeID)
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder();
            query.AppendLine("select");
            query.AppendLine("  SUM(pm.Price) as sum");
            query.AppendLine(" FROM Agreement a");
            query.AppendLine(" inner join AgreeParking ap");
            query.AppendLine(" on a.AgreeID = ap.AgreeID");
            query.AppendLine(string.Format(" AND a.AgreeID = {0}", AgreeID));
            query.AppendLine(" inner join ParkingMaster pm");
            query.AppendLine(" on ap.ParkingID = pm.ParkingID");

            dt = Util.QueryExecuteReturn(query.ToString());

            return int.Parse(dt.Rows[0]["sum"].ToString());
        }

        public static int TotalPayment(int AgreeID)
        {
            int sum = 0;
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder();
            query.AppendLine("select");
            query.AppendLine("  SUM(money) as sum");
            query.AppendLine(" FROM Payment");
            query.AppendLine(string.Format(" where AgreeID = {0}", AgreeID));

            dt = Util.QueryExecuteReturn(query.ToString());

            if (!int.TryParse(dt.Rows[0]["sum"].ToString(), out sum)) sum = 0;

            return sum;
        }

        public static bool From16toAgreeID(int AgreeID)
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder();
            query.AppendLine("select");
            query.AppendLine("  AgreeFrom");
            query.AppendLine(" FROM Agreement");
            query.AppendLine(string.Format(" where AgreeID = {0}", AgreeID));

            dt = Util.QueryExecuteReturn(query.ToString());

            return From16toString(dt.Rows[0]["AgreeFrom"].ToString());
        }
        public static bool From16toDateTime(DateTime dt)
        {
            return dt.Day == 16;
        }
        public static bool From16toString(string dt)
        {
            if (!DateTime.TryParse(dt, out DateTime dtt)) return false;
            return From16toDateTime(dtt);
        }


        public static string[] GetApportPay(int AgreeID,int SubID, int year)
        {
            string[] pay = new string[12];

            AgreeInfo ai = new AgreeInfo(AgreeID);

            int mp = MonthlyPrice(AgreeID);
            double tp = TotalPayment(AgreeID);
            bool a16 = From16toDateTime(ai.AgreeFrom);
            // 処理しやすいように契約開始終了日を１日にしておく
            DateTime tmpFrom = new DateTime(ai.AgreeFrom.Year, ai.AgreeFrom.Month, 1);
            DateTime tmpTo = new DateTime(ai.AgreeTo.Year, ai.AgreeTo.Month, 1);

            DateTime bsDate = new DateTime(year, 4, 1);

            // 指定年度より前より契約してたら
            if (tmpFrom < bsDate)
            {
                tp = tp - ((MonthDiff(tmpFrom, bsDate) - (a16 ? 0.5 : 0)) * mp);
                a16 = false; // 既に半月の処理したので、falseにしておく
                tmpFrom = new DateTime(year, 4, 1);
            }

            // bsDateをプラス1カ月ずつしていき、開始日と終了日の間の支払いを配列に入れていく
            for(int i = 0; i < 12; i++)
            {
                if(tmpFrom == bsDate)
                {
                    for(int j = i; j < 12; j++)
                    {
                        // 終了日を超えた場合
                        if (tmpTo < bsDate)
                        {
                            // 残高がある場合は!!で囲う、ない場合は「-」を入れる
                            pay[j] = tp > 0 ? "!!" + mp.ToString() + "!!" : "-";
                        }
                        else
                        {
                            // 残高がある場合
                            if(tp > 0)
                            {
                                // 残高が月額より小さい場合は残高を入れる（残高不足）
                                pay[j] = tp < mp ? "!!" + tp.ToString() + "!!" : mp.ToString();
                            }
                            else
                            {
                                pay[j] = "0";
                            }
                        }

                        // 支払残高から１カ月の料金を引く　16日開始の場合は半分引く
                        if(a16)
                        {
                            tp = tp - (0.5 * mp);
                            a16 = false;
                        }
                        else
                        {
                            tp = tp - mp;
                        }
                        // 基準月をプラス１する
                        bsDate = bsDate.AddMonths(1);
                    }
                    break;
                }
                else
                {
                    // 開始日が4/1から始まらならない場合は、「-」を入れる
                    pay[i] = "-";
                    bsDate = bsDate.AddMonths(1);
                }
            }

            return pay;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="mode"></param>
        public static void PayDiff(DataGridView dgv, int year, int month, int mode)
        {
            StringBuilder query = new StringBuilder();

            DataTable dt = new DataTable();

            // 基準月の末日
            DateTime Startdt = new DateTime(year, month, 1);
            DateTime Enddt = Startdt.AddMonths(1);
            if (mode == (int)Remode.Reminder)
            {
                Enddt = Enddt.AddDays(-1);
            }

            query.AppendLine("select");
            query.AppendLine("  AgreeID,");
            query.AppendLine("  ClientSubID");
            query.AppendLine(" FROM Agreement");
            if (mode == (int)Remode.Reminder)
            {
                query.AppendLine(string.Format(" where (AgreeFrom <= '{0}' ", Enddt));
                query.AppendLine(string.Format(" or AgreeTo >= '{0}') ", Startdt));
            }
            else
            {
                query.AppendLine(string.Format(" where AgreeTo < '{0}' ", Enddt));
            }

            dt = Util.QueryExecuteReturn(query.ToString());

            foreach (DataRow dr in dt.Rows)
            {
                int AgreeID = int.Parse(dr["AgreeID"].ToString());
                int SubID = int.Parse(dr["ClientSubID"].ToString());
                AgreeInfo ai = new AgreeInfo(AgreeID);
                DateTime AgreeFrom = ai.AgreeFrom;
                DateTime AgreeTo = ai.AgreeTo;

                if (mode == (int)Remode.Reminder)
                {
                    // 終了日が基準日より前ならToを終了日にする
                    AgreeTo = ai.AgreeTo < Enddt ? ai.AgreeTo : Enddt;
                }

                int tp = Util.TotalPayment(AgreeID); // 合計支払額
                int mp = Util.MonthlyPrice(AgreeID); // 月額
                bool a16 = Util.From16toDateTime(AgreeFrom);
                string park = "";

                double df = Util.MonthDiff(AgreeFrom, AgreeTo) - (a16 ? 0.5 : 0); // トータル契約月数 16日スタートの場合マイナス0.5か月

                double a = tp - (df * mp);

                if (mode == (int)Remode.Reminder)
                {
                    // 月数に対して支払額が大きければ問題なし 以降の処理は無し
                    if (a >= 0) continue;
                }
                else
                {
                    if (a <= 0) continue;
                }

                foreach (DataRow pdr in ai.dtParkingInfo.Rows)
                {
                    park = park + pdr["ParkingName"].ToString() + "-" + pdr["SectionName"].ToString() + ",";
                }

                if (mode == (int)Remode.Reminder)
                {
                    dgv.Rows.Add(new string[] { AgreeID.ToString(), ai.ClientName, park, (a * (-1)).ToString() });
                }
                else
                {
                    dgv.Rows.Add(new string[] { AgreeID.ToString(), ai.ClientName, park, a.ToString() });
                }


            }
        }

    }



    public class PaymentInfo
    {
        public DataTable dt = new DataTable();

        public PaymentInfo(int AgreeID)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("select");
            query.AppendLine("  p.PaymentID,");
            query.AppendLine("  p.PayMonth,");
            query.AppendLine("  p.Money,");
            query.AppendLine("  pm.PaymentName");
            query.AppendLine(" FROM Payment p");
            query.AppendLine(" inner join PayMaster pm");
            query.AppendLine(" on p.PaymentID = pm.PaymentID");
            query.AppendLine(string.Format(" and p.AgreeID = {0}", AgreeID));

            dt = Util.QueryExecuteReturn(query.ToString());


        }
    }

    public class AgreeInfo
    {
        public string ClientName = "";
        public string ClientAddress = "";
        public int ClientID = 0;
        public int ClientSubID = 0;
        public string ClientTEL = "";
        public int CorpFlg = 0;
        public DateTime AgreeFrom = DateTime.Now;
        public DateTime AgreeTo = DateTime.Now;
        public int PaymentID = 0;

        public DataTable dtParkingInfo = new DataTable();


        public AgreeInfo(int AgreeID)
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder();
            query.AppendLine("select");
            query.AppendLine("  a.AgreeID,");
            query.AppendLine("  a.PaymentID,");
            query.AppendLine("  min(a.AgreeFrom) as AgreeFrom,");
            query.AppendLine("  max(a.AgreeTo) as AgreeTo,");
            query.AppendLine("  c.ClientID,");
            query.AppendLine("  c.CorpFlg,");
            query.AppendLine("  c.ClientName,");
            query.AppendLine("  c.ClientAddress,");
            query.AppendLine("  c.ClientTEL");
            query.AppendLine(" FROM Agreement a");
            query.AppendLine(" inner join ClientMaster c");
            query.AppendLine(" on c.ClientID = a.ClientID");
            query.AppendLine(string.Format(" and a.AgreeID = {0}", AgreeID));
            query.AppendLine(" group by");
            query.AppendLine("  a.AgreeID,");
            query.AppendLine("  a.PaymentID,");
            query.AppendLine("  c.ClientID,");
            query.AppendLine("  c.CorpFlg,");
            query.AppendLine("  c.ClientName,");
            query.AppendLine("  c.ClientAddress,");
            query.AppendLine("  c.ClientTEL");

            dt = Util.QueryExecuteReturn(query.ToString());

            ClientName = dt.Rows[0]["ClientName"].ToString();
            CorpFlg = int.Parse(dt.Rows[0]["CorpFlg"].ToString());
            ClientID = int.Parse(dt.Rows[0]["ClientID"].ToString());
            ClientAddress = dt.Rows[0]["ClientAddress"].ToString();
            ClientTEL = dt.Rows[0]["ClientTEL"].ToString();
            AgreeFrom = DateTime.Parse(dt.Rows[0]["AgreeFrom"].ToString());
            AgreeTo = DateTime.Parse(dt.Rows[0]["AgreeTo"].ToString());
            PaymentID = int.Parse(dt.Rows[0]["PaymentID"].ToString());



            query.Clear();
            query.AppendLine("select");
            query.AppendLine("  p.ParkingID,");
            query.AppendLine("  s.SectionID,");
            query.AppendLine("  p.ParkingName,");
            query.AppendLine("  s.SectionName");
            query.AppendLine(" FROM AgreeParking ap");
            query.AppendLine(" inner join ParkingMaster p");
            query.AppendLine("  on ap.ParkingID = p.ParkingID");
            query.AppendLine(" inner join SectionMaster s");
            query.AppendLine("  on ap.ParkingID = s.ParkingID");
            query.AppendLine("  and ap.SectionID = s.SectionID");
            query.AppendLine(string.Format(" where ap.AgreeID = {0} ", AgreeID));

            dtParkingInfo = Util.QueryExecuteReturn(query.ToString());
        }
    }


}
