using Datalibrary.DataAccess;
using Datalibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Datalibrary.BusinessLogic
{
    public class UserProcessor 
    {
        private readonly ISqlDataAccess _db;

        public UserProcessor(ISqlDataAccess db)
        {
            _db = db;
        }
        public void CreateUser(string email, string password)
        {
            string a = Createsalt();
            UserModel data = new UserModel()
            {
                email = email,
                salt = a,
                hash = GetHash(a + password)

            };

            _db.SaveData("dbo.spUser_Insert", data);
        }
        public void CreateClient(string name,string email,string gender,string phone_number,DateOnly birthdate )
        {
            ClientModel data = new ClientModel()
            {
                
                Client_Name = name,
                Client_Email = email,
                Client_gender = gender,
                Client_phone_number = phone_number,
                Client_birth_date = birthdate

            };

            _db.SaveData("dbo.spClient_Insert", data);
        }
        public void CreateEmp(string name, string email, string gender, string phone_number, DateOnly birthdate)
        {

            EmployeeModel data = new EmployeeModel()
            {
                Employe_Name = name,
                Employe_Email= email,
                Employe_gender = gender,
                Employe_phone_number = phone_number,
                Employe_birth_date = birthdate

            };

            _db.SaveData("dbo.spEmp_Insert", data);
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




        /*
        public static int CreateUser(string email, string password)
        {

            UserModel data = new UserModel
            {
                email = email,
                salt = Createsalt(),
                hash = GetHash(Createsalt() +password)

            };

            string sql = @"insert into dbo.User (email,hash,salt) values (@email,@hash,@salt);";

            return SqlDataAccess.SaveData(sql, data);
        }

        private static List<UserModel> LoadUser()
        {
            string sql = @"select Id, EmployeeId, FirstName, LastName, EmailAddress from dbo.Employee;";

            return SqlDataAccess.LoadData<UserModel>(sql);
        }
        */
    }
}
