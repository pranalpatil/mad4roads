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
                        INTREST9_25PCT = 9.25m, Months = 12 ;
        string rate;
        int lowerBound = 40000, uperBound = 80000, selectTermIndex = 0, passwordAttempt = 0, yearSwitch = 0, totalCounter = 0;
        string emiSwitch = "", totalInterestSwitch = "", totalRepaymentsSwitch = "", lineNum, postCode;
        decimal emi1 = 0, emi3 = 0, emi5 = 0, emi7 = 0, yearInMonth1 = 12, yearInMonth3 = 36, yearInMonth5 = 60, yearInMonth7 = 84;
        decimal totalInterest = 0.0m, totalInterest3 = 0.0m, TOTALINTREST5 = 0.0m, TOTALINTREST7 = 0.0m, TOTALREPAYMENTS1 = 0.0m, TOTALREPAYMENTS3 = 0.0m,
                TOTALREPAYMENTS5 = 0.0m, TOTALREPAYMENTS7 = 0.0m, investamount=0.0m,TOTALAMOUNTTAKEN=0m,OVERALLTOTALAMOUNTTAKEN=0m, OverallTotalMonths = 0,TotalMonths = 0, TotalIntrest=0m, OverallTotalIntrest=0m, Averagetotalmonths=0m, Averagetotalamounttaken=0m;

       
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
            int period = tenure*12 ;
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

        //public bool IsWithinRange( string name, decimal min, decimal max, decimal number )
        //{
            
           

        //    if (investamount > 10000 || investamount < 100000)
        //    {
        //        MessageBox.Show(name + " must be between " + min + " and " + max + ".", "Entry Error");
               
        //        return false;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please enter ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        investmentAmountTextBox.SelectAll();
        //        investmentAmountTextBox.Focus();
                
        //    }
        //    return true;
        //}
        private void displayButton_Click(object sender, EventArgs e)
        {
           
            
            try
            {
                investamount = decimal.Parse(investmentAmountTextBox.Text);
                if (investamount >= 10000 && investamount <= 100000)
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
                totalInterest=emi1*yearInMonth1;
                totalInterest3=emi3*yearInMonth3;
                TOTALINTREST5=emi5*yearInMonth5;
                TOTALINTREST7=emi7*yearInMonth7;
                TOTALREPAYMENTS1 = totalInterest+investAmount;
                TOTALREPAYMENTS3 = totalInterest3+investAmount;
                TOTALREPAYMENTS5 = TOTALINTREST5+investAmount;
                TOTALREPAYMENTS7 = TOTALINTREST7+investAmount;

                displayInterest(YEAR1, INTREST6PCT, emi1, totalInterest, TOTALREPAYMENTS1);
                displayInterest(YEAR3, INTREST6_5PCT, emi3, totalInterest3, TOTALREPAYMENTS3);
                displayInterest(YEAR5, INTREST7PCT, emi5, TOTALINTREST5, TOTALREPAYMENTS5);
                displayInterest(YEAR7, INTREST7_5PCT, emi7, TOTALINTREST7, TOTALREPAYMENTS7);
                //repaymentListBOX.Items.Add(YEAR1 + "Year\t" + INTREST6PCT + "%\t" + emi1.ToString("0.00")+ "\t" + totalInterest.ToString("0.00")+ "\t" + TOTALREPAYMENTS1.ToString("0.00"));
                //repaymentListBOX.Items.Add(YEAR3 + "Year\t" + INTREST6_5PCT + "%\t" + emi3.ToString("0.00")+ "\t" + totalInterest3.ToString("0.00")+ "\t" + TOTALREPAYMENTS3.ToString("0.00"));
                //repaymentListBOX.Items.Add(YEAR5 + "Year\t" + INTREST7PCT + "%\t" + emi5.ToString("0.00")+ "\t" + TOTALINTREST5.ToString("0.00")+ "\t" + TOTALREPAYMENTS5.ToString("0.00"));
                //repaymentListBOX.Items.Add(YEAR7 + "Year\t" + INTREST7_5PCT + "%\t" + emi7.ToString("0.00")+ "\t" + TOTALINTREST7.ToString("0.00")+ "\t" + TOTALREPAYMENTS7.ToString("0.00"));
            }
            else if (investAmount >= lowerBound && investAmount < uperBound)
            {
                emi1 = calculateEMI(YEAR1, INTREST8PCT, investAmount);
                emi3 = calculateEMI(YEAR3, INTREST8_5PCT, investAmount);
                emi5 = calculateEMI(YEAR5, INTREST9PCT, investAmount);
                emi7 = calculateEMI(YEAR7, INTREST9_5PCT, investAmount);
                totalInterest=emi1*yearInMonth1;
                totalInterest3=emi3*yearInMonth3;
                TOTALINTREST5=emi5*yearInMonth5;
                TOTALINTREST7=emi7*yearInMonth7;
                TOTALREPAYMENTS1 = totalInterest+investAmount;
                TOTALREPAYMENTS3 = totalInterest3+investAmount;
                TOTALREPAYMENTS5 = TOTALINTREST5+investAmount;
                TOTALREPAYMENTS7 = TOTALINTREST7+investAmount;

                displayInterest(YEAR1, INTREST8PCT, emi1, totalInterest, TOTALREPAYMENTS1);
                displayInterest(YEAR3, INTREST8_5PCT, emi3, totalInterest3, TOTALREPAYMENTS3);
                displayInterest(YEAR5, INTREST9PCT, emi5, TOTALINTREST5, TOTALREPAYMENTS5);
                displayInterest(YEAR7, INTREST9_5PCT, emi7, TOTALINTREST7, TOTALREPAYMENTS7);

                //repaymentListBOX.Items.Add(YEAR1 + "Year\t" + INTREST8PCT + "%\t" + emi1.ToString("0.00")+ "\t" + totalInterest.ToString("0.00")+ "\t" + TOTALREPAYMENTS1.ToString("0.00"));
                //repaymentListBOX.Items.Add(YEAR3 + "Year\t" + INTREST8_5PCT + "%\t" + emi3.ToString("0.00")+ "\t" + totalInterest3.ToString("0.00")+ "\t" + TOTALREPAYMENTS3.ToString("0.00"));
                //repaymentListBOX.Items.Add(YEAR5 + "Year\t" + INTREST9PCT + "%\t" + emi5.ToString("0.00")+ "\t" + TOTALINTREST5.ToString("0.00")+ "\t" + TOTALREPAYMENTS5.ToString("0.00"));
                //repaymentListBOX.Items.Add(YEAR7 + "Year\t" + INTREST9_5PCT + "%\t" + emi7.ToString("0.00")+ "\t" + TOTALINTREST7.ToString("0.00")+ "\t" + TOTALREPAYMENTS7.ToString("0.00"));
            }
            else
            {
                emi1 = calculateEMI(YEAR1, INTREST8_5PCT, investAmount);
                emi3 = calculateEMI(YEAR3, INTREST8_75PCT, investAmount);
                emi5 = calculateEMI(YEAR5, INTREST9_1PCT, investAmount);
                emi7 = calculateEMI(YEAR7, INTREST9_25PCT, investAmount);
                totalInterest=emi1*yearInMonth1;
                totalInterest3=emi3*yearInMonth3;
                TOTALINTREST5=emi5*yearInMonth5;
                TOTALINTREST7=emi7*yearInMonth7;
                TOTALREPAYMENTS1 = totalInterest+investAmount;
                TOTALREPAYMENTS3 = totalInterest3+investAmount;
                TOTALREPAYMENTS5 = TOTALINTREST5+investAmount;
                TOTALREPAYMENTS7 = TOTALINTREST7+investAmount;

                displayInterest(YEAR1, INTREST8_5PCT, emi1, totalInterest, TOTALREPAYMENTS1);
                displayInterest(YEAR3, INTREST8_75PCT, emi3, totalInterest3, TOTALREPAYMENTS3);
                displayInterest(YEAR5, INTREST9_1PCT, emi5, TOTALINTREST5, TOTALREPAYMENTS5);
                displayInterest(YEAR7, INTREST9_25PCT, emi7, TOTALINTREST7, TOTALREPAYMENTS7);

                //repaymentListBOX.Items.Add(YEAR1 + "Year\t" + INTREST8_5PCT + "%\t" + emi1.ToString("0.00")+ "\t" + totalInterest.ToString("0.00")+ "\t" + TOTALREPAYMENTS1.ToString("0.00"));
                //repaymentListBOX.Items.Add(YEAR3 + "Year\t" + INTREST8_75PCT + "%\t" + emi3.ToString("0.00")+ "\t" + totalInterest3.ToString("0.00")+ "\t" + TOTALREPAYMENTS3.ToString("0.00"));
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
            //int x = 0;
            Random random = new Random();
            do
            {
                return random.Next(10000, 100000).ToString();
            }
            while (!alreadyrecord(transactionNo));
            
        }

        private bool alreadyrecord(string NUM)
        {
            bool found = false;
            return found;
        }
        private void proceedButton_Click(object sender, EventArgs e)
        {



            if ((repaymentListBOX.SelectedIndex !=-1))
            {
                selectTermIndex = repaymentListBOX.SelectedIndex;

                switch (selectTermIndex)
                {
                    case 0:
                        yearSwitch=YEAR1; emiSwitch=emi1.ToString(); totalInterestSwitch=totalInterest.ToString(); totalRepaymentsSwitch=TOTALREPAYMENTS1.ToString(); rate = repaymentListBOX.SelectedItem.ToString().Split('\t')[1];
                        break;
                    case 1:
                        yearSwitch=YEAR3; emiSwitch=emi3.ToString(); totalInterestSwitch=totalInterest3.ToString(); totalRepaymentsSwitch=TOTALREPAYMENTS3.ToString(); rate = repaymentListBOX.SelectedItem.ToString().Split('\t')[1];
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

       
        public bool invalid_emailid(string emailaddress)
        {
            
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show("email is not in correct format");
                return false;
            }
        }
        private void submitButton_Click(object sender, EventArgs e)
        {
            Name=investorNameTextBox.Text;
            postCode=postCodeTextBox.Text;
            if (investorNameTextBox.Text == "")
            {
                // first name was incorrect
                MessageBox.Show("Please enter Name", "Message", MessageBoxButtons.OK);
                investorNameTextBox.Focus();
                return;
            }
            if (postCodeTextBox.Text == "")
            {
                // first name was incorrect
                MessageBox.Show("Please enter Post Code", "Message", MessageBoxButtons.OK);
                investorNameTextBox.Focus();
                return;
            }
            if (phoneNumberTextBox.Text == "")
            {
                // first name was incorrect
                MessageBox.Show("Please enter Phone Number", "Message", MessageBoxButtons.OK);
                investorNameTextBox.Focus();
                return;
            }

            if (emailIDTextBox.Text == "")
            {
                // first name was incorrect
                MessageBox.Show("Please enter Email ID", "Message", MessageBoxButtons.OK);
                investorNameTextBox.Focus();
                return;

            }
            else
            {
                bool emailaddress = invalid_emailid(emailIDTextBox.Text);
            }
            DialogResult dialogResult = MessageBox.Show("Name: "+Name+"Post Code: "+postCode, "Error", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                StreamWriter write = File.AppendText(filepath);
                using (write)
                {
                    write.WriteLine(transactionNoLabel.Text);
                    write.WriteLine(emailIDTextBox.Text);
                    write.WriteLine(investorNameTextBox.Text);
                    write.WriteLine(postCodeTextBox.Text);
                    write.WriteLine(phoneNumberTextBox.Text);//skip
                    write.WriteLine(investmentAmountTextBox.Text);
                    write.WriteLine(emiSwitch);
                    write.WriteLine(yearSwitch*12);
                    write.WriteLine(totalRepaymentsSwitch);
                    write.WriteLine(rate);
                    //1-5 skip
                    //6-RW
                    //7skip
                    //8WR
                    //9WR

                    //write.WriteLine("Transaction number: " + transactionNoLabel.Text);
                    //write.WriteLine("Email ID: " + emailIDTextBox.Text);
                    //write.WriteLine("Investor name: " + investorNameTextBox.Text);
                    //write.WriteLine("Postal code" + postCodeTextBox.Text);
                    //write.WriteLine("Contact number: " + phoneNumberTextBox.Text);
                    //write.WriteLine("Principal loan amount: " + investmentAmountTextBox.Text);
                    //write.WriteLine("Monthly EMI: {0}", emiSwitch);
                    //write.WriteLine("Tenure of loan: "+ yearSwitch*12);
                    //write.WriteLine("Total repayment: {0}", totalRepaymentsSwitch);
                    //write.WriteLine("Rate of interest: " + rate);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                
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
            else if (emailSearchRadioButton.Checked==true)
            {
                string searchemailId = searchTransactionInputTextBox.Text;

                //using (tranID)
                //{
                //    string currentlines;
                //    currentlines = tranID.ReadLine();
                //    //string previousLine1 = "";

                //    while (currentlines != null)
                //    {
                //        string comparisonString =searchemailId;
                //        if (currentlines.Equals(comparisonString))
                //        {
                //           for (int i = 0; i < 7; i++)
                //           {
                //                searchTransactionListBox.Items.Add(tranID.ReadLine());

                //                return;

                //           }



                //        }
                //        else
                //        {
                //            currentlines=tranID.ReadLine();
                //        }

                //    }
                //}
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

                            }
                            

                            FileRead.ReadLine();
                            FileRead.ReadLine();

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
        private void clearTransactionButton_Click(object sender, EventArgs e)
        {
           
            searchTransactionListBox.Items.Clear();
            searchTransactionInputTextBox.Clear();
            transactionNoSearchRadioButton.Checked=false;
            emailSearchRadioButton.Checked=false;

      
        }
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
                        lineNum = FileReader.ReadLine(); //6 lines
                        TOTALAMOUNTTAKEN=decimal.Parse(lineNum);
                        OVERALLTOTALAMOUNTTAKEN+=TOTALAMOUNTTAKEN;
                       
                        lineNum= FileReader.ReadLine();// 7 line

                        lineNum = FileReader.ReadLine();// 8 line
                        totalCounter++;

                        TotalMonths=decimal.Parse(lineNum);
                        OverallTotalMonths+=TotalMonths;
                        Averagetotalmonths=OverallTotalMonths/totalCounter;
                        Averagetotalamounttaken=OVERALLTOTALAMOUNTTAKEN/totalCounter;
                        

                        lineNum = FileReader.ReadLine(); // 9 line
                        TotalIntrest=decimal.Parse(lineNum);
                        OverallTotalIntrest+=TotalIntrest;
                        


                        lineNum = FileReader.ReadLine();

                    }
                    summaryListBox.Items.Add("Total Amount Borrowed: "+ OVERALLTOTALAMOUNTTAKEN.ToString("C2"));
                    summaryListBox.Items.Add("Average Duration: "+Averagetotalmonths.ToString());
                    summaryListBox.Items.Add("Average Amount Borrowed: "+Averagetotalamounttaken.ToString("C2"));
                    summaryListBox.Items.Add("Total Interest Accruing: " + OverallTotalIntrest.ToString("C2"));

                    FileReader.Close();
                }
               
            }
            catch
            {

            }
            
        }
    }


    
}


