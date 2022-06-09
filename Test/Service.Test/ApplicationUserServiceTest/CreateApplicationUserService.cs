using Domain.Entities.Basic;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Service.Basic;
using ServiceTestBase.Base;
using System;
using System.Threading.Tasks;
using TestBase.DataProvider;
using Xunit;

namespace Service.Test.ApplicationUserServiceTest
{
    [Collection("DbCollection")]
    public class ApplicationUserServiceTest : Testing
    {

        [Theory]
        [ClassData(typeof(ApplicationUserTest))]
        public async Task ApplicationUser_Should_Be_Created(ApplicationUser user)
        {
            var applicationUserService = new ApplicationUserService(_context);

            var resUser = await applicationUserService.AddAndSaveAsync(user);
                   
            resUser.Should().NotBeNull();
            resUser.FirstName.Should().Be(user.FirstName);
        }

        [Theory]
        [ClassData(typeof(ApplicationUserTest))]
        public async Task ApplicationUser_Should_Require_UniquePhoneNumber(ApplicationUser user)
        {
            var applicationUserService = new ApplicationUserService(_context);

            await applicationUserService.AddAndSaveAsync(user);
            
            var resDup = await applicationUserService.IsExistByPhoneNumber(user.PhoneNumber);
            resDup.Should().BeTrue();
        }

        [Theory]
        [ClassData(typeof(ApplicationUserTest))]
        public async Task ApplicationUser_Should_Require_UniqueEmail(ApplicationUser user)
        {
            var applicationUserService = new ApplicationUserService(_context);

            await applicationUserService.AddAndSaveAsync(user);
            
            var resDup = await applicationUserService.IsExistByEmail(user.PhoneNumber);
            resDup.Should().BeTrue();
        }
    }
}