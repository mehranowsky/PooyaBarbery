using Microsoft.EntityFrameworkCore;
using ModelLayer.Context;
using ModelLayer.Models;

namespace ServiceLayer.Services
{
    public class AppointmentService : GenericService<Appointment>, IAppointmentService
    {
        public AppointmentService(BarberyDbContext context):base(context)
        {
            
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            return await _context.Appointments.
                OrderBy(a=>a.AppointmentDayId)
                .ThenBy(a=> a.AppointmentHourId).ToListAsync();
        }
    }
}
