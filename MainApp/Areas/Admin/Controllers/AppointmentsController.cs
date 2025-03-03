using AutoMapper;
using MainApp.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelLayer.Models;
using ServiceLayer.Services;

namespace MainApp.Area.Admin.Controllers
{
    [Area("Admin")]
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
            ViewBag.AppointmentHours = await _appointmentHour.GetAll();
            return View(await _appointment.GetAll());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _appointment.GetEntity(id.Value);
            if (appointment == null)
            {
                return NotFound();
            }

            ViewData["AppointmentDayId"] = new SelectList(await _appointmentDay.GetAll(), "Id", "Day", appointment.AppointmentDayId);
            ViewData["AppointmentHourId"] = new SelectList(await _appointmentHour.GetAll(), "Id", "Hour", appointment.AppointmentHourId);
            return View(appointment);
        }


        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _appointment.GetEntity(id.Value);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["AppointmentDayId"] = new SelectList(await _appointmentDay.GetAll(), "Id", "Day", appointment.AppointmentDayId);
            ViewData["AppointmentHourId"] = new SelectList(await _appointmentHour.GetAll(), "Id", "Hour", appointment.AppointmentHourId);
            return View(appointment);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,PhoneNumber,AppointmentDayId,AppointmentHourId")] AppointmentViewModel appointmentViewModel)
        {

            if (ModelState.IsValid)
            {
                var appointment = _mapper.Map<AppointmentViewModel, Appointment>(appointmentViewModel);
                _appointment.Update(appointment);
                await _appointment.Save();
                return RedirectToAction(nameof(Index));
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
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _appointment.GetEntity(id);
            if (appointment != null)
            {
                _appointment.Delete(appointment);
            }

            await _appointment.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
