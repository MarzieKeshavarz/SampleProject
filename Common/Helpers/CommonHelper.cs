using Common.Constants;
using PhoneNumbers;
using System.Text.RegularExpressions;

namespace Common.Helpers
{
    public static class CommonHelper
    {

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            email = email.Trim();

            var result = Regex.IsMatch(email, RegularExpressionConstants.Email, RegexOptions.IgnoreCase);

            return result;
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            phoneNumber = ClearNumber(phoneNumber);

            try
            {
                var instance = PhoneNumberUtil.GetInstance();

                var parsedPhonenumber = instance.Parse(phoneNumber, "");

                var type = instance.GetNumberType(parsedPhonenumber);

                if (type == PhoneNumberType.MOBILE)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static string ClearNumber(string number)
        {
            number = number.Trim();

            if (number.StartsWith("00"))
            {
                // Replace 00 at beginning with +
                number = "+" + number.Remove(0, 2);
            }

            return number;
        }

    
    }
}