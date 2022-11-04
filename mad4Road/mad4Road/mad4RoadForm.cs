using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using System.Security.Cryptography;
using System.IO;
using System.Xml.Linq;

namespace mad4Road
{
    public partial class mad4RoadForm : Form
    {

        public const string PASSWORD = "";//2Fast4U#
        string filepath = @"\\Mac\Home\Desktop\Windows Data\University\Assignment 3\Final File\mad4roads_assign3\mad4Road\mad4Road\bin\Debug\transactionData.txt";


        public mad4RoadForm()
        {
            InitializeComponent();

        }

        const int EXPANSION = 100, WIDTHSTART = 580, HEIGHTSTART = 400,
                    HEIGHTEXPAND = 660, WIDTHEXPAND = 1000;
        Boolean FormWidthExpanded = false;
        const int YEAR1 = 1, YEAR3 = 3, YEAR5 = 5, YEAR7 = 7;
        const decimal INTREST6PCT = 6.0m, INTREST6_5PCT = 6.5m, INTREST7PCT = 7.0m, INTREST7_5PCT = 7.5m, INTREST8PCT = 8.0m,
                        INTREST8_5PCT = 8.5m, INTREST9PCT = 9.0m, INTREST9_5PCT = 9.5m, INTREST8_75PCT = 8.75m, INTREST9_1PCT = 9.1m,
                        INTREST9_25PCT = 9.25m, Months = 12;

        

        string rate;


        int lowerBound = 40000, uperBound = 80000, selectTermIndex = 0, loginattempt = 0, passwordAttempt = 1, yearSwitch = 0, intrestPerSwitch = 0;
        string emiSwitch = "", totalInterestSwitch = "", totalRepaymentsSwitch = "", transactionId = "";
        decimal emi1 = 0, emi3 = 0, emi5 = 0, emi7 = 0, YearInMonth1 = 12, YearInMonth3 = 36, YearInMonth5 = 60, YearInMonth7 = 84;
        decimal TOTALINTREST1 = 0.0m, TOTALINTREST3 = 0.0m, TOTALINTREST5 = 0.0m, TOTALINTREST7 = 0.0m, TOTALREPAYMENTS1 = 0.0m, TOTALREPAYMENTS3 = 0.0m,
                TOTALREPAYMENTS5 = 0.0m, TOTALREPAYMENTS7 = 0.0m;


        private void loginButton_Click(object sender, EventArgs e)
        {
            if (passwordInputBox.Text.Equals(PASSWORD))
            {
                if (!FormWidthExpanded)
                {
                    for (int i = WIDTHSTART; i < WIDTHEXPAND; i +=
                    EXPANSION)
                    {
                        this.Size = new Size(i, HEIGHTEXPAND);
                        this.Update();
                        System.Threading.Thread.Sleep(1);
                    }
                    //FormWidthExpanded = false;
                    //FormHeightExpanded = false;
                }
                passwordInputBox.Visible = false;
                passwordLabel.Visible=false;
                logoPictureBox.Visible=false;
                loginButton.Visible=false;
                investmentSelectionGroupBox.Visible=true;
                investorDetailsGroupBox.Visible=true;
                searchTransactionGroupBox.Visible=true;
                summaryGroupBox.Visible=true;
                buttonLogoPictureBox.Visible=true;
                investorDetailsGroupBox.Enabled=false;
                searchTransactionGroupBox.Enabled=false;
                summaryGroupBox.Enabled=false;

            }
            else
            {

                MessageBox.Show("You entered wrong password. \n "+passwordAttempt+"\n out of 2 Attemps");

                passwordAttempt+=1;

                if (passwordAttempt==3)
                {
                    MessageBox.Show("You entered wrong password. \n "+passwordAttempt+"\n out of 2 Attemps");
                    this.Close();
                }

            }





        }
        decimal calculateEMI(int tenure, decimal roi, decimal principalAmount)
        {
            decimal cons = 1.00m;
            decimal pct = 100.00m;
            decimal rate = Convert.ToDecimal(roi/12);
            decimal amount = principalAmount;
            int period = tenure*12;
            decimal sum = cons + rate/pct;

            double numValue = Math.Pow(Decimal.ToDouble(sum), period);
            double denomValue = (Math.Pow(Decimal.ToDouble(sum), period) - 1);

            decimal emi = amount*(rate/100)*Convert.ToDecimal(numValue)/Convert.ToDecimal(denomValue);

            return emi;
        }

