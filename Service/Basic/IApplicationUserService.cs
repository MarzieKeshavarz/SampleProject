using Domain.Entities.Basic;
using Infrastructure.DbContexts;
using Service.Base;
using System.Threading.Tasks;

namespace Service.Basic
{
    public interface IApplicationUserService : IBaseIdentityService<ApplicationUser, ApplicationDbContext>
    {
        public Task<bool> IsExistByPhoneNumber(string phoneNumber);

        public Task<bool> IsExistByEmail(string phoneNumber);
    }
}
