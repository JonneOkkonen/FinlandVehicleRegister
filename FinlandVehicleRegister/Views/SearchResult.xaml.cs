using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Drawing;
using Windows.UI.Xaml.Media.Animation;
using FinlandVehicleRegister.Core;
using FinlandVehicleRegister.Views;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FinlandVehicleRegister.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchResult : Page
    {
        public static List<Vehicle> Vehicles = new List<Vehicle>();
        public SearchResult()
        {
            this.InitializeComponent();
            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            // Set active window colors
            titleBar.ForegroundColor = Windows.UI.Colors.White;
            titleBar.BackgroundColor = Windows.UI.Color.FromArgb(1, 38, 38, 38);
            titleBar.ButtonForegroundColor = Windows.UI.Colors.White;
            titleBar.ButtonBackgroundColor = Windows.UI.Color.FromArgb(1, 38, 38, 38);
            titleBar.ButtonHoverForegroundColor = Windows.UI.Colors.White;
            titleBar.ButtonHoverBackgroundColor = Windows.UI.Color.FromArgb(1, 70, 70, 70);
            titleBar.ButtonPressedForegroundColor = Windows.UI.Colors.White;
            titleBar.ButtonPressedBackgroundColor = Windows.UI.Color.FromArgb(1, 70, 70, 70);
            //Change view to this page
            NavigationBar.DataContext = this;

            // Set DataGrid ItemSource
            dgData.ItemsSource = Vehicles;

            // Set Result Count
            txtResultCount.Text = Vehicles.Count.ToString();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Search), null, new SuppressNavigationTransitionInfo());
        }
    }
}