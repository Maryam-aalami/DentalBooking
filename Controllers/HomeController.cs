using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LocalTest.Models;
using System;

namespace LocalTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly DentalDbContext _context;

        public HomeController(DentalDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new AppointmentViewModel
            {
                Doctors = _context.Doctors.ToList(),
                Services = _context.Services.ToList(),
                Appointment = new Appointment()
            };

            return View(viewModel);
        }
        
        [HttpGet]
public IActionResult GetServicesByDoctor(int doctorId)
{
    var services = _context.DoctorServices
        .Where(ds => ds.DoctorId == doctorId)
        .Join(
            _context.Services,
            ds => ds.ServiceId,
            s => s.ServiceId,
            (ds, s) => new
            {
                ServiceId = s.ServiceId,
                ServiceName = s.ServiceName
            })
        .ToList();

    return Json(services);
}

// [HttpPost]
// public IActionResult Create( Appointment appointment)
// {
//   try{
//  _context.Appointments.Add(appointment);
//     _context.SaveChanges();
//     return Ok("Appointment booked successfully!");
    
//   }
//   catch (Exception ex){
//     return BadRequest(ex.Message);
//   }
// }



[HttpPost]
public IActionResult Create(Appointment appointment)
{
    try
    {
        if (appointment.AppointmentId == 0)
        {
            _context.Appointments.Add(appointment);
        }
        else
        {
            var existingAppointment = _context.Appointments
                .FirstOrDefault(a => a.AppointmentId == appointment.AppointmentId);

            if (existingAppointment == null)
                return NotFound();

            existingAppointment.FirstName = appointment.FirstName;
            existingAppointment.LastName = appointment.LastName;
            existingAppointment.Mobile = appointment.Mobile;
            existingAppointment.Email = appointment.Email;
            existingAppointment.DoctorId = appointment.DoctorId;
            existingAppointment.ServiceId = appointment.ServiceId;
            existingAppointment.AppointmentDate = appointment.AppointmentDate;
            existingAppointment.AppointmentTime = appointment.AppointmentTime;
        }

        _context.SaveChanges();

        return Ok("Appointment booked successfully!");
    }
    catch (Exception ex)
    {
        return BadRequest(ex.Message);
    }
}


[HttpGet]
public IActionResult GetAppointment(int appointmentId)
{
    var appointment = _context.Appointments
        .FirstOrDefault(a => a.AppointmentId == appointmentId);

    if (appointment == null)
        return NotFound();

    return Json(appointment);
}



[HttpGet]
public IActionResult GetAppointments(string mobile)
{
     var appointments = _context.Appointments
        .Where(a => a.Mobile == mobile)
        .Join(
            _context.Doctors,
            a => a.DoctorId,
            d => d.DoctorId,
            (a, d) => new
            {
                a.FirstName,
                a.LastName,
                a.Mobile,
                DoctorName = d.DoctorName,
                a.ServiceId,
                a.AppointmentDate,
                a.AppointmentTime,
                a.AppointmentId
            })
        .Join(
            _context.Services,
            a => a.ServiceId,
            s => s.ServiceId,
            (a, s) => new
            {
                a.FirstName,
                a.LastName,
                a.Mobile,
                a.DoctorName,
                ServiceName = s.ServiceName,
                a.AppointmentDate,
                a.AppointmentTime,
                a.AppointmentId,
              
            })
        .ToList();

    return Json(appointments);
}


[HttpPost]
public IActionResult DeleteAppointment(int appointmentId)
{
    try
    {
        var appointment = _context.Appointments
            .FirstOrDefault(a => a.AppointmentId == appointmentId);

        if (appointment == null)
            return NotFound();

        _context.Appointments.Remove(appointment);
        _context.SaveChanges();

        return Ok();
    }
    catch (Exception ex)
    {
        return BadRequest(ex.Message);
    }
}






    }
    
}