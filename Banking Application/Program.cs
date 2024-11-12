using System;
 
class Program
{
    public static void Main(string[] args)
    { 
        Console.WriteLine("Banking Application");
        Console.WriteLine(" ");
        Bank bank = new Bank();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Welcome to the Banking Application");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            int choice = GetValidIntegerInput();

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Register");
                    bank.Register();
                    break;
                case 2:
                    Console.WriteLine("Login");
                    bank.Login();
                    break;
                case 3:
                    exit = true;
                    break;
                default:
                    Console.WriteLine(" ");
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

        }

    }

    // to check for valid input (integer only)
    public static int GetValidIntegerInput()
    {
        int choice;
        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out choice))
            {
                return choice;
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine("Invalid input. Please enter a number.");
                Console.Write("Try again: ");
            }
        }
    }
}


class Bank
{
    private List<User> users = new List<User>();
    private User loggedInUser;
    
    public void Register()
    {

        Console.WriteLine(" ");
        Console.WriteLine("User Registration Form");
        Console.WriteLine("Enter Username : ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Password : ");
        string password = Console.ReadLine();   

        User user = new User(name.ToLower(), password.ToLower());
        users.Add(user);
        Console.WriteLine("Registration successful! You can now login.");
        Console.WriteLine(" ");
    }

    public void Login()
    {
        Console.WriteLine(" ");
        Console.WriteLine("Login Form"); 
        Console.WriteLine("Enter Username : ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Password : ");
        string password = Console.ReadLine();

        //using lambda function
        loggedInUser = users.Find(u => u.Username == name && u.Password == password);
        if (loggedInUser != null)
        {
            Console.WriteLine("Login successful!"); 
            Console.WriteLine(" ");
            UserMenu();
        }
        else
        {
            Console.WriteLine("Invalid username or password.");
            Console.WriteLine(" ");
        }
    }

