using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlLocalDb;

namespace ssk
{
    public static class StoredProc
    {

        public static SqlParameter sp(string name, SqlDbType t, int s, object v)
        {
            SqlParameter p = null;
            switch (t)
            {
                case SqlDbType.NVarChar:
                case SqlDbType.VarBinary:
                case SqlDbType.VarChar:
                case SqlDbType.Char:
                case SqlDbType.Binary:
                    p = s > 0 ? new SqlParameter(name, t, s) : new SqlParameter(name, t);
                    p.Value = v;
                    break;
                default:
                    p = new SqlParameter(name, t);
                    p.Value = v;
                    break;
            }
            return p;
        }

        public static SqlParameter sout(string name, SqlDbType t)
        {
            SqlParameter p = new SqlParameter(name, t);
            p.Direction = ParameterDirection.Output;
            return p;
        }

        public static string query_login_check(bool _alter)
        {
            StringBuilder query = new StringBuilder("");
            if (_alter) {
                query.AppendLine("IF OBJECT_ID(N'CheckUser') IS NOT NULL");
                query.AppendLine("DROP PROCEDURE CheckUser");
                query.AppendLine("GO");
            }
            query.AppendLine("CREATE ");
            query.AppendLine("PROCEDURE CheckUser");
            query.AppendLine("@userid nvarchar(64)");
            query.AppendLine(",@pass nvarchar(64)");
            query.AppendLine(",@lev int OUTPUT");
            query.AppendLine("AS");
            query.AppendLine("BEGIN");
            query.AppendLine("SET @lev=-1;");
            query.AppendLine("SELECT @lev=Lev FROM LOCALUSERS WHERE UserID=@userid AND Pass=@pass;");
            query.AppendLine("END");
            return query.ToString();
        }


        public static bool login_check(string id, string pass)
        {
            string s1 = id;
            string s2 = Util.md5(id, pass);
            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@userid", SqlDbType.NVarChar,64);
            p.Value = s1;
            pp.Add(p);
            p = new SqlParameter("@pass", SqlDbType.NVarChar,64);
            p.Value = s2;
            pp.Add(p);
            p = new SqlParameter("@lev", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            pp.Add(p);
            Util.ExcuteStoredProcedure("CheckUser", pp);

            if (pp[2].Value != null)
            {
                int r = Util.Str2Int(pp[2].Value);
                if (r > -1)
                {
                    Util.userLev = r;
                    Util.userID = id;
                }
                else
                {
                    Util.userLev = -1;
                    Util.userID = string.Empty;
                }
                return r > -1;
            }
            else
            {
                Util.userLev = -1;
                Util.userID = string.Empty;
                return false;
            }
        }

        public static string query_ChangePasswd(bool _alter)
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine(_alter ? "ALTER " : "CREATE ");
            query.AppendLine("PROCEDURE ChangePasswd");
            query.AppendLine("@userid nvarchar(64)");
            query.AppendLine(",@pass1 nvarchar(64)");
            query.AppendLine(",@pass2 nvarchar(64)");
            query.AppendLine(",@ret int OUTPUT");
            query.AppendLine("AS BEGIN");
            query.AppendLine("SET @ret=-1;");
            query.AppendLine("SELECT @ret=COUNT(*) FROM LOCALUSERS WHERE UserID=@userid AND Pass=@pass1; ");
            query.AppendLine("UPDATE LOCALUSERS SET Pass=@pass2 WHERE UserID=@userid AND Pass=@pass1;");
            query.AppendLine("END");

            return query.ToString();
        }
        public static bool ChangePasswd(string id, string pass_old, string pass_new)
        {
            string s1 = id;
            string s2 = Util.md5(id, pass_old);
            string s3 = Util.md5(id, pass_new);
            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@userid", SqlDbType.NVarChar,64);
            p.Value = s1;
            pp.Add(p);
            p = new SqlParameter("@pass1", SqlDbType.NVarChar,64);
            p.Value = s2;
            pp.Add(p);
            p = new SqlParameter("@pass2", SqlDbType.NVarChar,64);
            p.Value = s3;
            pp.Add(p);
            p = new SqlParameter("@ret", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            pp.Add(p);
            Util.ExcuteStoredProcedure("ChangePasswd", pp);
            if (pp[3].Value != null)
            {
                int r = Util.Str2Int(pp[3].Value);
                return r > 0;
            }
            return false;
        }

         public static string 伝票初期化(bool _alter)
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'伝票初期化') IS NOT NULL");
            query.AppendLine("DROP PROCEDURE 伝票初期化");
            query.AppendLine("GO");
            query.AppendLine("CREATE PROCEDURE 伝票初期化");
            query.AppendLine("AS BEGIN");
            query.AppendLine("DELETE FROM 振替伝票;");
            query.AppendLine("DBCC CHECKIDENT(N'振替伝票', RESEED, 0);");
            query.AppendLine("END");
            query.AppendLine("GO");
            return query.ToString();
        }

        public static string query_AddUser(bool _alter)
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine(_alter ? "ALTER " : "CREATE ");
            query.AppendLine("PROCEDURE AddUser");
            query.AppendLine("@userid nvarchar(64)");
            query.AppendLine(",@pass nvarchar(64)");
            query.AppendLine(",@lev int");
            query.AppendLine(",@ret int OUTPUT");
            query.AppendLine("AS BEGIN");
            query.AppendLine("SET @ret=-1;");
            query.AppendLine("INSERT INTO LOCALUSERS (UserID,Pass,Lev) VALUES (@userid,@pass,@lev);");
            query.AppendLine("SELECT @ret=COUNT(*) FROM LOCALUSERS WHERE UserID=@userid AND Pass=@pass; ");
            query.AppendLine("END");

