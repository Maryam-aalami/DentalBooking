using System.Collections.Generic;

namespace LocalTest.Models
{
    public class AppointmentViewModel
    {
        public Appointment Appointment { get; set; }

        public List<Doctor> Doctors { get; set; }

        public List<Service> Services { get; set; }
    }
}