using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace TestTaskCrypto.View.HomePage
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomeView : Window
    {
        public HomeView()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Properties.Settings.Default.languageCode);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.languageCode);
            InitializeComponent();
        }
    }
}
