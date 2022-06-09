using AutoMapper;
using Common.Helpers;
using Contract.Base;
using Contract.Basic.Messaging.ApplicationUser;
using Domain.Entities.Basic;
using Microsoft.Extensions.Logging;
using Service.Basic;
using System;
using System.Threading.Tasks;

namespace Contract.Basic
{

    public class ApplicationUserContract : BaseContract, IApplicationUserContract
    {
        private readonly IApplicationUserService _applicationUserService;

        public ApplicationUserContract(IApplicationUserService applicationUserService,
            IMapper mapper) : base(mapper)
        {
            _applicationUserService = applicationUserService;
        }

        public async Task<AddNewCustomerResponse> AddNewCustomer(AddNewCustomerRequest request)
        {
            var response = new AddNewCustomerResponse();

            try
            {
                if (!CommonHelper.IsValidEmail(request.ViewModel.Email))
                {
                    response.Failed();

                    response.FailedMessage("Email is not correct");

                    return response;
                }

                if (!CommonHelper.IsValidPhoneNumber(request.ViewModel.PhoneNumber))
                {
                    response.Failed();

                    response.FailedMessage("PhoneNumber is not correct");

                    response.FailedMessage("e.g. 00989127215825");

                    return response;
                }

                if (await _applicationUserService.IsExistByEmail(request.ViewModel.Email))
                {
                    response.Failed();

                    response.FailedMessage("User already exist with this Email!");

                    return response;
                }

                if (await _applicationUserService.IsExistByPhoneNumber(request.ViewModel.PhoneNumber))
                {
                    response.Failed();

                    response.FailedMessage("User already exist with this PhoneNumber!");

                    return response;
                }

                var model = _mapper.Map<ApplicationUser>(request.ViewModel);

                if (model is null)
                {
                    response.Failed();

                    response.FailedMessage();

                    return response;
                }

                await _applicationUserService.AddAsync(model);

                if (!((await _applicationUserService.SaveChangesAsync()) > 0))
                {
                    response.Failed();

                    response.FailedMessage();

                    return response;
                }

                response.Succeed();

                response.SuccessMessage();

                return response;
            }
            catch (Exception e)
            {
                response.Failed();

                response.FailedMessage();

                return response;
            }
        }
    }
}