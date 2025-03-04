using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MainApp.Models;
using ServiceLayer.Services;
using AutoMapper;
using MainApp.Models.ViewModel;
using ModelLayer.Models;
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
    public async Task<IActionResult> SubmitAppointment([Bind(include:"Name, LastName, PhoneNumber, AppointmentDayId, AppointmentHourId")]
                                            AppointmentViewModel appointmentViewModel)
    {
        if (ModelState.IsValid)
        {
            var appointment =  _mapper.Map<Appointment>(appointmentViewModel);
            bool isAvailable = _appointmentHour.IsHourAvailable(appointment.AppointmentHourId, appointment.AppointmentDayId);
            if (!isAvailable)
            {
                TempData["hourIsNotAvailable"] = "!این ساعت در روز انتخاب شده در دسترس نیست";
                return RedirectToAction("Index");
            }
            _appointmentHour.setUnavailable(appointment.AppointmentHourId, appointment.AppointmentDayId);
            await _appointment.Add(appointment);                                    
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
