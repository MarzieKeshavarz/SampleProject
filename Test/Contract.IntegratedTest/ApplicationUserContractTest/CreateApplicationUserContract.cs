using AutoMapper;
using Common.Helpers;
using Contract.Basic;
using Contract.Basic.Messaging.ApplicationUser;
using Contract.Basic.ViewModel;
using Domain.Entities.Basic;
using FluentAssertions;
using Moq;
using Service.Basic;
using ServiceTestBase.Base;
using System;
using System.Linq;
using System.Threading.Tasks;
using TestBase.DataProvider;
using Xunit;

namespace Contract.IntegratedTest.ApplicationUserContractTest
{
    public class ApplicationUserContractTest
    {
        private IMapper _mapper;
        public ApplicationUserContractTest()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<ApplicationUser, ApplicationUserViewModel>().ReverseMap();
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
        }

        [Theory]
        [ClassData(typeof(AddNewCustomerRequestTest))]
        public async Task ApplicationUser_Should_Be_Created(AddNewCustomerRequest request)
        {
            var applicationUserService = new Mock<IApplicationUserService>();
            applicationUserService.Setup(m => m.AddAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(new ApplicationUser());
            applicationUserService.Setup(m => m.SaveChangesAsync()).ReturnsAsync(1);
           
            var applicationUserContract = new ApplicationUserContract(applicationUserService.Object, _mapper); ;
           
            var resUser = await applicationUserContract.AddNewCustomer(request);

            resUser.Should().NotBeNull();
            resUser.IsSucceed.Should().Be(true);
            resUser.Messages.Should().NotBeNull();
            resUser.Messages.Should().HaveCountGreaterThan(0);
            resUser.Messages.Select(x=>x.Body).Should().Contain("The process was successful.");
        }
        
        [Theory]
        [InlineData("MarzieKeshavarz97@gmail.com",true)]
        [InlineData("MarzieKeshavarz97@a.a",true)]
        [InlineData("MarzieKeshavarz97",false)]
        [InlineData("@",false)]
        [InlineData(".com",false)]
        public void ApplicationUser_Should_Has_ValidEmail(string email,bool expect)
        {

            var resValidEmail = CommonHelper.IsValidEmail(email);
            resValidEmail.Should().Be(expect);
        }

        [Theory]
        [InlineData("00989386693107",true)]
        [InlineData("00989127215825", true)]
        [InlineData("09386693107", false)]
        [InlineData("a",false)]
        [InlineData("",false)]
        public void ApplicationUser_Should_Has_ValidPhoneNumber(string phoneNumber,bool expect)
        {

            var resValidEmail = CommonHelper.IsValidPhoneNumber(phoneNumber);
            resValidEmail.Should().Be(expect);
        }




    }
}