

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
  public partial class SecondPage : PhoneApplicationPage
  {
    public SecondPage()
    {
      InitializeComponent();
      boxFemale.Width = 0;
      boxMale.Width = 0;
    }

    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
      //Trace the event for debug purposes
      Utils.Trace("Navigated To SecondPage");

      //Check if page state has saved focus and apply it back
      if (State.ContainsKey("FocusedElement"))
      {
        Control focusedElement = this.FindName(State["FocusedElement"] as string) as Control;

        if (null != focusedElement)
          focusedElement.Focus();
      }

      base.OnNavigatedTo(e);
    }

    protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
    {
      //Trace the event for debug purposes
      Utils.Trace("Navigated From MainPage");

      //Remove focused element from previous time if any
      if (State.ContainsKey("FocusedElement"))
        State.Remove("FocusedElement");

      //If some input control is in focus, save it to the page state
      object obj = FocusManager.GetFocusedElement();
      if (null != obj)
      {
        string focusedControl = (obj as FrameworkElement).Name;
        State.Add("FocusedElement", focusedControl);
      }

      base.OnNavigatedFrom(e);
    }

    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
      //TODO: Save functionality here
      Utils.SaveTravelReport((App.Current.RootVisual as PhoneApplicationFrame).DataContext as TravelReportInfo, 
        "TravelReportInfo.dat", false);
    }



    private void buttonClear_Click(object sender, RoutedEventArgs e)
    {

    }

    private void button1_Click(object sender, RoutedEventArgs e)
    {
       
        boxMale.Width = 120;
        float s1, s3, s4, s5, s6, age, weight;


        float.TryParse(boxTriceps.Text, out s1);
        float.TryParse(boxChest.Text, out s3);
        float.TryParse(boxAbdomen.Text, out s4);
        float.TryParse(boxSupraillium.Text, out s5);
        float.TryParse(boxThigh.Text, out s6);

        float.TryParse(boxAge.Text, out age);
        float.TryParse(boxWeight.Text, out weight);
        float sumMale = s3 + s4 + s6;
        float sumFemale = s1 + s5 + s6;
        double sumMale2 = (s3 + s4 + s6) * (s3 + s4 + s6);
        double sumFemale2 = (s1 + s5 + s6) * (s1 + s5 + s6);
        double bodyD = ((1.1093800 - (0.0008267 * sumMale) + (0.0000016 * sumMale2) - (0.0002574 * age)));
        double bfMale = ((((4.95 / bodyD)) - 4.5) * 100);
        double bodyDFemale = ((1.0994921 - (0.0009929 * sumFemale) + (0.0000023 * sumFemale2) - (0.0001392 * age)));
        double bfFemale = ((((4.95 / bodyDFemale)) - 4.5) * 100);
        double fatinLbs = weight * (bfMale / 100);
        double fatinLbs2 = weight * (bfFemale / 100);
        double lbmmale = -1 * (fatinLbs - weight);
        double lbmfemale = fatinLbs2 - weight;
        boxMale.Text = bfMale.ToString("N2");

        boxBodyFat.Text = fatinLbs.ToString("N2");

        boxLBMMale.Text = lbmmale.ToString("N2");

        //Male textbox for levels
        if (bfMale < 5)
        {
            textEssintialFat.Opacity = 1;
            textAthleteM.Opacity = 0;
            textFitM.Opacity = 0;
            textOverweightM.Opacity = 0;
            textObeaseM.Opacity = 0;
        }
        if (bfMale >= 5 && bfMale < 14)
        {
            textAthleteM.Opacity = 1;
            textFitM.Opacity = 0;
            textOverweightM.Opacity = 0;
            textObeaseM.Opacity = 0;
            textEssintialFat.Opacity = 0;
        }
        if (bfMale > 14 && bfMale < 18)
        {
            textFitM.Opacity = 1;
            textOverweightM.Opacity = 0;
            textObeaseM.Opacity = 0;
            textAthleteM.Opacity = 0;
            textEssintialFat.Opacity = 0;
        }
        if (bfMale > 18 && bfMale < 26)
        {
            textOverweightM.Opacity = 1;
            textObeaseM.Opacity = 0;
            textAthleteM.Opacity = 0;
            textFitM.Opacity = 0;
            textEssintialFat.Opacity = 0;
        }
        if (bfMale >= 26)
        {
            textObeaseM.Opacity = 1;
            textAthleteM.Opacity = 0;
            textFitM.Opacity = 0;
            textOverweightM.Opacity = 0;
            textEssintialFat.Opacity = 0;


        }
    }

    private void button2_Click(object sender, RoutedEventArgs e)
    {
        boxFemale.Width = 120;
        float s1, s3, s4, s5, s6, age, weight;


        float.TryParse(boxTriceps.Text, out s1);
        float.TryParse(boxChest.Text, out s3);
        float.TryParse(boxAbdomen.Text, out s4);
        float.TryParse(boxSupraillium.Text, out s5);
        float.TryParse(boxThigh.Text, out s6);

        float.TryParse(boxAge.Text, out age);
        float.TryParse(boxWeight.Text, out weight);
        float sumMale = s3 + s4 + s6;
        float sumFemale = s1 + s5 + s6;
        double sumMale2 = (s3 + s4 + s6) * (s3 + s4 + s6);
        double sumFemale2 = (s1 + s5 + s6) * (s1 + s5 + s6);
        double bodyD = ((1.1093800 - (0.0008267 * sumMale) + (0.0000016 * sumMale2) - (0.0002574 * age)));
        double bfMale = ((((4.95 / bodyD)) - 4.5) * 100);
        double bodyDFemale = ((1.0994921 - (0.0009929 * sumFemale) + (0.0000023 * sumFemale2) - (0.0001392 * age)));
        double bfFemale = ((((4.95 / bodyDFemale)) - 4.5) * 100);
        double fatinLbs = weight * (bfMale / 100);
        double fatinLbs2 = weight * (bfFemale / 100);
        double lbmmale = fatinLbs - weight;
        double lbmfemale = -1 * (fatinLbs2 - weight);
        boxMale.Text = bfMale.ToString();
        boxFemale.Text = bfFemale.ToString("N2");

        boxFatLbsFemale.Text = fatinLbs2.ToString("N2");

        boxLBMFemale.Text = lbmfemale.ToString("N2");


        //Female textbox Fat Levels
        if (bfFemale < 13)
        {
            textEssintialFatW.Opacity = 1;
            textAthleteW.Opacity = 0;
            textFitW.Opacity = 0;
            textAcceptableW.Opacity = 0;
            textObeaseW.Opacity = 0;
        }
        if (bfFemale < 21 && bfFemale > 13)
        {
            textAthleteW.Opacity = 1;
            textFitW.Opacity = 0;
            textAcceptableW.Opacity = 0;
            textObeaseW.Opacity = 0;
            textEssintialFatW.Opacity = 0;
        }
        if (bfFemale < 25 && bfFemale > 20)
        {
            textFitW.Opacity = 1;
            textAcceptableW.Opacity = 0;
            textObeaseW.Opacity = 0;
            textAthleteW.Opacity = 0;
            textEssintialFatW.Opacity = 0;

        }
        if (bfFemale < 32 && bfFemale > 24)
        {
            textAcceptableW.Opacity = 1;
            textObeaseW.Opacity = 0;
            textFitW.Opacity = 0;
            textAthleteW.Opacity = 0;
            textEssintialFatW.Opacity = 0;

        }
        if (bfFemale >= 32)
        {
            textObeaseW.Opacity = 1;
            textFitW.Opacity = 0;
            textAthleteW.Opacity = 0;
            textEssintialFatW.Opacity = 0;
            textAcceptableW.Opacity = 0;
        }
    }

    private void checkBox1_Checked(object sender, RoutedEventArgs e)
    {

        boxTriceps.IsEnabled = false;
        boxSupraillium.IsEnabled = false;
        boxTriceps.Opacity = 0;
        boxSupraillium.Opacity = 0;
        textBlock6.Opacity = 0;
        textBlock7.Opacity = 0;
        boxChest.Opacity = 1;
        boxChest.IsEnabled = true;
        boxAbdomen.Opacity = 1;
        boxAbdomen.IsEnabled = true;
        textBlock3.Opacity = 1;
        textBlock4.Opacity = 1;
        checkBox2.IsChecked = false;
        button2.Height = 0;
        //Male
        textMale.Opacity = 1;
        boxBodyFat.Opacity = 1;
        boxLBMMale.Opacity = 1;
        boxMale.Opacity = 1;
        textFatlbsMale.Opacity = 1;
        textLBMMale.Opacity = 1;
        textBFMale.Opacity = 1;
        //Male Fat Levels
        textObeaseM.Opacity = 0;
        textAthleteM.Opacity = 0;
        textFitM.Opacity = 0;
        textOverweightM.Opacity = 0;
        textEssintialFat.Opacity = 0;

        //Female Fat Levels
        textEssintialFatW.Opacity = 0;
        textAthleteW.Opacity = 0;
        textFitW.Opacity = 0;
        textAcceptableW.Opacity = 0;
        textObeaseW.Opacity = 0;

        //Female
        textFemale.Opacity = 0;
        textFatlbsFemale.Opacity = 0;
        textLBMFemale.Opacity = 0;
        textBFFemale.Opacity = 0;
        boxFatLbsFemale.Opacity = 0;
        boxLBMFemale.Opacity = 0;
        boxFemale.Opacity = 0;
    }

    private void checkBox2_Checked(object sender, RoutedEventArgs e)
    {
        boxTriceps.IsEnabled = true;
        boxSupraillium.IsEnabled = true;
        boxTriceps.Opacity = 1;
        boxSupraillium.Opacity = 1;
        textBlock6.Opacity = 1;
        textBlock7.Opacity = 1;
        boxChest.Opacity = 0;
        boxChest.IsEnabled = false;
        boxAbdomen.Opacity = 0;
        boxAbdomen.IsEnabled = false;
        textBlock3.Opacity = 0;
        textBlock4.Opacity = 0;
        checkBox1.IsChecked = false;
        button2.Height = 72;
        //Female
        textFemale.Opacity = 1;
        textFatlbsFemale.Opacity = 1;
        textLBMFemale.Opacity = 1;
        textBFFemale.Opacity = 1;
        boxFatLbsFemale.Opacity = 1;
        boxLBMFemale.Opacity = 1;
        boxFemale.Opacity = 1;
        //Fat Male Levels
        textObeaseM.Opacity = 0;
        textAthleteM.Opacity = 0;
        textFitM.Opacity = 0;
        textOverweightM.Opacity = 0;
        textEssintialFat.Opacity = 0;
        //Fat Female Levels
        textEssintialFatW.Opacity = 0;
        textAthleteW.Opacity = 0;
        textFitW.Opacity = 0;
        textAcceptableW.Opacity = 0;
        textObeaseW.Opacity = 0;

        //Male
        textMale.Opacity = 0;
        boxBodyFat.Opacity = 0;
        boxLBMMale.Opacity = 0;
        boxMale.Opacity = 0;
        textFatlbsMale.Opacity = 0;
        textLBMMale.Opacity = 0;
        textBFMale.Opacity = 0;
    }

    private void button3_Click(object sender, RoutedEventArgs e)
    {
        //boxAge.Text = "";
        //boxWeight.Text = "";
        boxTriceps.Text = "";

        boxChest.Text = "";
        boxAbdomen.Text = "";
        boxSupraillium.Text = "";
        boxThigh.Text = "";

        boxBodyFat.Text = "";
        boxLBMMale.Text = "";
        boxLBMFemale.Text = "";
      //  boxFemale.Text = "";
       // boxMale.Text = "";
        boxMale.Width = 0;
        boxFemale.Width = 0;
        boxFatLbsFemale.Text = "";
        textObeaseW.Opacity = 0;
        textFitW.Opacity = 0;
        textAthleteW.Opacity = 0;
        textEssintialFatW.Opacity = 0;
        textAcceptableW.Opacity = 0;
        textMale.Opacity = 0;
        boxBodyFat.Opacity = 0;
        boxLBMMale.Opacity = 0;
        boxMale.Opacity = 0;
        textFatlbsMale.Opacity = 0;
        textLBMMale.Opacity = 0;
        textBFMale.Opacity = 0;
        checkBox1.IsChecked = false;
        checkBox2.IsChecked = false;
        textAthleteM.Opacity = 0;
        textFitM.Opacity = 0;
        textEssintialFat.Opacity = 0;
        textObeaseM.Opacity = 0;
        textOverweightM.Opacity=0;
    }
  }
}
