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
using FinlandVehicleRegister.Core;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FinlandVehicleRegister.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Charts : Page
    {
        List<Option> VehicleClasses = new List<Option>();
        List<ChartItem> SearchResult = new List<ChartItem>();
        public Charts()
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

            // Set Type Combobox Values
            cbType.Items.Add("Ajoneuvoluokka");
            cbType.Items.Add("Ensirekisteröintimäärät");
            cbType.Items.Add("Ajoneuvon käyttö");
            cbType.Items.Add("Väri");
            cbType.Items.Add("Korityyppi");
            cbType.Items.Add("Käyttövoima");
            cbType.Items.Add("Sähköhybridien määrä");
            cbType.Items.Add("Merkki");

            // Load Values to Vehicle Class Combobox
            //VehicleClasses = VehicleAPI.GetOptions(QueryBuilder.Table.VAjoneuvoluokka);
            //cbVehicleClass.ItemsSource = VehicleClasses;
            //cbVehicleClass.SelectedValuePath = "Value";
            //cbVehicleClass.DisplayMemberPath = "Value";
        }

        /// <summary>
        /// Event Handler for Type Selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(cbType.SelectedItem.ToString())
            {
                case "Ensirekisteröintimäärät":
                    StartDate.IsEnabled = true;
                    EndDate.IsEnabled = true;
                    cbVehicleClass.IsEnabled = true;
                    txtBrand.IsEnabled = true;
                    break;
                case "Korityyppi":
                    cbVehicleClass.IsEnabled = true;
                    break;
                case "Merkki":
                    cbVehicleClass.IsEnabled = true;
                    break;
                case "Sähköhybridien määrä":
                    StartDate.IsEnabled = true;
                    EndDate.IsEnabled = true;
                    break;
                default:
                    StartDate.IsEnabled = false;
                    EndDate.IsEnabled = false;
                    cbVehicleClass.IsEnabled = false;
                    txtBrand.IsEnabled = false;
                    break;
            }
        }

        /// <summary>
        /// Event Handler for Search Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SearchResult.Clear();
                switch (cbType.SelectedItem.ToString())
                {
                    case "Ajoneuvoluokka":
                        SearchResult = VehicleAPI.GetChartData(QueryBuilder.Table.ChartAjoneuvoluokka);
                        dgData.ItemsSource = SearchResult;
                        break;
                    case "Väri":
                        SearchResult = VehicleAPI.GetChartData(QueryBuilder.Table.ChartVari);
                        SearchResult.RemoveAt(0);
                        dgData.ItemsSource = SearchResult;
                        break;
                }
                PieChart.DataSource = SearchResult;
                PieChart.TitleMemberPath = "Name";
                PieChart.ValueMemberPath = "Value";
            }
            catch (NullReferenceException)
            {
                MessageDialog dialog = new MessageDialog("Select search type!");
                dialog.Title = "Info";
                await dialog.ShowAsync();
            }
            catch (Exception ex)
            {
                MessageDialog dialog = new MessageDialog(ex.Message);
                dialog.Title = "Exception";
                await dialog.ShowAsync();
            }
        }
    }
}
