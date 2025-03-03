using ModelLayer.Context;
using ModelLayer.Models;
using System.Runtime.CompilerServices;

namespace ServiceLayer.Services
{
    public class AppointmentHourService:GenericService<AppointmentHour>, IAppointmentHourService
    {        
        public AppointmentHourService(BarberyDbContext context): base(context)
        {
        }

        public bool IsHourAvailable(int hourId, int dayId)
        {
            var hour = _context.AppointmentHours.FirstOrDefault(h=> h.Id == hourId && h.DayId == dayId);
            if (hour.IsAvailable)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool setAvailable(int hourId, int dayId)
        {            
            try
            {
                var hour = _context.AppointmentHours.FirstOrDefault(h => h.Id == hourId && h.DayId == dayId);
                hour.IsAvailable = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool setUnavailable(int hourId, int dayId)
        {
            try
            {
                var hour = _context.AppointmentHours.FirstOrDefault(h => h.Id == hourId && h.DayId == dayId);
                hour.IsAvailable = false;                
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
