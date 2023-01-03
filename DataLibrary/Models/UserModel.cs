using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLibrary.Models
{
    public class UserModel
    {
        public string name { get; set; }
        public string phone_number { get; set; }
        public string mail { get; set; }
        public string salt { get; set; }
        public string hash { get; set; }
        public string gender { get; set; }

        public UserModel(string name, string phone_number, string mail, string salt, string hash, string gender)
        {
            this.name = name;
            this.phone_number = phone_number;
            this.mail = mail;
            this.salt = salt;
            this.hash = hash;
            this.gender = gender;
        }
    }
}
