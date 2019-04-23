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
using FinlandVehicleRegister.Views;
using System.Drawing;
using FinlandVehicleRegister.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Animation;
using Microsoft.Toolkit.Uwp.UI.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FinlandVehicleRegister
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
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
            // Set NavigationBar DataContext to this page
            NavigationBar.DataContext = this;
            // TEST SAVE TO SearchHistory
            //SearchHistory.List.Clear();
            //SearchHistory.AddItem(new SearchHistoryItem("BMW Haku", DateTime.Now, "5 results", "SELECT * FROM Ajoneuvo WHERE merkkiSelvakielinen = 'BMW' LIMIT 100;"));
            //SearchHistory.AddItem(new SearchHistoryItem("Volkswagen Haku", DateTime.Now, "2 results", "SELECT * FROM Ajoneuvo WHERE merkkiSelvakielinen = 'Volkswagen' LIMIT 100;"));
            //SearchHistory.Save();

            // Test SearchHistory
            LoadSearchHistory();
        }

        public async void LoadSearchHistory()
        {
            try
            {
                SearchHistory.Read();
                HistoryList.ItemsSource = SearchHistory.List;
            }
            catch (Exception ex)
            {
                MessageDialog dialog = new MessageDialog(ex.Message);
                dialog.Title = "Error";
                await dialog.ShowAsync();
            }
        }

        async private void HistoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchHistoryItem item = (SearchHistoryItem)HistoryList.SelectedItem;
            try
            {
                // Active ProgressSpinner and Show Progress Text
                SearchProgress.IsActive = true;
                txtSearchProgress.Text = "Searching...";
                SearchResult.Vehicles = await VehicleAPI.GetVehiclesAsync(item.Query);
                // Disable ProgressSpinner and Show Progress Text
                SearchProgress.IsActive = false;
                txtSearchProgress.Text = "";
                if (SearchResult.Vehicles.Count > 0) Frame.Navigate(typeof(SearchResult), null, new SuppressNavigationTransitionInfo());
            }
            catch (Exception ex)
            {
                MessageDialog dialog = new MessageDialog(ex.Message);
                dialog.Title = "Info";
                await dialog.ShowAsync();
            }
        }
    }
}
