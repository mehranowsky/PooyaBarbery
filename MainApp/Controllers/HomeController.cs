using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MainApp.Models;
using ServiceLayer.Services;
using AutoMapper;

namespace MainApp.Controllers;

public class HomeController : Controller
{
    private readonly IMapper _mapper;
    private readonly IAppointmentService _appointment;
    private readonly IAppointmentDayService _appointmentDay;
    private readonly IAppointmentHourService _appointmentHour;
    public HomeController(IAppointmentService appointment, IAppointmentDayService appointmentDay, IAppointmentHourService appointmentHour, IMapper mapper)
    {
        _mapper = mapper;
        _appointment = appointment;
        _appointmentDay = appointmentDay;
        _appointmentHour = appointmentHour;
    }
    public IActionResult Index()
    {
        ViewBag.AppointmentDays = _appointmentDay.GetAll();
        ViewBag.AppointmentHours = _appointmentHour.GetAll();
        return View();
    }

    [Route("/submit-appointment")]
    [HttpPost]
    public IActionResult SubmitAppointment()
    {
        ViewBag.message = "اطلاعات شما با موفقیت ثبت شد";
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
