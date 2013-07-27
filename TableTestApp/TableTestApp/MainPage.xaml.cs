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
using TableTestApp.ServiceReference1;

namespace TableTestApp
{
    public partial class MainPage : PhoneApplicationPage
    {

        //PLEASE NOTE
        //THIS APPLICATION IS SET UP TO USE THE SERVICE RUNNING IN AZURE
        //THE SERVICE REFERENCE NEEDS CHANGING IF APPLICATION IS TO RUN WITH THE AZURE EMULATOR

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Create new serviceclient for cloud storage service
            Service1Client svc = new Service1Client();
            svc.addCDCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(svc_addCDCompleted);
            //Adds data from textboxes to the cloud table
            svc.addCDAsync(name.Text, artist.Text, title.Text, year.Text);
        }

        //shows message box when upload is completed
        void svc_addCDCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Added.");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //Create new serviceclient for cloud storage service
            Service1Client svc = new Service1Client();
            svc.getCDCompleted += new EventHandler<getCDCompletedEventArgs>(svc_getCDCompleted);
            //Searches for entry from the name entered into the returnedCD textbox
            svc.getCDAsync(returnedCD.Text);
        }

        //Outputs returned information to the user
        void svc_getCDCompleted(object sender, getCDCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                MessageBox.Show("Your CD: \nArtist - " + e.Result.Artist + "\nTitle - " + e.Result.Title + "\nYear - " + e.Result.Year);
            }
            else
                MessageBox.Show("No result.");
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            //Create new serviceclient for cloud storage service
            Service1Client svc = new Service1Client();
            svc.deleteCDCompleted += new EventHandler<deleteCDCompletedEventArgs>(svc_deleteCDCompleted);
            svc.deleteCDAsync(returnedCD.Text);
        }

        //shows message when entry is succesfully deleted
        void svc_deleteCDCompleted(object sender, deleteCDCompletedEventArgs e)
        {
            MessageBox.Show("Entry Deleted");
        }

    }
}