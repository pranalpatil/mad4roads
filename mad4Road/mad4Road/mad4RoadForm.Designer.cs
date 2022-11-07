namespace mad4Road
{
    partial class mad4RoadForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mad4RoadForm));
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordInputBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.investmentSelectionGroupBox = new System.Windows.Forms.GroupBox();
            this.totalRepaymentsLabel = new System.Windows.Forms.Label();
            this.totalInterestLabel = new System.Windows.Forms.Label();
            this.monthlyInterestLabel = new System.Windows.Forms.Label();
            this.interestRateLabel = new System.Windows.Forms.Label();
            this.periodLabel = new System.Windows.Forms.Label();
            this.proceedButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.displayButton = new System.Windows.Forms.Button();
            this.repaymentListBOX = new System.Windows.Forms.ListBox();
            this.investmentAmountTextBox = new System.Windows.Forms.TextBox();
            this.investmentAmountLabel = new System.Windows.Forms.Label();
            this.investorDetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.transactionNoLabel = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.emailIDTextBox = new System.Windows.Forms.TextBox();
            this.phoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.postCodeTextBox = new System.Windows.Forms.TextBox();
            this.investorNameTextBox = new System.Windows.Forms.TextBox();
            this.phoneNumberLabel = new System.Windows.Forms.Label();
            this.emailIDLabel = new System.Windows.Forms.Label();
            this.postCodeLabel = new System.Windows.Forms.Label();
            this.transactionNameLabel = new System.Windows.Forms.Label();
            this.investorNameLabel = new System.Windows.Forms.Label();
            this.searchTransactionGroupBox = new System.Windows.Forms.GroupBox();
            this.searchTransactionListBox = new System.Windows.Forms.ListBox();
            this.clearTransactionButton = new System.Windows.Forms.Button();
            this.searchTransactionButton = new System.Windows.Forms.Button();
            this.searchTransactionInputTextBox = new System.Windows.Forms.TextBox();
            this.transactionNoSearchRadioButton = new System.Windows.Forms.RadioButton();
            this.emailSearchRadioButton = new System.Windows.Forms.RadioButton();
            this.transactionResultsLabel = new System.Windows.Forms.Label();
            this.summaryGroupBox = new System.Windows.Forms.GroupBox();
            this.summaryListBox = new System.Windows.Forms.ListBox();
            this.summaryButton = new System.Windows.Forms.Button();
            this.buttonLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.investmentSelectionGroupBox.SuspendLayout();
            this.investorDetailsGroupBox.SuspendLayout();
            this.searchTransactionGroupBox.SuspendLayout();
            this.summaryGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLogoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(557, 51);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(741, 212);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 0;
            this.logoPictureBox.TabStop = false;
            // 
            // passwordLabel
            // 
            this.passwordLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(663, 339);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(220, 31);
            this.passwordLabel.TabIndex = 1;
            this.passwordLabel.Text = "Enter Password";
            // 
            // passwordInputBox
            // 
            this.passwordInputBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.passwordInputBox.Location = new System.Drawing.Point(926, 339);
            this.passwordInputBox.Name = "passwordInputBox";
            this.passwordInputBox.PasswordChar = '*';
            this.passwordInputBox.Size = new System.Drawing.Size(252, 31);
            this.passwordInputBox.TabIndex = 2;
            // 
            // loginButton
            // 
            this.loginButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.Location = new System.Drawing.Point(818, 420);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(146, 47);
            this.loginButton.TabIndex = 3;
            this.loginButton.Text = "Log In";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // investmentSelectionGroupBox
            // 
            this.investmentSelectionGroupBox.Controls.Add(this.totalRepaymentsLabel);
            this.investmentSelectionGroupBox.Controls.Add(this.totalInterestLabel);
            this.investmentSelectionGroupBox.Controls.Add(this.monthlyInterestLabel);
            this.investmentSelectionGroupBox.Controls.Add(this.interestRateLabel);
            this.investmentSelectionGroupBox.Controls.Add(this.periodLabel);
            this.investmentSelectionGroupBox.Controls.Add(this.proceedButton);
            this.investmentSelectionGroupBox.Controls.Add(this.clearButton);
            this.investmentSelectionGroupBox.Controls.Add(this.displayButton);
            this.investmentSelectionGroupBox.Controls.Add(this.repaymentListBOX);
            this.investmentSelectionGroupBox.Controls.Add(this.investmentAmountTextBox);
            this.investmentSelectionGroupBox.Controls.Add(this.investmentAmountLabel);
            this.investmentSelectionGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.investmentSelectionGroupBox.Location = new System.Drawing.Point(59, 21);
            this.investmentSelectionGroupBox.Name = "investmentSelectionGroupBox";
            this.investmentSelectionGroupBox.Size = new System.Drawing.Size(1106, 487);
            this.investmentSelectionGroupBox.TabIndex = 4;
            this.investmentSelectionGroupBox.TabStop = false;
            this.investmentSelectionGroupBox.Text = "Investment Selection";
            this.investmentSelectionGroupBox.Visible = false;
            // 
            // totalRepaymentsLabel
            // 
            this.totalRepaymentsLabel.AutoSize = true;
            this.totalRepaymentsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalRepaymentsLabel.Location = new System.Drawing.Point(703, 118);
            this.totalRepaymentsLabel.Name = "totalRepaymentsLabel";
            this.totalRepaymentsLabel.Size = new System.Drawing.Size(142, 50);
            this.totalRepaymentsLabel.TabIndex = 12;
            this.totalRepaymentsLabel.Text = "Total \r\nRepayments";
            // 
            // totalInterestLabel
            // 
            this.totalInterestLabel.AutoSize = true;
            this.totalInterestLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalInterestLabel.Location = new System.Drawing.Point(514, 118);
            this.totalInterestLabel.Name = "totalInterestLabel";
            this.totalInterestLabel.Size = new System.Drawing.Size(98, 50);
            this.totalInterestLabel.TabIndex = 11;
            this.totalInterestLabel.Text = "Total \r\nInterest ";
            // 
            // monthlyInterestLabel
            // 
            this.monthlyInterestLabel.AutoSize = true;
            this.monthlyInterestLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthlyInterestLabel.Location = new System.Drawing.Point(320, 118);
            this.monthlyInterestLabel.Name = "monthlyInterestLabel";
            this.monthlyInterestLabel.Size = new System.Drawing.Size(102, 50);
            this.monthlyInterestLabel.TabIndex = 10;
            this.monthlyInterestLabel.Text = "Monthly \r\nInterest ";
            // 
            // interestRateLabel
            // 
            this.interestRateLabel.AutoSize = true;
            this.interestRateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interestRateLabel.Location = new System.Drawing.Point(190, 118);
            this.interestRateLabel.Name = "interestRateLabel";
            this.interestRateLabel.Size = new System.Drawing.Size(98, 50);
            this.interestRateLabel.TabIndex = 9;
            this.interestRateLabel.Text = "Interest \r\nRate";
            // 
            // periodLabel
            // 
            this.periodLabel.AutoSize = true;
            this.periodLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.periodLabel.Location = new System.Drawing.Point(56, 131);
            this.periodLabel.Name = "periodLabel";
            this.periodLabel.Size = new System.Drawing.Size(80, 25);
            this.periodLabel.TabIndex = 8;
            this.periodLabel.Text = "Period";
            // 
            // proceedButton
            // 
            this.proceedButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.proceedButton.Location = new System.Drawing.Point(653, 377);
            this.proceedButton.Name = "proceedButton";
            this.proceedButton.Size = new System.Drawing.Size(182, 51);
            this.proceedButton.TabIndex = 7;
            this.proceedButton.Text = "&Proceed";
            this.proceedButton.UseVisualStyleBackColor = true;
            this.proceedButton.Click += new System.EventHandler(this.proceedButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.clearButton.Location = new System.Drawing.Point(442, 377);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(182, 51);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "&Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // displayButton
            // 
            this.displayButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.displayButton.Location = new System.Drawing.Point(227, 377);
            this.displayButton.Name = "displayButton";
            this.displayButton.Size = new System.Drawing.Size(182, 51);
            this.displayButton.TabIndex = 5;
            this.displayButton.Text = "&Display";
            this.displayButton.UseVisualStyleBackColor = true;
            this.displayButton.Click += new System.EventHandler(this.displayButton_Click);
            // 
            // repaymentListBOX
            // 
            this.repaymentListBOX.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.repaymentListBOX.FormattingEnabled = true;
            this.repaymentListBOX.ItemHeight = 29;
            this.repaymentListBOX.Location = new System.Drawing.Point(47, 171);
            this.repaymentListBOX.Name = "repaymentListBOX";
            this.repaymentListBOX.Size = new System.Drawing.Size(878, 178);
            this.repaymentListBOX.TabIndex = 2;
            // 
            // investmentAmountTextBox
            // 
            this.investmentAmountTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.investmentAmountTextBox.Location = new System.Drawing.Point(277, 62);
            this.investmentAmountTextBox.Name = "investmentAmountTextBox";
            this.investmentAmountTextBox.Size = new System.Drawing.Size(226, 35);
            this.investmentAmountTextBox.TabIndex = 1;
            // 
            // investmentAmountLabel
            // 
            this.investmentAmountLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.investmentAmountLabel.AutoSize = true;
            this.investmentAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.investmentAmountLabel.Location = new System.Drawing.Point(56, 65);
            this.investmentAmountLabel.Name = "investmentAmountLabel";
            this.investmentAmountLabel.Size = new System.Drawing.Size(212, 25);
            this.investmentAmountLabel.TabIndex = 0;
            this.investmentAmountLabel.Text = "Investment Amount";
            // 
            // investorDetailsGroupBox
            // 
            this.investorDetailsGroupBox.Controls.Add(this.transactionNoLabel);
            this.investorDetailsGroupBox.Controls.Add(this.submitButton);
            this.investorDetailsGroupBox.Controls.Add(this.emailIDTextBox);
            this.investorDetailsGroupBox.Controls.Add(this.phoneNumberTextBox);
            this.investorDetailsGroupBox.Controls.Add(this.postCodeTextBox);
            this.investorDetailsGroupBox.Controls.Add(this.investorNameTextBox);
            this.investorDetailsGroupBox.Controls.Add(this.phoneNumberLabel);
            this.investorDetailsGroupBox.Controls.Add(this.emailIDLabel);
            this.investorDetailsGroupBox.Controls.Add(this.postCodeLabel);
            this.investorDetailsGroupBox.Controls.Add(this.transactionNameLabel);
            this.investorDetailsGroupBox.Controls.Add(this.investorNameLabel);
            this.investorDetailsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.investorDetailsGroupBox.Location = new System.Drawing.Point(1218, 32);
            this.investorDetailsGroupBox.Name = "investorDetailsGroupBox";
            this.investorDetailsGroupBox.Size = new System.Drawing.Size(587, 476);
            this.investorDetailsGroupBox.TabIndex = 5;
            this.investorDetailsGroupBox.TabStop = false;
            this.investorDetailsGroupBox.Text = "Investor Details";
            this.investorDetailsGroupBox.Visible = false;
            // 
            // transactionNoLabel
            // 
            this.transactionNoLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.transactionNoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.transactionNoLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.transactionNoLabel.Location = new System.Drawing.Point(300, 51);
            this.transactionNoLabel.Name = "transactionNoLabel";
            this.transactionNoLabel.Size = new System.Drawing.Size(182, 42);
            this.transactionNoLabel.TabIndex = 11;
            this.transactionNoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // submitButton
            // 
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(185, 386);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(182, 51);
            this.submitButton.TabIndex = 10;
            this.submitButton.Text = "&Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // emailIDTextBox
            // 
            this.emailIDTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.emailIDTextBox.Location = new System.Drawing.Point(284, 298);
            this.emailIDTextBox.Name = "emailIDTextBox";
            this.emailIDTextBox.Size = new System.Drawing.Size(219, 35);
            this.emailIDTextBox.TabIndex = 9;
            // 
            // phoneNumberTextBox
            // 
            this.phoneNumberTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.phoneNumberTextBox.Location = new System.Drawing.Point(284, 240);
            this.phoneNumberTextBox.Name = "phoneNumberTextBox";
            this.phoneNumberTextBox.Size = new System.Drawing.Size(219, 35);
            this.phoneNumberTextBox.TabIndex = 8;
            // 
            // postCodeTextBox
            // 
            this.postCodeTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.postCodeTextBox.Location = new System.Drawing.Point(284, 187);
            this.postCodeTextBox.Name = "postCodeTextBox";
            this.postCodeTextBox.Size = new System.Drawing.Size(219, 35);
            this.postCodeTextBox.TabIndex = 7;
            // 
            // investorNameTextBox
            // 
            this.investorNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.investorNameTextBox.Location = new System.Drawing.Point(284, 133);
            this.investorNameTextBox.Name = "investorNameTextBox";
            this.investorNameTextBox.Size = new System.Drawing.Size(219, 35);
            this.investorNameTextBox.TabIndex = 6;
            // 
            // phoneNumberLabel
            // 
            this.phoneNumberLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.phoneNumberLabel.AutoSize = true;
            this.phoneNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneNumberLabel.Location = new System.Drawing.Point(88, 246);
            this.phoneNumberLabel.Name = "phoneNumberLabel";
            this.phoneNumberLabel.Size = new System.Drawing.Size(167, 25);
            this.phoneNumberLabel.TabIndex = 4;
            this.phoneNumberLabel.Text = "Phone Number";
            // 
            // emailIDLabel
            // 
            this.emailIDLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.emailIDLabel.AutoSize = true;
            this.emailIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailIDLabel.Location = new System.Drawing.Point(88, 298);
            this.emailIDLabel.Name = "emailIDLabel";
            this.emailIDLabel.Size = new System.Drawing.Size(107, 25);
            this.emailIDLabel.TabIndex = 3;
            this.emailIDLabel.Text = "E-mail ID";
            // 
            // postCodeLabel
            // 
            this.postCodeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.postCodeLabel.AutoSize = true;
            this.postCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postCodeLabel.Location = new System.Drawing.Point(88, 190);
            this.postCodeLabel.Name = "postCodeLabel";
            this.postCodeLabel.Size = new System.Drawing.Size(121, 25);
            this.postCodeLabel.TabIndex = 2;
            this.postCodeLabel.Text = "Post Code";
            // 
            // transactionNameLabel
            // 
            this.transactionNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.transactionNameLabel.AutoSize = true;
            this.transactionNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionNameLabel.Location = new System.Drawing.Point(88, 57);
            this.transactionNameLabel.Name = "transactionNameLabel";
            this.transactionNameLabel.Size = new System.Drawing.Size(179, 25);
            this.transactionNameLabel.TabIndex = 1;
            this.transactionNameLabel.Text = "Transaction No:";
            // 
            // investorNameLabel
            // 
            this.investorNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.investorNameLabel.AutoSize = true;
            this.investorNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.investorNameLabel.Location = new System.Drawing.Point(88, 139);
            this.investorNameLabel.Name = "investorNameLabel";
            this.investorNameLabel.Size = new System.Drawing.Size(72, 25);
            this.investorNameLabel.TabIndex = 0;
            this.investorNameLabel.Text = "Name";
            // 
            // searchTransactionGroupBox
            // 
            this.searchTransactionGroupBox.Controls.Add(this.searchTransactionListBox);
            this.searchTransactionGroupBox.Controls.Add(this.clearTransactionButton);
            this.searchTransactionGroupBox.Controls.Add(this.searchTransactionButton);
            this.searchTransactionGroupBox.Controls.Add(this.searchTransactionInputTextBox);
            this.searchTransactionGroupBox.Controls.Add(this.transactionNoSearchRadioButton);
            this.searchTransactionGroupBox.Controls.Add(this.emailSearchRadioButton);
            this.searchTransactionGroupBox.Controls.Add(this.transactionResultsLabel);
            this.searchTransactionGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTransactionGroupBox.Location = new System.Drawing.Point(65, 534);
            this.searchTransactionGroupBox.Name = "searchTransactionGroupBox";
            this.searchTransactionGroupBox.Size = new System.Drawing.Size(934, 428);
            this.searchTransactionGroupBox.TabIndex = 6;
            this.searchTransactionGroupBox.TabStop = false;
            this.searchTransactionGroupBox.Text = "Search Transaction";
            this.searchTransactionGroupBox.Visible = false;
            // 
            // searchTransactionListBox
            // 
            this.searchTransactionListBox.FormattingEnabled = true;
            this.searchTransactionListBox.ItemHeight = 29;
            this.searchTransactionListBox.Location = new System.Drawing.Point(427, 55);
            this.searchTransactionListBox.Name = "searchTransactionListBox";
            this.searchTransactionListBox.Size = new System.Drawing.Size(442, 323);
            this.searchTransactionListBox.TabIndex = 17;
            // 
            // clearTransactionButton
            // 
            this.clearTransactionButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.clearTransactionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearTransactionButton.Location = new System.Drawing.Point(210, 306);
            this.clearTransactionButton.Name = "clearTransactionButton";
            this.clearTransactionButton.Size = new System.Drawing.Size(182, 51);
            this.clearTransactionButton.TabIndex = 16;
            this.clearTransactionButton.Text = "Cl&ear";
            this.clearTransactionButton.UseVisualStyleBackColor = true;
            this.clearTransactionButton.Click += new System.EventHandler(this.clearTransactionButton_Click);
            // 
            // searchTransactionButton
            // 
            this.searchTransactionButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.searchTransactionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTransactionButton.Location = new System.Drawing.Point(17, 306);
            this.searchTransactionButton.Name = "searchTransactionButton";
            this.searchTransactionButton.Size = new System.Drawing.Size(182, 51);
            this.searchTransactionButton.TabIndex = 8;
            this.searchTransactionButton.Text = "Sear&ch";
            this.searchTransactionButton.UseVisualStyleBackColor = true;
            this.searchTransactionButton.Click += new System.EventHandler(this.searchTransactionButton_Click);
            // 
            // searchTransactionInputTextBox
            // 
            this.searchTransactionInputTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.searchTransactionInputTextBox.Location = new System.Drawing.Point(32, 183);
            this.searchTransactionInputTextBox.Name = "searchTransactionInputTextBox";
            this.searchTransactionInputTextBox.Size = new System.Drawing.Size(226, 35);
            this.searchTransactionInputTextBox.TabIndex = 8;
            // 
            // transactionNoSearchRadioButton
            // 
            this.transactionNoSearchRadioButton.AutoSize = true;
            this.transactionNoSearchRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionNoSearchRadioButton.Location = new System.Drawing.Point(32, 78);
            this.transactionNoSearchRadioButton.Name = "transactionNoSearchRadioButton";
            this.transactionNoSearchRadioButton.Size = new System.Drawing.Size(203, 29);
            this.transactionNoSearchRadioButton.TabIndex = 15;
            this.transactionNoSearchRadioButton.TabStop = true;
            this.transactionNoSearchRadioButton.Text = "Transaction No";
            this.transactionNoSearchRadioButton.UseVisualStyleBackColor = true;
            // 
            // emailSearchRadioButton
            // 
            this.emailSearchRadioButton.AutoSize = true;
            this.emailSearchRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailSearchRadioButton.Location = new System.Drawing.Point(32, 124);
            this.emailSearchRadioButton.Name = "emailSearchRadioButton";
            this.emailSearchRadioButton.Size = new System.Drawing.Size(109, 29);
            this.emailSearchRadioButton.TabIndex = 14;
            this.emailSearchRadioButton.TabStop = true;
            this.emailSearchRadioButton.Text = "E-mail";
            this.emailSearchRadioButton.UseVisualStyleBackColor = true;
            // 
            // transactionResultsLabel
            // 
            this.transactionResultsLabel.AutoSize = true;
            this.transactionResultsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionResultsLabel.Location = new System.Drawing.Point(598, 27);
            this.transactionResultsLabel.Name = "transactionResultsLabel";
            this.transactionResultsLabel.Size = new System.Drawing.Size(91, 25);
            this.transactionResultsLabel.TabIndex = 13;
            this.transactionResultsLabel.Text = "Results";
            // 
            // summaryGroupBox
            // 
            this.summaryGroupBox.Controls.Add(this.summaryListBox);
            this.summaryGroupBox.Controls.Add(this.summaryButton);
            this.summaryGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summaryGroupBox.Location = new System.Drawing.Point(1046, 534);
            this.summaryGroupBox.Name = "summaryGroupBox";
            this.summaryGroupBox.Size = new System.Drawing.Size(759, 428);
            this.summaryGroupBox.TabIndex = 7;
            this.summaryGroupBox.TabStop = false;
            this.summaryGroupBox.Text = "Summary";
            this.summaryGroupBox.Visible = false;
            // 
            // summaryListBox
            // 
            this.summaryListBox.FormattingEnabled = true;
            this.summaryListBox.ItemHeight = 29;
            this.summaryListBox.Location = new System.Drawing.Point(253, 23);
            this.summaryListBox.Name = "summaryListBox";
            this.summaryListBox.Size = new System.Drawing.Size(410, 352);
            this.summaryListBox.TabIndex = 18;
            // 
            // summaryButton
            // 
            this.summaryButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.summaryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summaryButton.Location = new System.Drawing.Point(29, 327);
            this.summaryButton.Name = "summaryButton";
            this.summaryButton.Size = new System.Drawing.Size(182, 51);
            this.summaryButton.TabIndex = 17;
            this.summaryButton.Text = "S&ummary";
            this.summaryButton.UseVisualStyleBackColor = true;
            this.summaryButton.Click += new System.EventHandler(this.summaryButton_Click);
            // 
            // buttonLogoPictureBox
            // 
            this.buttonLogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("buttonLogoPictureBox.Image")));
            this.buttonLogoPictureBox.Location = new System.Drawing.Point(668, 983);
            this.buttonLogoPictureBox.Name = "buttonLogoPictureBox";
            this.buttonLogoPictureBox.Size = new System.Drawing.Size(497, 125);
            this.buttonLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonLogoPictureBox.TabIndex = 8;
            this.buttonLogoPictureBox.TabStop = false;
            this.buttonLogoPictureBox.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // mad4RoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1885, 1135);
            this.Controls.Add(this.buttonLogoPictureBox);
            this.Controls.Add(this.summaryGroupBox);
            this.Controls.Add(this.searchTransactionGroupBox);
            this.Controls.Add(this.investorDetailsGroupBox);
            this.Controls.Add(this.investmentSelectionGroupBox);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordInputBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.logoPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mad4RoadForm";
            this.Text = "Mad4Road";
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.investmentSelectionGroupBox.ResumeLayout(false);
            this.investmentSelectionGroupBox.PerformLayout();
            this.investorDetailsGroupBox.ResumeLayout(false);
            this.investorDetailsGroupBox.PerformLayout();
            this.searchTransactionGroupBox.ResumeLayout(false);
            this.searchTransactionGroupBox.PerformLayout();
            this.summaryGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonLogoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordInputBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.GroupBox investmentSelectionGroupBox;
        private System.Windows.Forms.TextBox investmentAmountTextBox;
        private System.Windows.Forms.Label investmentAmountLabel;
        private System.Windows.Forms.ListBox repaymentListBOX;
        private System.Windows.Forms.Button proceedButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button displayButton;
        private System.Windows.Forms.GroupBox investorDetailsGroupBox;
        private System.Windows.Forms.TextBox investorNameTextBox;
        private System.Windows.Forms.Label phoneNumberLabel;
        private System.Windows.Forms.Label emailIDLabel;
        private System.Windows.Forms.Label postCodeLabel;
        private System.Windows.Forms.Label transactionNameLabel;
        private System.Windows.Forms.Label investorNameLabel;
        private System.Windows.Forms.GroupBox searchTransactionGroupBox;
        private System.Windows.Forms.GroupBox summaryGroupBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.TextBox emailIDTextBox;
        private System.Windows.Forms.TextBox phoneNumberTextBox;
        private System.Windows.Forms.TextBox postCodeTextBox;
        private System.Windows.Forms.PictureBox buttonLogoPictureBox;
        private System.Windows.Forms.Label transactionNoLabel;
        private System.Windows.Forms.TextBox searchTransactionInputTextBox;
        private System.Windows.Forms.RadioButton transactionNoSearchRadioButton;
        private System.Windows.Forms.RadioButton emailSearchRadioButton;
        private System.Windows.Forms.Label transactionResultsLabel;
        private System.Windows.Forms.Button clearTransactionButton;
        private System.Windows.Forms.Button searchTransactionButton;
        private System.Windows.Forms.Button summaryButton;
        private System.Windows.Forms.Label totalRepaymentsLabel;
        private System.Windows.Forms.Label totalInterestLabel;
        private System.Windows.Forms.Label monthlyInterestLabel;
        private System.Windows.Forms.Label interestRateLabel;
        private System.Windows.Forms.Label periodLabel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ListBox searchTransactionListBox;
        private System.Windows.Forms.ListBox summaryListBox;
    }
}

