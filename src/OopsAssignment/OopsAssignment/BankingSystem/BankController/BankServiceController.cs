using System;
using OopsAssignment;
using OopsAssignment.BankingSystem.BankModel;

namespace OopsAssignment.BankingSystem.BankController
{
    /// <summary>
    /// Handles the communication between view and models.
    /// </summary>
    internal class BankServiceController
    {
        private readonly ProjectConsoleView _consoleView;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankServiceController"/> class.
        /// </summary>
        /// <param name="consoleView">The view is instance</param>
        public BankServiceController(ProjectConsoleView consoleView)
        {
            this._consoleView = consoleView;
        }

        /// <summary>
        /// Starts the execution of the banking system application.
        /// </summary>
        public void StartBankingSystem()
        {
            int userInput;
            do
            {
                this._consoleView.BankSystemMenu();
                userInput = this.GetChoice();
                BankMenu menuChoice = (BankMenu)userInput;

                switch (menuChoice)
                {
                    case BankMenu.Savings:
                        this.GetSavingsAccount();
                        break;
                    case BankMenu.Checking:
                        this.GetCheckingAccount();
                        break;
                    case BankMenu.Exit:
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
            while (true)
            {
                this._consoleView.ShowMessage("Enter savings bank account number :");
                accountNumber = this._consoleView.ReadInput();

                if (InputValidator.ValidateAccountNumber(accountNumber))
                {
                    break;
                }

                this._consoleView.ShowMessage("Invalid account number: cannot be invalid length, null, empty, or whitespace.");
            }

            this._consoleView.ShowMessage("Enter savings account balance: ");
            decimal balance = this.GetInput();

            SavingsAccount savingsAccount = new (accountNumber, balance);
            this._consoleView.EndLine();
            this._consoleView.ShowMessage(savingsAccount.PrintDetails());

            this._consoleView.ShowMessage("--Please select a operation--");

            int choice;
            do
            {
                this._consoleView.ShowMessage("[1]. Deposit\n[2]. Withdraw\n[3].Exit");
                choice = this.GetChoice();
                BankOperations menuChoice = (BankOperations)choice;
                switch (menuChoice)
                {
                    case BankOperations.Deposit:
                        DepositAmount();
                        break;
                    case BankOperations.Withdraw:
                        WithdrawAmount();
                        break;
                    case BankOperations.Exit:
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
                decimal amount = this.GetInput();
                if (amount > 0 && amount <= decimal.MaxValue)
                {
                    savingsAccount.Deposit(amount);
                    this._consoleView.ShowMessage("Deposit successful");
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
                decimal amount = this.GetInput();

                if ((savingsAccount.Balance - amount) < SavingsAccount.MinimumBalance)
                {
                    this._consoleView.ShowMessage("No minimum balance available to withdraw");
                }
                else
                {
                    savingsAccount.Withdraw(amount);
                }

                this._consoleView.EndLine();
                this._consoleView.ShowMessage(savingsAccount.PrintDetails());
                this._consoleView.ShowMessage($"Debited amount: {amount}");
                this._consoleView.EndLine();
            }
        }

        /// <summary>
        /// Perform deposit and withdraw operation and Display checking account details.
        /// </summary>
        public void GetCheckingAccount()
        {
            string? accountNumber;
            while (true)
            {
                this._consoleView.ShowMessage("Enter checking bank account number :");
                accountNumber = this._consoleView.ReadInput();

                if (InputValidator.ValidateAccountNumber(accountNumber))
                {
                    break;
                }

                this._consoleView.ShowMessage("Invalid account number: cannot be invalid length, null, empty, or whitespace.");
            }

            this._consoleView.ShowMessage("Enter checking account balance: ");
            decimal balance = this.GetInput();

            CheckingAccount checkingAccount = new (accountNumber, balance);
            this._consoleView.EndLine();
            this._consoleView.ShowMessage(checkingAccount.PrintDetails());

            this._consoleView.ShowMessage("--Which operation do you need to perform--");
            int choice;
            do
            {
                this._consoleView.ShowMessage("[1]. Deposit\n[2]. Withdraw\n[3].Exit");
                choice = this.GetChoice();
                BankOperations menuChoice = (BankOperations)choice;
                switch (menuChoice)
                {
                    case BankOperations.Deposit:
                        DepositAmount();
                        break;
                    case BankOperations.Withdraw:
                        WithdrawAmount();
                        break;
                    case BankOperations.Exit:
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
                this._consoleView.ShowMessage("Enter amount to credit: ");
                decimal amount = this.GetInput();
                if (amount > 0)
                {
                    checkingAccount.Deposit(amount);
                    this._consoleView.ShowMessage("Amount credited successfully");
                }
                else
                {
                    this._consoleView.ShowMessage("Invalid input to credit amount");
                }

                this._consoleView.EndLine();
                this._consoleView.ShowMessage(checkingAccount.PrintDetails());
                this._consoleView.ShowMessage($"Credited amount: {amount}");
                this._consoleView.EndLine();
            }

            void WithdrawAmount()
            {
                this._consoleView.ShowMessage("Enter amount to debit: ");
                decimal amount = this.GetInput();

                if (amount > 0 && amount <= checkingAccount.Balance)
                {
                    checkingAccount.Withdraw(amount);
                    this._consoleView.ShowMessage("Amount debited successfully");
                }
                else
                {
                    this._consoleView.ShowMessage("Invalid input to debit amount");
                }

                this._consoleView.EndLine();
                this._consoleView.ShowMessage(checkingAccount.PrintDetails());
                this._consoleView.ShowMessage($"Debited amount: {amount}");
                this._consoleView.EndLine();
            }
        }

        /// <summary>
        /// Gets user input for balance.
        /// </summary>
        /// <returns>decimal representing the value of balance</returns>
        public decimal GetInput()
        {
            while (true)
            {
                if (decimal.TryParse(this._consoleView.ReadInput(), out decimal choiceValue))
                {
                    return choiceValue;
                }
                else
                {
                    this._consoleView.ShowMessage("Invalid input for amount\nEnter again: ");
                }
            }
        }

        /// <summary>
        /// Gets user input for switch case choice.
        /// </summary>
        /// <returns>Int value representing choice from menu</returns>
        public int GetChoice()
        {
            while (true)
            {
                if (int.TryParse(this._consoleView.ReadInput(), out int choiceValue))
                {
                    return choiceValue;
                }
                else
                {
                    this._consoleView.ShowMessage("Please enter valid choice\nEnter the choice again :");
                }
            }
        }
    }
}
