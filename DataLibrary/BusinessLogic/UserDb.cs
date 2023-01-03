using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DataLibrary.Models;
using System.Security.Cryptography;
using System.Reflection;

namespace DataLibrary.BusinessLogic
{
    public class UserDb
    {
        SqlConnection con = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=EzLabDB;Integrated Security=True");
        public void InsertUser(UserModel user)
        {
            user.salt= Createsalt();
            user.hash = GetHash(user.salt + user.hash);
            try
            {
                SqlCommand com = new SqlCommand("spUser_Insert", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@mail", user.mail);
                com.Parameters.AddWithValue("@salt", user.salt);
                com.Parameters.AddWithValue("@hash", user.hash);
                com.Parameters.AddWithValue("@phone_number", user.phone_number);
                com.Parameters.AddWithValue("@name", user.name);
                com.Parameters.AddWithValue("@gender", user.gender);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }

            catch
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        public bool UserExists(String Umail)
        {
            con.Open();
            using (SqlCommand command = new SqlCommand("spUser_Find", con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string mail = reader.GetString(0);
                        if (mail == Umail)
                        {
                            if (con.State == ConnectionState.Open) con.Close();
                            return true;
                        }
                    }
                }
            }
            if (con.State == ConnectionState.Open) con.Close();
            return false;
        }
        public bool CorrectPass(LogInModel Lim)
        {
            con.Open();
            using (SqlCommand command = new SqlCommand("spUser_check", con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string mail = reader.GetString(0);
                        string salt = reader.GetString(1);
                        string hash = reader.GetString(2);
                        if (mail == Lim.mail)
                        {
                            Lim.salt = salt;
                            Lim.hash = GetHash(Lim.salt + Lim.hash);
                            if (Lim.hash == hash) 
                            {
                                if (con.State == ConnectionState.Open) con.Close();
                                return true;
                            }
                            else
                            {
                                if (con.State == ConnectionState.Open) con.Close();
                                return false;
                            }
                            
                        }
                    }
                }
            }
            con.Close();
            return false;
        }
        public ProfileModel GetProfile(string Umail) 
        {
            ProfileModel model = new ProfileModel();
            con.Open();
            using (SqlCommand command = new SqlCommand("spUser_Profile", con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string mail = reader.GetString(0);
                        string name = reader.GetString(1);
                        string phone_number = reader.GetString(2);
                        string gender = reader.GetString(3);
                        if (mail == Umail)
                        {
                            model.mail = mail;
                            model.name = name;                            
                            model.phone_number = phone_number;
                            model.gender = gender;
                            if (con.State == ConnectionState.Open) con.Close();
                            return model;
                        }
                    }
                }
            }
            con.Close();
            return model;
        }
        public void Appoint(string Umail,string test_type,DateOnly date, TimeOnly time) 
        {
            con.Open();
            using (SqlCommand command = new SqlCommand("spUser_id", con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string mail = reader.GetString(0);
                        int id = reader.GetInt32(1);
                        if (mail == Umail)
                        {
                            
                            int U_id = id;
                            con.Close();
                            con.Open();
                            using (SqlCommand command2 = new SqlCommand("spTest_id", con))
                            {
                                    using (SqlDataReader reader2 = command2.ExecuteReader())
                                    {
                                        while (reader2.Read())
                                        {
                                            string Test_type = reader2.GetString(0);
                                            int id2 = reader2.GetInt32(1);
                                        if (Test_type == test_type)
                                        {

                                            int t_id = id2;
                                            con.Close();
                                            try
                                            {
                                                SqlCommand com = new SqlCommand("spAppointment_Insert", con);
                                                com.CommandType = CommandType.StoredProcedure;
                                                com.Parameters.AddWithValue("@test_id", t_id);
                                                com.Parameters.AddWithValue("@user_id", U_id);
                                                string Date = date.ToString();
                                                string Time = time.ToString("hh:mm:ss");
                                                com.Parameters.AddWithValue("@appointment_date", Date);
                                                com.Parameters.AddWithValue("@appointment_time", Time);
                                                con.Open();
                                                com.ExecuteNonQuery();
                                                con.Close();
                                                goto message;
                                            }

                                            catch
                                            {
                                                if (con.State == ConnectionState.Open)
                                                {
                                                    con.Close();
                                                }
                                            }
                                        
                                        }
                                    }

                                }

                            }
                        }
                    }
                }
            }
        message:
            ;
        }
        public static string Createsalt()
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[10];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
        public static string GetHash(string a)
        {
            SHA256 TempHash = SHA256.Create();
            var passwordBytes = Encoding.Default.GetBytes(a);
            var HashedPass = TempHash.ComputeHash(passwordBytes);
            return Convert.ToHexString(HashedPass);
        }
    }
}
