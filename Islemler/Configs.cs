using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace ZirveFerhatPastahane.Islemler
{
    public class Configs
    {

        public static string SQLCon_ZP = null;
        public static string SQLCon_Tiger = null;
        public static string LisansDate = null;
        public static int LisansUser = 0;

        private static string SQLServerName_ZP = null;
        private static string SQLServerDBName_ZP = null;
        private static string SQLServerUser_ZP = null;
        private static string SQLServerPW_ZP = null;
        private static string SQLServerPort_ZP = null;

        private static string SQLServerName_Tiger = null;
        public static string SQLServerDBName_Tiger = null;
        private static string SQLServerUser_Tiger = null;
        private static string SQLServerPW_Tiger = null;
        private static string SQLServerPort_Tiger = null;

        public static void ReadConfigs()
        {
            try
            {
                XmlTextReader xmlreader = new XmlTextReader("Configs\\Main.conf");
                while (xmlreader.Read())
                {
                    switch (xmlreader.Name) //.name özelliği ile içerk içerisindeki alanlarını kontrol edicez
                    {
                        #region SQL_ZP
                        case "SQLServerName_ZP":
                            Configs.SQLServerName_ZP = Convert.ToString(xmlreader.ReadString());
                            break;
                        case "SQLServerDBName_ZP":
                            Configs.SQLServerDBName_ZP = Convert.ToString(xmlreader.ReadString());
                            break;
                        case "SQLServerUser_ZP":
                            Configs.SQLServerUser_ZP = Convert.ToString(xmlreader.ReadString());
                            break;
                        case "SQLServerPW_ZP":
                            Configs.SQLServerPW_ZP = Convert.ToString(xmlreader.ReadString());
                            if (Configs.SQLServerPW_ZP.StartsWith("Sifrelendi_"))
                            {
                                Configs.SQLServerPW_ZP = Islemler.Crypto.DecryptString(Configs.SQLServerPW_ZP.Replace("Sifrelendi_", ""));
                            }
                            else
                            {
                                string temp = Islemler.Crypto.EncryptString(Configs.SQLServerPW_ZP);
                                xmlreader.Close();
                                XmlDocument doc = new XmlDocument();
                                doc.Load("Configs\\Main.conf");
                                XmlNode root = doc.DocumentElement;
                                XmlNode myNode = root.SelectSingleNode("CONFIG//SQLServerPW_ZP");
                                myNode.InnerText = "Sifrelendi_" + temp;
                                doc.Save("Configs\\Main.conf");
                                ReadConfigs();
                            }
                            break;
                        case "SQLServerPort_ZP":
                            Configs.SQLServerPort_ZP = Convert.ToString(xmlreader.ReadString());
                            break;
                        #endregion SQL
                        #region SQL
                        case "SQLServerName_Tiger":
                            Configs.SQLServerName_Tiger = Convert.ToString(xmlreader.ReadString());
                            break;
                        case "SQLServerDBName_Tiger":
                            Configs.SQLServerDBName_Tiger = Convert.ToString(xmlreader.ReadString());
                            break;
                        case "SQLServerUser_Tiger":
                            Configs.SQLServerUser_Tiger = Convert.ToString(xmlreader.ReadString());
                            break;
                        case "SQLServerPW_Tiger":
                            Configs.SQLServerPW_Tiger = Convert.ToString(xmlreader.ReadString());
                            if (Configs.SQLServerPW_Tiger.StartsWith("Sifrelendi_"))
                            {
                                Configs.SQLServerPW_Tiger = Islemler.Crypto.DecryptString(Configs.SQLServerPW_Tiger.Replace("Sifrelendi_", ""));
                            }
                            else
                            {
                                string temp = Islemler.Crypto.EncryptString(Configs.SQLServerPW_Tiger);
                                xmlreader.Close();
                                XmlDocument doc = new XmlDocument();
                                doc.Load("Configs\\Main.conf");
                                XmlNode root = doc.DocumentElement;
                                XmlNode myNode = root.SelectSingleNode("CONFIG//SQLServerPW_Tiger");
                                myNode.InnerText = "Sifrelendi_" + temp;
                                doc.Save("Configs\\Main.conf");
                                ReadConfigs();
                            }
                            break;
                        case "SQLServerPort_Tiger":
                            Configs.SQLServerPort_Tiger = Convert.ToString(xmlreader.ReadString());
                            break;
                        #endregion SQL
                        #region Lisans
                        case "LisansID":
                            string tempLisans = Islemler.Crypto.DecryptString(Convert.ToString(xmlreader.ReadString()));
                            var Main = tempLisans.Split("/*");
                            LisansDate = Main[0];
                            LisansUser = Convert.ToInt32(Main[1]);
                            break;
                        #endregion Lisans
                    }
                }
                xmlreader.Close();
                SQLCon_ZP =
                    "Data Source=" + Configs.SQLServerName_ZP + "," + Configs.SQLServerPort_ZP +
                    "; Initial Catalog=" + Configs.SQLServerDBName_ZP +
                    "; USER ID=" + Configs.SQLServerUser_ZP +
                    ";PASSWORD=" + Configs.SQLServerPW_ZP + "";
                SQLCon_Tiger =
                    "Data Source=" + Configs.SQLServerName_Tiger + "," + Configs.SQLServerPort_Tiger +
                    "; Initial Catalog=" + Configs.SQLServerDBName_Tiger +
                    "; USER ID=" + Configs.SQLServerUser_Tiger +
                    ";PASSWORD=" + Configs.SQLServerPW_Tiger + "";
            }


            catch (Exception ex)
            {
                Console.WriteLine("HATA CONFIG");
                Console.WriteLine(ex);
                throw;
            }


        }
    }
}
