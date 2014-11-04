using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace VoIP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SmsWindow _smsWindow;
        private SaveWindow _saveWindow;
        private CallWindow _callWindow;

        public MainWindow()
        {
            InitializeComponent();
            Closing += (sender, args) =>
            {
                if (_smsWindow != null) _smsWindow.Close();
                if (_saveWindow != null) _saveWindow.Close();
                if (_callWindow != null) _callWindow.Close();
            };
            FontSizeHelper.Initialize(new FrameworkElement[]
            {
                NumberTextBox,
                DialButton0,
                DialButton1,
                DialButton2,
                DialButton3,
                DialButton4,
                DialButton5,
                DialButton6,
                DialButton7,
                DialButton8,
                DialButton9,
                DialButtonStar,
                DialButtonHash,
                DialButtonSave,
                DialButtonSms,
                DialButtonCall
            });
        }

        private void OnNumberClicked(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                var btn = sender as Button;
                NumberTextBox.Text += btn.Tag;
            }
        }

        private void OnCallClicked(object sender, RoutedEventArgs e)
        {
            if (!Validator.ValidatePhoneNumber(NumberTextBox.Text))
            {
                return;
            }
            if (_callWindow == null)
            {
                _callWindow = new CallWindow();
                _callWindow.Closed += (o, args) => { _callWindow = null; };
                _callWindow.SetNumber(NumberTextBox.Text);
                _callWindow.ShowDialog();
            }
        }
        private void OnSaveClicked(object sender, RoutedEventArgs e)
        {
            if (!Validator.ValidatePhoneNumber(NumberTextBox.Text))
            {
                return;
            }
            if (_saveWindow == null)
            {
                _saveWindow = new SaveWindow();
                _saveWindow.Closed += (o, args) => { _saveWindow = null; };
                _saveWindow.ShowDialog();
            }
        }
        private void OnSmsClicked(object sender, RoutedEventArgs e)
        {
            if (!Validator.ValidatePhoneNumber(NumberTextBox.Text))
            {
                return;
            }
            if (_smsWindow == null)
            {
                _smsWindow = new SmsWindow();
                _smsWindow.Closed += (o, args) => { _smsWindow = null; };
                _smsWindow.SetNumber(NumberTextBox.Text);
                _smsWindow.ShowDialog();
            }
        }
        private void OnExitClicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void OnKeyHelpClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You can use the following key strokes:\n\n1 to 9    Type number\nALT+S   Save number\nAlt+C    Call number\nAlt+M   Send SMS to number\nAlt+E     Exit application", "Available shortcuts");
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (!NumberTextBox.IsFocused && e.Key == Key.Back)
            {
                NumberTextBox.Undo();
            }
        }
    }
}