    private void UserMenu()
    {

        Console.WriteLine(" ");
        Console.WriteLine("MENU ");
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine($"Welcome {loggedInUser.Username}"); 
            foreach (var account in loggedInUser.Accounts)
            {
                account.ApplyMonthlyInterest();
            } 
            Console.WriteLine("1. Open New Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Check Balance");
            Console.WriteLine("5. View Transactions / Statement");
            Console.WriteLine("6. Log Out");
            Console.Write("Choose an option: ");

            int c = Program.GetValidIntegerInput();
            switch (c)
            {
                case 1: Console.WriteLine(" ");
                    Console.WriteLine("Opening new Account ");
                    OpenNewAccount();
                    break;
                case 2: 
                    Deposit();
                    break;
                case 3: Console.WriteLine(" ");
                    WithDraw();
                    break;
                case 4: Console.WriteLine(" ");
                    Balance();
                    break;
                case 5: Console.WriteLine(" ");
                    ViewTransactions();
                    break;
                case 6:
                    loggedInUser = null;
                    exit = true;
                    break;
                default:
                    Console.WriteLine(" ");
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }



    private void OpenNewAccount()
    { 
        string accountType = "";
        while (accountType != "savings" && accountType != "checking")
        {
            Console.Write("Enter account type (savings/checking): ");
            accountType = Console.ReadLine().ToLower();
             
            if (accountType != "savings" && accountType != "checking")
            {
                Console.WriteLine("Invalid account type. Please enter 'savings' or 'checking'.");
            }
        }

        decimal initialDeposit = 0;
         
        while (initialDeposit < 100)
        {
            Console.WriteLine("You need to deposit at least 100.");
            Console.Write("Enter initial deposit amount: ");
             
            while (!decimal.TryParse(Console.ReadLine(), out initialDeposit) || initialDeposit < 100)
            {
                Console.WriteLine("Invalid input. Please enter a valid amount greater than or equal to 100.");
            }
        }



        Account newAcc = new Account(accountType, initialDeposit);
        loggedInUser.Accounts.Add(newAcc);
        Console.WriteLine($"Account created successfully! Account Number: SBIHYD{newAcc.AccountNumber}");
        Console.WriteLine(" ");
    }

    private void Deposit()
    {
        Console.WriteLine();
        Console.WriteLine("Deposit Form");
        Account account = SelectAcc();
        if (account != null)
        {
            Console.Write("Enter deposit amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            account.Deposit(amount);
            Console.WriteLine($"Deposited {amount:C} to your account.");
            Console.WriteLine(" ");
        }
    }

    private void WithDraw()
    {
        Console.WriteLine();
        Console.WriteLine("WithDraw From");
        Account account = SelectAcc();
        if (account != null)
        {
            Console.Write("Enter withdrawal amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            if (account.Withdraw(amount))
                Console.WriteLine($"Withdrew {amount:C} from your account.");
            else
                Console.WriteLine("Insufficient funds.");
            Console.WriteLine(" ");
        }
    }

    private void Balance()
    {
        Console.WriteLine("Check Balance");
        Account account = SelectAcc();
        if (account != null)
        {
            Console.WriteLine($"Current Balance: {account.Balance:C}");
            Console.WriteLine(" ");
        }
    }

    private void ViewTransactions()
    {
        Console.Clear();
        Console.WriteLine("View Transactions");

        Account account = SelectAcc();

        if (account != null)
        {
            foreach (var transaction in account.Transactions)
            {
                Console.WriteLine($"{transaction.Date} - {transaction.Type} - {transaction.Amount:C}");
            }
        }
        Console.WriteLine(" ");
        Console.ReadKey();
    }

    private Account SelectAcc()
    {
        Console.WriteLine("Select Account:");
        for (int i = 0; i < loggedInUser.Accounts.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Account SBIHYD{loggedInUser.Accounts[i].AccountNumber}");
        }
        Console.Write("Choose an account: ");
        int accountIndex = int.Parse(Console.ReadLine()) - 1;

        if (accountIndex >= 0 && accountIndex < loggedInUser.Accounts.Count)
            return loggedInUser.Accounts[accountIndex];
        Console.WriteLine(" ");
        Console.WriteLine("Invalid selection. Try again");
        Console.WriteLine(" ");
        return null;
    }

}



// this is for users (storing username , pw , total accounts)
class User
{
    public string Username { get; set; } 
    public string Password { get; set; }
    public List<Account> Accounts { get; set; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
        Accounts = new List<Account>();
    }

}
 
// this is data for all users , transactions and all
class Account
{
    private static int accountCounter = 0;

    private const decimal InterestRate = 0.005m; // 0.5% monthly interest rate
    private DateTime lastInterestAppliedDate;

    public int AccountNumber { get; private set; }
    public string AccountType { get; set; }
    public decimal Balance { get; private set; }
    public List<Transaction> Transactions { get; private set; }

    public Account(string accountType, decimal initialdeposit)
    {
        AccountNumber = accountCounter++;
        AccountType = accountType;
        Balance = initialdeposit;
        Transactions = new List<Transaction>();
        // assuming min value so that interest is added instantly 
        lastInterestAppliedDate = DateTime.MinValue;

        AddTransaction(new Transaction("Deposit", initialdeposit));
    }

    public void ApplyMonthlyInterest()
    {
        if (AccountType == "savings" && (DateTime.Now - lastInterestAppliedDate).Days >= 30)
        {
            decimal interest = Balance * InterestRate;
            Balance += interest;
            AddTransaction(new Transaction("Monthly Interest", interest));
            lastInterestAppliedDate = DateTime.Now;
            Console.WriteLine(" ");
            Console.WriteLine($"Interest of {interest:C} added to account SBIHYD{AccountNumber}.");
            Console.WriteLine(" ");
        }
    }


    public void Deposit(decimal amount)
    {
        Balance += amount;
        AddTransaction(new Transaction("Deposit",amount));
        
    }

    public bool Withdraw(decimal amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            AddTransaction(new Transaction("Withdrawal", amount));
            return true;
        }
        return false;
    }

    private void AddTransaction(Transaction transaction)
    {
        Transactions.Add(transaction);
    }
}


class Transaction
{
    public string Type { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    public Transaction(string type, decimal amount)
    {
        Type = type;
        Amount = amount;
        Date = DateTime.Now;
    }
}


 