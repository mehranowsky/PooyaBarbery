using ModelLayer.Context;
using ModelLayer.Models;

namespace ServiceLayer.Services
{
    public class AppointmentHourService:GenericService<AppointmentHour>, IAppointmentHourService
    {
        public AppointmentHourService(BarberyDbContext context): base(context)
        {
            
        }
    }
}
