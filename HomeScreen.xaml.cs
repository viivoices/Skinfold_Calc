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

namespace ApplicationLifecycle
{
    public partial class HomeScreen : PhoneApplicationPage
    {
        public HomeScreen()
        {

            InitializeComponent();
            
             
            
        }
          
          private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/SecondPage.xaml", UriKind.Relative));
           
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
            
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/User.xaml", UriKind.Relative));
            
           
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/User.xaml", UriKind.Relative));
            button4.Width = 0;
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you for downloading my app. I hope you enjoy it. (Make sure to go in your profile and hit save after calculating your BF%. This will allow you to keep your last BF% for viewing the next time you start the app). Just a reminder, please rate my app and leave a comment in the marketplace (let me know what you think of the app). Thank you.");
        }
    }
}
