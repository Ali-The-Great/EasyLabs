using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalibrary.Models
{
    internal class AppointmentModel
    {
        public int Appointment_Id { get; set; }
        public int Client_Id { get; set; }
        public int Test_Id { get; set; }
        public DateOnly Appointment_date { get; set; }
        public TimeOnly Appointment_time { get; set; }
    }
}
