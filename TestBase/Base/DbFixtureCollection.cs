using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestBase.Base
{
    [CollectionDefinition("DbCollection")]
    public class DbFixtureCollection : ICollectionFixture<DbFixture> { }
}