        public void displayInterest(int year, decimal interest, decimal emi, decimal totalInterest, decimal totalPayment)
        {
            repaymentListBOX.Items.Add(year + "Year\t" + interest + "%\t" + emi.ToString("0.00")+ "\t    " + totalInterest.ToString("0.00")+ "\t  " + totalPayment.ToString("0.00"));
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            decimal investAmount = Convert.ToDecimal(investmentAmountTextBox.Text);


            //double calculateRepayments(int)
            //repayment methd Return
            //create 2 more methd


            if (investAmount < lowerBound)
            {
                emi1 = calculateEMI(YEAR1, INTREST6PCT, investAmount);
                emi3 = calculateEMI(YEAR3, INTREST6_5PCT, investAmount);
                emi5 = calculateEMI(YEAR5, INTREST7PCT, investAmount);
                emi7 = calculateEMI(YEAR7, INTREST7_5PCT, investAmount);
                TOTALINTREST1=emi1*YearInMonth1;
                TOTALINTREST3=emi3*YearInMonth3;
                TOTALINTREST5=emi5*YearInMonth5;
                TOTALINTREST7=emi7*YearInMonth7;
                TOTALREPAYMENTS1 = TOTALINTREST1+investAmount;
                TOTALREPAYMENTS3 = TOTALINTREST3+investAmount;
                TOTALREPAYMENTS5 = TOTALINTREST5+investAmount;
                TOTALREPAYMENTS7 = TOTALINTREST7+investAmount;

                displayInterest(YEAR1, INTREST6PCT, emi1, TOTALINTREST1, TOTALREPAYMENTS1);
                displayInterest(YEAR3, INTREST6_5PCT, emi3, TOTALINTREST3, TOTALREPAYMENTS3);
                displayInterest(YEAR5, INTREST7PCT, emi5, TOTALINTREST5, TOTALREPAYMENTS5);
                displayInterest(YEAR7, INTREST7_5PCT, emi7, TOTALINTREST7, TOTALREPAYMENTS7);
                //repaymentListBOX.Items.Add(YEAR1 + "Year\t" + INTREST6PCT + "%\t" + emi1.ToString("0.00")+ "\t" + TOTALINTREST1.ToString("0.00")+ "\t" + TOTALREPAYMENTS1.ToString("0.00"));
                //repaymentListBOX.Items.Add(YEAR3 + "Year\t" + INTREST6_5PCT + "%\t" + emi3.ToString("0.00")+ "\t" + TOTALINTREST3.ToString("0.00")+ "\t" + TOTALREPAYMENTS3.ToString("0.00"));
                //repaymentListBOX.Items.Add(YEAR5 + "Year\t" + INTREST7PCT + "%\t" + emi5.ToString("0.00")+ "\t" + TOTALINTREST5.ToString("0.00")+ "\t" + TOTALREPAYMENTS5.ToString("0.00"));
                //repaymentListBOX.Items.Add(YEAR7 + "Year\t" + INTREST7_5PCT + "%\t" + emi7.ToString("0.00")+ "\t" + TOTALINTREST7.ToString("0.00")+ "\t" + TOTALREPAYMENTS7.ToString("0.00"));
            }
            else if (investAmount >= lowerBound && investAmount < uperBound)
            {
                emi1 = calculateEMI(YEAR1, INTREST8PCT, investAmount);
                emi3 = calculateEMI(YEAR3, INTREST8_5PCT, investAmount);
                emi5 = calculateEMI(YEAR5, INTREST9PCT, investAmount);
                emi7 = calculateEMI(YEAR7, INTREST9_5PCT, investAmount);
                TOTALINTREST1=emi1*YearInMonth1;
                TOTALINTREST3=emi3*YearInMonth3;
                TOTALINTREST5=emi5*YearInMonth5;
                TOTALINTREST7=emi7*YearInMonth7;
                TOTALREPAYMENTS1 = TOTALINTREST1+investAmount;
                TOTALREPAYMENTS3 = TOTALINTREST3+investAmount;
                TOTALREPAYMENTS5 = TOTALINTREST5+investAmount;
                TOTALREPAYMENTS7 = TOTALINTREST7+investAmount;

                displayInterest(YEAR1, INTREST8PCT, emi1, TOTALINTREST1, TOTALREPAYMENTS1);
                displayInterest(YEAR3, INTREST8_5PCT, emi3, TOTALINTREST3, TOTALREPAYMENTS3);
                displayInterest(YEAR5, INTREST9PCT, emi5, TOTALINTREST5, TOTALREPAYMENTS5);
                displayInterest(YEAR7, INTREST9_5PCT, emi7, TOTALINTREST7, TOTALREPAYMENTS7);

                //repaymentListBOX.Items.Add(YEAR1 + "Year\t" + INTREST8PCT + "%\t" + emi1.ToString("0.00")+ "\t" + TOTALINTREST1.ToString("0.00")+ "\t" + TOTALREPAYMENTS1.ToString("0.00"));
                //repaymentListBOX.Items.Add(YEAR3 + "Year\t" + INTREST8_5PCT + "%\t" + emi3.ToString("0.00")+ "\t" + TOTALINTREST3.ToString("0.00")+ "\t" + TOTALREPAYMENTS3.ToString("0.00"));
                //repaymentListBOX.Items.Add(YEAR5 + "Year\t" + INTREST9PCT + "%\t" + emi5.ToString("0.00")+ "\t" + TOTALINTREST5.ToString("0.00")+ "\t" + TOTALREPAYMENTS5.ToString("0.00"));
                //repaymentListBOX.Items.Add(YEAR7 + "Year\t" + INTREST9_5PCT + "%\t" + emi7.ToString("0.00")+ "\t" + TOTALINTREST7.ToString("0.00")+ "\t" + TOTALREPAYMENTS7.ToString("0.00"));
            }
            else
            {
                emi1 = calculateEMI(YEAR1, INTREST8_5PCT, investAmount);
                emi3 = calculateEMI(YEAR3, INTREST8_75PCT, investAmount);
                emi5 = calculateEMI(YEAR5, INTREST9_1PCT, investAmount);
                emi7 = calculateEMI(YEAR7, INTREST9_25PCT, investAmount);
                TOTALINTREST1=emi1*YearInMonth1;
                TOTALINTREST3=emi3*YearInMonth3;
                TOTALINTREST5=emi5*YearInMonth5;
                TOTALINTREST7=emi7*YearInMonth7;
                TOTALREPAYMENTS1 = TOTALINTREST1+investAmount;
                TOTALREPAYMENTS3 = TOTALINTREST3+investAmount;
                TOTALREPAYMENTS5 = TOTALINTREST5+investAmount;
                TOTALREPAYMENTS7 = TOTALINTREST7+investAmount;

                displayInterest(YEAR1, INTREST8_5PCT, emi1, TOTALINTREST1, TOTALREPAYMENTS1);
                displayInterest(YEAR3, INTREST8_75PCT, emi3, TOTALINTREST3, TOTALREPAYMENTS3);
                displayInterest(YEAR5, INTREST9_1PCT, emi5, TOTALINTREST5, TOTALREPAYMENTS5);
                displayInterest(YEAR7, INTREST9_25PCT, emi7, TOTALINTREST7, TOTALREPAYMENTS7);

                //repaymentListBOX.Items.Add(YEAR1 + "Year\t" + INTREST8_5PCT + "%\t" + emi1.ToString("0.00")+ "\t" + TOTALINTREST1.ToString("0.00")+ "\t" + TOTALREPAYMENTS1.ToString("0.00"));
                //repaymentListBOX.Items.Add(YEAR3 + "Year\t" + INTREST8_75PCT + "%\t" + emi3.ToString("0.00")+ "\t" + TOTALINTREST3.ToString("0.00")+ "\t" + TOTALREPAYMENTS3.ToString("0.00"));
                //repaymentListBOX.Items.Add(YEAR5 + "Year\t" + INTREST9_1PCT + "%\t" + emi5.ToString("0.00")+ "\t" + TOTALINTREST5.ToString("0.00")+ "\t" + TOTALREPAYMENTS5.ToString("0.00"));
                //repaymentListBOX.Items.Add(YEAR7 + "Year\t" + INTREST9_25PCT + "%\t" + emi7.ToString("0.00")+ "\t" + TOTALINTREST7.ToString("0.00")+ "\t" + TOTALREPAYMENTS7.ToString("0.00"));


            }




            displayButton.Enabled=false;
            investmentAmountTextBox.Enabled=false;




        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            investmentAmountTextBox.Text="";
            repaymentListBOX.Items.Clear();
            displayButton.Enabled=true;
            investmentAmountTextBox.Enabled=true;

        }