            return query.ToString();
        }
        public static bool AddUser(string id, string pass, int lev)
        {
            string s1 = id;
            string s2 = Util.md5(id, pass);
            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@userid", SqlDbType.NVarChar,64);
            p.Value = s1;
            pp.Add(p);
            p = new SqlParameter("@pass", SqlDbType.NVarChar,64);
            p.Value = s2;
            pp.Add(p);
            p = new SqlParameter("@lev", SqlDbType.Int);
            p.Value = lev;
            pp.Add(p);
            p = new SqlParameter("@ret", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            pp.Add(p);
            Util.ExcuteStoredProcedure("AddUser", pp);
            if (pp[3].Value != null)
            {
                int r = Util.Str2Int(pp[3].Value);
                return r > 0;
            }
            return false;
        }

        public static string query_DeleteUser(bool _alter)
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine(_alter ? "ALTER " : "CREATE ");
            query.AppendLine("PROCEDURE DeleteUser");
            query.AppendLine("@userid nvarchar(64)");
            query.AppendLine(",@pass nvarchar(64)");
            query.AppendLine(",@ret int OUTPUT");
            query.AppendLine("AS BEGIN");
            query.AppendLine("SET @ret=-1;");
            query.AppendLine("DELETE FROM LOCALUSERS WHERE UserID=@userid AND Pass=@pass;");
            query.AppendLine("SELECT @ret=COUNT(*) FROM LOCALUSERS WHERE UserID=@userid;");
            query.AppendLine("END");

            return query.ToString();
        }
        public static bool DeleteUser(string id, string pass)
        {
            Util.ExecSQL(query_DeleteUser(true));
            string s2 = Util.md5(id, pass);
            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@userid", SqlDbType.NVarChar,64);
            p.Value = id;
            pp.Add(p);
            p = new SqlParameter("@pass", SqlDbType.NVarChar, 64);
            p.Value = s2;
            pp.Add(p);
            p = new SqlParameter("@ret", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            pp.Add(p);

            Util.ExcuteStoredProcedure("DeleteUser", pp);
            if (pp[2].Value != null)
            {
                int r = Util.Str2Int(pp[2].Value);
                return r == 0;
            }
            return false;
        }

        public static string query_繰越設定(bool _alter)
        {
            StringBuilder query = new StringBuilder("");
            if (_alter)
            {
                query.AppendLine("IF OBJECT_ID(N'繰越設定') IS NOT NULL");
                query.AppendLine("DROP PROCEDURE 繰越設定;");
                query.AppendLine("GO");
            }
            else
            {
                query.AppendLine("IF OBJECT_ID(N'繰越設定') IS NULL");
                query.AppendLine("BEGIN");
            }
            query.AppendLine("CREATE PROCEDURE 繰越設定");
            query.AppendLine("@id INTEGER");
            query.AppendLine(",@nendo INTEGER");
            query.AppendLine(",@g INTEGER");
            query.AppendLine("AS BEGIN");
            query.AppendLine("DECLARE @n int;");
            query.AppendLine("SET @n=0;");
            query.AppendLine("SELECT @n=COUNT(*) FROM 繰越額 WHERE ID=@id AND 年度=@nendo;");
            query.AppendLine("IF @n=0");
            query.AppendLine("BEGIN");
            query.AppendLine("INSERT INTO 繰越額 (ID,年度,G) VALUES (@id,@nendo,@g);");
            query.AppendLine("END");
            query.AppendLine("IF @n=1");
            query.AppendLine("BEGIN");
            query.AppendLine("UPDATE 繰越額 SET G=@g WHERE ID=@id AND 年度=@nendo;");
            query.AppendLine("END");
            query.AppendLine("END");

            if (!_alter)
            {
                query.AppendLine("END");
            }
            query.AppendLine("GO");

            return query.ToString();
        }

        public static string query_繰越差額設定(bool _alter)
        {
            StringBuilder query = new StringBuilder("");
            if (_alter)
            {
                query.AppendLine("IF OBJECT_ID(N'繰越差額設定') IS NOT NULL");
                query.AppendLine("DROP PROCEDURE 繰越差額設定;");
                query.AppendLine("GO");
            }
            else
            {
                query.AppendLine("IF OBJECT_ID(N'繰越差額設定') IS NULL");
                query.AppendLine("BEGIN");
            }
            query.AppendLine("CREATE PROCEDURE 繰越差額設定");
            query.AppendLine("@id INTEGER");
            query.AppendLine(",@nendo INTEGER");
            query.AppendLine(",@g INTEGER");
            query.AppendLine("AS BEGIN");
            query.AppendLine("DECLARE @n int;");
            query.AppendLine("DECLARE @pn int;");
            query.AppendLine("DECLARE @prevg int;");
            query.AppendLine("DECLARE @prename NVARCHAR(64);");
            query.AppendLine("SET @n=0;");
            query.AppendLine("SELECT @n=COUNT(*) FROM 繰越額 WHERE ID=@id AND 年度=@nendo;");
            query.AppendLine("SELECT @pn=COUNT(*) FROM 繰越差額 WHERE ID=@id AND 年度=@nendo;");
            query.AppendLine("IF @n=1 AND @pn=0");
            query.AppendLine("BEGIN");
            query.AppendLine("SELECT @prevg=G,@prename=NAME FROM 繰越額 WHERE ID=@id AND 年度=@nendo;");
            query.AppendLine("INSERT INTO 繰越差額 (ID,年度,NAME,G) VALUES (@id,@nendo,@prename,@g-@prevg);");
            query.AppendLine("END");
            query.AppendLine("IF @n=1 AND @pn=1");
            query.AppendLine("BEGIN");
            query.AppendLine("SELECT @prevg=G,@prename=NAME FROM 繰越額 WHERE ID=@id AND 年度=@nendo;");
            query.AppendLine("UPDATE 繰越差額 SET G=@g-@prevg,NAME=@prename WHERE ID=@id AND 年度=@nendo;");
            query.AppendLine("END");
            query.AppendLine("END");

            if (!_alter)
            {
                query.AppendLine("END");
            }
            query.AppendLine("GO");

            return query.ToString();
        }

        public static void 繰越設定(int id, int gaku)
        {
            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@id", SqlDbType.Int);
            p.Value = id;
            pp.Add(p);
            p = new SqlParameter("@nendo", SqlDbType.Int);
            p.Value = Util.年度;
            pp.Add(p);
            p = new SqlParameter("@g", SqlDbType.Int);
            p.Value = gaku;
            pp.Add(p);
            Util.ExcuteStoredProcedure("繰越設定", pp);
        }

        public static void 繰越設定(int id, int nendo, int gaku)
        {
            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@id", SqlDbType.Int);
            p.Value = id;
            pp.Add(p);
            p = new SqlParameter("@nendo", SqlDbType.Int);
            p.Value = nendo;
            pp.Add(p);
            p = new SqlParameter("@g", SqlDbType.Int);
            p.Value = gaku;
            pp.Add(p);
            Util.ExcuteStoredProcedure("繰越設定", pp);
        }

        public static void 繰越差額設定(int id, int nendo, int gaku)
        {
            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@id", SqlDbType.Int);
            p.Value = id;
            pp.Add(p);
            p = new SqlParameter("@nendo", SqlDbType.Int);
            p.Value = nendo;
            pp.Add(p);
            p = new SqlParameter("@g", SqlDbType.Int);
            p.Value = gaku;
            pp.Add(p);
            Util.ExcuteStoredProcedure("繰越差額設定", pp);
        }

        public static string query_繰越読出(bool _alter)
        {
            StringBuilder query = new StringBuilder("");
            if (_alter)
            {
                query.AppendLine("IF OBJECT_ID(N'繰越読出') IS NOT NULL");
                query.AppendLine("DROP PROCEDURE 繰越読出;");
                query.AppendLine("GO");
            }
            else
            {
                query.AppendLine("IF OBJECT_ID(N'繰越読出') IS NULL");
                query.AppendLine("BEGIN");
            }
            query.AppendLine("CREATE PROCEDURE 繰越読出");
            query.AppendLine("@id INTEGER");
            query.AppendLine(",@nendo INTEGER");
            query.AppendLine(",@g INTEGER OUTPUT");
            query.AppendLine("AS BEGIN");
            query.AppendLine("DECLARE @pn int;");
            query.AppendLine("DECLARE @sagaku int;");
            query.AppendLine("SET @sagaku=0;");
            query.AppendLine("SELECT @pn=COUNT(*) FROM 繰越差額 WHERE ID=@id AND 年度=@nendo;");

            query.AppendLine("IF @pn<>0");
            query.AppendLine("SELECT @sagaku=G FROM 繰越差額 WHERE ID=@id AND 年度=@nendo;");

            query.AppendLine("SELECT @g=G FROM 繰越額 WHERE ID=@id AND 年度=@nendo;");
            query.AppendLine("SET @g = @g+@sagaku;");
            query.AppendLine("END");

            if (!_alter)
            {
                query.AppendLine("END");
            }

            return query.ToString();
        }

        public static int 繰越読出(int id,int nendo)
        {

            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@id", SqlDbType.Int);
            p.Value = id;
            pp.Add(p);
            p = new SqlParameter("@nendo", SqlDbType.Int);
            p.Value = nendo;
            pp.Add(p);
            p = new SqlParameter("@g", SqlDbType.Int);
            p.Direction=ParameterDirection.Output;
            pp.Add(p);
            if(Util.ExcuteStoredProcedure("繰越読出", pp))
            {
                if (pp[2].Value != null)
                {
                    return Util.Str2Int(pp[2].Value);
                }
            }
            return 0;
            
        }

        /*
IF OBJECT_ID(N'月集計') IS NOT NULL
DROP PROCEDURE 月集計;
GO

CREATE PROCEDURE 月集計
@from_date DATE
,@to_date DATE
AS
BEGIN
SELECT JG,科目,貸借,SUM(額) AS 合計額 FROM 累計内訳 WHERE 年月日 BETWEEN @from_date AND @to_date GROUP BY JG,科目,貸借
END;
GO
         */

        public static string proc_繰越集計(bool _alter)
        {
            StringBuilder query = new StringBuilder("");
            if (_alter)
            {
                query.AppendLine("IF OBJECT_ID(N'繰越集計') IS NOT NULL");
                query.AppendLine("DROP PROCEDURE 繰越集計;");
                query.AppendLine("GO");
            }
            else
            {
                query.AppendLine("IF OBJECT_ID(N'繰越集計') IS NULL");
                query.AppendLine("BEGIN");
            }
            query.AppendLine("CREATE PROCEDURE 繰越集計");
            query.AppendLine("@from_date DATE");
            query.AppendLine(",@to_date DATE");
            query.AppendLine("AS");
            query.AppendLine("BEGIN");
            //query.AppendLine("SELECT 1 AS JG,ID as 科目,IIF(ID=84,1,0) as 貸借,G as 合計額 from 繰越額 where 年度=YEAR(@from_date) and ID in (84,85,90,91,92,93,118);");
            query.AppendLine("SELECT 1 AS JG,ID as 科目,IIF(ID=84,1,0) as 貸借,G as 合計額 from 繰越額 where 年度=YEAR(@from_date) and ID in (18,84,85,90,91,92,93,118);");
            query.AppendLine("END");


            if (!_alter)
            {
                query.AppendLine("END");
            }
            return query.ToString();
        }


        public static string query_予算設定(bool _alter)
        {
            StringBuilder query = new StringBuilder("");
            if (_alter)
            {
                query.AppendLine("IF OBJECT_ID(N'予算設定') IS NOT NULL");
                query.AppendLine("DROP PROCEDURE 予算設定;");
                query.AppendLine("GO");
            }
            else
            {
                query.AppendLine("IF OBJECT_ID(N'予算設定') IS NULL");
                query.AppendLine("BEGIN");
            }
            query.AppendLine("CREATE PROCEDURE 予算設定");
            query.AppendLine("@cd INTEGER");
            query.AppendLine(",@nendo INTEGER");
            query.AppendLine(",@jigyou INTEGER");
            query.AppendLine(",@tousyo BIT");
            query.AppendLine(",@g INTEGER");
            query.AppendLine("AS BEGIN");
            query.AppendLine("DECLARE @n int;");
            query.AppendLine("SET @n =0;");
            query.AppendLine("SELECT @n =COUNT(*) FROM 予算額 WHERE 科目=@cd AND 事業=@jigyou AND 当初=@tousyo AND 年度=@nendo;");
            query.AppendLine("IF @n=1");
            query.AppendLine("BEGIN");
            query.AppendLine("UPDATE 予算額 SET G=@g WHERE 科目=@cd AND 事業=@jigyou AND 当初=@tousyo AND 年度=@nendo;");
            query.AppendLine("END");
            query.AppendLine("IF @n=0");
            query.AppendLine("BEGIN");
            query.AppendLine("INSERT INTO 予算額 (科目,事業,当初,年度,G) VALUES (@cd,@jigyou,@tousyo,@nendo,@g);");
            query.AppendLine("END");
            query.AppendLine("END");
            if (!_alter)
            {
                query.AppendLine("END");
            }

            return query.ToString();
        }
        public static void 予算設定(int cd, int jigyou, bool tousyo, int gaku)
        {

#if DEBUG
            if(gaku>0){
                ;
            }
#endif
            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@cd", SqlDbType.Int);
            p.Value = cd;
            pp.Add(p);
            p = new SqlParameter("@nendo", SqlDbType.Int);
            p.Value = Util.年度;
            pp.Add(p);
            p = new SqlParameter("@jigyou", SqlDbType.Int);
            p.Value = jigyou;
            pp.Add(p);
            p = new SqlParameter("@tousyo", SqlDbType.Bit);
            p.Value = tousyo;
            pp.Add(p);
            p = new SqlParameter("@g", SqlDbType.Int);
            p.Value = gaku;
            pp.Add(p);
            Util.ExcuteStoredProcedure("予算設定", pp);
        }
        public static void 予算設定(int nendo, int cd, int jigyou, bool tousyo, int gaku)
        {

            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@cd", SqlDbType.Int);
            p.Value = cd;
            pp.Add(p);
            p = new SqlParameter("@nendo", SqlDbType.Int);
            p.Value = nendo;
            pp.Add(p);
            p = new SqlParameter("@jigyou", SqlDbType.Int);
            p.Value = jigyou;
            pp.Add(p);
            p = new SqlParameter("@tousyo", SqlDbType.Bit);
            p.Value = tousyo;
            pp.Add(p);
            p = new SqlParameter("@g", SqlDbType.Int);
            p.Value = gaku;
            pp.Add(p);
            Util.ExcuteStoredProcedure("予算設定", pp);
        }


        public static string query_予算読出(bool _alter)
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine(_alter ? "ALTER " : "CREATE ");
            query.AppendLine("PROCEDURE 予算読出");
            query.AppendLine("@cd INTEGER");
            query.AppendLine(",@nendo INTEGER");
            query.AppendLine(",@jigyou INTEGER");
            query.AppendLine(",@tousyo BIT");
            query.AppendLine(",@g INTEGER OUTPUT");
            query.AppendLine("AS BEGIN");
            query.AppendLine("SELECT @g=G FROM 予算額 WHERE 科目=@cd AND 事業=@jigyou AND 当初=@tousyo AND 年度=@nendo;");
            query.AppendLine("END");

            return query.ToString();
        }
        public static int 予算(int cd, int jigyou, bool tousyo)
        {
            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@cd", SqlDbType.Int);
            p.Value = cd;
            pp.Add(p);
            p = new SqlParameter("@nendo", SqlDbType.Int);
            p.Value = Util.年度;
            pp.Add(p);
            p = new SqlParameter("@jigyou", SqlDbType.Int);
            p.Value = jigyou;
            pp.Add(p);
            p = new SqlParameter("@tousyo", SqlDbType.Bit);
            p.Value = tousyo;
            pp.Add(p);
            p = new SqlParameter("@g", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            pp.Add(p);
            Util.ExcuteStoredProcedure("予算読出", pp);

            return Util.Str2Int(pp[4].Value.ToString());
        }
        public static int 予算(int nendo, int cd, int jigyou, bool tousyo)
        {
            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@cd", SqlDbType.Int);
            p.Value = cd;
            pp.Add(p);
            p = new SqlParameter("@nendo", SqlDbType.Int);
            p.Value = nendo;
            pp.Add(p);
            p = new SqlParameter("@jigyou", SqlDbType.Int);
            p.Value = jigyou;
            pp.Add(p);
            p = new SqlParameter("@tousyo", SqlDbType.Bit);
            p.Value = tousyo;
            pp.Add(p);
            p = new SqlParameter("@g", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            pp.Add(p);
            Util.ExcuteStoredProcedure("予算読出", pp);

            return Util.Str2Int(pp[4].Value.ToString());
        }

        public static string vw_全科目(bool _alter)
        {
            StringBuilder query = new StringBuilder("");

            query.AppendLine("IF OBJECT_ID(N'全科目') IS NULL");
            query.AppendLine("BEGIN");
            query.AppendLine("CREATE VIEW [全科目] AS");
            query.AppendLine("SELECT ID,NAME,順序 FROM 科目 WHERE 使用=1");
            query.AppendLine("END");
            if (_alter)
            {
                query.AppendLine("ELSE");
                query.AppendLine("BEGIN");
                query.AppendLine("ALTER VIEW [全科目] AS");
                query.AppendLine("SELECT ID,NAME,順序 FROM 科目 WHERE 使用=1");
                query.AppendLine("END");
            }
            return query.ToString();
        }

        public static string query_科目一覧(bool _alter)
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine(_alter ? "ALTER " : "CREATE ");
            query.AppendLine("PROCEDURE 科目一覧");
            query.AppendLine("@name nvarchar(64)");
            query.AppendLine("AS BEGIN");
            query.AppendLine("DECLARE @query As NVARCHAR(255)");
            query.AppendLine("SET @query = N'SELECT ID,NAME FROM ' + QUOTENAME(@name) + N'ORDER BY 順序'");
            query.AppendLine("EXECUTE sp_executesql @query");
            query.AppendLine("END");

            return query.ToString();
        }
        public static Dictionary<int, string> 科目一覧(string name)
        {

            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@name", SqlDbType.NVarChar,64);
            p.Value = name;
            pp.Add(p);
            DataSet ds = new DataSet();
            Util.ExcuteStoredProcedure(ref ds, "科目一覧", pp);

            Dictionary<int, string> d = new Dictionary<int, string>();

            if (ds.Tables.Count > 0)
            {
                DataTableReader rd = new DataTableReader(ds.Tables[0]);

                while (rd.Read())
                {
                    d.Add(Util.Str2Int(rd["ID"]), rd["NAME"].ToString());
                }
                rd.Close();
            }

            return d;

        }
/*
        IF OBJECT_ID(N'管理経費科目') IS NOT NULL
DROP VIEW 管理経費科目;
GO
CREATE VIEW 管理経費科目 AS 
SELECT ID,NAME,順序 FROM 科目 WHERE 管理経費=1;
*/

        public static string view_管理経費科目()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'管理経費科目') IS NOT NULL");
            query.AppendLine("DROP VIEW 管理経費科目;");
            query.AppendLine("GO");
            query.AppendLine("CREATE VIEW 管理経費科目 AS ");
            query.AppendLine("SELECT ID,NAME,順序 FROM 科目 WHERE 管理経費=1 and 使用=1");
            return query.ToString();
        }

        /// <summary>
        /// kubunselect用
        /// </summary>
        /// <returns></returns>
        public static string view_管理経費科目2()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'管理経費科目2') IS NOT NULL");
            query.AppendLine("DROP VIEW 管理経費科目2;");
            query.AppendLine("GO");
            query.AppendLine("CREATE VIEW 管理経費科目2 AS ");
            query.AppendLine("SELECT ID,NAME,順序 FROM 科目 WHERE (管理経費=1 and 使用=1) or ID=18");
            return query.ToString();
        }

        public static string view_収入科目表示()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'収入科目表示') IS NOT NULL");
            query.AppendLine("DROP VIEW 収入科目表示;");
            query.AppendLine("GO");
            query.AppendLine("CREATE VIEW 収入科目表示 AS ");
            query.AppendLine("SELECT ID,NAME,順序 FROM 科目 WHERE (収入=1 or ID in (18,84,90,91,92,93) )and (not id in (86,87)) and 使用=1");
            return query.ToString();
        }
        public static string query_本部納付金削除()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("DELETE FROM 科目 WHERE ID=19;");
            return query.ToString();
        }


        public static string query_事業一覧(bool _alter)
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine(_alter ? "ALTER " : "CREATE ");
            query.AppendLine("PROCEDURE 事業一覧");
            query.AppendLine("AS BEGIN");
            query.AppendLine("SELECT ID,NAME,仮払 FROM 事業区分;");
            query.AppendLine("END");

            return query.ToString();
        }
        public static Dictionary<int, string> 事業一覧(int 種別)
        {
            DataSet ds = new DataSet();
            Util.ExcuteStoredProcedure(ref ds, "事業一覧", null);

            Dictionary<int, string> d = new Dictionary<int, string>();

            if (ds.Tables.Count > 0)
            {
                DataTableReader rd = new DataTableReader(ds.Tables[0]);

                while (rd.Read())
                {
                    int id = Util.Str2Int(rd["ID"]);
                    int kari = Util.Str2Int(rd["仮払"]);
                    if (id > 0)
                    {
                        switch (種別)
                        {
                            default:
                                d.Add(id, rd["NAME"].ToString());
                                break;
                            case 1:
                                if (kari == 0) d.Add(id, rd["NAME"].ToString());
                                break;
                            case 2:
                                if (kari == 1) d.Add(id, rd["NAME"].ToString());
                                break;
                        }
                    }
                }
                rd.Close();
            }

            return d;
        }

         public static string query_科目名称(bool _alter)
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine(_alter ? "ALTER " : "CREATE ");
            query.AppendLine("PROCEDURE 科目名称");
            query.AppendLine("@id INTEGER");
            query.AppendLine(",@name nvarchar(64) OUTPUT");
            query.AppendLine("AS BEGIN");
            query.AppendLine("SELECT @name=NAME FROM 科目 WHERE ID=@id;");
            query.AppendLine("END");

            return query.ToString();
        }
        public static string 科目(int id)
        {
            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@id", SqlDbType.Int);
            p.Value = id;
            pp.Add(p);
            p = new SqlParameter("@name", SqlDbType.NVarChar,64);
            p.Direction = ParameterDirection.Output;
            pp.Add(p);
            Util.ExcuteStoredProcedure("科目名称", pp);
            if (pp[1].Value == null)
            {
                return id.ToString();
            }
            else
            {
                return pp[1].Value.ToString();
            }

        }

        public static string query_名称科目(bool _alter)
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine(_alter ? "ALTER " : "CREATE ");
            query.AppendLine("PROCEDURE 名称科目");
            query.AppendLine("@name NVARCHAR(64)");
            query.AppendLine(",@id INTEGER OUTPUT");
            query.AppendLine("AS BEGIN");
            query.AppendLine("SELECT @id=ID FROM 科目 WHERE NAME=@name;");
            query.AppendLine("END");

            return query.ToString();
        }
        public static int 科目コード(string name)
        {
            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@name", SqlDbType.NVarChar,64);
            p.Value = name;
            pp.Add(p);
            p = new SqlParameter("@id", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            pp.Add(p);
            Util.ExcuteStoredProcedure("名称科目", pp);
            if (pp[1].Value == null)
            {
                return -1;
            }
            else
            {
                return Util.Str2Int(pp[1].Value);
            }

        }

        public static string query_経費集計2()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'経費集計2') IS NOT NULL");
            query.AppendLine("DROP PROCEDURE 経費集計2;");
            query.AppendLine("GO");
            query.AppendLine("CREATE PROCEDURE 経費集計2");
            query.AppendLine("@nendo INTEGER");
            query.AppendLine("AS BEGIN");
            query.AppendLine("SELECT 月,事業,科目,SUM(IIF(貸借=0,-合計額,合計額)) AS 合計 FROM 経費内訳 WHERE 年度=@nendo GROUP BY 月,事業,科目 ORDER BY 月,事業,科目;");
            query.AppendLine("END;");

            return query.ToString();

        }

        public static string query_記帳集計()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'記帳集計') IS NOT NULL");
            query.AppendLine("DROP PROCEDURE 記帳集計");
            query.AppendLine("GO");
            query.AppendLine("CREATE PROCEDURE 記帳集計");
            query.AppendLine("@kamoku INTEGER");
            query.AppendLine(",@d_start Date");
            query.AppendLine(",@d_end Date");
            query.AppendLine("AS BEGIN");
            query.AppendLine("SELECT K.事業 as 事業,SUM(K.合計) as 合計額 FROM (");
            query.AppendLine("SELECT 事業,SUM(借方) AS 合計 FROM 記帳 WHERE (年月日 between @d_start AND @d_end) AND 借方科目=@kamoku GROUP BY 事業");
            query.AppendLine("UNION ALL");
            query.AppendLine("SELECT 事業,-SUM(貸方) AS 合計 FROM 記帳 WHERE (年月日 between @d_start AND @d_end) AND 貸方科目=@kamoku GROUP BY 事業");
            query.AppendLine(") AS K GROUP BY K.事業");
            query.AppendLine("END");
            //query.AppendLine("GO");

            return query.ToString();

        }

        public static int 記帳集計(int 科目, DateTime 開始, DateTime 終了)
        {
            Util.SqlExcute(query_記帳集計());

            List<SqlParameter> pp = new List<SqlParameter>();
            pp.Add(sp("@kamoku", SqlDbType.Int, 1, 科目));
            pp.Add(sp("@d_start", SqlDbType.Date, 1, 開始.Date));
            pp.Add(sp("@d_end", SqlDbType.Date, 1, 終了.Date));
            DataSet ds = new DataSet();
            Util.ExcuteStoredProcedure(ref ds, "記帳集計",pp);
            if (ds.Tables.Count > 0)
            {
                DataRow[] dr = ds.Tables[0].Select("事業=1");
                if (dr.Length > 0)
                {
                    int r = Util.Str2Int(dr[0]["合計額"]);
                    return r;
                }
            }

            return 0;
        }

        public static int 仮払金集計(DateTime 開始, DateTime 終了)
        {
            Util.SqlExcute(query_記帳集計());

            List<SqlParameter> pp = new List<SqlParameter>();
            pp.Add(sp("@kamoku", SqlDbType.Int, 1, 18));
            pp.Add(sp("@d_start", SqlDbType.Date, 1, 開始.Date));
            pp.Add(sp("@d_end", SqlDbType.Date, 1, 終了.Date));
            DataSet ds = new DataSet();
            Util.ExcuteStoredProcedure(ref ds, "記帳集計", pp);
            int r = 0;
            if (ds.Tables.Count > 0)
            {
                DataRow[] dr = ds.Tables[0].Select("事業=1");
                if (dr.Length > 0)
                {
                    r += Util.Str2Int(dr[0]["合計額"]);
                }
            }

            foreach (var kamoku in new int[] { 1, 2, 3,4,5,7,8,9,10,11,12,13,14,15,16,17,19 })
            {
                ds = new DataSet();
                pp = new List<SqlParameter>();
                pp.Add(sp("@kamoku", SqlDbType.Int, 1, kamoku));
                pp.Add(sp("@d_start", SqlDbType.Date, 1, 開始.Date));
                pp.Add(sp("@d_end", SqlDbType.Date, 1, 終了.Date));
                Util.ExcuteStoredProcedure(ref ds, "記帳集計", pp);
                if (ds.Tables.Count > 0)
                {
                    DataRow[] dr = ds.Tables[0].Select("事業=5");

                    if (dr.Length > 0)
                    {
                        r += Util.Str2Int(dr[0]["合計額"]);
                    }
                }
            }
            foreach (var kamoku in new int[] { 1, 2, 3, 4, 5, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 19 })
            {
                ds = new DataSet();
                pp = new List<SqlParameter>();
                pp.Add(sp("@kamoku", SqlDbType.Int, 1, kamoku));
                pp.Add(sp("@d_start", SqlDbType.Date, 1, 開始.Date));
                pp.Add(sp("@d_end", SqlDbType.Date, 1, 終了.Date));
                Util.ExcuteStoredProcedure(ref ds, "記帳集計", pp);
                if (ds.Tables.Count > 0)
                {
                    DataRow[] dr = ds.Tables[0].Select("事業=6");

                    if (dr.Length > 0)
                    {
                        r += Util.Str2Int(dr[0]["合計額"]);
                    }
                }
            }
            return r;
        }

        public static string query_経費集計修正()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'経費集計') IS NOT NULL");
            query.AppendLine("DROP PROCEDURE 経費集計;");
            query.AppendLine("GO");
            query.AppendLine("CREATE PROCEDURE 経費集計");
            query.AppendLine("@m_start INTEGER");
            query.AppendLine(",@m_end INTEGER");
            query.AppendLine("AS BEGIN");
            query.AppendLine("SELECT 事業,科目,SUM(IIF(貸借=0,-合計額,合計額)) AS 合計 FROM 経費内訳 WHERE 年月 BETWEEN @m_start AND @m_end GROUP BY 事業,科目;");
            query.AppendLine("END;");

            return query.ToString();
        }

        public static string query_累計内訳変更()
        {
                        StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'累計内訳') IS NOT NULL");
            query.AppendLine("DROP VIEW 累計内訳;");
            query.AppendLine("GO");
            query.AppendLine("CREATE VIEW 累計内訳 AS");
            query.AppendLine("SELECT 年月日");
            query.AppendLine(",年度");
            query.AppendLine(",0 AS 貸借");
            query.AppendLine(",CASE 事業 WHEN 0 THEN 0 WHEN 1 THEN 1 WHEN 5 THEN 3 WHEN 6 THEN 4 ELSE 2 END AS JG");
            query.AppendLine(",借方科目 AS 科目");
            query.AppendLine(",SUM(借方) AS 額");
            query.AppendLine("FROM 記帳");
            query.AppendLine(" GROUP BY 年月日,年度");
            query.AppendLine(",CASE 事業 WHEN 0 THEN 0 WHEN 1 THEN 1 WHEN 5 THEN 3 WHEN 6 THEN 4 ELSE 2 END ,借方科目");
            query.AppendLine("UNION");
            query.AppendLine("SELECT 年月日");
            query.AppendLine(",年度");
            query.AppendLine(",1 AS 貸借");
            query.AppendLine(",CASE 事業 WHEN 0 THEN 0 WHEN 1 THEN 1 WHEN 5 THEN 3 WHEN 6 THEN 4 ELSE 2 END AS JG,貸方科目 AS 科目,SUM(貸方) AS 額");
            query.AppendLine("FROM 記帳");
            query.AppendLine("GROUP BY 年月日,年度");
            query.AppendLine(",CASE 事業 WHEN 0 THEN 0 WHEN 1 THEN 1 WHEN 5 THEN 3 WHEN 6 THEN 4 ELSE 2 END,貸方科目");
            query.AppendLine("GO");

            return query.ToString();
        }
       
        public static string query_支部使用金融機関(bool _alter)
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine(_alter ? "ALTER " : "CREATE ");
            query.AppendLine("PROCEDURE 支部使用金融機関");
            query.AppendLine("@id int");
            query.AppendLine(",@name nvarchar(64)");
            query.AppendLine("AS BEGIN");
            query.AppendLine("UPDATE 科目 SET NAME=@name,使用=1 WHERE ID=@id;");
            query.AppendLine("END");

            return query.ToString();
        }
        public static void 支部使用金融機関(int id, string name)
        {
            List<SqlParameter> pp = new List<SqlParameter>();

            SqlParameter p = new SqlParameter("@id", SqlDbType.Int);
            p.Value = id;
            pp.Add(p);
            p = new SqlParameter("@name", SqlDbType.NVarChar,64);
            p.Value = name;
            pp.Add(p);
            Util.ExcuteStoredProcedure("支部使用金融機関", pp);
        }

        public static string query_新規伝票(bool _alter)
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine(_alter ? "ALTER " : "CREATE ");
            query.AppendLine("PROCEDURE 新規伝票");
            query.AppendLine("@sibu INTEGER");
            query.AppendLine(",@dt DATE");
            query.AppendLine(",@nendo INTEGER");
            query.AppendLine(",@jigyou INTEGER");
            query.AppendLine(",@r1 INTEGER");
            query.AppendLine(",@rk1 INTEGER");
            query.AppendLine(",@ty1 NVARCHAR(128)");
            query.AppendLine(",@k1 INTEGER");
            query.AppendLine(",@kk1 INTEGER");
            query.AppendLine(",@r2 INTEGER");
            query.AppendLine(",@rk2 INTEGER");
            query.AppendLine(",@ty2 NVARCHAR(128)");
            query.AppendLine(",@k2 INTEGER");
            query.AppendLine(",@kk2 INTEGER");
            query.AppendLine("AS BEGIN");
            query.AppendLine("INSERT INTO 振替伝票 (");
            query.AppendLine("支部,年月日,年度,事業");
            query.AppendLine(",借方1,借方科目1,摘要1,貸方1,貸方科目1");
            query.AppendLine(",借方2,借方科目2,摘要2,貸方2,貸方科目2) VALUES (");
            query.AppendLine("@sibu,@dt,@nendo,@jigyou");
            query.AppendLine(",@r1,@rk1,@ty1,@k1,@kk1");
            query.AppendLine(",@r2,@rk2,@ty2,@k2,@kk2");
            query.AppendLine(");");
            query.AppendLine("END");

            return query.ToString();
        }
        public static bool 支払記帳(DateTime dt, int 金額, int 事業cd, int 科目cd, int 支払資産cd, int 諸手数料cd, int 手数料, string 摘要)
        {
            bool rst = false;
            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@sibu", Util.sibucode);
            pp.Add(p);
            p = new SqlParameter("@dt", dt.Date);
            pp.Add(p);
            p = new SqlParameter("@nendo", SqlDbType.Int);
            p.Value = Util.年度;
            pp.Add(p);
            p = new SqlParameter("@jigyou", SqlDbType.Int);
            p.Value = 事業cd;
            pp.Add(p);

            p = new SqlParameter("@r1", SqlDbType.Int);
            p.Value = 金額;
            pp.Add(p);
            p = new SqlParameter("@rk1", SqlDbType.Int);
            p.Value = 科目cd;
            pp.Add(p);
            p = new SqlParameter("@ty1", SqlDbType.NVarChar,64);
            p.Value = 摘要;
            pp.Add(p);
            p = new SqlParameter("@k1", SqlDbType.Int);
            p.Value = 金額;
            pp.Add(p);
            p = new SqlParameter("@kk1", SqlDbType.Int);
            p.Value = 支払資産cd;
            pp.Add(p);


            p = new SqlParameter("@r2", SqlDbType.Int);
            p.Value = 手数料;
            pp.Add(p);
            p = new SqlParameter("@rk2", SqlDbType.Int);
            p.Value = 手数料 != 0 ? 諸手数料cd : 0;//諸手数料
            pp.Add(p);
            p = new SqlParameter("@ty2", SqlDbType.NVarChar,64);
            p.Value = "諸手数料(" + 摘要 + ")";
            pp.Add(p);
            p = new SqlParameter("@k2", SqlDbType.Int);
            p.Value = 手数料;
            pp.Add(p);
            p = new SqlParameter("@kk2", SqlDbType.Int);
            p.Value = 支払資産cd;
            pp.Add(p);

            if (Util.ExcuteStoredProcedure("新規伝票", pp))
            {
                rst = true;
            }
            return rst;
        }


        public static bool 入金記帳(DateTime dt, int 金額, int 事業cd, int 科目cd, int 収入cd, int 諸手数料cd, int 手数料, string 摘要)
        {
            bool rst = false;

            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@sibu", Util.sibucode);
            pp.Add(p);
            p = new SqlParameter("@dt", dt.Date);
            pp.Add(p);
            p = new SqlParameter("@nendo", SqlDbType.Int);
            p.Value = Util.年度;
            pp.Add(p);
            p = new SqlParameter("@jigyou", SqlDbType.Int);
            p.Value = 事業cd;
            pp.Add(p);

            p = new SqlParameter("@r1", SqlDbType.Int);
            p.Value = 金額;
            pp.Add(p);
            p = new SqlParameter("@rk1", SqlDbType.Int);
            p.Value = 科目cd;
            pp.Add(p);
            p = new SqlParameter("@ty1", SqlDbType.NVarChar,64);
            p.Value = 摘要;
            pp.Add(p);
            p = new SqlParameter("@k1", SqlDbType.Int);
            p.Value = 金額;
            pp.Add(p);
            p = new SqlParameter("@kk1", SqlDbType.Int);
            p.Value = 収入cd;
            pp.Add(p);


            p = new SqlParameter("@r2", SqlDbType.Int);
            p.Value = 手数料;
            pp.Add(p);
            p = new SqlParameter("@rk2", SqlDbType.Int);
            p.Value = 諸手数料cd;
            pp.Add(p);
            p = new SqlParameter("@ty2", SqlDbType.NVarChar,64);
            p.Value = 手数料 != 0 ? "(諸手数料：" + 摘要 + ")" : "";
            pp.Add(p);
            p = new SqlParameter("@k2", SqlDbType.Int);
            p.Value = 手数料;
            pp.Add(p);
            p = new SqlParameter("@kk2", SqlDbType.Int);
            p.Value = 科目cd;
            pp.Add(p);
            if (Util.ExcuteStoredProcedure("新規伝票", pp))
            {
                rst = true;
            }

            return rst;
        }

        public static bool 返金記帳(DateTime dt, int 金額, int 事業cd, int 科目cd, int 収入cd, int 諸手数料cd, int 手数料, string 摘要)
        {
            bool rst = false;

            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@sibu", Util.sibucode);
            pp.Add(p);
            p = new SqlParameter("@dt", dt.Date);
            pp.Add(p);
            p = new SqlParameter("@nendo", SqlDbType.Int);
            p.Value = Util.年度;
            pp.Add(p);
            p = new SqlParameter("@jigyou", SqlDbType.Int);
            p.Value = 事業cd;
            pp.Add(p);

            p = new SqlParameter("@r1", SqlDbType.Int);
            p.Value = 金額;
            pp.Add(p);
            p = new SqlParameter("@rk1", SqlDbType.Int);
            p.Value = 収入cd;
            pp.Add(p);
            p = new SqlParameter("@ty1", SqlDbType.NVarChar,64);
            p.Value = 摘要;
            pp.Add(p);
            p = new SqlParameter("@k1", SqlDbType.Int);
            p.Value = 金額;
            pp.Add(p);
            p = new SqlParameter("@kk1", SqlDbType.Int);
            p.Value = 科目cd;
            pp.Add(p);


            p = new SqlParameter("@r2", SqlDbType.Int);
            p.Value = 手数料;
            pp.Add(p);
            p = new SqlParameter("@rk2", SqlDbType.Int);
            p.Value = 手数料 != 0 ? 諸手数料cd : 0;//諸手数料
            pp.Add(p);
            p = new SqlParameter("@ty2", SqlDbType.NVarChar);
            p.Value = 手数料 != 0 ? "(諸手数料：" + 摘要 + ")" : "";
            pp.Add(p);
            p = new SqlParameter("@k2", SqlDbType.Int);
            p.Value = 手数料;
            pp.Add(p);
            p = new SqlParameter("@kk2", SqlDbType.Int);
            p.Value = 科目cd;
            pp.Add(p);
            if (Util.ExcuteStoredProcedure("新規伝票", pp))
            {
                rst = true;
            }

            return rst;
        }


        //public static bool 預り金送付記帳

