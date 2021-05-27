using Appointment_App.Services;
using Appointment_App.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_App.Controllers
{
    //[Authorize(Roles = Helper.Admin)]
    [Authorize]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        public IActionResult Index()
        {
            ViewBag.Duration = Helper.GetTimeDropDown();
          ViewBag.DoctorList =  _appointmentService.GetDoctorList();
          ViewBag.PatientList = _appointmentService.GetPatientList();

            return View();
        }
    }
}
