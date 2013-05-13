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
    public partial class Page1 : PhoneApplicationPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            float ft, In, weight;
            float.TryParse(boxft.Text, out ft);
            float.TryParse(boxin.Text, out In);
            float.TryParse(boxWeight.Text, out weight);
            double inches = (ft * 12) + In;
            double BMI = (weight / (inches * inches)) * 703;
            boxBF.Text = BMI.ToString("N1");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            boxBF.Text = "";
            boxft.Text = "";
            boxin.Text = "";
            boxWeight.Text = "";
        }
    }
}