#if false
        public static string query_繰越読出(bool _alter)
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine(_alter ? "ALTER " : "CREATE ");
            query.AppendLine("PROCEDURE 繰越読出");
            query.AppendLine("@id INTEGER");
            query.AppendLine(",@nendo INTEGER");
            query.AppendLine(",@g INTEGER OUTPUT");
            query.AppendLine("AS BEGIN");
            query.AppendLine("SELECT @g=G FROM 繰越額 WHERE ID=@id AND 年度=@nendo;");
            query.AppendLine("END");

            return query.ToString();
        }
#endif
        public static int 前期繰越額(int id)
        {

            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@id", SqlDbType.Int);
            p.Value = id;
            pp.Add(p);
            p = new SqlParameter("@nendo", SqlDbType.Int);
            p.Value = Util.年度;
            pp.Add(p);
            p = new SqlParameter("@g", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            pp.Add(p);
            Util.ExcuteStoredProcedure("繰越読出", pp);

            if (id == 86)
            {
                return -Util.Str2Int(pp[2].Value.ToString());
            }
            else
            {
                return Util.Str2Int(pp[2].Value.ToString());
            }
        }

        public static int 前期繰越額(int id, int nendo)
        {


            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@id", SqlDbType.Int);
            p.Value = id;
            pp.Add(p);
            p = new SqlParameter("@nendo", SqlDbType.Int);
            p.Value = nendo;
            pp.Add(p);
            p = new SqlParameter("@g", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            pp.Add(p);
            Util.ExcuteStoredProcedure("繰越読出", pp);


            return Util.Str2Int(pp[2].Value.ToString());
        }



        public static string query_伝票削除()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'伝票削除') IS NOT NULL");
            query.AppendLine("DROP PROCEDURE 伝票削除");
            query.AppendLine("GO");

            query.AppendLine("CREATE PROCEDURE 伝票削除");
            query.AppendLine("@id INTEGER");
            query.AppendLine("AS BEGIN");

            query.AppendLine("DELETE FROM 送金記録 where ID in (SELECT SK.ID FROM 送金記録 SK inner join 振替伝票 FD ON SK.年月日=FD.年月日");
            query.AppendLine("where FD.ID=@id AND FD.借方科目1 in (90,91,92,93,100,101,102,103) AND SK.科目=FD.借方科目1);");

            query.AppendLine("UPDATE 振替伝票 SET 削除 = 1, 更新=GETDATE()  WHERE ID=@id");
            query.AppendLine("END");

            return query.ToString();
        }
        public static void 伝票削除(int id)
        {
            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@id", SqlDbType.Int);
            p.Value = id;
            pp.Add(p);
            Util.ExcuteStoredProcedure("伝票削除", pp);
        }

        public static string query_伝票読出(bool _alter)
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine(_alter ? "ALTER " : "CREATE ");
            query.AppendLine("PROCEDURE 伝票読出");
            query.AppendLine("@id INTEGER");
            query.AppendLine("AS BEGIN");
            query.AppendLine("SELECT * FROM 振替伝票 WHERE ID=@id;");
            query.AppendLine("END");

            return query.ToString();
        }
        public static DataSet 伝票読出(int id)
        {
            DataSet ds = new DataSet();
            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@id", SqlDbType.Int);
            p.Value = id;
            pp.Add(p);
            Util.ExcuteStoredProcedure(ref ds, "伝票読出", pp);
            return ds;
        }

