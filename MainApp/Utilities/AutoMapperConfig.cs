using AutoMapper;
using MainApp.Models.ViewModel;
using ModelLayer.Models;

namespace MainApp.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Appointment, AppointmentViewModel>().ReverseMap();
            // Add other mappings here
        }
    }
}
