﻿using System;
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
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FinlandVehicleRegister.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Search : Page
    {
        //List of options for the comboboxes used in the application
        private List<Option> vColor;
        private List<Option> vCarClass;
        private List<Option> vFrameType;
        private List<Option> vCounty;
        private List<Option> vFuelType;

        public Search()
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
            // Set NavigationBar Datacontext to this page
            NavigationBar.DataContext = this;
            LoadComboBoxItems();
        }

        async private void BtnDoSearch_Click(object sender, RoutedEventArgs e)
        {
            //Upon clock perform the folllowing actions if possible.
            try
            {
                QueryBuilder searchquery = new QueryBuilder();
                //If Brand field is not empty, perform the following:
                if (txtBrand.Text != "")

                {
                    searchquery.AddField(Field.Fields.merkkiSelvakielinen, txtBrand.Text);
                }
                //If Model field is not empty, perform the following:
                if (txtModel.Text != "")
                {
                    searchquery.AddField(Field.Fields.mallimerkinta, txtModel.Text);
                }

                //If Color field is not empty, perform the following:
                if (cbColor.SelectedValue != null)
                {
                    searchquery.AddField(Field.Fields.vari, cbColor.SelectedValue.ToString());
                }

                //If First Registration Date field is not empty and the checkbox was checked to activate the field, perform the following:
                if (dpFirstRegDate1.Date != null && dpFirstRegDate2.Date != null && cbFirstRegDate.IsChecked == true)
                {
                    searchquery.AddField(Field.Fields.ensirekisterointipvm, dpFirstRegDate1.Date.ToString("yyyy-MM-dd"), dpFirstRegDate2.Date.ToString("yyyy-MM-dd"));
                }

                if (dpDeployDate1.Date != null && dpDeployDate2.Date != null && cbDeployDate.IsChecked == true)
                {
                    searchquery.AddField(Field.Fields.kayttoonottopvm, dpDeployDate1.Date.ToString("yyyy-MM-dd"), dpDeployDate2.Date.ToString("yyyy-MM-dd"));
                }

                //If Fuel Type field is not empty, perform the following:
                if (cbFuelType.SelectedValue != null)
                {
                    searchquery.AddField(Field.Fields.kayttovoima, cbFuelType.SelectedValue.ToString());
                }

                //If Frame Type field is not empty, perform the following:
                if (cbFrameType.SelectedValue != null)
                {
                    searchquery.AddField(Field.Fields.korityyppi_pitkaselite, cbFrameType.SelectedValue.ToString());
                }

                //If County field is not empty, perform the following:
                if (cbCounty.SelectedValue != null)
                {
                    searchquery.AddField(Field.Fields.kunta, cbCounty.SelectedValue.ToString());
                }

                //If Gears field is not empty, perform the following:
                if (txtGears.Text != "")
                {
                    int value;
                    if (int.TryParse(txtGears.Text, out value) == false) throw new Exception("Number of Gears value isn't integer");
                    searchquery.AddField(Field.Fields.vaihteisto, value.ToString());
                }

                //If Serial Number field is not empty, perform the following:
                if (txtSerialNmb.Text != "")
                {
                    searchquery.AddField(Field.Fields.valmistenumero2, txtSerialNmb.Text);
                }

                //If Co2 field is not empty and the input is in integer format, perform the following:
                if (txtStartCo2.Text != "" && txtEndCo2.Text != "")
                {
                    int start, end;
                    if (int.TryParse(txtStartCo2.Text, out start) == false) throw new Exception("Co2 Start value isn't integer");
                    if (int.TryParse(txtEndCo2.Text, out end) == false) throw new Exception("Co2 End value isn't integer");
                    searchquery.AddField(Field.Fields.Co2, start.ToString(), end.ToString());
                }

                //If Mileage field is not empty and the input is in integer format, perform the following:
                if (txtStartMileage.Text != "" && txtEndMileage.Text != "")
                {
                    int start, end;
                    if (int.TryParse(txtStartMileage.Text, out start) == false) throw new Exception("Mileage Start value isn't integer");
                    if (int.TryParse(txtEndMileage.Text, out end) == false) throw new Exception("Mileage End value isn't integer");
                    searchquery.AddField(Field.Fields.matkamittarilukema, start.ToString(), end.ToString());
                }

                //If Mass field is not empty and the input is in integer format, perform the following:
                if (txtStartMass.Text != "" && txtEndMass.Text != "")
                {
                    int start, end;
                    if (int.TryParse(txtStartMass.Text, out start) == false) throw new Exception("Weight Start value isn't integer");
                    if (int.TryParse(txtEndMass.Text, out end) == false) throw new Exception("Weight End value isn't integer");
                    searchquery.AddField(Field.Fields.omamassa, start.ToString(), end.ToString());
                }

                //If Cylinder Cap field is not empty and the input is in integer format, perform the following:
                if (txtStartCylinderCap.Text != "" && txtEndCylinderCap.Text != "")
                {
                    int start, end;
                    if (int.TryParse(txtStartCylinderCap.Text, out start) == false) throw new Exception("Engine Size Start value isn't integer");
                    if (int.TryParse(txtEndCylinderCap.Text, out end) == false) throw new Exception("Engine Size End value isn't integer");
                    searchquery.AddField(Field.Fields.sylintereidenLkm, start.ToString(), end.ToString());
                }

                //If Power field is not empty and the input is in integer format, perform the following:
                if (txtStartNetPower.Text != "" && txtEndNetPower.Text != "")
                {
                    int start, end;
                    if (int.TryParse(txtStartNetPower.Text, out start) == false) throw new Exception("Power Start value isn't integer");
                    if (int.TryParse(txtEndNetPower.Text, out end) == false) throw new Exception("Power End value isn't integer");
                    searchquery.AddField(Field.Fields.suurinNettoteho, start.ToString(), end.ToString());
                }

                //If Car Class field is not empty, perform the following:
                if (cbCarClass.SelectedValue != null)
                {
                    searchquery.AddField(Field.Fields.ajoneuvoluokka_koodi, cbCarClass.SelectedValue.ToString());
                }

                //If Electric Hybrid field is checked, perform the following:
                if (ckbElecHybrid.IsChecked == true)
                {
                    searchquery.AddField(Field.Fields.sahkohybridi, "1");
                }

                // Build Query and set limit to 100
                searchquery.Build(QueryBuilder.QueryType.Select, 1000);

                // Activate ProgressSpinner, Show Progress Text and Disable Search button
                SearchProgress.IsActive = true;
                txtSearchProgress.Text = "Searching...";
                btnDoSearch.IsEnabled = false;
                // Load Vehicles from API asynchronously
                SearchResult.Vehicles = await VehicleAPI.GetVehiclesAsync(searchquery.QueryString);
                // Disable ProgressSpinner, Show Progress Text and Enable Search button
                SearchProgress.IsActive = false;
                txtSearchProgress.Text = "Done";
                btnDoSearch.IsEnabled = true;
                // If there was no result, stay in search page
                if (SearchResult.Vehicles.Count > 0)
                {
                    // Add Search to History
                    SearchHistory.AddItem(new SearchHistoryItem("Search", DateTime.Now, SearchResult.Vehicles.Count + " results", searchquery.QueryString, searchquery.FieldsToString()));
                    SearchHistory.Save();
                    // Navigate to SearchResult page
                    Frame.Navigate(typeof(SearchResult), null, new SuppressNavigationTransitionInfo());
                }
            }
            //Handle exceptions
            catch (Exception ex)
            {
                MessageDialog dialog = new MessageDialog(ex.Message);
                dialog.Title = "Info";
                await dialog.ShowAsync();

                // Disable ProgressSpinner, Show Progress Text and Enable Search button
                SearchProgress.IsActive = false;
                txtSearchProgress.Text = "Done";
                btnDoSearch.IsEnabled = true;
            }
        }

        /// <summary>
        /// Enable/Disable FirstRegistrationDate based on selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbFirstRegDate_Click(object sender, RoutedEventArgs e)
        {
            if(cbFirstRegDate.IsChecked == true)
            {
                dpFirstRegDate1.IsEnabled = true;
                dpFirstRegDate2.IsEnabled = true;
            }else
            {
                dpFirstRegDate1.IsEnabled = false;
                dpFirstRegDate2.IsEnabled = false;
            }
        }

        /// <summary>
        /// Enable/Disable DeployDate based on selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbDeployDate_Click(object sender, RoutedEventArgs e)
        {
            if (cbDeployDate.IsChecked == true)
            {
                dpDeployDate1.IsEnabled = true;
                dpDeployDate2.IsEnabled = true;
            }
            else
            {
                dpDeployDate1.IsEnabled = false;
                dpDeployDate2.IsEnabled = false;
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

            //Retrieve data to Color combobox
            vColor = await VehicleAPI.GetOptionsAsync(QueryBuilder.Table.VVari);
            cbColor.ItemsSource = vColor;
            cbColor.SelectedValuePath = "Value";
            cbColor.DisplayMemberPath = "Value";

            //Retrieve data to FuelType combobox
            vFuelType = await VehicleAPI.GetOptionsAsync(QueryBuilder.Table.VKayttovoima);
            cbFuelType.ItemsSource = vFuelType;
            cbFuelType.SelectedValuePath = "Value";
            cbFuelType.DisplayMemberPath = "Value";

            //Retrieve data to FrameType combobox
            vFrameType = await VehicleAPI.GetOptionsAsync(QueryBuilder.Table.VKorityyppi);
            cbFrameType.ItemsSource = vFrameType;
            cbFrameType.SelectedValuePath = "Value";
            cbFrameType.DisplayMemberPath = "Value";

            //Retrieve data to County combobox
            vCounty = await VehicleAPI.GetOptionsAsync(QueryBuilder.Table.VKunta);
            cbCounty.ItemsSource = vCounty;
            cbCounty.SelectedValuePath = "Value";
            cbCounty.DisplayMemberPath = "Value";

            //Retrieve data to Car Class combobox
            vCarClass = await VehicleAPI.GetOptionsAsync(QueryBuilder.Table.VAjoneuvoluokka);
            cbCarClass.ItemsSource = vCarClass;
            cbCarClass.SelectedValuePath = "Value";
            cbCarClass.DisplayMemberPath = "Value";

            // Disable ProgressSpinner and Show progress text
            LoadingProgress.IsActive = false;
            txtLoadingProgress.Text = "";
        }
    }
}

