using AutoMapper;
using MainApp.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelLayer.Models;
using ServiceLayer.Services;
using System.Threading.Tasks;

namespace MainApp.Area.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentService _appointment;
        private readonly IAppointmentDayService _appointmentDay;
        private readonly IAppointmentHourService _appointmentHour;
        private readonly IMapper _mapper;

        public AppointmentsController(IAppointmentService appointment, IAppointmentDayService appointmentDay,
                IAppointmentHourService appointmentHour, IMapper mapper)
        {
            _appointment = appointment;
            _appointmentDay = appointmentDay;
            _appointmentHour = appointmentHour;
            _mapper = mapper;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var appointments = await _appointment.GetAllAppointments();
            var appointmentViewModel = _mapper.Map<IEnumerable<AppointmentViewModel>>(appointments);
            var appointmentHours = await _appointmentHour.GetAll();
            var appointmentDays = await _appointmentDay.GetAll();

            ViewBag.AppointmentHours = appointmentHours;
            ViewBag.AppointmentDays = appointmentDays;
            return View(appointmentViewModel);
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _appointment.GetEntity(id.Value);
            var appointmentViewModel = _mapper.Map<PhoneNumberViewModel>(appointment);
            if (appointmentViewModel == null)
            {
                return NotFound();
            }
            
            return View(appointmentViewModel);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _appointment.GetEntity(id.Value);
            var appointmentViewModel = _mapper.Map<PhoneNumberViewModel>(appointment);
            if (appointmentViewModel == null)
            {
                return NotFound();
            }

            return View(appointmentViewModel);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _appointment.GetEntity(id);
            if (appointment != null)
            {
                _appointmentHour.setAvailable(appointment.AppointmentHourId, appointment.AppointmentDayId);
                await _appointment.Delete(appointment);
            }            
            return RedirectToAction(nameof(Index));
        }
    }
}
