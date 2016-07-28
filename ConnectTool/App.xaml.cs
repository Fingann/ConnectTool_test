using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using ConnectTool.Model.LogWatcher;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConnectTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private const int MINIMUM_SPLASH_TIME = 1500; // Miliseconds
        private const int SPLASH_FADE_TIME = 500;     // Miliseconds

        static App()
        {
            DispatcherHelper.Initialize();
            
            //FileWatcher LogMonitor = new FileWatcher();
            //LogMonitor.Start();


        }
        protected override void OnStartup(StartupEventArgs e)
        {
            // Step 1 - Load the splash screen
            //SplashScreen splash = new SplashScreen("Resource/Image/SplashScreen.jpg");
            //splash.Show(false, true);

            // Step 2 - Start a stop watch
            //Stopwatch timer = new Stopwatch();
            //timer.Start();

            // Step 3 - Load your windows but don't show it yet
            base.OnStartup(e);
            

            // Step 4 - Make sure that the splash screen lasts at least two seconds
            //timer.Stop();
            //int remainingTimeToShowSplash = MINIMUM_SPLASH_TIME - (int)timer.ElapsedMilliseconds;
            //if (remainingTimeToShowSplash > 0)
            //    Thread.Sleep(remainingTimeToShowSplash);

            //// Step 5 - show the page
            //splash.Close(TimeSpan.FromMilliseconds(SPLASH_FADE_TIME));
           
        }


    }
}