#if false
        IF OBJECT_ID('IDNUM') IS NOT NULL
DROP TABLE IDNUM;
GO
CREATE TABLE IDNUM (ID int primary key,ID2 int);
INSERT INTO IDNUM (ID,ID2) VALUES
 (1,0)--個人
,(2,80000)--法人
,(3,40000)--送付グループ
,(4,60000)--請求グループ
;
GO
#endif

        public static string query_メール()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID('MAIL') IS NULL");
            query.AppendLine("BEGIN");
            query.AppendLine("CREATE TABLE MAIL (");
            query.AppendLine("SMTP nvarchar(80)");
            query.AppendLine(",PORT INT");
            query.AppendLine(",USESSL bit default 0");
            query.AppendLine(",USERID nvarchar(80)");
            query.AppendLine(",USERPASS nvarchar(80)");
            query.AppendLine(",HONBU nvarchar(80)");
            query.AppendLine(",CC nvarchar(128)");
            query.AppendLine(",TANTOU nvarchar(128)");
            query.AppendLine(");");
            query.AppendLine("INSERT INTO MAIL (SMTP,PORT,USESSL,USERID,USERPASS,HONBU,CC,TANTOU) VALUES (");
            query.AppendLine("N'smtp.ck.em-net.ne.jp',587,0");

            query.AppendLine(",N'sysmail03-ck',N'h7cnb5pe'");//ユーザーID,PASS
            query.AppendLine(",N'rma-s2@aqua.ocn.ne.jp'");//本部
            query.AppendLine(",N'',N''");//支部長,担当者
            query.AppendLine(");");
            query.AppendLine("END");

            return query.ToString();
        }
