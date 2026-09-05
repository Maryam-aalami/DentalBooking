using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LocalTest.Models
{
    public partial class DoctorServices
    {
        public int DoctorId { get; set; }
        public int ServiceId { get; set; }

        public virtual Doctors Doctor { get; set; }
        public virtual Services Service { get; set; }
    }
}
