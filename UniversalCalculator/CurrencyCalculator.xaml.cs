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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace git_assignment_currency_calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CurrencyCalculator : Page
    {
        public CurrencyCalculator()
        {
            this.InitializeComponent();
        }

        //convert button
        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            
            double total;
            double userAmount;
            string fromAmount;
            string toAmount;
            string conversionRate;
            string toSignAmount;

            userAmount = double.Parse(amountTextBox.Text);
            total = calcAmount(userAmount);
            fromAmount = calcFromAmount(userAmount);
            toAmount = calcToAmount(userAmount);
            toSignAmount = calcToSign();
            conversionRate = calcConversionRate();

            summaryTextBlock.Text = fromAmount + " " + toSignAmount + total + toAmount;
            conversionTextBlock.Text = "Conversion Rate\n" + conversionRate;

            //once convert button is clicked the stackpanel is visible
            textStackPanel.Visibility = Visibility.Visible;
            
        }

        // convertor method calculations
        private double calcAmount(double userAmount)
        {
            double convertTotal = 0;

            // from amount chosen is USD
            if (fromComboBox.SelectedValue.ToString() == "USD - US Dollar" && toComboBox.SelectedValue.ToString() == "GPB - Pound Sterling")
            {
                convertTotal = userAmount * 0.72872436;
                
            }
            else if (fromComboBox.SelectedValue.ToString() == "USD - US Dollar" && toComboBox.SelectedValue.ToString() == "EUR - Euro")
            {
                convertTotal = userAmount * 0.85189;
            }
            else if (fromComboBox.SelectedValue.ToString() == "USD - US Dollar" && toComboBox.SelectedValue.ToString() == "INR - Indian Rupee")
            {
                convertTotal = userAmount * 74.257327;
            }
            else if (fromComboBox.SelectedValue.ToString() == "USD - US Dollar" && toComboBox.SelectedValue.ToString() == "USD - US Dollar")
            {
                convertTotal = userAmount * 1;
            }

            // from amount chosen is Euro
            else if (fromComboBox.SelectedValue.ToString() == "EUR - Euro" && toComboBox.SelectedValue.ToString() == "GPB - Pound Sterling")
            {
                convertTotal = userAmount * 0.8556672;
            }
            else if (fromComboBox.SelectedValue.ToString() == "EUR - Euro" && toComboBox.SelectedValue.ToString() == "INR - Indian Rupee")
            {
                convertTotal = userAmount * 87.00755;
            }

            else if (fromComboBox.SelectedValue.ToString() == "EUR - Euro" && toComboBox.SelectedValue.ToString() == "USD - US Dollar")
            {
                convertTotal = userAmount * 1.1739732;
            }
            else if (fromComboBox.SelectedValue.ToString() == "EUR - Euro" && toComboBox.SelectedValue.ToString() == "EUR - Euro")
            {
                convertTotal = userAmount * 1;
            }

            // from amount chosen is British
            else if (fromComboBox.SelectedValue.ToString() == "GPB - Pound Sterling" && toComboBox.SelectedValue.ToString() == "INR - Indian Rupee")
            {
                convertTotal = userAmount * 101.68635;
            }
            else if (fromComboBox.SelectedValue.ToString() == "GPB - Pound Sterling" && toComboBox.SelectedValue.ToString() == "USD - US Dollar")
            {
                convertTotal = userAmount * 1.371907;
            }
            else if (fromComboBox.SelectedValue.ToString() == "GPB - Pound Sterling" && toComboBox.SelectedValue.ToString() == "EUR - Euro")
            {
                convertTotal = userAmount * 1.1686692;
            }
            else if (fromComboBox.SelectedValue.ToString() == "GPB - Pound Sterling" && toComboBox.SelectedValue.ToString() == "GPB - Pound Sterling")
            {
                convertTotal = userAmount * 1;
            }

            // from amount chosen is Indian Rupee
            else if (fromComboBox.SelectedValue.ToString() == "INR - Indian Rupee" && toComboBox.SelectedValue.ToString() == "GPB - Pound Sterling")
            {
                convertTotal = userAmount * 0.0098339397;
            }
            else if (fromComboBox.SelectedValue.ToString() == "INR - Indian Rupee" && toComboBox.SelectedValue.ToString() == "USD - US Dollar")
            {
                convertTotal = userAmount * 0.011492628;
            }
            else if (fromComboBox.SelectedValue.ToString() == "INR - Indian Rupee" && toComboBox.SelectedValue.ToString() == "EUR - Euro")
            {
                convertTotal = userAmount * 0.013492774;
            }
            else if (fromComboBox.SelectedValue.ToString() == "INR - Indian Rupee" && toComboBox.SelectedValue.ToString() == "INR - Indian Rupee")
            {
                convertTotal = userAmount * 1;
            }
            return convertTotal;
        }

        //calculate to display text with corresponding from amount dropdown box
        private string calcFromAmount(double userAmount)
        {
            string fromAmount;

            if (fromComboBox.SelectedValue.ToString() == "USD - US Dollar")
            {
                fromAmount = "$"+ userAmount + " US Dollars =";
            }
            else if (fromComboBox.SelectedValue.ToString() == "EUR - Euro")
            {
                
                fromAmount = "€" + userAmount + " Euros =";
            }
            else if (fromComboBox.SelectedValue.ToString() == "GPB - Pound Sterling")
            {
                
                fromAmount = "£" + userAmount + " British Pounds =";
            }
            else
            {
                fromAmount = "₹" + userAmount + " Indian Rupees =";
            }
            return fromAmount;
        }
        
        // conversion rate method
        //shows the conversion rate of the chosen currency
        private string calcConversionRate()
        {
            string conversionRate;
            conversionRate = conversionTextBlock.Text;

            //USD
            if (fromComboBox.SelectedValue.ToString() == "USD - US Dollar" && toComboBox.SelectedValue.ToString() == "GPB - Pound Sterling")
            {
                conversionRate = conversionTextBlock.Text = "$1 US Dollar = £0.72872436 British Pound" + "\n£1 British Pound = $1.371907 US Dollar";
            }
            else if (fromComboBox.SelectedValue.ToString() == "USD - US Dollar" && toComboBox.SelectedValue.ToString() == "EUR - Euro")
            {
                conversionRate = conversionTextBlock.Text = "$1 US Dollar = €0.85189982 Euro" + "\n€1 Euro = $1.1739732 US Dollar";
            }
            else if (fromComboBox.SelectedValue.ToString() == "USD - US Dollar" && toComboBox.SelectedValue.ToString() == "INR - Indian Rupee")
            {
                conversionRate = conversionTextBlock.Text = "$1 US Dollar = ₹74.257327 Rupee" + "\n₹1 Rupee = $0.011492628 US Dollar";
            }
            else if (fromComboBox.SelectedValue.ToString() == "USD - US Dollar" && toComboBox.SelectedValue.ToString() == "USD - US Dollar")
            {
                conversionRate = conversionTextBlock.Text = "$1 US Dollar = $1 US Dollar" + "\n$1 US Dollar = $1 US Dollar";
            }

            //EUR
            else if (fromComboBox.SelectedValue.ToString() == "EUR - Euro" && toComboBox.SelectedValue.ToString() == "GPB - Pound Sterling")
            {
                conversionRate = conversionTextBlock.Text = "€1 Euro = £0.8556672 British Pound" + "\n£1 British Pound = €1.1686692 Euro";
            }
            else if (fromComboBox.SelectedValue.ToString() == "EUR - Euro" && toComboBox.SelectedValue.ToString() == "USD - US Dollar")
            {
                conversionRate = conversionTextBlock.Text = "€1 Euro = $1.1739732 US Dollar" + "\n$1 US Dollar = €0.85189982 Euro";
            }
            else if (fromComboBox.SelectedValue.ToString() == "EUR - Euro" && toComboBox.SelectedValue.ToString() == "INR - Indian Rupee")
            {
                conversionRate = conversionTextBlock.Text = "€1 Euro = ₹87.00755 Rupee" + "\n₹1 Rupee = €0.013492774 Euro";
            }
            else if (fromComboBox.SelectedValue.ToString() == "EUR - Euro" && toComboBox.SelectedValue.ToString() == "EUR - Euro")
            {
                conversionRate = conversionTextBlock.Text = "€1 Euro = €1 Euro" + "\n€1 Euro = €1 Euro";
            }

            //GBP
            else if (fromComboBox.SelectedValue.ToString() == "GPB - Pound Sterling" && toComboBox.SelectedValue.ToString() == "EUR - Euro")
            {
                conversionRate = conversionTextBlock.Text = "£1 British Pound = €1.1686692 Euro" + "\n€1 Euro = £0.8556672 British Pound";
            }
            else if (fromComboBox.SelectedValue.ToString() == "GPB - Pound Sterling" && toComboBox.SelectedValue.ToString() == "USD - US Dollar")
            {
                conversionRate = conversionTextBlock.Text = "£1 British Pound = $1.371907 US Dollar" + "\n$1 US Dollar = £0.72872436 British Pound";
            }
            else if (fromComboBox.SelectedValue.ToString() == "GPB - Pound Sterling" && toComboBox.SelectedValue.ToString() == "INR - Indian Rupee")
            {
                conversionRate = conversionTextBlock.Text = "£1 British Pound = ₹101.68635 Rupee" + "\n₹1 Rupee = £0.0098339397 British Pound";
            }
            else if (fromComboBox.SelectedValue.ToString() == "GPB - Pound Sterling" && toComboBox.SelectedValue.ToString() == "GPB - Pound Sterling")
            {
                conversionRate = conversionTextBlock.Text = "£1 British Pound = £1 British Pound" + "\n£1 British Pound = £1 British Pound";
            }

            //INR
            else if (fromComboBox.SelectedValue.ToString() == "INR - Indian Rupee" && toComboBox.SelectedValue.ToString() == "GPB - Pound Sterling")
            {
                conversionRate = conversionTextBlock.Text = "₹1 Rupee = £0.0098339397 British Pound" + "\n£1 British Pound = ₹101.68635 Rupee";
            }
            else if (fromComboBox.SelectedValue.ToString() == "INR - Indian Rupee" && toComboBox.SelectedValue.ToString() == "USD - US Dollar")
            {
                conversionRate = conversionTextBlock.Text = "₹1 Rupee = $0.011492628 US Dollar" + "\n$1 US Dollar = ₹74.257327 Rupee";
            }
            else if (fromComboBox.SelectedValue.ToString() == "INR - Indian Rupee" && toComboBox.SelectedValue.ToString() == "EUR - Euro")
            {
                conversionRate = conversionTextBlock.Text = "₹1 Rupee = €0.013492774 Euro" + "\n€1 Euro = ₹87.00755 Rupee";
            }
            else if (fromComboBox.SelectedValue.ToString() == "INR - Indian Rupee" && toComboBox.SelectedValue.ToString() == "INR - Indian Rupee")
            {
                conversionRate = conversionTextBlock.Text = "₹1 Rupee = ₹1 Rupee" + "\n₹1 Rupee = ₹1 Rupee";
            }
            return conversionRate;
        }

        //calculate to display text with corresponding to amount dropdown box
        private string calcToAmount(double convertTotal)
        {
            string toAmount;

            if (toComboBox.SelectedValue.ToString() == "GPB - Pound Sterling")
            {
                toAmount = " British Pounds";
            }
            else if (toComboBox.SelectedValue.ToString() == "EUR - Euro")
            {
                toAmount = " Euros";
            }
            else if (toComboBox.SelectedValue.ToString() == "USD - US Dollar")
            {
                toAmount = " US Dollars";
            }
            else
            {
                toAmount = " Indian Rupees";
            }
            return toAmount;
        }

        //to display to currency symbol
        private string calcToSign()
        {
            string toSignAmount;
            //toSignAmount = "";

            if (toComboBox.SelectedValue.ToString() == "GPB - Pound Sterling")
            {
                toSignAmount = "£";
            }
            else if (toComboBox.SelectedValue.ToString() == "EUR - Euro")
            {
                toSignAmount = "€";
            }
            else if (toComboBox.SelectedValue.ToString() == "USD - US Dollar")
            {
                toSignAmount = "$";
            }
            else
            {
                toSignAmount = "₹";
            }
            return toSignAmount;
        }

        //exit button to close the application
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
			this.Frame.Navigate(typeof(GIT_Assignment_Main_Menu.MainMenu));
		}
    }
}
