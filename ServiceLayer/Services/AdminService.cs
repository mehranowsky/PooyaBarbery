using ModelLayer.Context;
using ModelLayer.Models;

namespace ServiceLayer.Services
{
    public class AdminService : GenericService<Admin>, IAdminService
    {
        public AdminService(BarberyDbContext context):base(context)
        {            
        }
        
    }
}
