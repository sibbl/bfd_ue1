using System.Windows;

namespace VoIP
{
    public partial class SmsWindow : Window
    {
        public SmsWindow()
        {
            InitializeComponent();

            FontSizeHelper.Initialize(new FrameworkElement[]
            {
                NumberTextBox,
                CancelButton,
                SendButton,
                NumberLabel,
                MessageLabel
            });
        }

        public void SetNumber(string number)
        {
            NumberTextBox.Text = number;
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validator.ValidatePhoneNumber(NumberTextBox.Text))
            {
                return;
            }
            if (!Validator.ValidateSmsMessageText(MessageTextBox.Text))
            {
                return;
            }
            MessageBox.Show("The message was successfully sent.", "Message sent", MessageBoxButton.OK,
                MessageBoxImage.Information);
            Close();
        }
    }
}
