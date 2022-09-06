using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CalculatorTrip
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TripCalculator : Page
    {
        public TripCalculator()
        {
            this.InitializeComponent();
        }

        

        //Calculations for the vehicle charge
        private double calcVehicleCharge(double daysRented)
        {
            double vehicleCharge = 0;
            const double TOYOTA_RATE = 35;
            const double SUV_RATE = 65;
            const double VAN_RATE = 75;

            if (toyotaRadioButton.IsChecked == true)
            {
                vehicleCharge = TOYOTA_RATE * daysRented;
            }

            else if (suvRadioButton.IsChecked == true)
            {
                vehicleCharge = SUV_RATE * daysRented;
            }

            else if (vanRadioButton.IsChecked == true)
            {
                vehicleCharge = VAN_RATE * daysRented;
            }
            return vehicleCharge;
        }

        //Calclations for the KM charge
        private static double calcKmCharge(double kmDriven)
        {
            double extraKmAmount = 0;
            const double UNDER_EXTRA = 0;
            const double OVER_EXTRA = 2;

            if (kmDriven < 200)
            {
                extraKmAmount = kmDriven * UNDER_EXTRA;
            }

            else if (kmDriven > 200)
            {
                extraKmAmount = (kmDriven - 200) * OVER_EXTRA;
            }
            return extraKmAmount;
        }

        //Clears all data input
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            daysRentedTextBox.Text = "";
            kmDrivenTextBox.Text = "";
            eExtraKmAmountTextBox.Text = "";
            eVehicleChargeAmountTextBox.Text = "";
            eFinalAmountTextBox.Text = "";
            toyotaRadioButton.IsChecked = false;
            suvRadioButton.IsChecked = false;
            vanRadioButton.IsChecked = false;
        }

        //Exit to main menu
        private void exit_Click(object sender, RoutedEventArgs e)
        {
			this.Frame.Navigate(typeof(GIT_Assignment_Main_Menu.MainMenu));
        }

		private async void calculate_Click(object sender, RoutedEventArgs e)
		{
			double daysRented;
			double kmDriven;
			double extraKmAmount;
			double finalAmount;
			double vehicleCharge;

			//Try and catch if user enters characters instead of numbers
			try
			{
				daysRented = double.Parse(daysRentedTextBox.Text);
			}

			catch (Exception exception)
			{
				var dialogMessage = new MessageDialog("Please enter numbers only. " + exception.Message);
				await dialogMessage.ShowAsync();
				daysRentedTextBox.Focus(FocusState.Programmatic);
				daysRentedTextBox.SelectAll();
				return;
			}

			try
			{
				kmDriven = double.Parse(kmDrivenTextBox.Text);
			}

			catch (Exception exception)
			{
				var dialogMessage = new MessageDialog("Please enter numbers only. " + exception.Message);
				await dialogMessage.ShowAsync();
				kmDrivenTextBox.Focus(FocusState.Programmatic);
				kmDrivenTextBox.SelectAll();
				return;
			}

			//Try and catch to ensure user enters data to be calculated
			if (daysRentedTextBox.Text == string.Empty)
			{
				var dialogMessage = new MessageDialog("Please enter Days rented ");
				await dialogMessage.ShowAsync();
				daysRentedTextBox.Focus(FocusState.Programmatic);
				daysRentedTextBox.SelectAll();
				return;
			}
			if (kmDrivenTextBox.Text == string.Empty)
			{
				var dialogMessage = new MessageDialog("Please enter Kilometers driven. ");
				await dialogMessage.ShowAsync();
				kmDrivenTextBox.Focus(FocusState.Programmatic);
				kmDrivenTextBox.SelectAll();
				return;
			}

			{
				//Calculations
				vehicleCharge = calcVehicleCharge(daysRented);
				extraKmAmount = calcKmCharge(kmDriven);
				finalAmount = vehicleCharge + extraKmAmount;
				eVehicleChargeAmountTextBox.Text = vehicleCharge.ToString("C");
				eExtraKmAmountTextBox.Text = extraKmAmount.ToString("C");
				eFinalAmountTextBox.Text = finalAmount.ToString("C");


			}
		}
	}
}
