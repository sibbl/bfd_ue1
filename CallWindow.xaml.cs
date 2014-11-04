using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    /// Interaction logic for CallWindow.xaml
    /// </summary>
    public partial class CallWindow : Window
    {
        private SoundPlayer _dialingSound;
        public CallWindow()
        {
            InitializeComponent();

            FontSizeHelper.Initialize(new FrameworkElement[]
            {
                HangUpButton,
                CallingTextBlock
            });


            _dialingSound = new SoundPlayer(Properties.Resources.DialingSound);
            Closing += (sender, args) => _dialingSound.Stop();
            Loaded += (sender, args) => _dialingSound.PlayLooping();
        }

        public void SetNumber(string number)
        {
            PhoneNumberTextBlock.Text = number;
        }
    }
}
