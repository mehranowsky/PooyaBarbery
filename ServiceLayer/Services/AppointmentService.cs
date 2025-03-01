using ModelLayer.Context;
using ModelLayer.Models;

namespace ServiceLayer.Services
{
    public class AppointmentService : GenericService<Appointment>, IAppointmentService
    {
        public AppointmentService(BarberyDbContext context):base(context)
        {
            
        }
        
    }
}