        private string getRandomTransactionNo()
        {
            string transactionNo;
            int x = 0;
            Random random = new Random();

            return random.Next(10000, 100000).ToString();
        }

        private void proceedButton_Click(object sender, EventArgs e)
        {



            if ((repaymentListBOX.SelectedIndex !=-1))
            {
                selectTermIndex = repaymentListBOX.SelectedIndex;

                switch (selectTermIndex)
                {
                    case 0:
                        yearSwitch=YEAR1; emiSwitch=emi1.ToString(); totalInterestSwitch=TOTALINTREST1.ToString(); totalRepaymentsSwitch=TOTALREPAYMENTS1.ToString(); rate = repaymentListBOX.SelectedItem.ToString().Split('\t')[1];
                        break;
                    case 1:
                        yearSwitch=YEAR3; emiSwitch=emi3.ToString(); totalInterestSwitch=TOTALINTREST3.ToString(); totalRepaymentsSwitch=TOTALREPAYMENTS3.ToString(); rate = repaymentListBOX.SelectedItem.ToString().Split('\t')[1];
                        break;
                    case 2:
                        yearSwitch=YEAR5; emiSwitch=emi5.ToString(); totalInterestSwitch=TOTALINTREST5.ToString(); totalRepaymentsSwitch=TOTALREPAYMENTS5.ToString(); rate = repaymentListBOX.SelectedItem.ToString().Split('\t')[1];
                        break;
                    case 4:
                        yearSwitch=YEAR7; emiSwitch=emi7.ToString(); totalInterestSwitch=TOTALINTREST7.ToString(); totalRepaymentsSwitch=TOTALREPAYMENTS7.ToString(); rate = repaymentListBOX.SelectedItem.ToString().Split('\t')[1];
                        break;

                }
                //searchTransactionLabel.Text= term3;
                investorDetailsGroupBox.Enabled=true;
                investmentSelectionGroupBox.Enabled=false;
                transactionNoLabel.Text=getRandomTransactionNo();

            }

            else
            {
                MessageBox.Show("Please Select the Loan term", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                repaymentListBOX.Focus();
            }






        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            StreamWriter write = File.AppendText(filepath);
            using (write)
            {
                write.WriteLine(transactionNoLabel.Text);
                write.WriteLine(emailIDTextBox.Text);
                write.WriteLine(investorNameTextBox.Text);
                write.WriteLine(postCodeTextBox.Text);
                write.WriteLine(phoneNumberTextBox.Text);
                write.WriteLine(investmentAmountTextBox.Text);
                write.WriteLine(emiSwitch);
                write.WriteLine(yearSwitch*12);
                write.WriteLine(totalRepaymentsSwitch);
                write.WriteLine(rate);

            }



            searchTransactionGroupBox.Enabled=true;


        }



        private void searchTransactionButton_Click(object sender, EventArgs e)
        {

            StreamReader fileRead = new StreamReader(filepath);
            string ID = Console.ReadLine();





            using (fileRead)
            {
                string currentLineValue;
                currentLineValue=fileRead.ReadLine();

                while (currentLineValue != null)
                {
                    if (currentLineValue.Equals(currentLineValue))
                    {
                        for (int i = 0; i < 9; i++)
                        {

                        }
                        Console.WriteLine(fileRead.ReadLine());
                        Console.WriteLine(fileRead.ReadLine());
                        Console.WriteLine(fileRead.ReadLine());
                        break;
                    }
                    else
                    {
                        currentLineValue=fileRead.ReadLine();
                    }
                    searchTransactionListBox.Items.Add(currentLineValue);
                }

            }

        }
        private void clearTransactionButton_Click(object sender, EventArgs e)
        {
           
                searchTransactionListBox.Items.Clear();
            searchTransactionInputTextBox.Clear();
        }
    }


    
}


