using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZirveFerhatPastahane.Islemler
{
    public class DB_op
    {
        private static DB_op DB_Works;
        public static DB_op Instance
        {
            get
            {
                if (DB_Works == null)
                    DB_Works = new DB_op();
                return DB_Works;
            }
        }

        public DataTable selectToZP_DT(string sqlSorgu)//Databaseden verileri datatale olarak döndürür
        {
            //using (SqlConnection connect = new SqlConnection(WebConfigurationManager.ConnectionStrings[connectName].ConnectionString))
            //using (SqlConnection connect = new SqlConnection("Data Source=127.0.0.1;Initial Catalog=MERPEY;User ID=sa;Password=Ferhat_123*;Connect Timeout=60;Persist Security Info=True;MultipleActiveResultSets=true;"))// providerName = \"System.Data.SqlClient"))
            using (SqlConnection connect = new SqlConnection(Configs.SQLCon_ZP + ";Connect Timeout=60;Persist Security Info=True;MultipleActiveResultSets=true;"))// providerName = \"System.Data.SqlClient"))
            {
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(sqlSorgu, connect))
                {
                    try
                    {
                        da.Fill(dt);
                        return dt;
                    }
                    catch (Exception ex)
                    {
                        //Logger.Logcu(ex + "--Sorgu: " + sqlSorgu);
                        return dt;
                    }
                }
            }
        }
        public string selectToZP(string sqlSorgu)
        {
            using (SqlConnection connect = new SqlConnection(Configs.SQLCon_ZP + ";Connect Timeout=60;Persist Security Info=True;MultipleActiveResultSets=true;"))// providerName = \"System.Data.SqlClient"))
            {
                using (SqlCommand cmd = new SqlCommand(sqlSorgu, connect))
                {
                    try
                    {
                        if (connect.State != ConnectionState.Open)
                            connect.Open();
                        using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleRow))
                        {
                            try
                            {
                                if (rd.HasRows)
                                {
                                    rd.Read();
                                    return rd[0].ToString();
                                }
                                else
                                    return string.Empty;
                            }
                            catch (Exception ex)
                            {
                                //Logger.Logcu(ex + "--Sorgu: " + sqlSorgu);
                                return string.Empty;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //Logger.Logcu(ex);
                        return string.Empty;
                    }
                    finally
                    {
                        if (connect.State != ConnectionState.Closed)
                            connect.Close();
                    }
                }
            }
        }
        public DataTable selectToTiger_DT(string sqlSorgu)//Databaseden verileri datatale olarak döndürür
        {
            //using (SqlConnection connect = new SqlConnection(WebConfigurationManager.ConnectionStrings[connectName].ConnectionString))
            //using (SqlConnection connect = new SqlConnection("Data Source=127.0.0.1;Initial Catalog=MERPEY;User ID=sa;Password=Ferhat_123*;Connect Timeout=60;Persist Security Info=True;MultipleActiveResultSets=true;"))// providerName = \"System.Data.SqlClient"))
            using (SqlConnection connect = new SqlConnection(Configs.SQLCon_Tiger + ";Connect Timeout=60;Persist Security Info=True;MultipleActiveResultSets=true;"))// providerName = \"System.Data.SqlClient"))
            {
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(sqlSorgu, connect))
                {
                    try
                    {
                        da.Fill(dt);
                        return dt;
                    }
                    catch (Exception ex)
                    {
                        //Logger.Logcu(ex + "--Sorgu: " + sqlSorgu);
                        return dt;
                    }
                }
            }
        }
        public DataTable selectTo210807Har_DT(string sqlSorgu)//Databaseden verileri datatale olarak döndürür
        {
            //using (SqlConnection connect = new SqlConnection(WebConfigurationManager.ConnectionStrings[connectName].ConnectionString))
            //using (SqlConnection connect = new SqlConnection("Data Source=127.0.0.1;Initial Catalog=MERPEY;User ID=sa;Password=Ferhat_123*;Connect Timeout=60;Persist Security Info=True;MultipleActiveResultSets=true;"))// providerName = \"System.Data.SqlClient"))
            using (SqlConnection connect = new SqlConnection("Data Source=95.9.175.8; Initial Catalog=INTER_BOS; USER ID=logo;PASSWORD=11321" + ";Connect Timeout=60;Persist Security Info=True;MultipleActiveResultSets=true;"))// providerName = \"System.Data.SqlClient"))
            {
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(sqlSorgu, connect))
                {
                    try
                    {
                        da.Fill(dt);
                        return dt;
                    }
                    catch (Exception ex)
                    {
                        //Logger.Logcu(ex + "--Sorgu: " + sqlSorgu);
                        return dt;
                    }
                }
            }
        }
        public string selectToTiger(string sqlSorgu)
        {
            using (SqlConnection connect = new SqlConnection(Configs.SQLCon_Tiger + ";Connect Timeout=60;Persist Security Info=True;MultipleActiveResultSets=true;"))// providerName = \"System.Data.SqlClient"))
            {
                using (SqlCommand cmd = new SqlCommand(sqlSorgu, connect))
                {
                    try
                    {
                        if (connect.State != ConnectionState.Open)
                            connect.Open();
                        using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleRow))
                        {
                            try
                            {
                                if (rd.HasRows)
                                {
                                    rd.Read();
                                    return rd[0].ToString();
                                }
                                else
                                    return string.Empty;
                            }
                            catch (Exception ex)
                            {
                                //Logger.Logcu(ex + "--Sorgu: " + sqlSorgu);
                                return string.Empty;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //Logger.Logcu(ex);
                        return string.Empty;
                    }
                    finally
                    {
                        if (connect.State != ConnectionState.Closed)
                            connect.Close();
                    }
                }
            }
        }
        public StringBuilder selectToTiger_StringBuilder(string sqlSorgu)
        {
            StringBuilder a1 = new StringBuilder();

            using (SqlConnection connect = new SqlConnection(Configs.SQLCon_Tiger + ";Connect Timeout=60;Persist Security Info=True;MultipleActiveResultSets=true;"))// providerName = \"System.Data.SqlClient"))
            {
                using (SqlCommand cmd = new SqlCommand(sqlSorgu, connect))
                {
                    try
                    {
                        if (connect.State != ConnectionState.Open)
                            connect.Open();
                        using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleRow))
                        {
                            try
                            {
                                if (rd.HasRows)
                                {
                                    rd.Read();
                                    //return
                                    a1.Append(rd[0]);// rd[0].ToString();
                                    return a1;
                                }
                                else
                                    return a1;
                            }
                            catch (Exception ex)
                            {
                                //Logger.Logcu(ex + "--Sorgu: " + sqlSorgu);
                                return a1;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //Logger.Logcu(ex);
                        return a1;
                    }
                    finally
                    {
                        if (connect.State != ConnectionState.Closed)
                            connect.Close();
                    }
                }
            }
        }
    }
}
