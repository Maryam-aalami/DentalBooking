using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using LocalTest.Models;

namespace LocalTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DentalDbContext _context;

        public List<Doctor> Doctors { get; set; }
        public int? DoctorId{get;set;}
        public int? ServiceId{get;set;}

        public IndexModel(
            ILogger<IndexModel> logger,
            DentalDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            Doctors = _context.Doctors.ToList();
        }
    }
}