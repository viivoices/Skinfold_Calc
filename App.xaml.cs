

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;

namespace ApplicationLifecycle
{
  public partial class App : Application
  {

    // Easy access to the root frame
    public PhoneApplicationFrame RootFrame { get; private set; }

    // Constructor
    public App()
    {
      // Global handler for uncaught exceptions. 
      // Note that exceptions thrown by ApplicationBarItem.Click will not get caught here.
      UnhandledException += Application_UnhandledException;

      // Standard Silverlight initialization
      InitializeComponent();

      // Phone-specific initialization
      InitializePhoneApplication();
    }

    // Code to execute when the application is launching (eg, from Start)
    // This code will not execute when the application is reactivated
    private void Application_Launching(object sender, LaunchingEventArgs e)
    {
      //Trace the event for debug purposes
      Utils.Trace("Application Launching");

      //Create new data object variable
      TravelReportInfo travelReportInfo = null;

      //Try to load previously saved data from IsolatedStorage
      using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
      {
        //Check if file exits
        if (isf.FileExists("TravelReportInfo.dat"))
        {
          using (IsolatedStorageFileStream fs = isf.OpenFile("TravelReportInfo.dat", System.IO.FileMode.Open))
          {
            //Read the file contents and try to deserialize it back to data object
            XmlSerializer ser = new XmlSerializer(typeof(TravelReportInfo));
            object obj = ser.Deserialize(fs);

            //If successfully deserialized, initialize data object variable with it
            if (null != obj && obj is TravelReportInfo)
              travelReportInfo = obj as TravelReportInfo;
            else
              travelReportInfo = new TravelReportInfo();
          }
        }
        else
          //If previous data not found, create new istance
          travelReportInfo = new TravelReportInfo();
      }

      //Set data variable (either recovered or new) as a DataContext for all the pages of the application
      RootFrame.DataContext = travelReportInfo;
    }

    // Code to execute when the application is activated (brought to foreground)
    // This code will not execute when the application is first launched
    private void Application_Activated(object sender, ActivatedEventArgs e)
    {
      //Trace the event for debug purposes
      Utils.Trace("Application Activated");

      //Create new data object variable
      TravelReportInfo travelReportInfo = null;

      //Try to locate previous data in transient state of the application
      if (PhoneApplicationService.Current.State.ContainsKey("UnsavedTravelReportInfo"))
      {
        //If found, initialize the data variable and remove in from application's state
        travelReportInfo = PhoneApplicationService.Current.State["UnsavedTravelReportInfo"] as TravelReportInfo;
        PhoneApplicationService.Current.State.Remove("UnsavedTravelReportInfo");
      }

      //If found set it as a DataContext for all the pages of the application
      //An application is not guaranteed to be activated after it has been tombstoned, 
      //thus if not found create new data object
      if (null != travelReportInfo)
        RootFrame.DataContext = travelReportInfo;
      else
        RootFrame.DataContext = new TravelReportInfo();
    }

    // Code to execute when the application is deactivated (sent to background)
    // This code will not execute when the application is closing
    private void Application_Deactivated(object sender, DeactivatedEventArgs e)
    {
      //Trace the event for debug purposes
      Utils.Trace("Application Deactivated");

    //Add current data object to Application state
    PhoneApplicationService.Current.State.Add("UnsavedTravelReportInfo", RootFrame.DataContext as TravelReportInfo);
    }

    // Code to execute when the application is closing (eg, user hit Back)
    // This code will not execute when the application is deactivated
    private void Application_Closing(object sender, ClosingEventArgs e)
    {
      //Trace the event for debug purposes
      Utils.Trace("Application Closing");
    }

    // Code to execute if a navigation fails
    void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
    {
      if (System.Diagnostics.Debugger.IsAttached)
      {
        // A navigation has failed; break into the debugger
        System.Diagnostics.Debugger.Break();
      }
    }

    // Code to execute on Unhandled Exceptions
    private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
    {
      if (System.Diagnostics.Debugger.IsAttached)
      {
        // An unhandled exception has occurred; break into the debugger
        System.Diagnostics.Debugger.Break();
      }
    }

    #region Phone application initialization

    // Avoid double-initialization
    private bool phoneApplicationInitialized = false;

    // Do not add any additional code to this method
    private void InitializePhoneApplication()
    {
      if (phoneApplicationInitialized)
        return;

      // Create the frame but don't set it as RootVisual yet; this allows the splash
      // screen to remain active until the application is ready to render.
      RootFrame = new PhoneApplicationFrame();
      RootFrame.Navigated += CompleteInitializePhoneApplication;

      // Handle navigation failures
      RootFrame.NavigationFailed += RootFrame_NavigationFailed;

      // Ensure we don't initialize again
      phoneApplicationInitialized = true;
    }

    // Do not add any additional code to this method
    private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
    {
      // Set the root visual to allow the application to render
      if (RootVisual != RootFrame)
        RootVisual = RootFrame;

      // Remove this handler since it is no longer needed
      RootFrame.Navigated -= CompleteInitializePhoneApplication;
    }

    #endregion
  }
}