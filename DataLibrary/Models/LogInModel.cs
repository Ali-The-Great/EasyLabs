using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class LogInModel
    {
        public string mail { get; set; }
        public string salt { get; set; }
        public string hash { get; set; }

        public LogInModel(string mail, string salt, string hash)
        {
            this.mail = mail;
            this.salt = salt;
            this.hash = hash;
        }
    }
}
