using Api.Framework.Base;
using Contract.Basic;
using Contract.Basic.Messaging.ApplicationUser;
using Contract.Basic.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Controllers.Basic
{
    public class UserController : BaseController
    {
        private readonly IApplicationUserContract _contract;

        public UserController(IApplicationUserContract contract)
        {
            _contract = contract;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCustomer(ApplicationUserViewModel model)
        {
            var statusRes = await _contract.AddNewCustomer(new AddNewCustomerRequest(model));

            return Response(statusRes);
        }
    }
}
