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
            BankMenu menuChoice;
            do
            {
                this._consoleView.BankSystemMenu();
                userInput = this.GetChoice();
                menuChoice = (BankMenu)userInput;

                switch (menuChoice)
                {
                    case BankMenu.Savings:
                        this.GetSavingsAccount();
                        break;
                    case BankMenu.Checking:
                        this.GetCheckingAccount();
                        break;
                    case BankMenu.Exit:
                        this._consoleView.ShowMessage("Closing banking system application.");
                        break;
                    default:
                        this._consoleView.ShowMessage("Invalid input: select 1, 2, or 3");
                        break;
                }
            }
            while (menuChoice != BankMenu.Exit);
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

            decimal balance = 0;
            bool isValidBalance = false;
            while (!isValidBalance)
            {
                this._consoleView.ShowMessage("Enter savings account balance: ");
                balance = this.GetValidAmountInput();
                if (balance >= SavingsAccount.MinimumBalance)
                {
                    isValidBalance = true;
                    break;
                }
                else
                {
                    this._consoleView.ShowMessage("Minimum balance should be Rs.1000");
                }
            }

            SavingsAccount savingsAccount = new (accountNumber, balance);
            this._consoleView.EndLine();
            this._consoleView.ShowMessage(savingsAccount.PrintDetails());

            this._consoleView.ShowMessage("--Please select a operation--");

            int choice;
            BankOperations menuChoice;
            do
            {
                this._consoleView.ShowMessage("[1]. Deposit\n[2]. Withdraw\n[3]. Exit");
                choice = this.GetChoice();
                menuChoice = (BankOperations)choice;
                switch (menuChoice)
                {
                    case BankOperations.Deposit:
                        DepositAmount();
                        break;
                    case BankOperations.Withdraw:
                        WithdrawAmount();
                        break;
                    case BankOperations.Exit:
                        this._consoleView.ShowMessage("Closing banking operations.");
                        break;
                    default:
                        this._consoleView.ShowMessage("Invalid input");
                        break;
                }
            }
            while (menuChoice != BankOperations.Exit);

            void DepositAmount()
            {
                this._consoleView.ShowMessage("Enter amount to credit: ");
                decimal amount = this.GetValidAmountInput();
                if (InputValidator.CheckBankBalance(amount, savingsAccount.Balance))
                {
                    savingsAccount.Deposit(amount);
                    this._consoleView.ShowMessage("Amount credited successfully.");
                }
                else
                {
                    this._consoleView.ShowMessage($"Invalid input for credit\nBalance limit :{decimal.MaxValue}");
                }

                this._consoleView.EndLine();
                this._consoleView.ShowMessage(savingsAccount.PrintDetails());
                this._consoleView.ShowMessage($"Deposit amount: {amount}");
                this._consoleView.EndLine();
            }

            void WithdrawAmount()
            {
                this._consoleView.ShowMessage("Enter amount to withdraw: ");
                decimal amount = this.GetValidAmountInput();

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
            decimal balance = this.GetValidAmountInput();

            CheckingAccount checkingAccount = new (accountNumber, balance);
            this._consoleView.EndLine();
            this._consoleView.ShowMessage(checkingAccount.PrintDetails());

            this._consoleView.ShowMessage("--Which operation do you need to perform--");
            int choice;
            BankOperations menuChoice;
            do
            {
                this._consoleView.ShowMessage("[1]. Deposit\n[2]. Withdraw\n[3]. Exit");
                choice = this.GetChoice();
                menuChoice = (BankOperations)choice;
                switch (menuChoice)
                {
                    case BankOperations.Deposit:
                        DepositAmount();
                        break;
                    case BankOperations.Withdraw:
                        WithdrawAmount();
                        break;
                    case BankOperations.Exit:
                        this._consoleView.ShowMessage("Closing banking operations.");
                        break;
                    default:
                        this._consoleView.ShowMessage("Invalid input");
                        break;
                }
            }
            while (menuChoice != BankOperations.Exit);

            void DepositAmount()
            {
                this._consoleView.ShowMessage("Enter amount to credit: ");
                decimal amount = this.GetValidAmountInput();
                if (InputValidator.ValidateDepositAmount(amount) && InputValidator.CheckBankBalance(amount, checkingAccount.Balance))
                {
                    checkingAccount.Deposit(amount);
                    this._consoleView.ShowMessage("Amount credited successfully");
                }
                else
                {
                    this._consoleView.ShowMessage($"Invalid input to credit amount\nBalance limit :{decimal.MaxValue}");
                }

                this._consoleView.EndLine();
                this._consoleView.ShowMessage(checkingAccount.PrintDetails());
                this._consoleView.ShowMessage($"Credited amount: {amount}");
                this._consoleView.EndLine();
            }

            void WithdrawAmount()
            {
                this._consoleView.ShowMessage("Enter amount to debit: ");
                decimal amount = this.GetValidAmountInput();

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
        /// Prompts the user via the console and validates a positive amount input value.
        /// </summary>
        /// <returns>A valid positive decimal value representing the user's input.</returns>
        public decimal GetValidAmountInput()
        {
            while (true)
            {
                if (decimal.TryParse(this._consoleView.ReadInput(), out decimal balance) && InputValidator.ValidateDepositAmount(balance))
                {
                    return balance;
                }
                else
                {
                    this._consoleView.ShowMessage($"Credit failed.\nAmount should be positive and within the limit\nAmount limit :{decimal.MaxValue}\nEnter again: ");
                }
            }
        }

        /// <summary>
        /// Prompts the user and reads a validated integer menu choice from the console.
        /// </summary>
        /// <returns>The validated integer value representing the user's selected option.</returns>
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
