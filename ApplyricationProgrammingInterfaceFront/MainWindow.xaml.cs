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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ApplyricationProgrammingInterfaceBack;

namespace ApplyricationProgrammingInterfaceFront
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonGo_Click(object sender, RoutedEventArgs e)
        {
            var lyrics = API.GetLyric(API.GetUrl(TextBoxArtist.Text, TextBoxTitle.Text));
            if (lyrics != "") TextBlockLyrics.Text = lyrics;
            else TextBlockLyrics.Text = "Lyrics Not Found";
        }
    }
}
