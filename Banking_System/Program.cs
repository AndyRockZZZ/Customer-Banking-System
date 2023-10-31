using System.Runtime.InteropServices;

namespace Banking_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Bank Systems");
            Console.Write("\nWould you like to open up a new account? Yes or No: ");

            var response = Console.ReadLine();
            if (response.ToLower() == "yes")
            {
                Console.Write("\nOk brilliant. As a new customer, can you provide your full name please: ");
                Customer customer = new Customer(Console.ReadLine());
                Console.Write("\nThank you, for your new bank account, can you enter your initial balance: £");
                var deposit = decimal.Parse(Console.ReadLine());
                Account account1 = new Account(customer, deposit);
                customer.AddAccount(account1);
                var current_account = customer.Accounts[0];

                var InBank = true;
                while (InBank)
                {
                    Console.Write("\nPlease select one of the options below:\n1 - Withdraw\n2 - Deposit\n3 - Transfer\n4 - New Account\n5 - Switch Account\n6 - View Balance\n7 - Exit\nOption: ");
                    var option = Console.ReadLine();

                    if (option == "1")
                    {
                        Console.Write("\nPlease enter the value you like to withdraw: £");
                        var value = decimal.Parse(Console.ReadLine());
                        current_account.Withdraw(current_account.AccountID, value);
                    }
                    else if (option == "2")
                    {
                        Console.Write("\nPlease enter the value you like to deposit: £");
                        var value = decimal.Parse(Console.ReadLine());
                        current_account.Deposit(current_account.AccountID, value);
                    }
                    else if (option == "3")
                    {
                        if (customer.Accounts.Count > 1)
                        {
                            for (int i = 0; i < customer.Accounts.Count; i++)
                            {
                                var accountId = $"{i + 1} - {customer.Accounts[i].AccountID}";
                                if (current_account.AccountID == customer.Accounts[i].AccountID)
                                {
                                    accountId += " - [Your current account]";
                                }
                                Console.WriteLine(accountId);
                            }
                            Console.Write("\nPlease select one of the accounts that you like to transfer? Use the index number: ");
                            var account_option = int.Parse(Console.ReadLine()) - 1;
                            var to_account = customer.Accounts[account_option];
                            if (current_account != to_account)
                            {
                                Console.Write("\nHow much will you like to transfer: £");
                                var transfer = decimal.Parse(Console.ReadLine());
                                current_account.Transfer(to_account, transfer);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Sorry you need another account to do the transfer.\n");
                        }
                    }
                    else if (option == "4") 
                    {
                        Console.Write("\nHow much initial balance would you like in your new account: ");
                        var init_balance = decimal.Parse(Console.ReadLine());
                        var new_account = new Account(customer, init_balance);
                        customer.AddAccount(new_account);
                    }
                    else if (option == "5")
                    {
                        if (customer.Accounts.Count > 1)
                        {
                            for (int i = 0; i < customer.Accounts.Count; i++)
                            {
                                var accountId = $"Account {customer.Accounts[i].AccountID}, Balance: £{customer.Accounts[i].Balance}";
                                if (current_account.AccountID == customer.Accounts[i].AccountID)
                                {
                                    accountId += " - [Your current account]";
                                }
                                Console.WriteLine(accountId);
                            }
                            Console.Write("Please select one of the accounts that you like to switch to? Use the index number: ");
                            var account_option = int.Parse(Console.ReadLine()) - 1;
                            current_account = customer.Accounts[account_option];
                        }
                        else
                        {
                            Console.WriteLine("Sorry you only have one account.");
                        }
                    }
                    else if (option == "6") 
                    {
                        Console.WriteLine($"Your current balance for this account is £{current_account.Balance}.");
                    }
                    else
                    {
                        InBank = false;
                    }
                }
            }
        }
    }
}