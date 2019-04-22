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
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FinlandVehicleRegister.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Search : Page
    {

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

            //Retrieve data to Color combobox
            vColor = VehicleAPI.GetOptions(QueryBuilder.Table.VVari);
            cbColor.ItemsSource = vColor;
            cbColor.SelectedValuePath = "Value";
            cbColor.DisplayMemberPath = "Value";

            //Retrieve data to FuelType combobox
            vFuelType = VehicleAPI.GetOptions(QueryBuilder.Table.VKayttovoima);
            cbFuelType.ItemsSource = vFuelType;
            cbFuelType.SelectedValuePath = "Value";
            cbFuelType.DisplayMemberPath = "Value";

            //Retrieve data to FrameType combobox
            vFrameType = VehicleAPI.GetOptions(QueryBuilder.Table.VKorityyppi);
            cbFrameType.ItemsSource = vFrameType;
            cbFrameType.SelectedValuePath = "Value";
            cbFrameType.DisplayMemberPath = "Value";

            //Retrieve data to County combobox
            vCounty = VehicleAPI.GetOptions(QueryBuilder.Table.VKunta);
            cbCounty.ItemsSource = vCounty;
            cbCounty.SelectedValuePath = "Value";
            cbCounty.DisplayMemberPath = "Value";

            //Retrieve data to Car Class combobox
            vCarClass = VehicleAPI.GetOptions(QueryBuilder.Table.VAjoneuvoluokka);
            cbCarClass.ItemsSource = vCarClass;
            cbCarClass.SelectedValuePath = "Value";
            cbCarClass.DisplayMemberPath = "Value";
        }

        async private void BtnDoSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                QueryBuilder searchquery = new QueryBuilder();
                if (txtBrand.Text != "")

                {
                    searchquery.AddField(Field.Fields.merkkiSelvakielinen, txtBrand.Text);
                }

                if (txtModel.Text != "")
                {
                    searchquery.AddField(Field.Fields.mallimerkinta, txtModel.Text);
                }

                if (cbColor.SelectedValue != null)
                {
                    searchquery.AddField(Field.Fields.vari, cbColor.SelectedValue.ToString());
                }

                if (dpFirstRegDate1.Date != null && dpFirstRegDate2.Date != null)
                {
                    searchquery.AddField(Field.Fields.ensirekisterointipvm, dpFirstRegDate1.Date.ToString("yyyy-MM-dd"), dpFirstRegDate2.Date.ToString("yyyy-MM-dd"));
                }

                if (dpDeployDate1.Date != null && dpDeployDate2.Date != null)
                {
                    searchquery.AddField(Field.Fields.kayttoonottopvm, dpDeployDate1.Date.ToString("yyyy-MM-dd"), dpDeployDate2.Date.ToString("yyyy-MM-dd"));
                }

                if (cbFuelType.SelectedValue != null)
                {
                    searchquery.AddField(Field.Fields.kayttovoima, cbFuelType.SelectedValue.ToString());
                }

                if (cbFrameType.SelectedValue != null)
                {
                    searchquery.AddField(Field.Fields.korityyppi_pitkaselite, cbFrameType.SelectedValue.ToString());
                }

                if (cbCounty.SelectedValue != null)
                {
                    searchquery.AddField(Field.Fields.kunta, cbCounty.SelectedValue.ToString());
                }

                if (txtGears.Text != "")
                {
                    searchquery.AddField(Field.Fields.vaihteisto, txtGears.Text);
                }

                if (txtSerialNmb.Text != "")
                {
                    searchquery.AddField(Field.Fields.valmistenumero2, txtSerialNmb.Text);
                }

                if (txtStartCo2.Text != "" && txtEndCo2.Text != "")
                {
                    searchquery.AddField(Field.Fields.Co2, txtStartCo2.Text, txtEndCo2.Text);
                }

                if(txtStartMileage.Text != "" && txtEndMileage.Text != "")
                {
                    searchquery.AddField(Field.Fields.matkamittarilukema, txtStartMileage.Text, txtEndMileage.Text);
                }

                if (txtStartMass.Text != "" && txtEndMass.Text != "")
                {
                    searchquery.AddField(Field.Fields.omamassa, txtStartMass.Text, txtEndMass.Text);
                }

                if (txtStartCylinderCap.Text != "" && txtEndCylinderCap.Text != "")
                {
                    searchquery.AddField(Field.Fields.sylintereidenLkm, txtStartCylinderCap.Text, txtEndCylinderCap.Text);
                }

                if (txtStartNetPower.Text != "" && txtEndNetPower.Text != "")
                {
                    searchquery.AddField(Field.Fields.suurinNettoteho, txtStartNetPower.Text, txtEndNetPower.Text);
                }

                if (cbCarClass.SelectedValue != null)
                {
                    searchquery.AddField(Field.Fields.ajoneuvoluokka_koodi, cbCarClass.SelectedValue.ToString());
                }

                if (ckbElecHybrid.IsChecked == true)
                {
                    searchquery.AddField(Field.Fields.sahkohybridi, "1");
                }

                searchquery.Build(QueryBuilder.QueryType.Select, 1000);
                string query = searchquery.QueryString;
                SearchResult.Vehicles = VehicleAPI.GetVehicles(searchquery.QueryString);
            }
            catch (Exception ex)
            {
                MessageDialog dialog = new MessageDialog(ex.Message);
                dialog.Title = "Error";
                await dialog.ShowAsync();
            }
            this.Frame.Navigate(typeof(SearchResult), null, new SuppressNavigationTransitionInfo());
        }
    }
}

