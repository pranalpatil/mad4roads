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
using System.Net.Mail;
using System.Linq.Expressions;

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
            public const string PASSWORD = "2Fast4U#";//2Fast4U# 
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
                        INTREST9_25PCT = 9.25m, Months = 12 ;
        string rate;

       

        int lowerBound = 40000, uperBound = 80000, selectTermIndex = 0, passwordAttempt = 0, yearSwitch = 0, totalCounter = 0;

        

        string emiSwitch = "", totalInterestSwitch = "", totalRepaymentsSwitch = "", lineNum, postCode, phoneNo, emailId, tId;
        decimal emi1 = 0, emi3 = 0, emi5 = 0, emi7 = 0, yearInMonth1 = 12, yearInMonth3 = 36, yearInMonth5 = 60, yearInMonth7 = 84;
        decimal totalInterest = 0.0m, totalInterest3 = 0.0m, totalInterest5 = 0.0m, totalInterest7 = 0.0m, totalRepayments1 = 0.0m, totalRepayments3 = 0.0m,
                totalRepayments5 = 0.0m, totalRepayments7 = 0.0m, investamount=0.0m,totalAmountTaken=0m,overallTotalAmountTaken=0m, overalltotalMonths = 0,totalMonths = 0, totalInterest1=0m, overallTotalInterest1=0m, averageTotalMonths=0m, averageTotalAmountTaken=0m;

       // Login button use to give access of application and increase the size of application.
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (passwordInputBox.Text != PASSWORD) // Checking if the password is matching.
            {
                passwordAttempt++;  // count the no of attemps
                if(passwordAttempt < 2) // if its greater then to below if-else Method. 
                {
                    MessageBox.Show("You entered wrong password. \n"+passwordAttempt+" out of 2 Attemps", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("You entered wrong password. \n "+passwordAttempt+" out of 2 Attemps", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    
                }
                

            }
            else // once Password matched the size of the application will increase.
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
                    
                }
                // enableing below once password matched
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
        // created method for calculating the EMI formula
        decimal calculateEMI(int tenure, decimal roi, decimal principalAmount)
        {
            decimal cons = 1.00m;
            decimal pct = 100.00m;
            decimal rate = Convert.ToDecimal(roi/12);
            decimal amount = principalAmount;
            int period = tenure*12 ;
            decimal sum = cons + (rate/pct);

            double numValue = Math.Pow(Decimal.ToDouble(sum), period);
            double denomValue = (Math.Pow(Decimal.ToDouble(sum), period) - 1);

            decimal emi = amount*(rate/100)*Convert.ToDecimal(numValue)/Convert.ToDecimal(denomValue);

            return Math.Round(emi,2);
        }

        // created the method tho print interest in list box. 
        public void displayInterest(int year, decimal interest, decimal emi, decimal totalInterest, decimal totalPayment)
        {
           repaymentListBOX.Items.Add(year + "Year\t" + interest + "%\t" + emi.ToString("C")+"\t" + totalInterest.ToString("C")+"\t    "+ totalPayment.ToString("C")+"\t       ");
        }

        // Display all calculation which calling from calculateEMI methord So user can select the option as per requiremnent.
        private void displayButton_Click(object sender, EventArgs e)
        {
           
            
            try
            {
                investamount = decimal.Parse(investmentAmountTextBox.Text);
                if (investamount >= 10000 && investamount <= 100000) // defining Limit of Loan amount
                {
                                   

                }
                else
                {
                    throw new investamoutValidity("Invalid number");
                }
            }
            //Catching the Invalid data for entering customer. 
            catch
            {
                MessageBox.Show("Please enter amount between 10000 to 100000", "Invalid Data entered. ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                investmentAmountTextBox.SelectAll();
                investmentAmountTextBox.Focus();
                return;

            }
            // Converting to decimal and storing the entered amount by customer
            decimal investAmount = Convert.ToDecimal(investmentAmountTextBox.Text);

            if (investAmount < lowerBound)
            {
                emi1 = calculateEMI(YEAR1, INTREST6PCT, investAmount); // calculating the EMI per year. 
                emi3 = calculateEMI(YEAR3, INTREST6_5PCT, investAmount); // calculating the EMI per year
                emi5 = calculateEMI(YEAR5, INTREST7PCT, investAmount); // calculating the EMI per year
                emi7 = calculateEMI(YEAR7, INTREST7_5PCT, investAmount); // calculating the EMI  per year
                totalInterest=emi1*yearInMonth1 - investAmount; // calculating the Total Interest for 1 year
                totalInterest3=emi3*yearInMonth3 - investAmount; // calculating the Total Interest for 3 year
                totalInterest5=emi5*yearInMonth5 - investAmount; // calculating the Total Interest for 5 year
                totalInterest7=emi7*yearInMonth7 - investAmount;// calculating the Total Interest for 7 year
                totalRepayments1 = totalInterest+investAmount; // calculating the total repayments for 1 year
                totalRepayments3 = totalInterest3+investAmount;// calculating the total repayments for 3 year
                totalRepayments5 = totalInterest5+investAmount;// calculating the total repayments for 5 year
                totalRepayments7 = totalInterest7+investAmount;// calculating the total repayments for 7 year

                //Priting the interest and calulation for amount less then 40,000.
                displayInterest(YEAR1, INTREST6PCT, emi1, totalInterest, totalRepayments1); 
                displayInterest(YEAR3, INTREST6_5PCT, emi3, totalInterest3, totalRepayments3);
                displayInterest(YEAR5, INTREST7PCT, emi5, totalInterest5, totalRepayments5);
                displayInterest(YEAR7, INTREST7_5PCT, emi7, totalInterest7, totalRepayments7);
      
            
            }
            else if (investAmount >= lowerBound && investAmount < uperBound)
            {
                emi1 = calculateEMI(YEAR1, INTREST8PCT, investAmount); // calculating the EMI per year.
                emi3 = calculateEMI(YEAR3, INTREST8_5PCT, investAmount); // calculating the EMI per year.
                emi5 = calculateEMI(YEAR5, INTREST9PCT, investAmount); // calculating the EMI per year.
                emi7 = calculateEMI(YEAR7, INTREST9_5PCT, investAmount); // calculating the EMI per year.
                totalInterest=emi1*yearInMonth1 - investAmount; // calculating the Total Interest for 1 year
                totalInterest3=emi3*yearInMonth3 - investAmount; // calculating the Total Interest for 3 year
                totalInterest5=emi5*yearInMonth5 - investAmount; // calculating the Total Interest for 5 year
                totalInterest7=emi7*yearInMonth7 - -investAmount; // calculating the Total Interest for 7 year
                totalRepayments1 = totalInterest+investAmount; // calculating the total repayments for 1 year
                totalRepayments3 = totalInterest3+investAmount; // calculating the total repayments for 3 year
                totalRepayments5 = totalInterest5+investAmount; // calculating the total repayments for 5 year
                totalRepayments7 = totalInterest7+investAmount; // calculating the total repayments for 7 year

                //Priting the interest and calulation for amount greter & less then then 40,000 & less then 80,000.
                displayInterest(YEAR1, INTREST8PCT, emi1, totalInterest, totalRepayments1);
                displayInterest(YEAR3, INTREST8_5PCT, emi3, totalInterest3, totalRepayments3);
                displayInterest(YEAR5, INTREST9PCT, emi5, totalInterest5, totalRepayments5);
                displayInterest(YEAR7, INTREST9_5PCT, emi7, totalInterest7, totalRepayments7);

            }
            else
            {
                emi1 = calculateEMI(YEAR1, INTREST8_5PCT, investAmount); // calculating the EMI per year.
                emi3 = calculateEMI(YEAR3, INTREST8_75PCT, investAmount); // calculating the EMI per year. 
                emi5 = calculateEMI(YEAR5, INTREST9_1PCT, investAmount);// calculating the EMI per year.
                emi7 = calculateEMI(YEAR7, INTREST9_25PCT, investAmount);// calculating the EMI per year.
                totalInterest=emi1*yearInMonth1 - investAmount; // calculating the Total Interest for 1 year
                totalInterest3=emi3*yearInMonth3 - investAmount; // calculating the Total Interest for 3 year
                totalInterest5=emi5*yearInMonth5 - investAmount; // calculating the Total Interest for 5 year
                totalInterest7=emi7*yearInMonth7 - -investAmount; // calculating the Total Interest for 7 year
                totalRepayments1 = totalInterest+investAmount; // calculating the total repayments for 1 year
                totalRepayments3 = totalInterest3+investAmount; // calculating the total repayments for 3 year
                totalRepayments5 = totalInterest5+investAmount; // calculating the total repayments for 5 year
                totalRepayments7 = totalInterest7+investAmount; // calculating the total repayments for 7 year

                //Priting the interest and calulation for amount greter then 80,000.
                displayInterest(YEAR1, INTREST8_5PCT, emi1, totalInterest, totalRepayments1);
                displayInterest(YEAR3, INTREST8_75PCT, emi3, totalInterest3, totalRepayments3);
                displayInterest(YEAR5, INTREST9_1PCT, emi5, totalInterest5, totalRepayments5);
                displayInterest(YEAR7, INTREST9_25PCT, emi7, totalInterest7, totalRepayments7);

            }
            
            displayButton.Enabled=false;
            investmentAmountTextBox.Enabled=false;




        }
        // Clearing the Investment Section so user can again calculate
        private void clearButton_Click(object sender, EventArgs e)
        {
            investmentAmountTextBox.Text="";
            repaymentListBOX.Items.Clear();
            displayButton.Enabled=true;
            investmentAmountTextBox.Enabled=true;

        }
        // created methord to Genrate random 5 digit Transaction numbers.
        private string getRandomTransactionNo()
        {
            string transactionNo;
            //int x = 0;
            Random random = new Random();
            do
            {
                return random.Next(10000, 100000).ToString();
            }
            while (!alreadyrecord(transactionNo));
            
        }
        // checking whether recored are already entered.
        private bool alreadyrecord(string NUM)
        {
            bool found = false;
            return found;
        }

        // Proceed Button select the user selection from list box and store to index.Also Generate the Transaction no for Investor details.
        private void proceedButton_Click(object sender, EventArgs e)
        {



            if ((repaymentListBOX.SelectedIndex !=-1))
            {
                selectTermIndex = repaymentListBOX.SelectedIndex;

                switch (selectTermIndex)
                {
                    case 0:
                        yearSwitch=YEAR1; emiSwitch=emi1.ToString(); totalInterestSwitch=totalInterest.ToString(); totalRepaymentsSwitch=totalRepayments1.ToString(); rate = repaymentListBOX.SelectedItem.ToString().Split('\t')[1];
                        break;
                    case 1:
                        yearSwitch=YEAR3; emiSwitch=emi3.ToString(); totalInterestSwitch=totalInterest3.ToString(); totalRepaymentsSwitch=totalRepayments3.ToString(); rate = repaymentListBOX.SelectedItem.ToString().Split('\t')[1];
                        break;
                    case 2:
                        yearSwitch=YEAR5; emiSwitch=emi5.ToString(); totalInterestSwitch=totalInterest5.ToString(); totalRepaymentsSwitch=totalRepayments5.ToString(); rate = repaymentListBOX.SelectedItem.ToString().Split('\t')[1];
                        break;
                    case 4:
                        yearSwitch=YEAR7; emiSwitch=emi7.ToString(); totalInterestSwitch=totalInterest7.ToString(); totalRepaymentsSwitch=totalRepayments7.ToString(); rate = repaymentListBOX.SelectedItem.ToString().Split('\t')[1];
                        break;

                }
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


        // Method where email id is validating.
        private static Regex invalid_emailid()
        {
            string regexPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(regexPattern, RegexOptions.IgnoreCase);
        }

        static Regex validateID = invalid_emailid();

        // it store the data into text file.
        private void submitButton_Click(object sender, EventArgs e)
        {
            
            Name =investorNameTextBox.Text;
            postCode=postCodeTextBox.Text;
            phoneNo=phoneNumberTextBox.Text;
            emailId=emailIDTextBox.Text;
            tId=transactionNoLabel.Text;


            // Validation for Investor name.
            if (String.IsNullOrEmpty(investorNameTextBox.Text)) 
            { 
                MessageBox.Show("Invalid Customer Name!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                return; 
            }
            
            Regex validationPC = new Regex(@"(?=^.{7}$)");
            // Validation for Investor Post Code.
            if (validationPC.IsMatch(postCodeTextBox.Text) != true)
            {

                MessageBox.Show("Invalid Post Code!"+"\n"+"For eg. H73738H", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                return;
            }
            
            // Validation for Investor Phone Number. where it store only 9 digit.
            Regex phoneValidation = new Regex(@"(?=\d{9}$)");
            if (phoneValidation.IsMatch(phoneNumberTextBox.Text) != true)
            {
                MessageBox.Show("Invalid Phone Number!"+"\n"+"For eg. 738493029", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); phoneNumberTextBox.Focus(); return;

            }
           
            // Validation for email and calling method from above. 
            if (validateID.IsMatch(emailIDTextBox.Text) != true) 
            {
                MessageBox.Show("Invalid Email ID!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
                return; 
            }

            // Dailog Box if we press Yes the data will write in to text file.
            DialogResult dialogResult = MessageBox.Show("Please Confirm Details"+"\n"+"\n"+"Name: "+Name+"\n"+"Post Code: "+postCode+"\n"+"Phone No: "+phoneNo+"\n"+" Email ID: "+emailId+"\n"+"Transaction No: "+tId+"\n"+"\n"+"Loan Details: "+investamount+" @ "+rate+" Over "+yearSwitch+" Year "+"\n"+"\n"+"Confirm Transaction ?", "Confirmation", MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {   
                StreamWriter write = File.AppendText(filepath);
                using (write)
                {
                    write.WriteLine(transactionNoLabel.Text); // Storing the transaction ID
                    write.WriteLine(emailIDTextBox.Text); // Storing the Emailn ID
                    write.WriteLine(investorNameTextBox.Text);// Storing the name
                    write.WriteLine(postCodeTextBox.Text);// Storing the Post Code
                    write.WriteLine(phoneNumberTextBox.Text);// Storing the Phone Number
                    write.WriteLine(investmentAmountTextBox.Text);// Storing the investment amount
                    write.WriteLine(emiSwitch); // Storing the EMI 
                    write.WriteLine(yearSwitch*12); // Storing the Year of loan
                    write.WriteLine(totalRepaymentsSwitch);// Storing the Total Repayments
                    write.WriteLine(rate); // Storing the Interest

                }
                investmentSelectionGroupBox.Enabled=true;
                repaymentListBOX.Items.Clear();
                investmentAmountTextBox.Enabled=true;
                investmentAmountTextBox.Text="";
                investmentAmountTextBox.Focus();
                investmentSelectionGroupBox.Enabled = true;
                displayButton.Enabled=true;
                transactionNoLabel.Text="";
                investorNameTextBox.Text="";
                postCodeTextBox.Text="";
                phoneNumberTextBox.Text="";
                emailIDTextBox.Text="";



            }

            else if (dialogResult == DialogResult.No)
            {
                
            }
               searchTransactionGroupBox.Enabled=true;
          
            
        }

        
         // Search the transacion from transaction ID and Email.
        private void searchTransactionButton_Click(object sender, EventArgs e)
        {
            StreamReader tranID = new StreamReader(filepath);
            


            if (transactionNoSearchRadioButton.Checked==true) // if this is checked the transaction will search by ID 
            {
                string searchtranId = searchTransactionInputTextBox.Text;


                using (tranID)
                {
                    string currentlines;
                    currentlines=tranID.ReadLine();
                    while (currentlines!=null)
                    {
                        if (currentlines.Equals(searchtranId))
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
            else if (emailSearchRadioButton.Checked==true) // if this is checked the transaction will search by Email
            {
                string searchemailId = searchTransactionInputTextBox.Text;

                StreamReader FileRead; 
                try
                {
                    using (FileRead= new StreamReader(filepath)) ;
                    FileRead = File.OpenText(filepath);
                    {
                        while (!FileRead.EndOfStream)
                        {
                            string transID = FileRead.ReadLine();

                            for (int line = 1; line <=1; line++)
                            {
                                string checkMail = FileRead.ReadLine();
                                // Writing all information into file in as below. 
                                if (checkMail.Contains(searchemailId))
                                {
                                    searchTransactionListBox.Items.Add("Transaction number: " + transID);
                                    searchTransactionListBox.Items.Add("Email ID: " + checkMail);
                                    searchTransactionListBox.Items.Add("Name: " + FileRead.ReadLine());
                                    searchTransactionListBox.Items.Add("Postal code: " + FileRead.ReadLine());
                                    searchTransactionListBox.Items.Add("Contact number: " + FileRead.ReadLine());
                                    searchTransactionListBox.Items.Add("Borrowed amount: " + FileRead.ReadLine());
                                    searchTransactionListBox.Items.Add("Monthly EMI: " + FileRead.ReadLine());
                                    searchTransactionListBox.Items.Add("Tenure: " + FileRead.ReadLine());
                                    searchTransactionListBox.Items.Add("Total repayment: " + FileRead.ReadLine());
                                    searchTransactionListBox.Items.Add("Rate of interest: " + FileRead.ReadLine());
                                    searchTransactionListBox.Items.Add("\n\n");
                                }
                                else
                                {
                                    FileRead.ReadLine();
                                    FileRead.ReadLine();
                                    FileRead.ReadLine();
                                    FileRead.ReadLine();
                                    FileRead.ReadLine();
                                    FileRead.ReadLine();
                                    FileRead.ReadLine();
                                    FileRead.ReadLine();
                                }

                            }
                            


                        }
                        FileRead.Close();
                    }

                }
                catch
                {

                }

            }

            else
            {
                MessageBox.Show("select one");
            }


            


        }
        //Clear the transaction group box if next transaction should need to be search.
        private void clearTransactionButton_Click(object sender, EventArgs e)
        {
           
            searchTransactionListBox.Items.Clear();
            searchTransactionInputTextBox.Clear();
            transactionNoSearchRadioButton.Checked=false;
            emailSearchRadioButton.Checked=false;

      
        }
        // Showing all the Summary of the compnay.
        private void summaryButton_Click(object sender, EventArgs e)
        {
            StreamReader FileReader;
            try 
            {
                using (FileReader= new StreamReader(filepath)) ;
                FileReader = File.OpenText(filepath);
                {
                    while (!FileReader.EndOfStream)
                    {
                        for (int line = 1; line <=5; line++) 
                        {
                            FileReader.ReadLine();
                        }
                        lineNum = FileReader.ReadLine(); 
                        totalAmountTaken=decimal.Parse(lineNum);
                        overallTotalAmountTaken+=totalAmountTaken;
                       
                        lineNum= FileReader.ReadLine();

                        lineNum = FileReader.ReadLine();
                        totalCounter++;

                        totalMonths=decimal.Parse(lineNum);
                        overalltotalMonths+=totalMonths;
                        averageTotalMonths=overalltotalMonths/totalCounter;
                        averageTotalAmountTaken=overallTotalAmountTaken/totalCounter;
                        

                        lineNum = FileReader.ReadLine(); 
                        totalInterest1=decimal.Parse(lineNum);
                        overallTotalInterest1+=totalInterest1;
                        


                        lineNum = FileReader.ReadLine();

                    }
                    // priting the data into Summary list box. 
                    summaryListBox.Items.Add("Total Amount Borrowed: "+ overallTotalAmountTaken.ToString("C2"));
                    summaryListBox.Items.Add("Average Duration: "+averageTotalMonths.ToString());
                    summaryListBox.Items.Add("Average Amount Borrowed: "+averageTotalAmountTaken.ToString("C2"));
                    summaryListBox.Items.Add("Total Interest Accruing: " + overallTotalInterest1.ToString("C2"));

                    FileReader.Close();
                }
               
            }
            catch
            {

            }
            summaryButton.Enabled=false;


        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void summaryClearButton_Click(object sender, EventArgs e)
        {
            summaryListBox.Items.Clear();
            summaryButton.Enabled=true;
        }
    }


    
}


