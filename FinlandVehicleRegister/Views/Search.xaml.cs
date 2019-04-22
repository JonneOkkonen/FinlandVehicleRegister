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
        public List<string> colors = new List<string>();
        public List<string> carclass = new List<string>();
        public List<string> brand = new List<string>();
        public List<string> frametype = new List<string>();
        public List<string> fueltype = new List<string>();
        public List<string> county = new List<string>();
        public List<string> model = new List<string>();
        public List<string> deploymentdate = new List<string>();
        public List<string> serialnumber = new List<string>();
        public List<string> co2 = new List<string>();
        public List<string> mass = new List<string>();
        public List<string> cylindercap = new List<string>();
        public List<string> netpower = new List<string>();
        public List<string> gears = new List<string>();

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


            txtBrand.Text = "Test";

            txtModel.Text = "model1";

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
            cbFrameType.SelectedValue = "Value";
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
            cbCounty.DisplayMemberPath = "Value";

            txtGears.Text = "6";

            txtSerialNmb.Text = "SeR14L NuMB3r";

            txtCo2.Text = "High";

            txtMass.Text = "1200 kg";

            txtCylinderCap.Text = "16";

            txtNetPower.Text = "100000 mPa";

            //Retrieve data to Car Class combobox
            vCarClass = VehicleAPI.GetOptions(QueryBuilder.Table.VAjoneuvoluokka);
            cbCarClass.ItemsSource = vCarClass;
            cbCarClass.SelectedValue = "Value";
            cbCarClass.DisplayMemberPath = "Value";
        }

        private void BtnDoSearch_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SearchResult), null, new SuppressNavigationTransitionInfo());


        }

        private void TxtModel_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtModel.Text = txtModel.Text;
        }

        private void TxtSerialNmb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtBrand_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtCo2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtMass_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtCylinderCap_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtNetPower_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtGears_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

