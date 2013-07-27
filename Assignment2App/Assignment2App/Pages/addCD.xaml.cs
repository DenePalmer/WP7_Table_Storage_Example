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
    public partial class addCD : PhoneApplicationPage
    {
        public addCD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // set value for uploading to cloud SQL database for YOUR UNIQUE guid
            string storageGuid = "Guid: c9c5673b-e773-441d-acaa-968095b28662";
            Guid storageId = Guid.Parse(storageGuid);
            // create new serviceclient instance for our cloud storage service and upload our data using AddImageAsync
            Service1Client svc = new Service1Client();
            svc.AddCDCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(svc_AddCDCompleted);
            // pass our guid, and title, artist and year from textblocks
            string artist = ("Artist: " + textBox1.Text);
            string title = ("Title: " + textBox2.Text);
            string year = ("Year: " + textBox3.Text);
            //svc.AddCDAsync(storageId, textBox1.Text, textBox2.Text, textBox3.Text);
            svc.AddCDAsync(storageId, artist, title, year);
         }

        // displays message if new profile has been added  to database successfully
        void svc_AddCDCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                MessageBox.Show("CD info added!", "Success", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Problem adding CD info", "Unsuccessful", MessageBoxButton.OK);
                Console.WriteLine("An error occured:" + e.Error);
            }
        }
        
    }
}