/*
IF OBJECT_ID(N'全科目') IS NOT NULL
DROP VIEW 全科目;
GO
CREATE VIEW 全科目 AS 
SELECT ID,NAME,順序 FROM 科目 WHERE 使用=1;

GO
*/

        public static string query_経費外科目()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'経費外科目') IS NOT NULL");
            query.AppendLine("DROP VIEW 経費外科目;");
            query.AppendLine("GO");
            query.AppendLine("CREATE VIEW 経費外科目");
            query.AppendLine("AS SELECT ID,NAME,順序 FROM 科目 WHERE 使用=1 AND 管理経費=0 AND 事業経費=0;");
            query.AppendLine("GO");
            query.AppendLine("DELETE FROM 事業区分 WHERE ID=0;");
            query.AppendLine("GO");

            return query.ToString();
        }

        public static string sql_未収金未払金()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("UPDATE 科目 set 使用=0 WHERE NAME=N'未収金' OR NAME=N'未払金'");
            query.AppendLine("GO");

            return query.ToString();
        }

        public static string CREATE_NENSYO()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'年初') IS NULL");
            query.AppendLine("CREATE TABLE 年初 (年度 int,N1 int,N2 int,N3 int,N4 int,N5 int);");
            query.AppendLine("GO");
            return query.ToString();
        }
        public static string proc_年初読出()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'年初読出') IS NOT NULL");
            query.AppendLine("DROP PROCEDURE 年初読出");
            query.AppendLine("GO");
            query.AppendLine("CREATE PROCEDURE 年初読出");
            query.AppendLine("@nendo int");
            query.AppendLine(",@n1 int output");
            query.AppendLine(",@n2 int output");
            query.AppendLine(",@n3 int output");
            query.AppendLine(",@n4 int output");
            query.AppendLine(",@n5 int output");

            query.AppendLine("AS BEGIN");
            query.AppendLine("SET @n1=0;");
            query.AppendLine("SET @n2=0;");
            query.AppendLine("SET @n3=0;");
            query.AppendLine("SET @n4=0;");
            query.AppendLine("SET @n5=0;");
            query.AppendLine("SELECT @n1=N1,@n2=N2,@n3=N3,@n4=N4,@n5=N5 FROM 年初 WHERE 年度=@nendo; ");
            query.AppendLine("END");

            return query.ToString();
        }

        public static void 年初読出(ref int N1, ref int N2, ref int N3, ref int N4, ref int N5)
        {
            Util.SqlExcute(CREATE_NENSYO());
            Util.SqlExcute(proc_年初読出());
            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@nendo", SqlDbType.Int);
            p.Value = Util.年度;
            pp.Add(p);
            p = new SqlParameter("@n1", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            pp.Add(p);
            p = new SqlParameter("@n2", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            pp.Add(p);
            p = new SqlParameter("@n3", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            pp.Add(p);
            p = new SqlParameter("@n4", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            pp.Add(p);
            p = new SqlParameter("@n5", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            pp.Add(p);

            Util.ExcuteStoredProcedure("年初読出", pp);

            N1 = Util.Str2Int(pp[1].Value);
            N2 = Util.Str2Int(pp[2].Value);
            N3 = Util.Str2Int(pp[3].Value);
            N4 = Util.Str2Int(pp[4].Value);
            N5 = Util.Str2Int(pp[5].Value);
        }

        public static string proc_年初書込()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'年初書込') IS NOT NULL");
            query.AppendLine("DROP PROCEDURE 年初書込");
            query.AppendLine("GO");
            query.AppendLine("CREATE PROCEDURE 年初書込");
            query.AppendLine("@nendo int");
            query.AppendLine(",@n1 int");
            query.AppendLine(",@n2 int");
            query.AppendLine(",@n3 int");
            query.AppendLine(",@n4 int");
            query.AppendLine(",@n5 int");

            query.AppendLine("AS BEGIN");
            query.AppendLine("DECLARE  @n  int;");
            query.AppendLine("SET @n=0;");
            query.AppendLine("SELECT @n=count(*) FROM 年初 WHERE 年度=@nendo; ");
            query.AppendLine("IF @n=1");
            query.AppendLine("  UPDATE 年初 SET N1=@n1,N2=@n2,N3=@n3,N4=@n4,N5=@n5 WHERE 年度=@nendo;");
            query.AppendLine("ELSE");
            query.AppendLine("  INSERT INTO 年初 (年度,N1,N2,N3,N4,N5) VALUES (@nendo,@n1,@n2,@n3,@n4,@n5);");
            query.AppendLine("");
            query.AppendLine("END");
            query.AppendLine("GO");

            return query.ToString();
        }

        public static void 年初書込(int N1, int N2, int N3, int N4, int N5)
        {
            Util.SqlExcute(CREATE_NENSYO());
            Util.SqlExcute(proc_年初書込());
            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@nendo", SqlDbType.Int);
            p.Value = Util.年度;
            pp.Add(p);
            p = new SqlParameter("@n1", SqlDbType.Int);
            p.Value = N1;
            pp.Add(p);
            p = new SqlParameter("@n2", SqlDbType.Int);
            p.Value = N2;
            pp.Add(p);
            p = new SqlParameter("@n3", SqlDbType.Int);
            p.Value = N3;
            pp.Add(p);
            p = new SqlParameter("@n4", SqlDbType.Int);
            p.Value = N4;
            pp.Add(p);
            p = new SqlParameter("@n5", SqlDbType.Int);
            p.Value = N5;
            pp.Add(p);

            Util.ExcuteStoredProcedure("年初書込", pp);
        }

        public static string CREATE_TYUUKAN()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'中間') IS NULL");
            query.AppendLine("CREATE TABLE 中間 (年度 int,N1 int,N2 int,N3 int,N4 int,N5 int);");
            query.AppendLine("GO");
            return query.ToString();
        }


        public static string proc_中間読出()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'中間読出') IS NOT NULL");
            query.AppendLine("DROP PROCEDURE 中間読出");
            query.AppendLine("GO");
            query.AppendLine("CREATE PROCEDURE 中間読出");
            query.AppendLine("@nendo int");
            query.AppendLine(",@n1 float output");
            query.AppendLine(",@n2 float output");
            query.AppendLine(",@n3 float output");
            query.AppendLine(",@n4 float output");
            query.AppendLine(",@n5 float output");

            query.AppendLine("AS BEGIN");
            query.AppendLine("SET @n1=0;");
            query.AppendLine("SET @n2=0;");
            query.AppendLine("SET @n3=0;");
            query.AppendLine("SET @n4=0;");
            query.AppendLine("SET @n5=0;");
            query.AppendLine("SELECT @n1=N1,@n2=N2,@n3=N3,@n4=N4,@n5=N5 FROM 中間 WHERE 年度=@nendo; ");
            query.AppendLine("END");

            return query.ToString();
        }

        public static void 中間読出(ref float N1, ref float N2, ref float N3, ref float N4, ref float N5)
        {
            Util.SqlExcute(CREATE_TYUUKAN());
            Util.SqlExcute(proc_中間読出());
            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@nendo", SqlDbType.Int);
            p.Value = Util.年度;
            pp.Add(p);
            p = new SqlParameter("@n1", SqlDbType.Float);
            p.Direction = ParameterDirection.Output;
            pp.Add(p);
            p = new SqlParameter("@n2", SqlDbType.Float);
            p.Direction = ParameterDirection.Output;
            pp.Add(p);
            p = new SqlParameter("@n3", SqlDbType.Float);
            p.Direction = ParameterDirection.Output;
            pp.Add(p);
            p = new SqlParameter("@n4", SqlDbType.Float);
            p.Direction = ParameterDirection.Output;
            pp.Add(p);
            p = new SqlParameter("@n5", SqlDbType.Float);
            p.Direction = ParameterDirection.Output;
            pp.Add(p);

            Util.ExcuteStoredProcedure("中間読出", pp);

            N1 = Util.Str2Int(pp[1].Value);
            N2 = Util.Str2Int(pp[2].Value);
            N3 = Util.Str2Int(pp[3].Value);
            N4 = Util.Str2Int(pp[4].Value);
            N5 = Util.Str2Int(pp[5].Value);
        }

        public static void 中間読出(int nendo, ref float N1, ref float N2, ref float N3, ref float N4, ref float N5)
        {
            Util.SqlExcute(CREATE_TYUUKAN());
            Util.SqlExcute(proc_中間読出());
            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@nendo", SqlDbType.Int);
            p.Value = nendo;
            pp.Add(p);
            p = new SqlParameter("@n1", SqlDbType.Float);
            p.Direction = ParameterDirection.Output;
            pp.Add(p);
            p = new SqlParameter("@n2", SqlDbType.Float);
            p.Direction = ParameterDirection.Output;
            pp.Add(p);
            p = new SqlParameter("@n3", SqlDbType.Float);
            p.Direction = ParameterDirection.Output;
            pp.Add(p);
            p = new SqlParameter("@n4", SqlDbType.Float);
            p.Direction = ParameterDirection.Output;
            pp.Add(p);
            p = new SqlParameter("@n5", SqlDbType.Float);
            p.Direction = ParameterDirection.Output;
            pp.Add(p);

            Util.ExcuteStoredProcedure("中間読出", pp);

            N1 = Util.Str2Int(pp[1].Value);
            N2 = Util.Str2Int(pp[2].Value);
            N3 = Util.Str2Int(pp[3].Value);
            N4 = Util.Str2Int(pp[4].Value);
            N5 = Util.Str2Int(pp[5].Value);
        }

        public static string proc_中間書込()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'中間書込') IS NOT NULL");
            query.AppendLine("DROP PROCEDURE 中間書込");
            query.AppendLine("GO");
            query.AppendLine("CREATE PROCEDURE 中間書込");
            query.AppendLine("@nendo int");
            query.AppendLine(",@n1 float");
            query.AppendLine(",@n2 float");
            query.AppendLine(",@n3 float");
            query.AppendLine(",@n4 float");
            query.AppendLine(",@n5 float");

            query.AppendLine("AS BEGIN");
            query.AppendLine("DECLARE  @n  int;");
            query.AppendLine("SET @n=0;");
            query.AppendLine("SELECT @n=count(*) FROM 中間 WHERE 年度=@nendo; ");
            query.AppendLine("IF @n=1");
            query.AppendLine("  UPDATE 中間 SET N1=@n1,N2=@n2,N3=@n3,N4=@n4,N5=@n5 WHERE 年度=@nendo;");
            query.AppendLine("ELSE");
            query.AppendLine("  INSERT INTO 中間 (年度,N1,N2,N3,N4,N5) VALUES (@nendo,@n1,@n2,@n3,@n4,@n5);");
            query.AppendLine("");
            query.AppendLine("END");
            query.AppendLine("GO");

            return query.ToString();
        }

        public static void 中間書込(float N1, float N2, float N3, float N4, float N5)
        {
            Util.SqlExcute(CREATE_TYUUKAN());
            Util.SqlExcute(proc_中間書込());
            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@nendo", SqlDbType.Int);
            p.Value = Util.年度;
            pp.Add(p);
            p = new SqlParameter("@n1", SqlDbType.Float);
            p.Value = N1;
            pp.Add(p);
            p = new SqlParameter("@n2", SqlDbType.Float);
            p.Value = N2;
            pp.Add(p);
            p = new SqlParameter("@n3", SqlDbType.Float);
            p.Value = N3;
            pp.Add(p);
            p = new SqlParameter("@n4", SqlDbType.Float);
            p.Value = N4;
            pp.Add(p);
            p = new SqlParameter("@n5", SqlDbType.Float);
            p.Value = N5;
            pp.Add(p);

            Util.ExcuteStoredProcedure("中間書込", pp);
        }


        public static string query_交付金名称変更()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("UPDATE 科目 SET NAME=N'交付金（個人会費）' WHERE ID=70;");
            query.AppendLine("UPDATE 科目 SET NAME=N'交付金（団体会費）' WHERE ID=71;");
            query.AppendLine("UPDATE 科目 SET NAME=N'交付金（個人入会）' WHERE ID=72;");
            query.AppendLine("UPDATE 科目 SET NAME=N'交付金（団体入会）' WHERE ID=73;");
            query.AppendLine("GO");
            return query.ToString();
        }

        public static string query_技術認定事業追加()
        {
            StringBuilder query = new StringBuilder("");
#if true
            query.AppendLine("IF OBJECT_ID(N'事業一覧') IS NOT NULL");
            query.AppendLine("DROP procedure 事業一覧");
            query.AppendLine("GO");
#endif
            query.AppendLine("IF OBJECT_ID(N'事業区分') IS NOT NULL");
            query.AppendLine("DROP TABLE 事業区分;");
            query.AppendLine("GO");
            query.AppendLine("CREATE TABLE 事業区分 (ID int primary key,NAME nvarchar(64),順序 int,仮払 int);");
            query.AppendLine("GO");
            query.AppendLine("INSERT INTO 事業区分 (ID,NAME,順序,仮払) VALUES");
            query.AppendLine("(1,N'管理費',1,0)");
            query.AppendLine(",(2,N'研究・講習会',2,0)");
            query.AppendLine(",(3,N'教育知識普及',3,0)");
            query.AppendLine(",(4,N'刊行物発行',4,0)");
            query.AppendLine(",(5,N'(仮払)技術認定車両',5,1)");
            query.AppendLine(",(6,N'(仮払)技術認定機械',6,1)");
            query.AppendLine(";");
            query.AppendLine("GO");
#if true
            query.AppendLine("CREATE PROCEDURE 事業一覧");
            query.AppendLine("AS BEGIN");
            query.AppendLine("SELECT ID,NAME,仮払 FROM 事業区分;");
            query.AppendLine("END");
#endif


            return query.ToString();
        }

        public static string query_科目集計()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'科目集計') IS NOT NULL");
            query.AppendLine("DROP PROCEDURE 科目集計");
            query.AppendLine("GO");
            query.AppendLine("CREATE PROCEDURE 科目集計");
            query.AppendLine("@cd int");
            query.AppendLine(",@n1 int");
            query.AppendLine(",@n2 int");
            query.AppendLine(",@taisyaku int");
            query.AppendLine(",@total int output");
            query.AppendLine("AS BEGIN");
            query.AppendLine("SELECT @total=sum(合計額) from 経費内訳 where 科目=@cd and 貸借=@taisyaku and 年月 between @n1 and @n2 ");
            query.AppendLine("END");
            query.AppendLine("GO");
            return query.ToString();
        }

        public static string proc_経費集計2()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'経費集計2') IS NOT NULL");
            query.AppendLine("DROP PROCEDURE 経費集計2");
            query.AppendLine("GO");
            query.AppendLine("CREATE PROCEDURE 経費集計2");
            query.AppendLine("@m_start int");
            query.AppendLine(",@m_end int");
            query.AppendLine("AS BEGIN");
            query.AppendLine("SELECT 事業,科目,SUM(IIF(貸借=0,合計額,-合計額)) AS 合計 FROM 経費内訳 WHERE 年月 BETWEEN @m_start AND @m_end GROUP BY 事業,科目");
            query.AppendLine("END");
            query.AppendLine("GO");
            return query.ToString();
        }


        public static string func_収入科目集計()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'収入科目集計') IS NOT NULL");
            query.AppendLine("DROP FUNCTION 収入科目集計");
            query.AppendLine("GO");
            query.AppendLine("CREATE FUNCTION 収入科目集計");
            query.AppendLine("(@m_start int");
            query.AppendLine(",@m_end int)");
            query.AppendLine("RETURNS TABLE");
            query.AppendLine("AS RETURN (");
            query.AppendLine("SELECT 科目,SUM(IIF(貸借=0,合計額,-合計額)) AS 合計 FROM 経費内訳 WHERE 年月 BETWEEN @m_start AND @m_end GROUP BY 科目");
            query.AppendLine(")");
            query.AppendLine("GO");
            return query.ToString();
        }

        public static string query_技術認定集計()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'技術認定集計') IS NOT NULL");
            query.AppendLine("DROP PROCEDURE 技術認定集計");
            query.AppendLine("GO");
            query.AppendLine("CREATE PROCEDURE 技術認定集計");
            query.AppendLine("@n1 int");
            query.AppendLine(",@n2 int");
            query.AppendLine(",@taisyaku int");
            query.AppendLine(",@total int output");
            query.AppendLine("AS BEGIN");
            query.AppendLine("SELECT @total=sum(合計額) from 経費内訳 where 事業 in (5,6) and 科目<20 and 貸借=@taisyaku and 年月 between @n1 and @n2 ");
            query.AppendLine("END");
            query.AppendLine("GO");
            return query.ToString();
        }


        public static string sql_預り金削除()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("DELETE FROM 科目 where NAME=N'預り金' or NAME=N'預かり金';");
            return query.ToString();
        }

        public static string sql_作業委託費修正()
        {
            // ,(83,N'作業委託費',0,0,1,0,0,813,82,0,0,0,0,1,1,0)
            
            StringBuilder query = new StringBuilder("");
            query.AppendLine("if not exists (select * from 科目 with (updlock,serializable) where NAME=N'雑収入(作業委託費)')");
            query.AppendLine("begin");
            query.AppendLine("INSERT INTO 科目 (ID,NAME,資産,現金,収入,管理経費,事業経費,PCA,順序,会費収入,入会金収入,刊行物収入,その他収入,雑収入,使用,金融種別) VALUES ");
            query.AppendLine("(83,N'雑収入(作業委託費)',0,0,1,0,0,813,82,0,0,0,0,1,1,0);");
            query.AppendLine("end");
            return query.ToString();
        }



        public static string sql_預り金追加()
        {
            //,(84,N'預かり金',0,0,1,0,0,813,83,0,0,0,0,1,1,0)

            StringBuilder query = new StringBuilder("");
            query.AppendLine("if not exists (select * from 科目 with (updlock,serializable) where NAME=N'預り金'or NAME=N'預かり金')");
            query.AppendLine("begin");
            query.AppendLine("INSERT INTO 科目 (ID,NAME,資産,現金,収入,管理経費,事業経費,PCA,順序,会費収入,入会金収入,刊行物収入,その他収入,雑収入,使用,金融種別) VALUES ");
            query.AppendLine("(84,N'預り金',0,0,1,0,0,813,83,0,0,0,0,1,1,0);");
            query.AppendLine("end");
            return query.ToString();
        }

        public static string sql_会費預り金追加()
        {
            //,(84,N'預かり金',0,0,1,0,0,813,83,0,0,0,0,1,1,0)

            StringBuilder query = new StringBuilder("");
            query.AppendLine("if not exists (select * from 科目 with (updlock,serializable) where NAME=N'預かり金(個人会費)')");
            query.AppendLine("begin");
            query.AppendLine("INSERT INTO 科目 (ID,NAME,資産,現金,収入,管理経費,事業経費,PCA,順序,会費収入,入会金収入,刊行物収入,その他収入,雑収入,使用,金融種別) VALUES ");
            query.AppendLine("(90,N'預かり金(個人会費)',0,0,0,0,0,813,83,0,0,0,0,1,1,0);");
            query.AppendLine("INSERT INTO 科目 (ID,NAME,資産,現金,収入,管理経費,事業経費,PCA,順序,会費収入,入会金収入,刊行物収入,その他収入,雑収入,使用,金融種別) VALUES ");
            query.AppendLine("(91,N'預かり金(団体会費)',0,0,0,0,0,813,83,0,0,0,0,1,1,0);");
            query.AppendLine("INSERT INTO 科目 (ID,NAME,資産,現金,収入,管理経費,事業経費,PCA,順序,会費収入,入会金収入,刊行物収入,その他収入,雑収入,使用,金融種別) VALUES ");
            query.AppendLine("(92,N'預かり金(個人入会金)',0,0,0,0,0,813,83,0,0,0,0,1,1,0);");
            query.AppendLine("INSERT INTO 科目 (ID,NAME,資産,現金,収入,管理経費,事業経費,PCA,順序,会費収入,入会金収入,刊行物収入,その他収入,雑収入,使用,金融種別) VALUES ");
            query.AppendLine("(93,N'預かり金(団体入会金)',0,0,0,0,0,813,83,0,0,0,0,1,1,0);");
            query.AppendLine("end");
            return query.ToString();
        }

        public static string sql_繰越差額()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'繰越差額') IS NULL");
            query.AppendLine("CREATE TABLE 繰越差額 (ID INT, 年度 INT, NAME NVARCHAR(64), G INTEGER);");
            return query.ToString();
        }

        public static string sql_会費預り金負債設定()
        {
            //,(84,N'預かり金',0,0,1,0,0,813,83,0,0,0,0,1,1,0)

            StringBuilder query = new StringBuilder("");
            query.AppendLine("update 科目 set 収入=0,雑収入=0 where ID in (84,90,91,92,93)");
            return query.ToString();
        }
        public static string sql_管理費一部追加()
        {
            //,(84,N'預かり金',0,0,1,0,0,813,83,0,0,0,0,1,1,0)

            StringBuilder query = new StringBuilder("");
            query.AppendLine("if not exists (select * from 科目 where ID=7)");
            query.AppendLine("begin");
            query.AppendLine("INSERT INTO 科目 (ID,NAME,資産,現金,収入,管理経費,事業経費,PCA,順序,会費収入,入会金収入,刊行物収入,その他収入,雑収入,使用,金融種別) VALUES ");
            query.AppendLine("(7,N'図書費',0,0,0,1,1,737,83,0,0,0,0,1,1,0);");
            query.AppendLine("end");
            query.AppendLine("GO");
            query.AppendLine("if not exists (select * from 科目 where ID=8)");
            query.AppendLine("begin");
            query.AppendLine("INSERT INTO 科目 (ID,NAME,資産,現金,収入,管理経費,事業経費,PCA,順序,会費収入,入会金収入,刊行物収入,その他収入,雑収入,使用,金融種別) VALUES ");
            query.AppendLine("(8,N'消耗品費',0,0,0,1,1,754,83,0,0,0,0,1,1,0);");
            query.AppendLine("end");
            query.AppendLine("GO");
            query.AppendLine("if not exists (select * from 科目 where ID=9)");
            query.AppendLine("begin");
            query.AppendLine("INSERT INTO 科目 (ID,NAME,資産,現金,収入,管理経費,事業経費,PCA,順序,会費収入,入会金収入,刊行物収入,その他収入,雑収入,使用,金融種別) VALUES ");
            query.AppendLine("(9,N'印刷費',0,0,0,1,1,751,83,0,0,0,0,1,1,0);");
            query.AppendLine("end");
            query.AppendLine("GO");
            return query.ToString();
        }

        public static string view_預り金科目()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'預り金科目') IS NOT NULL");
            query.AppendLine("DROP VIEW 預り金科目;");
            query.AppendLine("GO");
            query.AppendLine("CREATE VIEW 預り金科目");
            query.AppendLine("AS SELECT ID,NAME,順序 FROM 科目 WHERE ID in (90,91,92,93);");
            query.AppendLine("GO");

            return query.ToString();
        }

        public static string sql_預り金送付科目追加()
        {
            //,(94,N'預かり金送付(個人会費)',0,0,0,0,0,813,70,1,0,0,0,0,1,0)
            //,(95,N'預かり金送付(団体会費)',0,0,0,0,0,813,71,1,0,0,0,0,1,0)
            //,(96,N'預かり金送付(個人入会)',0,0,0,0,0,813,72,0,1,0,0,0,1,0)
            //,(97,N'預かり金送付(団体入会)',0,0,0,0,0,813,73,0,1,0,0,0,1,0)

            StringBuilder query = new StringBuilder("");
            query.AppendLine("if not exists (select * from 科目 where ID=94)");
            query.AppendLine("begin");
            query.AppendLine("INSERT INTO 科目 (ID,NAME,資産,現金,収入,管理経費,事業経費,PCA,順序,会費収入,入会金収入,刊行物収入,その他収入,雑収入,使用,金融種別) VALUES ");
            query.AppendLine("(94,N'預かり金送付(個人会費)',0,0,0,0,0,813,94,1,0,0,0,0,1,0);");
            query.AppendLine("end");
            query.AppendLine("GO");
            query.AppendLine("if not exists (select * from 科目 where ID=95)");
            query.AppendLine("begin");
            query.AppendLine("INSERT INTO 科目 (ID,NAME,資産,現金,収入,管理経費,事業経費,PCA,順序,会費収入,入会金収入,刊行物収入,その他収入,雑収入,使用,金融種別) VALUES ");
            query.AppendLine("(95,N'預かり金送付(団体会費)',0,0,0,0,0,813,95,1,0,0,0,0,1,0);");
            query.AppendLine("end");
            query.AppendLine("GO");
            query.AppendLine("if not exists (select * from 科目 where ID=96)");
            query.AppendLine("begin");
            query.AppendLine("INSERT INTO 科目 (ID,NAME,資産,現金,収入,管理経費,事業経費,PCA,順序,会費収入,入会金収入,刊行物収入,その他収入,雑収入,使用,金融種別) VALUES ");
            query.AppendLine("(96,N'預かり金送付(個人入会)',0,0,0,0,0,813,96,0,1,0,0,0,1,0);");
            query.AppendLine("end");
            query.AppendLine("GO");
            query.AppendLine("if not exists (select * from 科目 where ID=97)");
            query.AppendLine("begin");
            query.AppendLine("INSERT INTO 科目 (ID,NAME,資産,現金,収入,管理経費,事業経費,PCA,順序,会費収入,入会金収入,刊行物収入,その他収入,雑収入,使用,金融種別) VALUES ");
            query.AppendLine("(97,N'預かり金送付(団体入会)',0,0,0,0,0,813,97,0,1,0,0,0,1,0);");
            query.AppendLine("end");
            query.AppendLine("GO");
            query.AppendLine("update 科目 set 会費収入=0,入会金収入=0 where ID in (94,95,96,97);");
            query.AppendLine("GO");

            query.AppendLine("if not exists (select * from 科目 where ID=100)");
            query.AppendLine("begin");
            query.AppendLine("INSERT INTO 科目 (ID,NAME,資産,現金,収入,管理経費,事業経費,PCA,順序,会費収入,入会金収入,刊行物収入,その他収入,雑収入,使用,金融種別) VALUES ");
            query.AppendLine("(100,N'繰越預かり金(個人会費)',0,0,0,0,0,813,100,1,0,0,0,0,1,0);");
            query.AppendLine("end");
            query.AppendLine("GO");
            query.AppendLine("if not exists (select * from 科目 where ID=101)");
            query.AppendLine("begin");
            query.AppendLine("INSERT INTO 科目 (ID,NAME,資産,現金,収入,管理経費,事業経費,PCA,順序,会費収入,入会金収入,刊行物収入,その他収入,雑収入,使用,金融種別) VALUES ");
            query.AppendLine("(101,N'繰越預かり金(団体会費)',0,0,0,0,0,813,101,1,0,0,0,0,1,0);");
            query.AppendLine("end");
            query.AppendLine("GO");
            query.AppendLine("if not exists (select * from 科目 where ID=102)");
            query.AppendLine("begin");
            query.AppendLine("INSERT INTO 科目 (ID,NAME,資産,現金,収入,管理経費,事業経費,PCA,順序,会費収入,入会金収入,刊行物収入,その他収入,雑収入,使用,金融種別) VALUES ");
            query.AppendLine("(102,N'繰越預かり金(個人入会)',0,0,0,0,0,813,102,0,1,0,0,0,1,0);");
            query.AppendLine("end");
            query.AppendLine("GO");
            query.AppendLine("if not exists (select * from 科目 where ID=103)");
            query.AppendLine("begin");
            query.AppendLine("INSERT INTO 科目 (ID,NAME,資産,現金,収入,管理経費,事業経費,PCA,順序,会費収入,入会金収入,刊行物収入,その他収入,雑収入,使用,金融種別) VALUES ");
            query.AppendLine("(103,N'繰越預かり金(団体入会)',0,0,0,0,0,813,103,0,1,0,0,0,1,0);");
            query.AppendLine("end");
            query.AppendLine("if not exists (select * from 科目 where ID=104)");
            query.AppendLine("begin");
            query.AppendLine("INSERT INTO 科目 (ID,NAME,資産,現金,収入,管理経費,事業経費,PCA,順序,会費収入,入会金収入,刊行物収入,その他収入,雑収入,使用,金融種別) VALUES ");
            query.AppendLine("(104,N'繰越預かり金(その他)',0,0,0,0,0,813,104,0,1,0,0,0,1,0);");
            query.AppendLine("end");
            query.AppendLine("GO");

            return query.ToString();
        }

        public static string sql_繰越金科目追加()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("if not exists (select * from 科目 where ID=190)");
            query.AppendLine("begin");
            query.AppendLine("INSERT INTO 科目 (ID,NAME,資産,現金,収入,管理経費,事業経費,順序,会費収入,入会金収入,刊行物収入,その他収入,雑収入,使用,金融種別) VALUES ");
            query.AppendLine("(190,N'前期預かり金',1,0,0,0,0,94,0,0,0,0,0,1,0);");
            query.AppendLine("end");
            query.AppendLine("GO");
            query.AppendLine("if not exists (select * from 科目 where ID=191)");
            query.AppendLine("begin");
            query.AppendLine("INSERT INTO 科目 (ID,NAME,資産,現金,収入,管理経費,事業経費,順序,会費収入,入会金収入,刊行物収入,その他収入,雑収入,使用,金融種別) VALUES ");
            query.AppendLine("(191,N'前期仮受金',1,0,0,0,0,95,0,0,0,0,0,1,0);");
            query.AppendLine("end");
            query.AppendLine("GO");
            query.AppendLine("if not exists (select * from 科目 where ID=192)");
            query.AppendLine("begin");
            query.AppendLine("INSERT INTO 科目 (ID,NAME,資産,現金,収入,管理経費,事業経費,順序,会費収入,入会金収入,刊行物収入,その他収入,雑収入,使用,金融種別) VALUES ");
            query.AppendLine("(192,N'前期仮払金',1,0,0,0,0,96,0,0,0,0,0,1,0);");
            query.AppendLine("end");
            query.AppendLine("GO");
            return query.ToString();
        }

        public static string sql_記帳2()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'記帳2') IS NOT NULL");
            query.AppendLine("DROP VIEW 記帳2;");
            query.AppendLine("GO");
            query.AppendLine("CREATE VIEW 記帳2 AS SELECT * FROM");
            query.AppendLine("(");
            query.AppendLine("SELECT 	ID,1 AS SUBID,支部,年月日,年度,事業,借方1 AS 借方,借方科目1 AS 借方科目,摘要1 AS 摘要,貸方1 AS 貸方,貸方科目1 AS 貸方科目 FROM 振替伝票 WHERE 削除=0");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,2 AS SUBID,支部,年月日,年度,事業,借方2 AS 借方,借方科目2 AS 借方科目,摘要2 AS 摘要,貸方2 AS 貸方,貸方科目2 AS 貸方科目 FROM 振替伝票 WHERE 削除=0");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,3 AS SUBID,支部,年月日,年度,事業,借方3 AS 借方,借方科目3 AS 借方科目,摘要3 AS 摘要,貸方3 AS 貸方,貸方科目3 AS 貸方科目 FROM 振替伝票 WHERE 削除=0");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,4 AS SUBID,支部,年月日,年度,事業,借方4 AS 借方,借方科目4 AS 借方科目,摘要4 AS 摘要,貸方4 AS 貸方,貸方科目4 AS 貸方科目 FROM 振替伝票 WHERE 削除=0");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,5 AS SUBID,支部,年月日,年度,事業,借方5 AS 借方,借方科目5 AS 借方科目,摘要5 AS 摘要,貸方5 AS 貸方,貸方科目5 AS 貸方科目 FROM 振替伝票 WHERE 削除=0");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,6 AS SUBID,支部,年月日,年度,事業,借方6 AS 借方,借方科目6 AS 借方科目,摘要6 AS 摘要,貸方6 AS 貸方,貸方科目6 AS 貸方科目 FROM 振替伝票 WHERE 削除=0");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,7 AS SUBID,支部,年月日,年度,事業,借方7 AS 借方,借方科目7 AS 借方科目,摘要7 AS 摘要,貸方7 AS 貸方,貸方科目7 AS 貸方科目 FROM 振替伝票 WHERE 削除=0");
            query.AppendLine(") AS T WHERE (T.借方科目>0 OR T.貸方科目>0)");

            return query.ToString();
        }

