using ModelLayer.Context;
using ModelLayer.Models;

namespace ServiceLayer.Services
{
    public class AppointmentDayService : GenericService<AppointmentDay>, IAppointmentDayService
    {
        public AppointmentDayService(BarberyDbContext context):base(context)
        {
            
        }
    }
}
