using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShop.Data.DAO
{
    class DataProvider
    {
        private DataProvider() { }

        private static DataProvider instance;
        public static DataProvider Instance()
        {
            if (instance == null)
            {
                instance = new DataProvider();
            }
            return instance;
        }

        string connString = ConfigurationManager.ConnectionStrings["PracticeShopDbContex"].ToString();
        public DataTable executeQuery(string strQuery, string[] strParametter = null, object[] ojParametter = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand sqlCommand = new SqlCommand(strQuery, conn))
                {
                    if (strParametter != null && ojParametter != null)
                    {
                        int i = 0;
                        foreach (string strPara in strParametter)
                        {
                            sqlCommand.Parameters.AddWithValue(strPara, ojParametter[i]);
                            i += 1;
                        }
                    }
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(dt);
                }
                conn.Close();
            }
            return dt;
        }

        public int executeNonQuery(string strQuery, string[] strParametter = null, object[] ojParametter = null)
        {
            int re = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand sqlCommand = new SqlCommand(strQuery, conn))
                {
                    if (strParametter != null && ojParametter != null)
                    {
                        int i = 0;
                        foreach (string strPara in strParametter)
                        {
                            sqlCommand.Parameters.AddWithValue(strPara, ojParametter[i]);
                            i += 1;
                        }
                    }
                    re = sqlCommand.ExecuteNonQuery();
                }
                conn.Close();
            }
            return re;
        }

        public object executeScalar(string strQuery, string[] strParametter = null, object[] ojParametter = null)
        {
            object re = null;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand sqlCommand = new SqlCommand(strQuery, conn))
                {
                    if (strParametter != null && ojParametter != null)
                    {
                        int i = 0;
                        foreach (string strPara in strParametter)
                        {
                            sqlCommand.Parameters.AddWithValue(strPara, ojParametter[i]);
                            i += 1;
                        }
                    }
                    re = sqlCommand.ExecuteScalar();
                }
                conn.Close();
            }
            return re;
        }
    }
}