#if false
IF OBJECT_ID(N'記帳一覧') IS NOT NULL
DROP PROCEDURE 記帳一覧;
GO

CREATE PROCEDURE 記帳一覧
	@date1 DATE
	,@date2 DATE
AS
BEGIN
	SELECT * FROM 記帳 WHERE 年月日 BETWEEN @date1 AND @date2 ORDER BY 年月日,ID,SUBID;
END
#endif
        public static string proc_記帳一覧()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'記帳一覧') IS NOT NULL");
            query.AppendLine("DROP PROCEDURE 記帳一覧;");
            query.AppendLine("GO");
            query.AppendLine("CREATE PROCEDURE 記帳一覧");
            query.AppendLine("	@date1 DATE");
            query.AppendLine("	,@date2 DATE");
            query.AppendLine("AS");
            query.AppendLine("BEGIN");
            query.AppendLine("	SELECT * FROM 記帳2 WHERE 年月日 BETWEEN @date1 AND @date2 ORDER BY 年月日,ID,SUBID;");
            query.AppendLine("END");
            return query.ToString();
        }
        /// <summary>
        /// 預かり金は負債であるため、金額を負にして集計する必要がある。
        /// 預かり金が貸方で借方が現金であれば、現金は符号をマイナスにして集計
        /// </summary>
        /// <returns></returns>
 #if false
            public static string sql_負債考慮記帳()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'記帳') IS NOT NULL");
            query.AppendLine("DROP VIEW 記帳;");
            query.AppendLine("GO");
            query.AppendLine("CREATE VIEW 記帳 AS SELECT * FROM");
            query.AppendLine("(");
            query.AppendLine("SELECT 	ID,1 AS SUBID,支部,年月日,年度,事業,借方1 AS 借方,借方科目1 AS 借方科目,摘要1 AS 摘要,貸方1 AS 貸方,貸方科目1 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND not (借方科目1 in (84,90,91,92,93,100,101,102,103) or 貸方科目1 in (84,90,91,92,93,100,101,102,103))");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,2 AS SUBID,支部,年月日,年度,事業,借方2 AS 借方,借方科目2 AS 借方科目,摘要2 AS 摘要,貸方2 AS 貸方,貸方科目2 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND not (借方科目2 in (84,90,91,92,93,100,101,102,103) or 貸方科目2 in (84,90,91,92,93,100,101,102,103))");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,3 AS SUBID,支部,年月日,年度,事業,借方3 AS 借方,借方科目3 AS 借方科目,摘要3 AS 摘要,貸方3 AS 貸方,貸方科目3 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND not (借方科目3 in (84,90,91,92,93,100,101,102,103) or 貸方科目3 in (84,90,91,92,93,100,101,102,103))");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,4 AS SUBID,支部,年月日,年度,事業,借方4 AS 借方,借方科目4 AS 借方科目,摘要4 AS 摘要,貸方4 AS 貸方,貸方科目4 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND not (借方科目4 in (84,90,91,92,93,100,101,102,103) or 貸方科目4 in (84,90,91,92,93,100,101,102,103))");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,5 AS SUBID,支部,年月日,年度,事業,借方5 AS 借方,借方科目5 AS 借方科目,摘要5 AS 摘要,貸方5 AS 貸方,貸方科目5 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND not (借方科目5 in (84,90,91,92,93,100,101,102,103) or 貸方科目5 in (84,90,91,92,93,100,101,102,103))");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,6 AS SUBID,支部,年月日,年度,事業,借方6 AS 借方,借方科目6 AS 借方科目,摘要6 AS 摘要,貸方6 AS 貸方,貸方科目6 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND not (借方科目6 in (84,90,91,92,93,100,101,102,103) or 貸方科目6 in (84,90,91,92,93,100,101,102,103))");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,7 AS SUBID,支部,年月日,年度,事業,借方7 AS 借方,借方科目7 AS 借方科目,摘要7 AS 摘要,貸方7 AS 貸方,貸方科目7 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND not (借方科目7 in (84,90,91,92,93,100,101,102,103) or 貸方科目7 in (84,90,91,92,93,100,101,102,103))");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,1 AS SUBID,支部,年月日,年度,事業,貸方1 AS 借方,貸方科目1 AS 借方科目,摘要1 AS 摘要,借方1 AS 貸方,借方科目1 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND (借方科目1 in (84,90,91,92,93,100,101,102,103) or 貸方科目1 in (84,90,91,92,93,100,101,102,103))");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,2 AS SUBID,支部,年月日,年度,事業,貸方2 AS 借方,貸方科目2 AS 借方科目,摘要2 AS 摘要,借方2 AS 貸方,借方科目2 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND (借方科目2 in (84,90,91,92,93,100,101,102,103) or 貸方科目2 in (84,90,91,92,93,100,101,102,103))");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,3 AS SUBID,支部,年月日,年度,事業,貸方3 AS 借方,貸方科目3 AS 借方科目,摘要3 AS 摘要,借方3 AS 貸方,借方科目3 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND (借方科目3 in (84,90,91,92,93,100,101,102,103) or 貸方科目3 in (84,90,91,92,93,100,101,102,103))");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,4 AS SUBID,支部,年月日,年度,事業,貸方4 AS 借方,貸方科目4 AS 借方科目,摘要4 AS 摘要,借方4 AS 貸方,借方科目4 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND (借方科目4 in (84,90,91,92,93,100,101,102,103) or 貸方科目4 in (84,90,91,92,93,100,101,102,103))");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,5 AS SUBID,支部,年月日,年度,事業,貸方5 AS 借方,貸方科目5 AS 借方科目,摘要5 AS 摘要,借方5 AS 貸方,借方科目5 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND (借方科目5 in (84,90,91,92,93,100,101,102,103) or 貸方科目5 in (84,90,91,92,93,100,101,102,103))");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,6 AS SUBID,支部,年月日,年度,事業,貸方6 AS 借方,貸方科目6 AS 借方科目,摘要6 AS 摘要,借方6 AS 貸方,借方科目6 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND (借方科目6 in (84,90,91,92,93,100,101,102,103) or 貸方科目6 in (84,90,91,92,93,100,101,102,103))");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,7 AS SUBID,支部,年月日,年度,事業,貸方7 AS 借方,貸方科目7 AS 借方科目,摘要7 AS 摘要,借方7 AS 貸方,借方科目7 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND (借方科目7 in (84,90,91,92,93,100,101,102,103) or 貸方科目7 in (84,90,91,92,93,100,101,102,103))");
            query.AppendLine(") AS T WHERE (T.借方科目>0 OR T.貸方科目>0)");

            return query.ToString();
        }

