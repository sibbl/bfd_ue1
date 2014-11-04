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
    }
}
