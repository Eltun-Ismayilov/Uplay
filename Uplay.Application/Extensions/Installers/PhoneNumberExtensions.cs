using System.Text.RegularExpressions;

namespace Uplay.Application.Extensions.Installers
{
    public static class PhoneNumberExtensions
    {
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^\d{9}$";

            return Regex.IsMatch(phoneNumber, pattern);
        }

        public static bool IsValidPassword(string password)
        {
            string pattern = @"^(?=.*[A-Z])(?=.*[a-zA-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

            return Regex.IsMatch(password, pattern);
        }
    }
}