#else
        public static string sql_負債考慮記帳()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'記帳') IS NOT NULL");
            query.AppendLine("DROP VIEW 記帳;");
            query.AppendLine("GO");
            query.AppendLine("CREATE VIEW 記帳 AS SELECT * FROM");
            query.AppendLine("(");
            query.AppendLine("SELECT 	ID,1 AS SUBID,支部,年月日,年度,事業,借方1 AS 借方,借方科目1 AS 借方科目,摘要1 AS 摘要,貸方1 AS 貸方,貸方科目1 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND not (借方科目1 in (84,90,91,92,93) or 貸方科目1 in (84,90,91,92,93))");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,2 AS SUBID,支部,年月日,年度,事業,借方2 AS 借方,借方科目2 AS 借方科目,摘要2 AS 摘要,貸方2 AS 貸方,貸方科目2 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND not (借方科目2 in (84,90,91,92,93) or 貸方科目2 in (84,90,91,92,93))");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,3 AS SUBID,支部,年月日,年度,事業,借方3 AS 借方,借方科目3 AS 借方科目,摘要3 AS 摘要,貸方3 AS 貸方,貸方科目3 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND not (借方科目3 in (84,90,91,92,93) or 貸方科目3 in (84,90,91,92,93))");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,4 AS SUBID,支部,年月日,年度,事業,借方4 AS 借方,借方科目4 AS 借方科目,摘要4 AS 摘要,貸方4 AS 貸方,貸方科目4 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND not (借方科目4 in (84,90,91,92,93) or 貸方科目4 in (84,90,91,92,93))");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,5 AS SUBID,支部,年月日,年度,事業,借方5 AS 借方,借方科目5 AS 借方科目,摘要5 AS 摘要,貸方5 AS 貸方,貸方科目5 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND not (借方科目5 in (84,90,91,92,93) or 貸方科目5 in (84,90,91,92,93))");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,6 AS SUBID,支部,年月日,年度,事業,借方6 AS 借方,借方科目6 AS 借方科目,摘要6 AS 摘要,貸方6 AS 貸方,貸方科目6 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND not (借方科目6 in (84,90,91,92,93) or 貸方科目6 in (84,90,91,92,93))");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,7 AS SUBID,支部,年月日,年度,事業,借方7 AS 借方,借方科目7 AS 借方科目,摘要7 AS 摘要,貸方7 AS 貸方,貸方科目7 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND not (借方科目7 in (84,90,91,92,93) or 貸方科目7 in (84,90,91,92,93))");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,1 AS SUBID,支部,年月日,年度,事業,貸方1 AS 借方,貸方科目1 AS 借方科目,摘要1 AS 摘要,借方1 AS 貸方,借方科目1 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND (借方科目1 in (84,90,91,92,93) or 貸方科目1 in (84,90,91,92,93))");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,2 AS SUBID,支部,年月日,年度,事業,貸方2 AS 借方,貸方科目2 AS 借方科目,摘要2 AS 摘要,借方2 AS 貸方,借方科目2 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND (借方科目2 in (84,90,91,92,93) or 貸方科目2 in (84,90,91,92,93))");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,3 AS SUBID,支部,年月日,年度,事業,貸方3 AS 借方,貸方科目3 AS 借方科目,摘要3 AS 摘要,借方3 AS 貸方,借方科目3 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND (借方科目3 in (84,90,91,92,93) or 貸方科目3 in (84,90,91,92,93))");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,4 AS SUBID,支部,年月日,年度,事業,貸方4 AS 借方,貸方科目4 AS 借方科目,摘要4 AS 摘要,借方4 AS 貸方,借方科目4 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND (借方科目4 in (84,90,91,92,93) or 貸方科目4 in (84,90,91,92,93))");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,5 AS SUBID,支部,年月日,年度,事業,貸方5 AS 借方,貸方科目5 AS 借方科目,摘要5 AS 摘要,借方5 AS 貸方,借方科目5 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND (借方科目5 in (84,90,91,92,93) or 貸方科目5 in (84,90,91,92,93))");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,6 AS SUBID,支部,年月日,年度,事業,貸方6 AS 借方,貸方科目6 AS 借方科目,摘要6 AS 摘要,借方6 AS 貸方,借方科目6 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND (借方科目6 in (84,90,91,92,93) or 貸方科目6 in (84,90,91,92,93))");
            query.AppendLine("union");
            query.AppendLine("SELECT 	ID,7 AS SUBID,支部,年月日,年度,事業,貸方7 AS 借方,貸方科目7 AS 借方科目,摘要7 AS 摘要,借方7 AS 貸方,借方科目7 AS 貸方科目 FROM 振替伝票 WHERE 削除=0 AND (借方科目7 in (84,90,91,92,93) or 貸方科目7 in (84,90,91,92,93))");
            query.AppendLine(") AS T WHERE (T.借方科目>0 OR T.貸方科目>0)");

            return query.ToString();
        }
#endif

        public static string sql_仮払金_経費区分変更()
        {
            //旧　　,(18,N'仮払金',0,0,0,1,0,791,17,0,0,0,0,0,1,0)
            //新　　,(18,N'仮払金',1,0,0,0,0,791,17,0,0,0,0,0,1,0)

            StringBuilder query = new StringBuilder("");
            query.AppendLine("UPDATE 科目 set 資産=0,現金=0,収入=0,管理経費=0,事業経費=0 WHERE ID=18;");
            query.AppendLine("UPDATE 科目 set 資産=0,現金=0,収入=0,管理経費=0,事業経費=0,雑収入=0 WHERE ID=86;");
            //query.AppendLine("DELETE FROM 科目 WHERE ID=83;");
            return query.ToString();
        }


        public static int 科目集計(int 科目, int 開始年月, int 終了年月, int 貸借)
        {
            Util.SqlExcute(query_科目集計());
            List<SqlParameter> pp = new List<SqlParameter>();
            pp.Add(sp("@cd", SqlDbType.Int, 1, 科目));
            pp.Add(sp("@n1", SqlDbType.Int, 1, 開始年月));
            pp.Add(sp("@n2", SqlDbType.Int, 1, 終了年月));
            pp.Add(sp("@taisyaku", SqlDbType.Int, 1, 貸借));
            pp.Add(sout("@total", SqlDbType.Int));

            Util.ExcuteStoredProcedure("科目集計", pp);


            return Util.Str2Int(pp[4].Value);
        }

        public static int 技術認定集計(int 開始年月, int 終了年月, int 貸借)
        {
            Util.SqlExcute(query_技術認定集計());
            List<SqlParameter> pp = new List<SqlParameter>();
            pp.Add(sp("@n1", SqlDbType.Int, 1, 開始年月));
            pp.Add(sp("@n2", SqlDbType.Int, 1, 終了年月));
            pp.Add(sp("@taisyaku", SqlDbType.Int, 1, 貸借));
            pp.Add(sout("@total", SqlDbType.Int));

            Util.ExcuteStoredProcedure("技術認定集計", pp);


            return Util.Str2Int(pp[pp.Count-1].Value);
        }

        public static void AlterAllStored()
        {
            Util.SqlExcute(query_login_check(true));
            Util.SqlExcute(query_ChangePasswd(true));
            Util.SqlExcute(query_AddUser(true));
            Util.SqlExcute(query_DeleteUser(true));
            Util.SqlExcute(query_繰越設定(true));
            Util.SqlExcute(query_予算設定(true));
            Util.SqlExcute(query_予算読出(true));
            Util.SqlExcute(query_科目一覧(true));
            Util.SqlExcute(query_事業一覧(true));
            Util.SqlExcute(query_科目名称(true));
            Util.SqlExcute(query_名称科目(true));
            Util.SqlExcute(query_支部使用金融機関(true));
            Util.SqlExcute(query_新規伝票(true));
            Util.SqlExcute(query_繰越読出(true));
            Util.SqlExcute(query_伝票読出(true));
            Util.SqlExcute(query_経費外科目());
            Util.SqlExcute(query_科目集計());

        }


