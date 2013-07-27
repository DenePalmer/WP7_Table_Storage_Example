using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.WindowsAzure.Samples.Phone.Identity.AccessControl;

namespace Assignment2App
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            var simpleWebTokenStore = Application.Current.Resources["swtStore"] as SimpleWebTokenStore;

            var name = simpleWebTokenStore.SimpleWebToken.Claims[ClaimTypes.Name];

            textBlock2.Text = name.ToString();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/addCD.xaml", UriKind.Relative));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/viewCollection.xaml", UriKind.Relative));
        }
    }
}