using ModelLayer.Models;

namespace ServiceLayer.Services
{
    public interface IAdminService : IGenericService<Admin>
    {
        Task<bool> IsAdmin(string username, string password);
    }
}
