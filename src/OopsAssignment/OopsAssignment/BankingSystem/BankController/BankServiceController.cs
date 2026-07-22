using System;
using OopsAssignment.BankingSystem.BankModel;
using OopsAssignment.BankingSystem.BankView;

namespace OopsAssignment.BankingSystem.BankController
{
    /// <summary>
    /// Handles the communication between view and models.
    /// </summary>
    internal class BankServiceController
    {
        private readonly BankConsoleView _consoleView;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankServiceController"/> class.
        /// </summary>
        /// <param name="consoleView">The view is instance</param>
        public BankServiceController(BankConsoleView consoleView)
        {
            this._consoleView = consoleView;
        }

        /// <summary>
        /// Starts the execution of the bank program.
        /// </summary>
        public void RunBankAccount()
        {
            int userInput;
            do
            {
                this._consoleView.EndLine();
                this._consoleView.ShowMessage("[1].Savings Account");
                this._consoleView.ShowMessage("[2].Checking Account");
                this._consoleView.ShowMessage("[3].Exit");
                this._consoleView.EndLine();

                userInput = Convert.ToInt32(this._consoleView.ReadInput());

                switch (userInput)
                {
                    case 1:
                        this.GetSavingsAccount();
                        break;
                    case 2:
                        break;
                    case 3:
                        this._consoleView.ShowMessage("Exiting...");
                        break;
                    default:
                        this._consoleView.ShowMessage("Invalid input: select 1, 2, or 3");
                        break;
                }
            }
            while (userInput != 3);
        }

        /// <summary>
        /// Perform deposit and withdraw operation and Display savings account details.
        /// </summary>
        public void GetSavingsAccount()
        {
            string? accountNumber;
            do
            {
                this._consoleView.ShowMessage("Enter the savings account number: ");
                accountNumber = this._consoleView.ReadInput();
                if (!InputValidator.ValidateAccountNumber(accountNumber))
                {
                    this._consoleView.ShowMessage("Invalid input for account number\nEnter account number again");
                }
            }
            while (!InputValidator.ValidateAccountNumber(accountNumber));
            this._consoleView.ShowMessage("Enter savings account balance: ");
            decimal balance = Convert.ToDecimal(this._consoleView.ReadInput());

            SavingsAccount savingsAccount = new SavingsAccount(accountNumber, balance);
            this._consoleView.ShowMessage("--Which operation do you need to perform--");

            int choice;
            do
            {
                this._consoleView.ShowMessage("[1]. Deposit\n[2]. Withdraw\n[3].Exit");
                choice = Convert.ToInt32(this._consoleView.ReadInput());
                switch (choice)
                {
                    case 1:
                        DepositAmount();
                        break;
                    case 2:
                        WithdrawAmount();
                        break;
                    case 3:
                        this._consoleView.ShowMessage("Exiting...");
                        break;
                    default:
                        this._consoleView.ShowMessage("Invalid input");
                        break;
                }
            }
            while (choice != 3);

            void DepositAmount()
            {
                this._consoleView.ShowMessage("Enter amount to deposit: ");
                decimal amount = Convert.ToDecimal(this._consoleView.ReadInput());
                if (amount > 0)
                {
                    savingsAccount.Balance += amount;
                    this._consoleView.ShowMessage("Deposit successfull");
                }
                else
                {
                    this._consoleView.ShowMessage("Invalid input for amount");
                }

                this._consoleView.EndLine();
                this._consoleView.ShowMessage(savingsAccount.PrintDetails());
                this._consoleView.ShowMessage($"Deposit amount: {amount}");
                this._consoleView.EndLine();
            }

            void WithdrawAmount()
            {
                this._consoleView.ShowMessage("Enter amount to withdraw: ");
                decimal amount = Convert.ToDecimal(this._consoleView.ReadInput());

                if (amount > SavingsAccount.MinimumBalance)
                {
                    this._consoleView.ShowMessage("No minimum balance available to withdraw");
                }
                else
                {
                    savingsAccount.Balance -= amount;
                    this._consoleView.ShowMessage("Withdraw successfull");
                }

                this._consoleView.EndLine();
                this._consoleView.ShowMessage(savingsAccount.PrintDetails());
                this._consoleView.ShowMessage($"Withdraw amount: {amount}");
                this._consoleView.EndLine();
            }
        }

        /// <summary>
        /// Perform deposit and withdraw operation and Display checking account details.
        /// </summary>
        public void GetCheckingAccount()
        {
            string? accountNumber;
            do
            {
                this._consoleView.ShowMessage("Enter the savings account number: ");
                accountNumber = this._consoleView.ReadInput();
                if (!InputValidator.ValidateAccountNumber(accountNumber))
                {
                    this._consoleView.ShowMessage("Invalid input for account number\nEnter account number again");
                }
            }
            while (!InputValidator.ValidateAccountNumber(accountNumber));
            this._consoleView.ShowMessage("Enter savings account balance: ");
            decimal balance = Convert.ToDecimal(this._consoleView.ReadInput());

            CheckingAccount checkingAccount = new CheckingAccount(accountNumber, balance);
            this._consoleView.ShowMessage("--Which operation do you need to perform--");
            int choice;
            do
            {
                this._consoleView.ShowMessage("[1]. Deposit\n[2]. Withdraw\n[3].Exit");
                choice = Convert.ToInt32(this._consoleView.ReadInput());
                switch (choice)
                {
                    case 1:
                        DepositAmount();
                        break;
                    case 2:
                        WithdrawAmount();
                        break;
                    case 3:
                        this._consoleView.ShowMessage("Exiting...");
                        break;
                    default:
                        this._consoleView.ShowMessage("Invalid input");
                        break;
                }
            }
            while (choice != 3);

            void DepositAmount()
            {
                this._consoleView.ShowMessage("Enter amount to deposit: ");
                decimal amount = Convert.ToDecimal(this._consoleView.ReadInput());
                if (amount > 0)
                {
                    checkingAccount.Balance += amount;
                    this._consoleView.ShowMessage("Deposit successfull");
                }
                else
                {
                    this._consoleView.ShowMessage("Invalid input to deposit amount");
                }

                this._consoleView.EndLine();
                this._consoleView.ShowMessage(checkingAccount.PrintDetails());
                this._consoleView.ShowMessage($"Deposit amount: {amount}");
                this._consoleView.EndLine();
            }

            void WithdrawAmount()
            {
                this._consoleView.ShowMessage("Enter amount to withdraw: ");
                decimal amount = Convert.ToDecimal(this._consoleView.ReadInput());

                if (amount > 0 && amount <= checkingAccount.Balance)
                {
                    checkingAccount.Balance -= amount;
                    this._consoleView.ShowMessage("Deposit successfull");
                }
                else
                {
                    this._consoleView.ShowMessage("Invalid input to withdraw amount");
                }

                this._consoleView.EndLine();
                this._consoleView.ShowMessage(checkingAccount.PrintDetails());
                this._consoleView.ShowMessage($"Withdraw amount: {amount}");
                this._consoleView.EndLine();
            }
        }
    }
}