#if false
            query.AppendLine("PROCEDURE 新規伝票");
            query.AppendLine("@sibu INTEGER");
            query.AppendLine(",@dt DATE");
            query.AppendLine(",@nendo INTEGER");
            query.AppendLine(",@jigyou INTEGER");
            query.AppendLine(",@r1 INTEGER");
            query.AppendLine(",@rk1 INTEGER");
            query.AppendLine(",@ty1 NVARCHAR(128)");
            query.AppendLine(",@k1 INTEGER");
            query.AppendLine(",@kk1 INTEGER");
            query.AppendLine(",@r2 INTEGER");
            query.AppendLine(",@rk2 INTEGER");
            query.AppendLine(",@ty2 NVARCHAR(128)");
            query.AppendLine(",@k2 INTEGER");
            query.AppendLine(",@kk2 INTEGER");
#endif

        public static bool 送金記帳(DateTime dt, int 金額90, int 金額91, int 金額92, int 金額93, int 支払資産cd, int 手数料, string 摘要, bool 未払金)
        {
            bool rst = true;
            List<SqlParameter> pp = new List<SqlParameter>();

            if (rst && 金額90 > 0)
            {
                pp = new List<SqlParameter>();
                pp.Add(sp("@sibu",SqlDbType.Int,1,Util.sibucode));
                pp.Add(sp("@dt", SqlDbType.Date, 1, dt));
                pp.Add(sp("@nendo", SqlDbType.Int, 1, Util.年度));
                pp.Add(sp("@jigyou", SqlDbType.Int, 1, 1));

                pp.Add(sp("@r1", SqlDbType.Int, 1, 金額90));
                pp.Add(sp("@rk1", SqlDbType.Int, 1, 未払金 ? 100: 90));
                pp.Add(sp("@ty1", SqlDbType.NVarChar, 255, 摘要));
                pp.Add(sp("@k1", SqlDbType.Int, 1, 金額90));
                pp.Add(sp("@kk1", SqlDbType.Int, 1, 支払資産cd));

                pp.Add(sp("@r2", SqlDbType.Int, 1, 0));
                pp.Add(sp("@rk2", SqlDbType.Int, 1, 0));
                pp.Add(sp("@ty2", SqlDbType.Int, 1, 0));
                pp.Add(sp("@k2", SqlDbType.Int, 1, 0));
                pp.Add(sp("@kk2", SqlDbType.Int, 1, 0));
                rst=Util.ExcuteStoredProcedure("新規伝票", pp);
            }
            if (rst && 金額91 > 0)
            {
                pp = new List<SqlParameter>();
                pp.Add(sp("@sibu", SqlDbType.Int, 1, Util.sibucode));
                pp.Add(sp("@dt", SqlDbType.Date, 1, dt));
                pp.Add(sp("@nendo", SqlDbType.Int, 1, Util.年度));
                pp.Add(sp("@jigyou", SqlDbType.Int, 1, 1));

                pp.Add(sp("@r1", SqlDbType.Int, 1, 金額91));
                pp.Add(sp("@rk1", SqlDbType.Int, 1, 未払金 ? 101 : 91));
                pp.Add(sp("@ty1", SqlDbType.NVarChar, 255, 摘要));
                pp.Add(sp("@k1", SqlDbType.Int, 1, 金額91));
                pp.Add(sp("@kk1", SqlDbType.Int, 1, 支払資産cd));

                pp.Add(sp("@r2", SqlDbType.Int, 1, 0));
                pp.Add(sp("@rk2", SqlDbType.Int, 1, 0));
                pp.Add(sp("@ty2", SqlDbType.Int, 1, 0));
                pp.Add(sp("@k2", SqlDbType.Int, 1, 0));
                pp.Add(sp("@kk2", SqlDbType.Int, 1, 0));
                rst = Util.ExcuteStoredProcedure("新規伝票", pp);
            }
            if (rst && 金額92 > 0)
            {
                pp = new List<SqlParameter>();
                pp.Add(sp("@sibu", SqlDbType.Int, 1, Util.sibucode));
                pp.Add(sp("@dt", SqlDbType.Date, 1, dt));
                pp.Add(sp("@nendo", SqlDbType.Int, 1, Util.年度));
                pp.Add(sp("@jigyou", SqlDbType.Int, 1, 1));

                pp.Add(sp("@r1", SqlDbType.Int, 1, 金額92));
                pp.Add(sp("@rk1", SqlDbType.Int, 1, 未払金 ? 102 : 92));
                pp.Add(sp("@ty1", SqlDbType.NVarChar, 255, 摘要));
                pp.Add(sp("@k1", SqlDbType.Int, 1, 金額92));
                pp.Add(sp("@kk1", SqlDbType.Int, 1, 支払資産cd));

                pp.Add(sp("@r2", SqlDbType.Int, 1, 0));
                pp.Add(sp("@rk2", SqlDbType.Int, 1, 0));
                pp.Add(sp("@ty2", SqlDbType.Int, 1, 0));
                pp.Add(sp("@k2", SqlDbType.Int, 1, 0));
                pp.Add(sp("@kk2", SqlDbType.Int, 1, 0));
                rst = Util.ExcuteStoredProcedure("新規伝票", pp);
            }
            if (rst && 金額93 > 0)
            {
                pp = new List<SqlParameter>();
                pp.Add(sp("@sibu", SqlDbType.Int, 1, Util.sibucode));
                pp.Add(sp("@dt", SqlDbType.Date, 1, dt));
                pp.Add(sp("@nendo", SqlDbType.Int, 1, Util.年度));
                pp.Add(sp("@jigyou", SqlDbType.Int, 1, 1));

                pp.Add(sp("@r1", SqlDbType.Int, 1, 金額93));
                pp.Add(sp("@rk1", SqlDbType.Int, 1, 未払金 ? 103 : 93));
                pp.Add(sp("@ty1", SqlDbType.NVarChar, 255, 摘要));
                pp.Add(sp("@k1", SqlDbType.Int, 1, 金額93));
                pp.Add(sp("@kk1", SqlDbType.Int, 1, 支払資産cd));

                pp.Add(sp("@r2", SqlDbType.Int, 1, 0));
                pp.Add(sp("@rk2", SqlDbType.Int, 1, 0));
                pp.Add(sp("@ty2", SqlDbType.Int, 1, 0));
                pp.Add(sp("@k2", SqlDbType.Int, 1, 0));
                pp.Add(sp("@kk2", SqlDbType.Int, 1, 0));
                rst = Util.ExcuteStoredProcedure("新規伝票", pp);
            }

            if (rst && 手数料 > 0)
            {
                pp = new List<SqlParameter>();
                pp.Add(sp("@sibu", SqlDbType.Int, 1, Util.sibucode));
                pp.Add(sp("@dt", SqlDbType.Date, 1, dt));
                pp.Add(sp("@nendo", SqlDbType.Int, 1, Util.年度));
                pp.Add(sp("@jigyou", SqlDbType.Int, 1, 1));

                pp.Add(sp("@r1", SqlDbType.Int, 1, 手数料));
                pp.Add(sp("@rk1", SqlDbType.Int, 1, 12));//諸手数料　科目
                pp.Add(sp("@ty1", SqlDbType.NVarChar, 255, 摘要));
                pp.Add(sp("@k1", SqlDbType.Int, 1, 手数料));
                pp.Add(sp("@kk1", SqlDbType.Int, 1, 支払資産cd));

                pp.Add(sp("@r2", SqlDbType.Int, 1, 0));
                pp.Add(sp("@rk2", SqlDbType.Int, 1, 0));
                pp.Add(sp("@ty2", SqlDbType.Int, 1, 0));
                pp.Add(sp("@k2", SqlDbType.Int, 1, 0));
                pp.Add(sp("@kk2", SqlDbType.Int, 1, 0));
                rst = Util.ExcuteStoredProcedure("新規伝票", pp);
            }

            return rst;
        }


        public static string createtable_送金記録()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'送金記録') IS NULL");
            query.AppendLine("CREATE TABLE 送金記録 (ID int IDENTITY(1,1) primary key,年度 int, 科目 int, 金額 int, 年月日 date, 適要 nvarchar(255),登録日 date);");
            query.AppendLine("GO");
            return query.ToString();
        }
        public static string proc_送金()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'送金') IS NOT NULL");
            query.AppendLine("DROP PROCEDURE 送金");
            query.AppendLine("GO");
            query.AppendLine("CREATE PROCEDURE 送金");
            query.AppendLine("@kamoku int");
            query.AppendLine(",@kingaku int");
            query.AppendLine(",@hiduke date");
            query.AppendLine(",@memo nvarchar(255)");
            query.AppendLine("AS BEGIN");
            query.AppendLine("DECLARE @n int;");
            query.AppendLine("DECLARE @id int;");
            query.AppendLine("SET @id=0;");
            query.AppendLine("SET @n=0;");
            query.AppendLine("select @id=ID,@n=1 from 送金記録 where 年月日=@hiduke AND 科目=@kamoku");
            query.AppendLine("IF @n = 0");
            query.AppendLine("INSERT INTO 送金記録 (年度,科目,金額,年月日,適要,登録日)");
            query.AppendLine("VALUES (YEAR(DATEADD(month,-3,@hiduke)),@kamoku,@kingaku,@hiduke,@memo,GETDATE());");
            query.AppendLine("IF @id > 0 and @n>0");
            query.AppendLine("UPDATE 送金記録 set 金額=@kingaku,適要=@memo,登録日=GETDATE() where ID=@id;");
            query.AppendLine("END;");
            return query.ToString();
        }

        public static bool 送金(int 科目, int 金額, DateTime 年月日, string 摘要)
        {
            List<SqlParameter> pp = new List<SqlParameter>();
            SqlParameter p = new SqlParameter("@kamoku", SqlDbType.Int);
            p.Value = 科目;
            pp.Add(p);
            p = new SqlParameter("@kingaku", SqlDbType.Int);
            p.Value = 金額;
            pp.Add(p);
            p = new SqlParameter("@hiduke", SqlDbType.Date);
            p.Value = 年月日.Date;
            pp.Add(p);
            p = new SqlParameter("@memo", SqlDbType.NVarChar,255);
            p.Value = 摘要;
            pp.Add(p);

            Util.ExcuteStoredProcedure("送金", pp);
            return true;
        }

        public static string proc_送金集計()
        {
            StringBuilder query = new StringBuilder("");
            query.AppendLine("IF OBJECT_ID(N'送金集計') IS NOT NULL");
            query.AppendLine("DROP PROCEDURE 送金集計");
            query.AppendLine("GO");
            query.AppendLine("CREATE PROCEDURE 送金集計");
            query.AppendLine("@kamoku int");
            query.AppendLine(",@fromhiduke date");
            query.AppendLine(",@tohiduke date");
            query.AppendLine(",@total int output");
            query.AppendLine("AS");
            query.AppendLine("SELECT @total=sum(金額) FROM 送金記録 WHERE 科目=@kamoku AND (年月日 between @fromhiduke AND @tohiduke);");
            return query.ToString();
        }

        public static int 送金集計(int 科目,DateTime 開始, DateTime 終了)
        {
            List<SqlParameter> pp = new List<SqlParameter>();
            pp.Add(sp("@kamoku", SqlDbType.Int, 1, 科目));
            pp.Add(sp("@fromhiduke", SqlDbType.Date, 1, 開始));
            pp.Add(sp("@tohiduke", SqlDbType.Date, 1, 終了));
            pp.Add(sout("@total", SqlDbType.Int));

            Util.ExcuteStoredProcedure("送金集計", pp);
            return Util.Str2Int(pp[3].Value);
        }

        public static string proc_残高累計()
        {
            StringBuilder query = new StringBuilder("");

            query.AppendLine("IF OBJECT_ID(N'残高累計') IS NOT NULL");
            query.AppendLine("DROP PROCEDURE 残高累計;");
            query.AppendLine("GO");
            query.AppendLine("CREATE PROCEDURE 残高累計");
            query.AppendLine("@date1 DATE");
            query.AppendLine(",@date2 DATE");
            query.AppendLine("AS BEGIN");
            query.AppendLine("  SELECT 科目,貸借,SUM(金額) AS 総計 FROM 単票 WHERE  年月日 BETWEEN @date1 AND @date2 GROUP BY 科目,貸借;");
            query.AppendLine("END");
            query.AppendLine("GO");

            return query.ToString();
        }


    }
}
