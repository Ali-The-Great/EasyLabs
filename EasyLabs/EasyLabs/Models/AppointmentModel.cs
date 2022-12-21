namespace EasyLabs.Models
{
    public class AppointmentModel
    {
        public int Appointment_ID { get; set; }
        public DateOnly Appointment_Date { get; set; }
        public TimeOnly Appointment_Time { get; set; }
        public int Test_ID { get; set; }
        public int Client_ID { get; set; }

    }
}
