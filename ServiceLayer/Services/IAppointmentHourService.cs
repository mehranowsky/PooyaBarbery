using ModelLayer.Models;

namespace ServiceLayer.Services
{
    public interface IAppointmentHourService: IGenericService<AppointmentHour>
    {
        bool IsHourAvailable(int hourId, int dayId);
        bool setUnavailable(int hourId, int dayId);
        bool setAvailable(int hourId, int dayId);
    }
}
