using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GksKatowiceBot.Helpers
{
    public class BaseDB
    {

        public static string appName = "CHEchoKielce";



        public static void AddToLog(string action)
        {
            try
            {
                SqlConnection sqlConnection1 = new SqlConnection("Server=tcp:plps.database.windows.net,1433;Initial Catalog=PLPS;Persist Security Info=False;User ID=tomasoft;Password=Tomason18,;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "INSERT INTO Log"+ appName + " (Tresc) VALUES ('" + action + " " + DateTime.Now.ToString() + "')";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                cmd.ExecuteNonQuery();

                sqlConnection1.Close();
            }
            catch (Exception ex)
            {
                SqlConnection sqlConnection1 = new SqlConnection("Server=tcp:plps.database.windows.net,1433;Initial Catalog=PLPS;Persist Security Info=False;User ID=tomasoft;Password=Tomason18,;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "INSERT INTO Log" + appName + " (Tresc) VALUES ('" + "Błąd dodawania wiadomosci do Loga" + " " + DateTime.Now.ToString() + "')";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                cmd.ExecuteNonQuery();

                sqlConnection1.Close();
            }
        }

        public static void AddWiadomosci(List<System.Linq.IGrouping<string, string>> hrefList)
        {
            try
            {
                SqlConnection sqlConnection1 = new SqlConnection("Server=tcp:plps.database.windows.net,1433;Initial Catalog=PLPS;Persist Security Info=False;User ID=tomasoft;Password=Tomason18,;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                if (hrefList.Count == 3)
                {
                    cmd.CommandText = "INSERT INTO [dbo].[WiadomosciCHEchoKielce] (Nazwa,DataUtw,Wiadomosc1,Wiadomosc2,Wiadomosc3,Wiadomosc4,Wiadomosc5,Wiadomosc6) VALUES ('" + "" + "','" + DateTime.Now + "','" + hrefList[0].Key + "','" + hrefList[1].Key + "','" + hrefList[2].Key + "','" + "" + "','" + "" + "','" + "" + "')";

                }
                else if(hrefList.Count==4)
                {
                    cmd.CommandText = "INSERT INTO [dbo].[WiadomosciCHEchoKielce] (Nazwa,DataUtw,Wiadomosc1,Wiadomosc2,Wiadomosc3,Wiadomosc4,Wiadomosc5,Wiadomosc6) VALUES ('" + "" + "','" + DateTime.Now + "','" + hrefList[0].Key + "','" + hrefList[1].Key + "','" + hrefList[2].Key + "','" + hrefList[3].Key + "','" + "" + "','" + "" + "')";
                }
                else if (hrefList.Count == 5)
                {
                    cmd.CommandText = "INSERT INTO [dbo].[WiadomosciCHEchoKielce] (Nazwa,DataUtw,Wiadomosc1,Wiadomosc2,Wiadomosc3,Wiadomosc4,Wiadomosc5,Wiadomosc6) VALUES ('" + "" + "','" + DateTime.Now + "','" + hrefList[0].Key + "','" + hrefList[1].Key + "','" + hrefList[2].Key + "','" + hrefList[3].Key + "','" + hrefList[4].Key + "','" + "" + "')";
                }
                else if (hrefList.Count == 6)
                {
                    cmd.CommandText = "INSERT INTO [dbo].[WiadomosciCHEchoKielce] (Nazwa,DataUtw,Wiadomosc1,Wiadomosc2,Wiadomosc3,Wiadomosc4,Wiadomosc5,Wiadomosc6) VALUES ('" + "" + "','" + DateTime.Now + "','" + hrefList[0].Key + "','" + hrefList[1].Key + "','" + hrefList[2].Key + "','" + hrefList[3].Key + "','" + hrefList[4].Key + "','" + hrefList[5].Key + "')";
                }
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                cmd.ExecuteNonQuery();

                sqlConnection1.Close();
            }
            catch (Exception ex)
            {
                AddToLog("Błąd dodawania wiadomości: " + ex.ToString());
            }
        }

        public static void AddWiadomosciPromocje(List<System.Linq.IGrouping<string, string>> hrefList)
        {
            try
            {
                SqlConnection sqlConnection1 = new SqlConnection("Server=tcp:plps.database.windows.net,1433;Initial Catalog=PLPS;Persist Security Info=False;User ID=tomasoft;Password=Tomason18,;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "INSERT INTO [dbo].[WiadomosciCHEchoKielcePromocje] (Nazwa,DataUtw,Wiadomosc1,Wiadomosc2,Wiadomosc3,Wiadomosc4,Wiadomosc5,Wiadomosc6,Wiadomosc7,Wiadomosc8,Wiadomosc9,Wiadomosc10,Wiadomosc11,Wiadomosc12) VALUES ('" + "" + "','" + DateTime.Now + "','" + hrefList[0].Key + "','" + hrefList[1].Key + "','" + hrefList[2].Key + "','" + hrefList[3].Key + "','" + hrefList[4].Key +
                    "','" + hrefList[5].Key + "','" + hrefList[6].Key + "','" + hrefList[7].Key + "','" + hrefList[8].Key + "','" + hrefList[9].Key + "','" + hrefList[10].Key + "','" + hrefList[11].Key + "')";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                cmd.ExecuteNonQuery();

                sqlConnection1.Close();
            }
            catch (Exception ex)
            {
                AddToLog("Błąd dodawania wiadomości: " + ex.ToString());
            }
        }

        public static void AddWiadomosciWydarzenia(List<System.Linq.IGrouping<string, string>> hrefList)
        {
            try
            {
                SqlConnection sqlConnection1 = new SqlConnection("Server=tcp:plps.database.windows.net,1433;Initial Catalog=PLPS;Persist Security Info=False;User ID=tomasoft;Password=Tomason18,;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "INSERT INTO [dbo].[WiadomosciCHEchoKielceWydarzenia] (Nazwa,DataUtw,Wiadomosc1,Wiadomosc2,Wiadomosc3,Wiadomosc4,Wiadomosc5) VALUES ('" + "" + "','" + DateTime.Now + "','" + hrefList[0].Key + "','" + hrefList[1].Key + "','" + hrefList[2].Key + "','" + hrefList[3].Key + "','" + hrefList[4].Key + "')";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                cmd.ExecuteNonQuery();

                sqlConnection1.Close();
            }
            catch (Exception ex)
            {
                AddToLog("Błąd dodawania wiadomości: " + ex.ToString());
            }
        }






        public static DataTable GetWiadomosci()
        {
            try
            {
                SqlConnection sqlConnection1 = new SqlConnection("Server=tcp:plps.database.windows.net,1433;Initial Catalog=PLPS;Persist Security Info=False;User ID=tomasoft;Password=Tomason18,;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;
                DataTable dataTable = new DataTable();


                sqlConnection1.Open();

                cmd.CommandText = "Select Wiadomosc1,Wiadomosc2,Wiadomosc3,Wiadomosc4,Wiadomosc5 from [dbo].[WiadomosciCHEchoKielce]";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // this will query your database and return the result to your datatable
                da.Fill(dataTable);
                sqlConnection1.Close();
                da.Dispose();
                return dataTable;
            }
            catch (Exception ex)
            {
                AddToLog("Błąd dodawania wiadomości: " + ex.ToString());
                return null;
            }
        }




        public static DataTable GetWiadomosciWydarzenia()
        {
            try
            {
                SqlConnection sqlConnection1 = new SqlConnection("Server=tcp:plps.database.windows.net,1433;Initial Catalog=PLPS;Persist Security Info=False;User ID=tomasoft;Password=Tomason18,;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;
                DataTable dataTable = new DataTable();


                sqlConnection1.Open();

                cmd.CommandText = "Select Wiadomosc1,Wiadomosc2,Wiadomosc3,Wiadomosc4,Wiadomosc5 from [dbo].[WiadomosciCHEchoKielceWydarzenia]";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // this will query your database and return the result to your datatable
                da.Fill(dataTable);
                sqlConnection1.Close();
                da.Dispose();
                return dataTable;
            }
            catch (Exception ex)
            {
                AddToLog("Błąd dodawania wiadomości: " + ex.ToString());
                return null;
            }
        }




        public static DataTable GetWiadomosciPromocje()
        {
            try
            {
                SqlConnection sqlConnection1 = new SqlConnection("Server=tcp:plps.database.windows.net,1433;Initial Catalog=PLPS;Persist Security Info=False;User ID=tomasoft;Password=Tomason18,;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;
                DataTable dataTable = new DataTable();


                sqlConnection1.Open();

                cmd.CommandText = "Select Wiadomosc1,Wiadomosc2,Wiadomosc3,Wiadomosc4,Wiadomosc5,Wiadomosc6,Wiadomosc7,Wiadomosc8,Wiadomosc9,Wiadomosc10,Wiadomosc11,WIadomosc12 from [dbo].[WiadomosciCHEchoKielcePromocje]";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // this will query your database and return the result to your datatable
                da.Fill(dataTable);
                sqlConnection1.Close();
                da.Dispose();
                return dataTable;
            }
            catch (Exception ex)
            {
                AddToLog("Błąd dodawania wiadomości: " + ex.ToString());
                return null;
            }
        }

        public static void AddUser(string UserName, string UserId, string BotName, string BotId, string Url, byte flgTyp)
        {
            try
            {
                SqlConnection sqlConnection1 = new SqlConnection("Server=tcp:plps.database.windows.net,1433;Initial Catalog=PLPS;Persist Security Info=False;User ID=tomasoft;Password=Tomason18,;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "IF NOT EXISTS(Select * from [dbo].[User" + appName + "] where UserId='" + UserId + "')BEGIN INSERT INTO [dbo].[User" + appName + "] (UserName,UserId,BotName,BotId,Url,flgPlusLiga,DataUtw,flgDeleted) VALUES ('" + UserName + "','" + UserId + "','" + BotName + "','" + BotId + "','" + Url + "','" + flgTyp.ToString() + "','" + DateTime.Now + "','0')END";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                cmd.ExecuteNonQuery();

                sqlConnection1.Close();
            }
            catch (Exception ex)
            {
                AddToLog("Blad dodawania uzytkownika "+ex.ToString());
            }
        }
        public static object czyAdministrator(string UserId)
        {
            try
            {
                SqlConnection sqlConnection1 = new SqlConnection("Server=tcp:plps.database.windows.net,1433;Initial Catalog=PLPS;Persist Security Info=False;User ID=tomasoft;Password=Tomason18,;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "sprawdzCzyAdministrator"+ appName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", UserId);
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                var rowsAffected = cmd.ExecuteScalar();

                sqlConnection1.Close();

                return rowsAffected;
            }
            catch (Exception ex)
            {
                AddToLog("Blad sprawdzania uzytkownika czy admnistrator "+ex.ToString());
                return null;
            }
        }

        public static void ModyfikujListeSklepow(string tytul,string img,string link,string kategoria)
        {
            try
            {
                SqlConnection sqlConnection1 = new SqlConnection("Server=tcp:plps.database.windows.net,1433;Initial Catalog=PLPS;Persist Security Info=False;User ID=tomasoft;Password=Tomason18,;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "AddSklepy";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tytul", tytul);
                cmd.Parameters.AddWithValue("@Img", img);
                cmd.Parameters.AddWithValue("@Link", link);
                cmd.Parameters.AddWithValue("@Kategoria", kategoria);
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                cmd.ExecuteNonQuery();

                sqlConnection1.Close();

            }
            catch (Exception ex)
            {
                AddToLog("Blad sprawdzania uzytkownika czy admnistrator " + ex.ToString());
            }
        }

        public static DataTable dajListeSklepow(string link)
        {
            try
            {
                SqlConnection sqlConnection1 = new SqlConnection("Server=tcp:plps.database.windows.net,1433;Initial Catalog=PLPS;Persist Security Info=False;User ID=tomasoft;Password=Tomason18,;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;
                DataTable dataTable = new DataTable();


                sqlConnection1.Open();

                cmd.CommandText = "Select * from [dbo].[SklepyEcho] where Kategoria='"+link+"'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // this will query your database and return the result to your datatable
                da.Fill(dataTable);
                sqlConnection1.Close();
                da.Dispose();
                return dataTable;
            }
            catch (Exception ex)
            {
                AddToLog("Błąd dodawania wiadomości: " + ex.ToString());
                return null;
            }
        }


        public static void DeleteUser(string UserId)
        {
            try
            {
                SqlConnection sqlConnection1 = new SqlConnection("Server=tcp:plps.database.windows.net,1433;Initial Catalog=PLPS;Persist Security Info=False;User ID=tomasoft;Password=Tomason18,;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "Delete [dbo].[User" + appName + "] where UserId='" + UserId + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                cmd.ExecuteNonQuery();

                sqlConnection1.Close();
            }
            catch
            {
                AddToLog("Blad usuwania uzytkownika: " + UserId);
            }
        }

    }
}