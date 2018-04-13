using System;
using System.Configuration;
using System.Data;
//using System.Data.SqlClient;
using System.Data.SQLite;

namespace KeyboardPress_Analyzer.Helper
{
    public static class DBHelper
    {
        private static int userId = 0;
        private static string connStr;

        private static string ConnStr
        {
            get
            {
                //                if (String.IsNullOrWhiteSpace(connStr))
                //                {
                //                    string customLocation = ConfigurationManager.AppSettings["CustomDbFileLocation"];
                //                    connStr = $@"
                //Data Source=(LocalDB)\MSSQLLocalDB;
                //AttachDbFilename={(String.IsNullOrEmpty(customLocation) ? AppDomain.CurrentDomain.BaseDirectory : customLocation)}kpData.mdf;
                //Integrated Security=True";
                //                }
                //                return connStr;

                if (String.IsNullOrWhiteSpace(connStr))
                {
                    string customLocation = ConfigurationManager.AppSettings["CustomDbFileLocation"];
                    connStr = $@"Data Source={customLocation}; Version=3;";
                }
                return connStr;
            }
        }
        public static int UserId
        {
            get
            {
                if(userId == 0)
                {
                    userId = (int)SelectTopRow<Int64>("SELECT record_id FROM KP_USER LIMIT 1");
                }
                if(userId == 0)
                {
                    if (ExecSqlDb($"INSERT INTO KP_USER (name) VALUES ('{Guid.NewGuid()}')", true) != "OK")
                        throw new Exception("Klaida duomenų bazėje, nepavyksta sukurti vartotojo");
                    userId = (int)SelectTopRow<Int64>("SELECT record_id FROM KP_USER LIMIT 1");

                    if (userId == 0)
                        throw new Exception("Klaida. Nepavyksta gauti vartotojo");
                }
                
                return userId;
            }
        }

        //private static SqlConnection GetConnection()
        //{
        //    var conn = new SqlConnection(ConnStr);
        //    return conn;
        //}

        private static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnStr);
        }

        public static bool TestConnection()
        {
            try
            {
                using(var conn = GetConnection())
                {
                    conn.Open();

                    if(conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                        return true;
                    }
                    else
                    {
                        conn.Close();
                        return false;
                    }
                }
            }
            catch(Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
                return false;
            }
        }

        public static DataSet GetDataSetDb(string sql)
        {
            try
            {
                var ds = new DataSet();
                using (var conn = GetConnection())
                {
                    conn.Open();

                    //var sda = new SqlDataAdapter(sql, conn);
                    var sda = new SQLiteDataAdapter(sql, conn);
                    sda.Fill(ds);

                    conn.Close();
                }
                return ds;
            }
            catch(Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
                throw new Exception("Klaida naudojantis duomenų baze: " + ex.Message.ToString());
            }
        }

        public static DataTable GetDataTableDb(string sql)
        {
            try
            {
                var dt = new DataTable();
                using (var conn = GetConnection())
                {
                    conn.Open();

                    //var sda = new SqlDataAdapter(sql, conn);
                    var sda = new SQLiteDataAdapter(sql, conn);
                    sda.Fill(dt);

                    conn.Close();
                }
                return dt;
            }
            catch(Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
                throw new Exception("Klaida naudojantis duomenų baze: " + ex.Message.ToString());
            }
        }

        public static string ExecSqlDb(string sql, bool silentMode)
        {
            string result = "OK";
            try
            {
                using(var conn = GetConnection())
                {
                    conn.Open();
                    //SqlCommand comand = new SqlCommand(sql, conn);
                    var comand = new SQLiteCommand(sql, conn);
                    comand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                LogHelper.LogErrorMsg(ex);
                if (silentMode)
                    result = "Klaida naudojantis duomenų baze: " + ex.Message.ToString();
                else
                    throw new Exception("Klaida naudojantis duomenų baze: " + ex.Message.ToString());
            }

            return result;
        }

        public static T SelectTopRow<T>(string sql)
        {
            var dt = GetDataTableDb(sql);
            
            if (dt == null || dt.Rows.Count == 0)
                return default(T);

            return (T)dt.Rows[0][0];
        }
    }
}
