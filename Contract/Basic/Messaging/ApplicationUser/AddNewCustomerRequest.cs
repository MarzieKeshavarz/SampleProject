using Contract.Base.Messaging;
using Contract.Basic.ViewModel;

namespace Contract.Basic.Messaging.ApplicationUser
{
    public class AddNewCustomerRequest : BaseApiRequest<ApplicationUserViewModel>
    {
        public AddNewCustomerRequest(ApplicationUserViewModel viewModel)
        {
            ViewModel = viewModel;
        }
    }
}