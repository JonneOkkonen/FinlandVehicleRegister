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

            //txtBrand.Text = "Test";

            //txtModel.Text = "model1";

            //Retrieve data to Color combobox
            vColor = VehicleAPI.GetOptions(QueryBuilder.Table.VVari);
            cbColor.ItemsSource = vColor;
            cbColor.SelectedValue = "Value";
            cbColor.DisplayMemberPath = "Value";

            DatePicker dpFirstRegDate1 = new DatePicker();
            dpFirstRegDate1.Header = "FirstRegistrationDate";

            //To:

            DatePicker dpFirstRegDate2 = new DatePicker();
            dpFirstRegDate1.Header = "FirstRegistrationDate";

            //Retrieve data to FuelType combobox
            vFuelType = VehicleAPI.GetOptions(QueryBuilder.Table.VKayttovoima);
            cbFuelType.ItemsSource = vFuelType;
            cbFuelType.SelectedValue = "Value";
            cbFuelType.DisplayMemberPath = "Value";

            //Retrieve data to FrameType combobox
            vFrameType = VehicleAPI.GetOptions(QueryBuilder.Table.VKorityyppi);
            cbFrameType.ItemsSource = vFrameType;
            cbFrameType.SelectedValue = "Value";
            cbFrameType.DisplayMemberPath = "Value";

            //Retrieve data to County combobox
            vCounty = VehicleAPI.GetOptions(QueryBuilder.Table.VKunta);
            cbCounty.ItemsSource = vCounty;
            cbCounty.SelectedValue = "Value";

            //cbCounty.DisplayMemberPath = "Value";

            //txtGears.Text = "6";

            //txtSerialNmb.Text = "SeR14L NuMB3r";

            //txtCo2.Text = "High";

            //txtMass.Text = "1200 kg";

            //txtCylinderCap.Text = "16";

            //txtNetPower.Text = "100000 mPa";

            //Retrieve data to Car Class combobox
            vCarClass = VehicleAPI.GetOptions(QueryBuilder.Table.VAjoneuvoluokka);
            cbCarClass.ItemsSource = vCarClass;
            cbCarClass.SelectedValue = "Value";
            cbCarClass.DisplayMemberPath = "Value";
        }

        private void BtnDoSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                QueryBuilder searchquery = new QueryBuilder();
                if (txtBrand.Text != null)

                {
                    searchquery.AddField(Field.Fields.merkkiSelvakielinen, txtBrand.Text);
                }

                if (txtModel.Text != null)
                {
                    searchquery.AddField(Field.Fields.mallimerkinta, txtBrand.Text);
                }

                if (cbColor.SelectedValue != null)
                {
                    searchquery.AddField(Field.Fields.vari, cbColor.SelectedValue.ToString());
                }

                if (dpFirstRegDate1.Date != null)
                {
                    searchquery.AddField(Field.Fields.ensirekisterointipvm, dpFirstRegDate1.Date.ToString("yyyy-MM-dd"));
                }

                //To:

                if (dpFirstRegDate2.Date != null)
                {
                    searchquery.AddField(Field.Fields.ensirekisterointipvm, dpFirstRegDate2.Date.ToString("yyyy-MM-dd"));
                }

                if (dpDeployDate1.Date != null)
                {
                    searchquery.AddField(Field.Fields.kayttoonottopvm, dpDeployDate1.Date.ToString("yyyy-MM-dd"));
                }

                //To:

                if (dpDeployDate1.Date != null)
                {
                    searchquery.AddField(Field.Fields.kayttoonottopvm, dpDeployDate1.Date.ToString("yyyy-MM-dd"));
                }

                if (cbFuelType.SelectedValue != null)
                {
                    searchquery.AddField(Field.Fields.kayttovoima, cbFuelType.SelectedValue.ToString());
                }

                if (cbFrameType.SelectedValue != null)
                {
                    searchquery.AddField(Field.Fields.korityyppi, cbFrameType.SelectedValue.ToString());
                }

                if (cbCounty.SelectedValue != null)
                {
                    searchquery.AddField(Field.Fields.kunta, cbCounty.SelectedValue.ToString());
                }

                if (txtGears.Text != null)
                {
                    searchquery.AddField(Field.Fields.vaihteisto, txtGears.Text);
                }

                if (txtSerialNmb.Text != null)
                {
                    searchquery.AddField(Field.Fields.valmistenumero2, txtSerialNmb.Text);
                }

                if (txtCo2.Text != null)
                {
                    searchquery.AddField(Field.Fields.Co2, txtCo2.Text);
                }

                if (txtMass.Text != null)
                {
                    searchquery.AddField(Field.Fields.omamassa, txtMass.Text);
                }

                if (txtCylinderCap.Text != null)
                {
                    searchquery.AddField(Field.Fields.sylintereidenLkm, txtCylinderCap.Text);
                }

                if (txtNetPower.Text != null)
                {
                    searchquery.AddField(Field.Fields.suurinNettoteho, txtNetPower.Text);
                }

                if (cbCarClass.SelectedValue != null)
                {
                    searchquery.AddField(Field.Fields.ajoneuvoluokka, cbCarClass.SelectedValue.ToString());
                }

                if (ckbElecHybrid.IsChecked == true)
                {
                    searchquery.AddField(Field.Fields.sahkohybridi, "1");
                }

                searchquery.Build(QueryBuilder.QueryType.Select);
                List<Vehicle> vehicles = VehicleAPI.GetVehicles(searchquery.QueryString);
            }
            catch
            {
                throw;
            }

            this.Frame.Navigate(typeof(SearchResult), null, new SuppressNavigationTransitionInfo());
        }
    }
}

