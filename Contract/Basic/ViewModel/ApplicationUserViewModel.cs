using System;

namespace Contract.Basic.ViewModel
{
    public class ApplicationUserViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }

        public string PhoneNumber { get; set; }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value.ToLower(); }
        }


        public string BankAccountNumber { get; set; }
    }
}
