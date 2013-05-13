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
    public partial class User : PhoneApplicationPage
    {
        public User()
        {
            InitializeComponent();
            TravelReportInfo travelReportInfo = ((App.Current.RootVisual as PhoneApplicationFrame).DataContext as TravelReportInfo);
           
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Utils.SaveTravelReport((App.Current.RootVisual as PhoneApplicationFrame).DataContext as TravelReportInfo,
      "TravelReportInfo.dat", false);
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Utils.ClearTravelReport(((App.Current.RootVisual as PhoneApplicationFrame).DataContext as TravelReportInfo));
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            TravelReportInfo travelReportInfo = ((App.Current.RootVisual as PhoneApplicationFrame).DataContext as TravelReportInfo);
            travelReportInfo.Note = "";

        }
    }
}
    