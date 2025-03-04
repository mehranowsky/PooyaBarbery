using Microsoft.EntityFrameworkCore;
using ModelLayer.Context;
using ModelLayer.Models;

namespace ServiceLayer.Services
{
    public class AdminService : GenericService<Admin>, IAdminService
    {
        public AdminService(BarberyDbContext context):base(context)
        {
        }

        public async Task<Admin> GetAdmin(string username, string password)
        {
            return await _context.Admins.FirstOrDefaultAsync(a => a.Username == username && a.Password == password);
        }

    }
}
