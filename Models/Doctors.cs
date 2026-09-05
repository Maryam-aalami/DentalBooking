using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LocalTest.Models
{
    public partial class Doctors
    {
        public Doctors()
        {
            Appointments = new HashSet<Appointments>();
            DoctorServices = new HashSet<DoctorServices>();
        }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }

        public virtual ICollection<Appointments> Appointments { get; set; }
        public virtual ICollection<DoctorServices> DoctorServices { get; set; }
    }
}
