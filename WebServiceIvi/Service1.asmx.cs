using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

namespace WebServiceIvi
{

    [WebService(Namespace = "http://www.ividomain.somee.com/Service1")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Service1 : System.Web.Services.WebService
    {
        public static string connString = "workstation id=databaseivi.mssql.somee.com;packet size=4096;user id=XXXXXX;pwd=XXXXXX;data source=databaseivi.mssql.somee.com;persist security info=False;initial catalog=databaseivi";
        public String email;
        public String password;

        [WebMethod]
        public int registerUser(String useremail, String userpass, String usercellphone, String usercellphoneoper)
        {
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmdSQL = con.CreateCommand();
            String pv;
            if (String.IsNullOrEmpty(usercellphone))
            {
                pv = "NULL";
                usercellphone = "NULL";
            }
            else
            {
                usercellphone = String.Format("'{0}'", usercellphone);
                pv = "'pub'";
            }

            try
            {

                con.Open();
                cmdSQL.CommandText = String.Format("INSERT INTO [databaseivi].[dbo].[UsersIvi] ([Useremail],[Useremail_st],[Userpass],[Userphoneoper],[Userphone],[Userphone_st],[Sn_facebook],[Sn_linkedin],[Sn_googleplus],[Sn_skype],[Sn_twitter],[Userlastrefresh],[Usersince],[Username]) VALUES ('{0}','pub','{1}','{2}',{3},{4}, null, null, null, null, null, getDate(), getDate(), null)", useremail, userpass, usercellphoneoper, usercellphone, pv);
                int result = cmdSQL.ExecuteNonQuery();
                con.Close();

                return result;
            }
            catch (SqlException e)
            {
                foreach (SqlError error in e.Errors)
                {
                    return error.Number;
                }
                return 0;
            }
            /**
        reader = cmdSQL.ExecuteReader();
        String result = "";
            
        while (reader.Read())
        {
            result += (String.Format("{0} - {1} <br/>",
                reader["UserId"], reader["Username"]));
        }
        **/

            //-----------------------------------------------------------
            // This is the part where I should be able to retrieve the data from the database
            //-----------------------------------------------------------               

        }

        [WebMethod]
        public Contact loginUser(String useremail, String userpass)
        {


            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmdSQL = con.CreateCommand();
            try
            {

                con.Open();
                cmdSQL.CommandText = String.Format("SELECT * FROM [databaseivi].[dbo].[UsersIvi] WHERE [Useremail]= '{0}' AND [Userpass] = '{1}'", useremail, userpass);
                SqlDataReader reader = cmdSQL.ExecuteReader();
                Contact c = new Contact();
                ArrayList contact = new ArrayList();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        c.UserId = Int32.Parse(reader["UserID"].ToString());
                        c.UserEmail = reader["Useremail"].ToString();
                        c.UserEmailStatus = reader["Useremail_st"].ToString();
                        c.UserPassword = reader["Userpass"].ToString();
                        c.UserName = reader["Username"].ToString();
                        c.UserSimOperator = reader["Userphoneoper"].ToString();
                        c.UserCellPhone = reader["Userphone"].ToString();
                        c.UserCellPhoneStatus = reader["Userphone_st"].ToString();
                        c.UserFacebook = reader["Sn_facebook"].ToString();
                        c.UserLinkedin = reader["Sn_linkedin"].ToString();
                        c.UserGoogleplus = reader["Sn_googleplus"].ToString();
                        c.UserSkype = reader["Sn_skype"].ToString();
                        c.UserTwitter = reader["Sn_twitter"].ToString();
                        c.UserLastRefresh = reader["Userlastrefresh"].ToString();
                        c.UserRegisterDate = reader["Usersince"].ToString();
                        c.UserHomephone = reader["Userhomephone"].ToString();
                        c.UserHomephoneStatus = reader["Userhomephone_st"].ToString();
                        c.UserComerphone = reader["Usercomphone"].ToString();
                        c.UserComerphoneStatus = reader["Usercomphone_st"].ToString();
                        c.UserAltphone = reader["Useraltphone"].ToString();
                        c.UserAltphoneStatus = reader["Useraltphone_st"].ToString();
                        c.UserWebsite = reader["Userwebsite"].ToString();
                        c.UserWebsiteStatus = reader["Userwebsite_st"].ToString();
                        c.UserFacebookStatus = reader["Sn_facebook_st"].ToString();
                        c.UserLinkedin = reader["Sn_linkedin_st"].ToString();
                        c.UserGoogleplusStatus = reader["Sn_googleplus_st"].ToString();
                        c.UserSkypeStatus = reader["Sn_skype_st"].ToString();
                        c.UserTwitterStatus = reader["Sn_twitter_st"].ToString();
                    }
                    con.Close();
                }
                else
                {
                    return null;
                }

                con.Open();
                SqlCommand cmdSQL2 = con.CreateCommand();
                cmdSQL2.CommandText = String.Format("SELECT * FROM [databaseivi].[dbo].[UsersOptEmail] WHERE [UserID]= {0}", c.UserId);
                SqlDataReader reader2 = cmdSQL2.ExecuteReader();
                if (reader2.HasRows)
                {
                    int cont = 0;
                    List<OptEmail> opt = new List<OptEmail>();
                    while (reader2.Read())
                    {
                        opt.Add(new OptEmail(reader2["Useremail_opt"].ToString(), reader2["Useremail_opt_st"].ToString()));
                        cont++;
                    }
                    c.UserOptEmail = opt;
                }
                con.Close();
                return c;
            }
            catch (SqlException e)
            {
                foreach (SqlError error in e.Errors)
                {
                    return null;
                    //return error.Number.ToString();
                }
                return null;
            }
        }



