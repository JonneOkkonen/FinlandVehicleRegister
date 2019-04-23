using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace FinlandVehicleRegister.Views
{
    public sealed partial class NavigationBar : UserControl
    { 
        public NavigationBar()
        {
            this.InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Upon click the page sets itself to a different view.
            string button = ((Button)sender).Name.ToString();
            //These are all the different cases that change the view based on user input
            switch(button)
            {
                case "btnHomePage":
                    ((Page)DataContext).Frame.Navigate(typeof(MainPage), null, new SuppressNavigationTransitionInfo());
                    break;
                case "btnSearch":
                    ((Page)DataContext).Frame.Navigate(typeof(Search), null, new SuppressNavigationTransitionInfo());
                    break;
                case "btnCharts":
                    ((Page)DataContext).Frame.Navigate(typeof(Charts), null, new SuppressNavigationTransitionInfo());
                    break;
                case "btnHelp":
                    ((Page)DataContext).Frame.Navigate(typeof(Help), null, new SuppressNavigationTransitionInfo());
                    break;
            }
        }
    }
}
