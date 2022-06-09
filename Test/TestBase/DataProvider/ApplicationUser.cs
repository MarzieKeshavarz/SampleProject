using Contract.Basic.Messaging.ApplicationUser;
using Domain.Entities.Basic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBase.DataProvider
{

    public class AddNewCustomerRequestTest : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
              new AddNewCustomerRequest(
               new Contract.Basic.ViewModel.ApplicationUserViewModel  {
                FirstName = "Marzie",
                LastName = "Keshavarz",
                BankAccountNumber = "11111111111",
                BirthDay = new DateTime(1997, 6, 26),
                Email = "Marziekeshavarz97@gmail.com",
                PhoneNumber = "00989386693107"
            })
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
  
    public class ApplicationUserTest : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
            new ApplicationUser  {
                FirstName = "Marzie",
                LastName = "Keshavarz",
                BankAccountNumber = "11111111111",
                BirthDay = new DateTime(1997, 6, 26),
                Email = "Marziekeshavarz97@gmail.com",
                PhoneNumber = "00989386693107",
                IsDeleted = false

            },
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
