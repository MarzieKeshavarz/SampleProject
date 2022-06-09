using Contract.Basic.Messaging.ApplicationUser;
using System.Threading.Tasks;

namespace Contract.Basic
{
    public interface IApplicationUserContract
    {
        public Task<AddNewCustomerResponse> AddNewCustomer(AddNewCustomerRequest request);
    }
}
