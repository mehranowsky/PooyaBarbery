using Microsoft.EntityFrameworkCore;
using ModelLayer.Context;
using ModelLayer.Models;

namespace ServiceLayer.Services
{
    public class AdminService : GenericService<Admin>, IAdminService
    {
        private readonly BarberyDbContext _context;
        public AdminService(BarberyDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<bool> IsAdmin(string username, string password)
        {
            return await _context.Admins.AnyAsync(a => a.Username == username && a.Password == password);
        }

    }
}
