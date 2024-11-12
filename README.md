# Banking Application (C#)

A simple console-based banking application written in C# that simulates the functionality of a bank, including user registration, login, account management (deposit, withdraw, balance check), and monthly interest accrual.

## Features

- **User Registration and Login:** Users can register, log in, and perform various banking actions.
- **Multiple Account Support:** Each user can have multiple accounts (savings or checking).
- **Deposit and Withdraw:** Users can deposit or withdraw money from their accounts.
- **Balance Checking:** Users can check the balance of their accounts.
- **Transaction History:** Users can view the transaction history of each account.
- **Interest Accrual:** Savings accounts automatically apply a monthly interest of 0.5%.
- **Account Types:** Users can choose between savings or checking accounts when opening a new account.
- **Basic Error Handling:** The application handles common errors like invalid inputs, incorrect credentials, and insufficient funds.

## Technologies Used

- **C#**: The primary programming language used for this application.
- **.NET Core/Framework**: This application is designed to run on any environment that supports C#.
- **Lists and Collections**: Used to manage users, accounts, and transactions.

## Classes

### 1. **Program**
   - The entry point of the application. It handles the main menu and the logic for interacting with the `Bank` class.
   - Provides the option for the user to register, log in, or exit the application.

### 2. **Bank**
   - Contains the core banking logic. Manages user registration, login, and the user menu where users can manage their accounts.
   - Has methods for opening new accounts, depositing and withdrawing money, checking balances, and viewing transaction history.

### 3. **User**
   - Represents a bank user with a username, password, and a list of accounts.
   - Each user can have multiple accounts, and they can perform transactions on each account.

### 4. **Account**
   - Represents a bank account that belongs to a user.
   - Supports two account types: **savings** and **checking**.
   - Handles transactions like deposits and withdrawals, and applies monthly interest for savings accounts.
   - Tracks the transaction history.

### 5. **Transaction**
   - Represents a single transaction (deposit, withdrawal, interest).
   - Each transaction includes a type (Deposit/Withdrawal/Interest), amount, and the date it occurred.

### 6. **Helper Methods**
   - **GetValidIntegerInput**: A helper function to ensure valid integer input for the menu options.

## Getting Started

### Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/) or any C# compatible IDE.
- .NET SDK installed (if not using Visual Studio).

### Clone the Repository

To get started with the project, clone the repository to your local machine:

```bash
git clone https://github.com/Psrijith/Csharp-Console-Banking-Application.git
cd banking-application
```

### Example 
Welcome to the Banking Application
1. Register
2. Login
3. Exit
Choose an option: 1

User Registration Form
Enter Username : srijith
Enter Password : password123

Registration successful! You can now login.

Welcome to the Banking Application
1. Register
2. Login
3. Exit
Choose an option: 2

Login Form
Enter Username : srijith
Enter Password : password123

Login successful!

MENU
1. Open New Account
2. Deposit
3. Withdraw
4. Check Balance
5. View Transactions / Statement
6. Log Out
Choose an option: 1

Opening new Account
Enter account type (savings/checking): savings
You need to deposit at least 100.
Enter initial deposit amount: 500

Account created successfully! Account Number: SBIHYD0

MENU
1. Open New Account
2. Deposit
3. Withdraw
4. Check Balance
5. View Transactions / Statement
6. Log Out
Choose an option: 4

Check Balance
Current Balance: $500.00
