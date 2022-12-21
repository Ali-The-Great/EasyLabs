using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalibrary.Models
{
    internal class Test_ResultsModel
    {
        public int Result_Id { get; set; }
        public int Appointment_Id { get; set; }
        public int Component_Id { get; set; }
        public string Result_Value { get; set; }

    }
}
