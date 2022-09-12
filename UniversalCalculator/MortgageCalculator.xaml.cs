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

// Author: Julia Long, Sept. 2022

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MortgageCalculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MortgageCalculator : Page
    {
        public MortgageCalculator()
        {
            this.InitializeComponent();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            principalBorrowTextBox.Text = "";
            yearsTextBox.Text = "";
            monthsTextBox.Text = "0";
            principalBorrowTextBox.Text = "";
            yearlyInterestTextBox.Text = "";
            monthlyInterestTextBox.Text = "";
            monthlyRepayTextBox.Text = "";
            principalBorrowTextBox.Focus(FocusState.Programmatic);
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Variable declarations 
            double M;
            double P;
            double i;
            double annualInterestRate;
            double loanLengthInYears;
            double loanLengthExtraMonths;

            // copy the Principal Borrowed Loan Amount (loan amount borrowed)
            P = double.Parse(principalBorrowTextBox.Text);
            // copy the years of the loan length
            loanLengthInYears = double.Parse(yearsTextBox.Text);
            // copy any extra months, ***(should make default to 0!)
            loanLengthExtraMonths = double.Parse(monthsTextBox.Text);
            // copy the user's annualInterestRate
            annualInterestRate = double.Parse(yearlyInterestTextBox.Text);

            // call function to get monthly interest rate, with 1 parameter -- annualInterestRate
            i = calculateMonthlyInterest(annualInterestRate);
            // call function passing the main 4 parameters for final mortgage repayment result
            M = calculateMortgageRepayment(P, annualInterestRate, loanLengthInYears, loanLengthExtraMonths);

            // Display result of i, like... 0.1234%
            monthlyInterestTextBox.Text = i.ToString("F4") + "%";
            // Display result of M, like... $1234.12
            monthlyRepayTextBox.Text = M.ToString("C2");
        }
        
        // Exit button to go back to main menu
        private void exitButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // return to the universal calculator menu page ***
            this.Frame.Navigate(typeof(GIT_Assignment_Main_Menu.MainMenu));
        }

        // METHOD FUNCTIONS (total of 2)
        // Function method for calculating Monthly Interest Rate!!
        private double calculateMonthlyInterest(double annualInterestRate)
        {
            // convert the interest rate into a suitable decimal number, 3.5 --> 0.035
            annualInterestRate /= 100;
            // divide the converted InterestRate by 12 (months) to get the monthly interest rate!
            // monthlyInterestRate = annualInterestRate / 12;
            return annualInterestRate / 12;
        }

        // Function method for calculating the Mortgage Repayments!!
        private double calculateMortgageRepayment(double borrowedLoanAmount, double interestRate, double years, double months)
        {
            /*  
             *  equation to calculate the Monthly Repayment:
             *  M = P[i(1 + i) ^ n] / [(1 + i) ^ n – 1]
             *  P = Principal Loan Amount
             *  i = monthly interest rate
             *  n = number of months required to repay the loan
            */
            // I will resave some parameters into variables corresponding to the letters in the formula...
            double P;
            double i;
            double n;
            double annualInterestRate;
            double powResult;
            double yearsMonthsCombined;

            // copy the borrowed Loan Amount
            P = borrowedLoanAmount;
            // copy years and months together. Ensure to divide months into a decimal so it doesn't get mistakenly added as years! Like, 3 months is 0.25 years
            yearsMonthsCombined = years + (months / 12);
            // copy annualInterestRate
            annualInterestRate = interestRate;

            // call calculateMonthlyInterest function by passing annualInterestRate
            i = calculateMonthlyInterest(annualInterestRate);

            // get the total amount of months required to repay the borrowedLoanAmount
            n = yearsMonthsCombined * 12;

            // store Math.Pow result of (1+i^n) in powResult variable (makes reading it in the end formula much readable with less brackets)
            powResult = Math.Pow(1 + i, n);

            // M =
            return P * (i * powResult) / (powResult - 1);
        }


        /*
         * Past failed code from when I didn't know how to incorporate the formula... that pesky Math.Pow nesting...
         * 
         //double principalLoan, yearlyInterestRate, noOfPayments, termOfLoan;
            //int yearlyLength, monthsLength;
            //double monthlyInterestRate;
            //double monthlyRepayment;

            double loan;
            double rate;
            double yearlyPeriod;
            double numberOfPayments;
            double result;
            double monthlyRate;

            loan = double.Parse(principalBorrowTextBox.Text);
            yearlyPeriod = double.Parse(yearsTextBox.Text);
            rate = double.Parse(yearlyInterestTextBox.Text);

            //monthlyRate = rate / 12;
            numberOfPayments = yearlyPeriod * 12;

            //result = (loan * (monthlyRate * (Math.Pow(1 + monthlyRate, numberOfPayments)) / (Math.Pow(1 + monthlyRate, numberOfPayments) – 1);

            // P * ((r * (Math.Pow(1 + r, n))) / (Math.Pow(1 + r, n) – 1))

            // convert the yearly rate into a decimal number, example: 3.5 / 100 = 0.035
            //yearlyInterestRate = double.Parse(yearlyInterestTextBox.Text) / 100;

            //// if a loan must be paid every month of a year, 12 is the payment frequency
            //monthlyInterestRate = yearlyInterestRate / 12;
            //monthlyInterestTextBox.Text = monthlyInterestRate.ToString();

            ////find the number of payments required to pay the loan
            //noOfPayments = yearlyLength * 12;

            //// term of loan
            //termOfLoan = Math.Pow(1 + monthlyInterestRate, noOfPayments);

            //// final calculations
            //// monthlyRepayment = principalLoan * (monthlyInterestRate * (Math.Pow(1 + termOfLoan, noOfPayments) / (Math.Pow(1 + monthlyInterestRate, noOfPayments) - 1)));
            ////monthlyRepayment = principalLoan * (monthlyInterestRate * termOfLoan) / termOfLoan -1;
            //monthlyRepayment = yearlyInterestRate * yearlyLength / (1 - Math.Pow(1 + monthlyInterestRate, noOfPayments * -1));

            monthlyRepayTextBox.Text = result.ToString();
         */
    }
}
