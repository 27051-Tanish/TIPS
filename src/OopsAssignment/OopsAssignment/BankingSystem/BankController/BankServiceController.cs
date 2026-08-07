using OopsAssignment.BankingSystem.BankModel;
using OopsAssignment.Helper;
using OopsAssignment.Helper.ConstantVariables;

namespace OopsAssignment.BankingSystem.BankController
{
    /// <summary>
    /// Controls data flow and communication between view and model components.
    /// </summary>
    public class BankServiceController
    {
        private readonly ProjectConsoleView _consoleView;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankServiceController"/> class.
        /// </summary>
        /// <param name="consoleView">The console view instance.</param>
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
                this._consoleView.ShowMenu("[1]. Savings Account\n[2]. Checking Account\n[3]. Exit");
                userInput = this._consoleView.GetChoice("Please enter valid choice from [1 to 3]\nPlease enter again :");
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

        private void GetSavingsAccount()
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
            while (true)
            {
                this._consoleView.ShowMessage("Enter savings account balance: ");
                balance = this.GetValidAmountInput();

                if (balance >= AccountConstants.MinimumBalance)
                {
                    break;
                }

                this._consoleView.ShowMessage($"Minimum balance should be Rs. {AccountConstants.MinimumBalance}");
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
                choice = this._consoleView.GetChoice("Please enter valid choice from [1 to 3]\nPlease enter again :");
                menuChoice = (BankOperations)choice;
                switch (menuChoice)
                {
                    case BankOperations.Deposit:
                        this.DepositToSavingsAccount(savingsAccount);
                        break;
                    case BankOperations.Withdraw:
                        this.WithdrawFromSavingsAccount(savingsAccount);
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
        }

        private void DepositToSavingsAccount(SavingsAccount savingsAccount)
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

        private void WithdrawFromSavingsAccount(SavingsAccount savingsAccount)
        {
            this._consoleView.ShowMessage("Enter amount to withdraw: ");
            decimal amount = this.GetValidAmountInput();

            string withdrawOperation = savingsAccount.Withdraw(amount);
            this._consoleView.ShowMessage(withdrawOperation);

            if (withdrawOperation == TransactionResponse.GetSuccessMessage(savingsAccount.Balance))
            {
                this._consoleView.EndLine();
                this._consoleView.ShowMessage(savingsAccount.PrintDetails());
                this._consoleView.ShowMessage($"Debited amount: {amount}");
                this._consoleView.EndLine();
            }
        }

        private void GetCheckingAccount()
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
                choice = this._consoleView.GetChoice("Please enter valid choice from [1 to 3]\nPlease enter again :");
                menuChoice = (BankOperations)choice;
                switch (menuChoice)
                {
                    case BankOperations.Deposit:
                        this.DepositAmount(checkingAccount);
                        break;
                    case BankOperations.Withdraw:
                        this.WithdrawAmount(checkingAccount);
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
        }

        private void DepositAmount(CheckingAccount checkingAccount)
        {
                this._consoleView.ShowMessage("Enter amount to credit: ");
                decimal amount = this.GetValidAmountInput();
                if (InputValidator.ValidateAmount(amount) && InputValidator.CheckBankBalance(amount, checkingAccount.Balance))
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

        private void WithdrawAmount(CheckingAccount checkingAccount)
        {
                this._consoleView.ShowMessage("Enter amount to debit: ");
                decimal amount = this.GetValidAmountInput();

                if (amount > 0 && amount <= checkingAccount.Balance)
                {
                    checkingAccount.Withdraw(amount);
                }
                else
                {
                    this._consoleView.ShowMessage("Invalid input to debit amount\nBalance should be positive.");
                }

                this._consoleView.EndLine();
                this._consoleView.ShowMessage(checkingAccount.PrintDetails());
                this._consoleView.ShowMessage($"Debited amount: {amount}");
                this._consoleView.EndLine();
        }

        private decimal GetValidAmountInput()
        {
            while (true)
            {
                if (decimal.TryParse(this._consoleView.ReadInput(), out decimal amount) && InputValidator.ValidateAmount(amount))
                {
                    return amount;
                }
                else
                {
                    this._consoleView.ShowMessage($"Credit failed.\nAmount should be positive and within the limit\nAmount limit :{decimal.MaxValue}\nEnter again: ");
                }
            }
        }
    }
}
