using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VoIP
{
    /// <summary>
    /// Interaction logic for SaveWindow.xaml
    /// </summary>
    public partial class SaveWindow : Window
    {
        public SaveWindow()
        {
            InitializeComponent();

            FontSizeHelper.Initialize(new FrameworkElement[]
            {
                PhoneNumberTextBox,
                PhoneNumberLabel,
                NameTextBox,
                NameLabel,
                StreetTextBox,
                StreetLabel,
                ZipCodeTextBox,
                ZipCodeLabel,
                CityTextBox,
                CityLabel,
                EmailTextBox,
                EmailLabel,
                CancelButton,
                SaveButton,
            });
        }

        public void SetNumber(string number)
        {
            PhoneNumberTextBox.Text = number;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validator.ValidatePhoneNumber(PhoneNumberTextBox.Text))
            {
                return;
            }
            MessageBox.Show("The contact was successfully save.", "Contact saved", MessageBoxButton.OK,
                MessageBoxImage.Information);
            Close();
        }
    }
}
