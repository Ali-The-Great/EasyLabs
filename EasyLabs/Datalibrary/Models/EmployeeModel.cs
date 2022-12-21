using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalibrary.Models
{
    internal class EmployeeModel
    {
        public string Employe_Name { get; set; }
        public string Employe_Email { get; set; }
        public string Employe_gender { get; set; }
        public string Employe_phone_number { get; set; }
        public DateOnly Employe_birth_date { get; set; }
    }
}
