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
        public List<ChartItem> SearchResult = new List<ChartItem>();
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

            LoadComboBoxItems();
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
                    StartDate.Date = new DateTime(1900, 01, 01);
                    EndDate.IsEnabled = true;
                    cbVehicleClass.IsEnabled = true;
                    txtBrand.IsEnabled = true;
                    break;
                //case "Korityyppi":
                //    cbVehicleClass.IsEnabled = true;
                //    break;
                case "Merkki":
                    cbVehicleClass.IsEnabled = true;
                    break;
                case "Sähköhybridien määrä":
                    StartDate.IsEnabled = true;
                    StartDate.Date = new DateTime(1900, 01, 01);
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
                // Activate ProgressSpinner, Show Progress Text and Disable Search button
                SearchProgress.IsActive = true;
                txtSearchProgress.Text = "Searching...";
                btnSearch.IsEnabled = false;

                SearchResult.Clear();
                switch (cbType.SelectedItem.ToString())
                {
                    case "Ajoneuvoluokka":
                        SearchResult = await VehicleAPI.GetChartDataAsync(QueryBuilder.Table.ChartAjoneuvoluokka);
                        break;
                    case "Väri":
                        SearchResult = await VehicleAPI.GetChartDataAsync(QueryBuilder.Table.ChartVari);
                        SearchResult.RemoveAt(0);
                        break;
                    case "Käyttövoima":
                        SearchResult = await VehicleAPI.GetChartDataAsync(QueryBuilder.Table.ChartKayttovoima);
                        SearchResult.RemoveAt(0);
                        break;
                    case "Ajoneuvon käyttö":
                        SearchResult = await VehicleAPI.GetChartDataAsync(QueryBuilder.Table.ChartAjoneuvonKaytto);
                        SearchResult.RemoveAt(0);
                        break;
                    case "Korityyppi":
                        SearchResult = await VehicleAPI.GetChartDataAsync(QueryBuilder.Table.ChartKorityyppi);
                        SearchResult.RemoveAt(0);
                        break;
                    case "Merkki":
                        string vehicleClass = cbVehicleClass.SelectedValue.ToString();
                        string query = $"SELECT merkkiSelvakielinen as Name, COUNT(merkkiSelvakielinen) as Value FROM Ajoneuvo WHERE ajoneuvoluokka=(SELECT ID FROM Ajoneuvoluokka WHERE Kooditunnus = '{vehicleClass}') GROUP BY merkkiSelvakielinen HAVING Value > 100 ORDER BY Value DESC;";
                        SearchResult = await VehicleAPI.GetChartDataAsync(QueryBuilder.Table.Ajoneuvo, query);
                        break;
                    case "Ensirekisteröintimäärät":
                        string startDate = StartDate.Date.ToString("yyyy-MM-dd");
                        string endDate = EndDate.Date.ToString("yyyy-MM-dd");
                        string vehicleClass2 = "";
                        string brand = "";
                        if (cbVehicleClass.SelectedValue != null)
                        {
                            vehicleClass2 = $" ajoneuvoluokka=(SELECT ID FROM Ajoneuvoluokka WHERE Kooditunnus = '{cbVehicleClass.SelectedValue.ToString()}') AND ";
                        }
                        if(txtBrand.Text != "")
                        {
                            brand = $" merkkiSelvakielinen='{txtBrand.Text}' AND ";
                        }
                        string query2 = $"SELECT YEAR(ensirekisterointipvm) as Name, COUNT(ensirekisterointipvm) as Value FROM Ajoneuvo WHERE{vehicleClass2}{brand} ensirekisterointipvm BETWEEN '{startDate}' AND '{endDate}' GROUP BY YEAR(ensirekisterointipvm) ORDER BY Name DESC;";
                        SearchResult = await VehicleAPI.GetChartDataAsync(QueryBuilder.Table.Ajoneuvo, query2);
                        break;
                    case "Sähköhybridien määrä":
                        string startDate2 = StartDate.Date.ToString("yyyy-MM-dd");
                        string endDate2 = EndDate.Date.ToString("yyyy-MM-dd");
                        string query3 = $"SELECT YEAR(ensirekisterointipvm) as Name, COUNT(sahkohybridi) as Value FROM Ajoneuvo WHERE sahkohybridi=1 AND ensirekisterointipvm BETWEEN '{startDate2}' AND '{endDate2}' GROUP BY YEAR(ensirekisterointipvm) ORDER BY Name DESC;";
                        SearchResult = await VehicleAPI.GetChartDataAsync(QueryBuilder.Table.Ajoneuvo, query3);
                        break;
                }
                // Disable ProgressSpinner, Show Progress Text and Enable Search button
                SearchProgress.IsActive = false;
                txtSearchProgress.Text = "Done";
                btnSearch.IsEnabled = true;

                PieChart.DataSource = SearchResult;
                PieChart.TitleMemberPath = "Name";
                PieChart.ValueMemberPath = "Value";
                dgData.ItemsSource = SearchResult;
            }
            catch (NullReferenceException)
            {
                MessageDialog dialog = new MessageDialog("Fill all enabled fields!");
                dialog.Title = "Info";
                await dialog.ShowAsync();

                // Disable ProgressSpinner, Show Progress Text and Enable Search button
                SearchProgress.IsActive = false;
                txtSearchProgress.Text = "Done";
                btnSearch.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageDialog dialog = new MessageDialog(ex.Message);
                dialog.Title = "Exception";
                await dialog.ShowAsync();

                // Disable ProgressSpinner, Show Progress Text and Enable Search button
                SearchProgress.IsActive = false;
                txtSearchProgress.Text = "Done";
                btnSearch.IsEnabled = true;
            }
        }

        /// <summary>
        /// Load ComboBox Items from API
        /// </summary>
        private async void LoadComboBoxItems()
        {
            // Activate ProgressSpinner and Show progress text
            LoadingProgress.IsActive = true;
            txtLoadingProgress.Text = "Loading values...";

            //Load Values to Vehicle Class Combobox
            VehicleClasses = await VehicleAPI.GetOptionsAsync(QueryBuilder.Table.VAjoneuvoluokka);
            cbVehicleClass.ItemsSource = VehicleClasses;
            cbVehicleClass.SelectedValuePath = "Value";
            cbVehicleClass.DisplayMemberPath = "Value";

            // Disable ProgressSpinner and Show progress text
            LoadingProgress.IsActive = false;
            txtLoadingProgress.Text = "";
        }

        }
    }
