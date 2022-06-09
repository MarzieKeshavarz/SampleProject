using Contract.Basic.ViewModel;
using Domain.Entities.Basic;

namespace Contract.Base.Profile
{
    internal class BasicProfile : AutoMapper.Profile
    {
        public BasicProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserViewModel>()
                .ReverseMap();
        }
    }
}