        [WebMethod]
        public int recoverPassword(String useremail)
        {
            SqlCommand cmdSQL;
            SqlConnection con;
            try
            {
                con = new SqlConnection(connString);
                cmdSQL = con.CreateCommand();
                con.Open();
            }
            catch (SqlException e1)
            {
                return -1;
            }
            try
            {
                cmdSQL.CommandText = String.Format("SELECT [Useremail],[Userpass]  FROM [databaseivi].[dbo].[UsersIvi] WHERE [Useremail]= '{0}'", useremail);
                SqlDataReader reader = cmdSQL.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        email = reader["Useremail"].ToString();
                        password = reader["Userpass"].ToString();
                    }
                    con.Close();
                    SmtpClient client = new SmtpClient();
                    client.Credentials = new NetworkCredential("ividomain@gmail.com", "suporte123");
                    client.Port = 587;
                    client.Host = "smtp.gmail.com";
                    client.EnableSsl = true;
                    MailAddress maFrom = new MailAddress("ividomain@gmail.com", "Support IvI", Encoding.UTF8), maTo = new MailAddress(email, email, Encoding.UTF8);
                    MailMessage mmsg = new MailMessage(maFrom.Address, maTo.Address);
                    mmsg.Body = "<html><body><h1>Your IvI password is " + password + "</h1></body></html>";
                    mmsg.BodyEncoding = Encoding.UTF8;
                    mmsg.IsBodyHtml = true;
                    mmsg.Subject = "IvI Password Recovery";
                    mmsg.SubjectEncoding = Encoding.UTF8;
                    client.Send(mmsg);
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException e)
            {
                foreach (SqlError error in e.Errors)
                {
                    return error.Number;
                }
            }
            return 0;
        }


        //public String updateUser(ContactWeb c, String opt)
        [WebMethod]
        public int updateUser(ContactWeb c, String opt)
        {
            SqlCommand cmdSQLUpdateUsers, cmdSQLSelectOpt, cmdSQLInsertOpt, cmdSQLDeleteOpt, cmdSQLUpdateOpt;
            SqlConnection con;
            List<OptEmail> listOpt = null;
            List<OptEmail> optTemp = new List<OptEmail>();
            if (!String.IsNullOrEmpty(opt))
            {
                listOpt = parseStringOptEmails(opt);
            }
            con = new SqlConnection(connString);
            con.Open();
            try
            {
                //UPDATE USER  
                cmdSQLUpdateUsers = con.CreateCommand();
                cmdSQLUpdateUsers.CommandText = String.Format("UPDATE [databaseivi].[dbo].[UsersIvi] SET Useremail_st={0}, Userphoneoper={1}, Userphone={2}, Userphone_st={3}, Sn_facebook={4},  Sn_linkedin={5}, Sn_googleplus={6}, Sn_skype={7}, Sn_twitter={8}, Username={9}, Userlastrefresh=getDate(), Userhomephone={13}, Userhomephone_st={14}, Usercomphone={15}, Usercomphone_st={16}, Useraltphone={17}, Useraltphone_st={18}, Userwebsite={19}, Userwebsite_st = {20}, Sn_facebook_st = {21}, Sn_linkedin_st={22}, Sn_googleplus_st={23}, Sn_skype_st={24}, Sn_twitter_st = {25} WHERE Useremail='{10}' AND Userpass='{11}' AND UserID='{12}'", checkIsEmpty(c.UserEmailStatus), checkIsEmpty(c.UserSimOperator), checkIsEmpty(c.UserCellPhone), checkIsEmpty(c.UserCellPhoneStatus), checkIsEmpty(c.UserFacebook), checkIsEmpty(c.UserLinkedin), checkIsEmpty(c.UserGoogleplus), checkIsEmpty(c.UserSkype), checkIsEmpty(c.UserTwitter), checkIsEmpty(c.UserName), c.UserEmail, c.UserPassword, c.UserId, checkIsEmpty(c.UserHomephone), checkIsEmpty(c.UserHomephoneStatus), checkIsEmpty(c.UserComerphone), checkIsEmpty(c.UserComerphoneStatus), checkIsEmpty(c.UserAltphone), checkIsEmpty(c.UserAltphoneStatus), checkIsEmpty(c.UserWebsite), checkIsEmpty(c.UserWebsiteStatus), checkIsEmpty(c.UserFacebookStatus), checkIsEmpty(c.UserLinkedinStatus), checkIsEmpty(c.UserGoogleplusStatus), checkIsEmpty(c.UserSkypeStatus), checkIsEmpty(c.UserTwitterStatus)); 
                int row = cmdSQLUpdateUsers.ExecuteNonQuery();
                if (row == 0)
                {
                    con.Close();
                    return 0;
                }
                else
                {
                    cmdSQLSelectOpt = con.CreateCommand();
                    cmdSQLSelectOpt.CommandText = String.Format("SELECT [UserID],[Useremail_opt],[Useremail_opt_st] FROM [databaseivi].[dbo].[UsersOptEmail] WHERE [UserID]={0}", c.UserId);
                    SqlDataReader reader = cmdSQLSelectOpt.ExecuteReader();
                    while (reader.Read())
                    {
                        optTemp.Add(new OptEmail(reader["Useremail_opt"].ToString(), reader["Useremail_opt_st"].ToString()));
                    }
                    reader.Close();
                    if (optTemp.Count != 0 && listOpt == null)
                    {
                        //DELETE TUDO SE NAO TIVER LISTA
                        cmdSQLDeleteOpt = con.CreateCommand();
                        cmdSQLDeleteOpt.CommandText = String.Format("DELETE FROM [databaseivi].[dbo].[UsersOptEmail] WHERE [UserID]={0}", c.UserId);
                        cmdSQLDeleteOpt.ExecuteNonQuery();

                    }
                    else if (optTemp.Count == 0 && listOpt != null)
                    {
                        //Nada no DB, mas tem coisa na lista UserOpt pra colocar
                        foreach (OptEmail t in listOpt)
                        {
                            //Insere todos os emails opcionais
                            cmdSQLInsertOpt = con.CreateCommand();
                            cmdSQLInsertOpt.CommandText = String.Format("INSERT INTO [databaseivi].[dbo].[UsersOptEmail] ([UserID] ,[Useremail_opt] ,[Useremail_opt_st]) VALUES ({0},'{1}','{2}')", c.UserId, t.OptUserEmail, t.OptUserEmailStatus);
                            int result = cmdSQLInsertOpt.ExecuteNonQuery();
                        }
                    }
                    else if (optTemp.Count != 0 && listOpt != null)
                    {

                        foreach (OptEmail opDB in optTemp)
                        {
                            Boolean temNaList = false;
                            //Verificar se oq existia na lista de UserOpt ja ta cadastrada
                            foreach (OptEmail opCli in listOpt)
                            {
                                if (opDB.OptUserEmail == opCli.OptUserEmail)
                                {
                                    //Email da lista ja cadastrado no DB
                                    temNaList = true;
                                    //Verifica se mudou o Status do email
                                    if (opDB.OptUserEmailStatus != opCli.OptUserEmailStatus)
                                    {
                                        //UPDATE
                                        cmdSQLUpdateOpt = con.CreateCommand();
                                        cmdSQLUpdateOpt.CommandText = String.Format("UPDATE [databaseivi].[dbo].[UsersOptEmail]  SET [Useremail_opt_st] ='{0}' WHERE [Useremail_opt] = '{1}' AND [UserID]={2}", opCli.OptUserEmailStatus, opDB.OptUserEmail, c.UserId);
                                        int row2 = cmdSQLUpdateOpt.ExecuteNonQuery();
                                        Console.Write(row2.ToString());
                                    }
                                }
                            }

                            //Ta cadastrado no DB e não ta na List
                            if (temNaList == false)
                            {
                                //DELETE OQ NAO TEM MAIS
                                cmdSQLDeleteOpt = con.CreateCommand();
                                cmdSQLDeleteOpt.CommandText = String.Format("DELETE FROM [databaseivi].[dbo].[UsersOptEmail] WHERE [Useremail_opt] = '{0}' AND [UserID]={1}", opDB.OptUserEmail, c.UserId);
                                cmdSQLDeleteOpt.ExecuteNonQuery();
                            }

                        }

                        //Verifica se NAO tem no DB e tem na lista
                        foreach (OptEmail opCli in listOpt)
                        {
                            Boolean temNoDB = false;
                            foreach (OptEmail opDB in optTemp)
                            {
                                if (opCli.OptUserEmail == opDB.OptUserEmail)
                                {
                                    temNoDB = true;
                                }
                            }
                            if (temNoDB == false)
                            {
                                //INSERT - tem na List e nao tem no DB
                                cmdSQLInsertOpt = con.CreateCommand();
                                cmdSQLInsertOpt.CommandText = String.Format("INSERT INTO [databaseivi].[dbo].[UsersOptEmail] ([UserID] ,[Useremail_opt] ,[Useremail_opt_st]) VALUES ({0},'{1}','{2}')", c.UserId, opCli.OptUserEmail, opCli.OptUserEmailStatus);
                                cmdSQLInsertOpt.ExecuteNonQuery();
                            }
                        }

                    }


                }
                con.Close();
                return 1;
            }
            catch (SqlException e)
            {
                foreach (SqlError error in e.Errors)
                {
                    return error.Number;
                    //return error.Number.ToString();
                }
                return 0;
            }
        }

        public String checkIsEmpty(String value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return "NULL";
            }
            else
            {
                return "'" + value + "'";
            }
        }

        public List<OptEmail> parseStringOptEmails(String opt)
        {
            Boolean newOptEmail = false;
            Boolean newOptSt = false;
            String email = "";
            String email_st = "";
            List<OptEmail> listOpt = new List<OptEmail>();
            for (int i = 0; i < opt.Length; i++)
            {

                if (opt[i].ToString() == ":" || i + 1 > opt.Length)
                {
                    if (i > 0 && newOptSt == true)
                    {
                        listOpt.Add(new OptEmail(email, email_st));
                        if (i + 1 > opt.Length)
                        {
                            break;
                        }
                    }
                    i = i + 2;
                    newOptEmail = true;
                    newOptSt = false;
                    email = "";
                }

                if (opt[i].ToString() == "|")
                {
                    if (i + 1 < opt.Length)
                    {
                        i = i + 1;
                        newOptEmail = false;
                        newOptSt = true;
                        email_st = "";
                    }
                }
                if (newOptSt == true)
                {
                    email_st += opt[i];
                }
                if (newOptEmail == true)
                {
                    email += opt[i];
                }
            }
            listOpt.Add(new OptEmail(email, email_st));
            return listOpt;
        }

    }
}
