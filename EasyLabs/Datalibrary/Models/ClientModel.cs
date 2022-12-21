using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalibrary.Models
{
    internal class ClientModel
    {
        public string Client_Name { get; set; }
        public string Client_Email { get; set; }
        public string Client_gender { get; set; }
        public string Client_phone_number { get; set; }
        public DateOnly Client_birth_date { get; set; }
    }
}
