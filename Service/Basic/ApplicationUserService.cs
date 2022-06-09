using Domain.Entities.Basic;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Service.Base;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Basic
{
    public class ApplicationUserService : BaseIdentityService<ApplicationUser, ApplicationDbContext>, IApplicationUserService
    {
        public ApplicationUserService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsExistByPhoneNumber(string phoneNumber)
        {
            return Entities.AnyAsync(m => m.PhoneNumber == phoneNumber);
        }

        public Task<bool> IsExistByEmail(string phoneNumber)
        {
            return Entities.AnyAsync(m => m.PhoneNumber == phoneNumber);
        }
    }
}
