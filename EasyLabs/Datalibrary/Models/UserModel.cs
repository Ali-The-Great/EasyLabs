using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Datalibrary.Models
{
    public class UserModel
    {
        public int user_id;
        public string? email { get; set; }
        public string? salt { get; set; }
        public string? hash { get; set; }
/*        
        public UserModel(string email,string password)
        {
            this.email = email;
            salt = Createsalt();
            hash = GetHash(salt + password);
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
        }*/
    }
    
    
}
