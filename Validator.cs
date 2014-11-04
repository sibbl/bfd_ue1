using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VoIP
{
    public static class Validator
    {
        public static bool ValidatePhoneNumber(string number, bool showErrorMessage = true)
        {
            var isValid = !String.IsNullOrWhiteSpace(number); ;

            if (showErrorMessage && !isValid)
            {
                MessageBox.Show("Please enter a valid phone number!", "Invalid phone number",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return isValid;
        }

        public static bool ValidateSmsMessageText(string message, bool showErrorMessage = true)
        {
            var isValid = !String.IsNullOrWhiteSpace(message); ;

            if (showErrorMessage && !isValid)
            {
                MessageBox.Show("Please enter a valid message!", "Invalid message",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return isValid;
        }
    }
}
