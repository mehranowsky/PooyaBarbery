using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MainApp.Models;
using ServiceLayer.Services;
using AutoMapper;
using MainApp.Models.ViewModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ModelLayer.Models;
using ServiceLayer;
using ModelLayer.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

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
    public async Task<IActionResult> Index()
    {
        ViewBag.AppointmentDays = await _appointmentDay.GetAll();
        ViewBag.AppointmentHours = await _appointmentHour.GetAll();
        return View();
    }

    [Route("/submit-appointment")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SubmitAppointment([Bind(include:"Name, LastName, PhoneNumber, AppointmentDayId, AppointmentHourId")]
                                            AppointmentViewModel appointmentViewModel)
    {
        if (ModelState.IsValid)
        {
            var appointment =  _mapper.Map<AppointmentViewModel, Appointment>(appointmentViewModel);
            bool isAvailable = _appointmentHour.IsHourAvailable(appointment.AppointmentHourId, appointment.AppointmentDayId);
            if (!isAvailable)
            {
                TempData["hourIsNotAvailable"] = "!این ساعت در روز انتخاب شده در دسترس نیست";
                return RedirectToAction("Index");
            }
            _appointment.Add(appointment);
            _appointmentHour.setUnavailable(appointment.AppointmentHourId, appointment.AppointmentDayId);            
            _appointmentHour.Save();
            TempData["success"] = "اطلاعات شما با موفقیت ثبت شد";
            return RedirectToAction("Index");
        }
        TempData["error"] = "اطلاعات وارد شده نادرست میباشد!";
        return RedirectToAction("Index");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
