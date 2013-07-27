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
using Assignment2App.ServiceReference1;

namespace Assignment2App.Pages
{
    public partial class viewCollection : PhoneApplicationPage
    {
        public viewCollection()
        {
            InitializeComponent();
            // make call to SQL service when page loads
            // request to view all cd info and bind to listbox control

            Service1Client svc = new Service1Client();
            svc.ViewInfoCompleted += new EventHandler<ViewInfoCompletedEventArgs>(svc_ViewInfoCompleted);
            svc.ViewInfoAsync();
        }

        void svc_ViewInfoCompleted(object sender, ViewInfoCompletedEventArgs e)
        {
            if (e.Error == null)
            {

                // bind profiles to listbox
                listBox1.ItemsSource = e.Result;
                MessageBox.Show("CD collection downloaded!", "Success", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Problem viewing collection", "Unsuccessful", MessageBoxButton.OK);
                Console.WriteLine("An error occured:" + e.Error);
            }
        }
    }
}
