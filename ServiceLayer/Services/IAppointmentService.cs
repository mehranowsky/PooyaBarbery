using ModelLayer.Models;

namespace ServiceLayer.Services
{
    public interface IAppointmentService : IGenericService<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAllAppointments();
    }
}
