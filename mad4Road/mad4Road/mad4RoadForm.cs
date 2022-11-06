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
        public class investamoutValidity : Exception
        {
            public investamoutValidity(string message) : base(message)
            {
            }
        }
            public const string PASSWORD = "";//2Fast4U#
        string filepath = @"\\Mac\Home\Desktop\Windows Data\University\Assignment 3\Final File\mad4roads_assign3\mad4Road\mad4Road\bin\Debug\transactionData.txt";


        public mad4RoadForm()
        {
            InitializeComponent();
            //passwordAttempt = 0;
        }

        const int EXPANSION = 100, WIDTHSTART = 580, HEIGHTSTART = 400,
                    HEIGHTEXPAND = 660, WIDTHEXPAND = 1000;
        Boolean FormWidthExpanded = false;
        const int YEAR1 = 1, YEAR3 = 3, YEAR5 = 5, YEAR7 = 7;
        const decimal INTREST6PCT = 6.0m, INTREST6_5PCT = 6.5m, INTREST7PCT = 7.0m, INTREST7_5PCT = 7.5m, INTREST8PCT = 8.0m,
                        INTREST8_5PCT = 8.5m, INTREST9PCT = 9.0m, INTREST9_5PCT = 9.5m, INTREST8_75PCT = 8.75m, INTREST9_1PCT = 9.1m,
                        INTREST9_25PCT = 9.25m, Months = 12;

        

        string rate;


        int lowerBound = 40000, uperBound = 80000, selectTermIndex = 0, loginattempt = 0, passwordAttempt = 0, yearSwitch = 0, investamounts=0;
        string emiSwitch = "", totalInterestSwitch = "", totalRepaymentsSwitch = "", transactionId = "";
        decimal emi1 = 0, emi3 = 0, emi5 = 0, emi7 = 0, YearInMonth1 = 12, YearInMonth3 = 36, YearInMonth5 = 60, YearInMonth7 = 84;
        decimal TOTALINTREST1 = 0.0m, TOTALINTREST3 = 0.0m, TOTALINTREST5 = 0.0m, TOTALINTREST7 = 0.0m, TOTALREPAYMENTS1 = 0.0m, TOTALREPAYMENTS3 = 0.0m,
                TOTALREPAYMENTS5 = 0.0m, TOTALREPAYMENTS7 = 0.0m, investamount=0.0m;

       
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (passwordInputBox.Text != PASSWORD)
            {
                passwordAttempt++;
                if(passwordAttempt < 2)
                {
                    MessageBox.Show("You entered wrong password. \n"+passwordAttempt+" out of 2 Attemps");
                }
                else
                {
                    MessageBox.Show("You entered wrong password. \n "+passwordAttempt+" out of 2 Attemps");
                    this.Close();
                    
                }
                

            }
            else
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
                searchTransactionGroupBox.Enabled=true;
                summaryGroupBox.Enabled=true;


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
            //HoursWorked = decimal.Parse(HoursWorkedTextBox.Text);
            


            //double calculateRepayments(int)
            //repayment methd Return
            //create 2 more methd
            if (string.IsNullOrEmpty(investmentAmountTextBox.Text))
            {
                
                MessageBox.Show("Please enter ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                investmentAmountTextBox.SelectAll();
                investmentAmountTextBox.Focus();
                return;
            }
            //Validating the attendees for invalid Data input
            try
            {
                investamount = decimal.Parse(investmentAmountTextBox.Text);
                if (investamount>0)
                {
                                   

                }
                else
                {
                    throw new investamoutValidity("Invalid number");
                }
            }
            //Catching the Invalid number of attendees. 
            catch
            {
                MessageBox.Show("Invalid ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                investmentAmountTextBox.SelectAll();
                investmentAmountTextBox.Focus();
                return;

            }
            decimal investAmount = Convert.ToDecimal(investmentAmountTextBox.Text);

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

        public bool invalid_name(string n)
        {
            Regex check = new Regex(@"^([a-zA-Z]{3,30}\s*)+[a-zA-Z]{3,30}");
            bool valid = false;
            valid =check.IsMatch(n);
            if (valid)
            {
                return valid;
            }
            else
            {
                MessageBox.Show("Name is not in correct format");
                return valid;
            }
        }

        public bool invalid_postcode (string p)
        {
            Regex check = new Regex(@"");
            bool valid = false;
            valid =check.IsMatch(p);
            if (valid)
            {
                return valid;

            }
            else
            {
                MessageBox.Show("Post Code is not in correct format");
                return false;
            }
        }

        public bool invalid_emailid(string em)
        {
            Regex check = new Regex(@"^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$");
            bool valid = false;
            valid =check.IsMatch(em);
            if (valid==true)
            {
                return valid;

            }
            else
            {
                MessageBox.Show("email is not in correct format");
                return valid;
            }
        }
        private void submitButton_Click(object sender, EventArgs e)
        {
             if (investorNameTextBox.Text=="")
            {
                MessageBox.Show("Please enter the valid Details.");
            }
            else
            {
                

            }
            //bool n = invalid_name(investorNameTextBox.Text);
            //bool em = invalid_emailid(emailIDTextBox.Text);



            StreamWriter write = File.AppendText(filepath);
            using (write)
            {
                write.WriteLine("Transaction number: " + transactionNoLabel.Text);
                write.WriteLine("Email ID: " + emailIDTextBox.Text);
                write.WriteLine("Investor name: " + investorNameTextBox.Text);
                write.WriteLine("Postal code" + postCodeTextBox.Text);
                write.WriteLine("Contact number: " + phoneNumberTextBox.Text);
                write.WriteLine("Principal loan amount: " + investmentAmountTextBox.Text);
                write.WriteLine("Monthly EMI: {0}", emiSwitch);
                write.WriteLine("Tenure of loan: "+ yearSwitch*12);
                write.WriteLine("Total repayment: {0}", totalRepaymentsSwitch);
                write.WriteLine("Rate of interest: " + rate);
            }



            searchTransactionGroupBox.Enabled=true;

        }

        
         
        private void searchTransactionButton_Click(object sender, EventArgs e)
        {
            StreamReader tranID = new StreamReader(filepath);
            


            if (transactionNoSearchRadioButton.Checked==true)
            {
                string searchtranId = searchTransactionInputTextBox.Text;


                using (tranID)
                {
                    string currentlines;
                    currentlines=tranID.ReadLine();
                    while (currentlines!=null)
                    {
                        if (currentlines.Equals("Transaction number: " + searchtranId))
                        {
                            for (int i = 0; i < 9; i++)
                            {
                                searchTransactionListBox.Items.Add(tranID.ReadLine());
                            }

                            break;

                        }
                        else
                        {
                            currentlines=tranID.ReadLine();
                        }
                    }
                }

            }
            else if (emailSearchRadioButton.Checked==true)
            {
                string searchemailId = searchTransactionInputTextBox.Text;


                //var pattern = @"Transaction number:\s*\d+\s*\nEmail ID: " + searchemailId + "(.|\n)*";
                //string information = System.IO.File.ReadAllText(filepath);
                //MatchCollection matches = Regex.Matches(information, pattern);

                //foreach (Match match in matches)
                //{
                //    //Console.WriteLine(match.Groups[1].Value);
                //    var stringList = match.Value.Split(new[] { "Transaction" }, StringSplitOptions.None);
                //    foreach ()
                //    if (match.Value.Split(new[] { "Transaction" }, StringSplitOptions.None))
                //    {
                //        searchTransactionListBox.Items.Add("Transaction" + match.Value.Split(new[] { "Transaction" }, StringSplitOptions.None)[1].Split('\n')[0]);
                //        searchTransactionListBox.Items.Add(match.Value.Split(new[] { "Transaction" }, StringSplitOptions.None)[1].Split('\n')[1]);
                //        searchTransactionListBox.Items.Add(match.Value.Split(new[] { "Transaction" }, StringSplitOptions.None)[1].Split('\n')[2]);
                //        searchTransactionListBox.Items.Add(match.Value.Split(new[] { "Transaction" }, StringSplitOptions.None)[1].Split('\n')[3]);
                //        searchTransactionListBox.Items.Add(match.Value.Split(new[] { "Transaction" }, StringSplitOptions.None)[1].Split('\n')[4]);
                //        searchTransactionListBox.Items.Add(match.Value.Split(new[] { "Transaction" }, StringSplitOptions.None)[1].Split('\n')[5]);
                //        searchTransactionListBox.Items.Add(match.Value.Split(new[] { "Transaction" }, StringSplitOptions.None)[1].Split('\n')[6]);
                //        searchTransactionListBox.Items.Add(match.Value.Split(new[] { "Transaction" }, StringSplitOptions.None)[1].Split('\n')[7]);
                //        searchTransactionListBox.Items.Add(match.Value.Split(new[] { "Transaction" }, StringSplitOptions.None)[1].Split('\n')[8]);
                //        searchTransactionListBox.Items.Add(match.Value.Split(new[] { "Transaction" }, StringSplitOptions.None)[1].Split('\n')[9]);
                //    }

                //}

                using (tranID)
                {
                    string currentlines;
                    currentlines = tranID.ReadLine();
                    string previousLine1 = "";

                    while(currentlines != null)
                    {
                        string comparisonString = "Email ID: " + searchemailId;
                        if (currentlines.Equals(comparisonString))
                        {

                            searchTransactionListBox.Items.Add(comparisonString);
                            for (int i = 0; i < 7; i++)
                            {
                                searchTransactionListBox.Items.Add(tranID.ReadLine());
                            }
                            break;
                        }
                        else
                        {
                            currentlines=tranID.ReadLine();
                        }
                    }
                    

                    //if (currentlines.Contains(searchemailId))
                    //{
                    //    searchTransactionListBox.Items.Add("Email ID: " + searchemailId);
                    //    //for (int i = 0; i < 7; i++)
                    //    //{
                    //    //    searchTransactionListBox.Items.Add(tranID.ReadLine());
                    //    //}
                    //}
         
                }

            }

            else
            {
                MessageBox.Show("select one");
            }

            


            //try
            //{
            //    string transactionNo = searchTransactionInputTextBox.Text;
            //    StreamReader InputFile;
            //    string information = System.IO.File.ReadAllText(filepath);
            //    searchTransactionListBox.Items.Clear();

            //    var pattern = @"Transaction number: " + transactionNo + "(.|\n)*" + @"\s*(Transaction number: |.)";
            //    var match = Regex.Match(information, pattern);

            //    searchTransactionListBox.Items.Add(match.Value.ToString().Split('\n')[0]);
            //    searchTransactionListBox.Items.Add(match.Value.ToString().Split('\n')[1]);
            //    searchTransactionListBox.Items.Add(match.Value.ToString().Split('\n')[2]);
            //    searchTransactionListBox.Items.Add(match.Value.ToString().Split('\n')[3]);
            //    searchTransactionListBox.Items.Add(match.Value.ToString().Split('\n')[4]);
            //    searchTransactionListBox.Items.Add(match.Value.ToString().Split('\n')[5]);
            //    searchTransactionListBox.Items.Add(match.Value.ToString().Split('\n')[6]);
            //    searchTransactionListBox.Items.Add(match.Value.ToString().Split('\n')[7]);
            //    searchTransactionListBox.Items.Add(match.Value.ToString().Split('\n')[8]);
            //    searchTransactionListBox.Items.Add(match.Value.ToString().Split('\n')[9]);

            //    //InputFile.Close();
            //}
            //catch
            //{
            //    MessageBox.Show("wrong");
            //}

            

        }
        private void clearTransactionButton_Click(object sender, EventArgs e)
        {
           
            searchTransactionListBox.Items.Clear();
            searchTransactionInputTextBox.Clear();
            transactionNoSearchRadioButton.Checked=false;
            emailSearchRadioButton.Checked=false;

        }
    }


    
}


