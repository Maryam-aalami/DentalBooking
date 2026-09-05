using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LocalTest.Models
{
    public partial class Appointments
    {
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int ServiceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }

        public virtual Doctors Doctor { get; set; }
        public virtual Services Service { get; set; }
    }
}
