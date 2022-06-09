using Domain.Entities.Basic;
using Infrastructure.Attribute;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Map.Application.Basic
{
    [Application]
    internal class AdditionalUserDataMap : IdentityBaseEntityMap<ApplicationUser>
    {
        public AdditionalUserDataMap() : base()
        {
        }

        public override void Map(EntityTypeBuilder<ApplicationUser> builder)
        {
        }
    }
}