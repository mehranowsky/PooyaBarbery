using ModelLayer.Models;

namespace ServiceLayer.Services
{
    public interface IAdminService : IGenericService<Admin>
    {
        Task<Admin> GetAdmin(string username, string password);
    }
}
