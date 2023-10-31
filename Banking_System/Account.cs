using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    public class Customer
    {
        public string Fullname { get; set; }

        public List<Account> Accounts { get; } = new List<Account>();

        public Customer(string fullname)
        {
            Fullname = fullname;
        }

        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }

        public void RemoveAccount(Account account)
        {
            Accounts.Remove(account);
        }


    }
    public class Account
    {
        public int AccountID { get; }
        public Customer Owner { get; set; }
        public decimal Balance { get; set; }

        private static int accountNumberSeed = 1;
        public bool IsClosed { get; set; }

        public Account(Customer owner, decimal initial_balance)
        {
            Owner = owner;
            this.Balance = initial_balance;
            this.AccountID = accountNumberSeed;
            this.IsClosed = false;

            accountNumberSeed++;
            Console.WriteLine($"Welcome {Owner.Fullname} to your new account. Your new account ID is {this.AccountID}, and your current balance is £{this.Balance}.");
        }

        public void CloseAccount()
        {
            IsClosed = true;
            Console.WriteLine($"Account {AccountID} has been closed.");
        }

        public void Deposit(int accountNumber, decimal amount)
        {
            if (this.AccountID == accountNumber)
            {
                this.Balance += amount;
                Console.WriteLine($"You have successfully added £{amount} into your deposit.\nYour new balance is £{this.Balance}.");
            }
            else
            {
                Console.WriteLine("The account number provided does not match this account.");
            }
        }

        public void Withdraw(int accountNumber, decimal amount)
        {
            if (this.AccountID == accountNumber && this.Balance >= amount)
            {
                this.Balance -= amount;
                Console.WriteLine($"You have successfully withdrawn £{amount}.\nYour new balance is £{this.Balance}.");
            }
            else
            {
                Console.WriteLine("The account number provided does not match this account or insufficient funds.");
            }
        }

        public void Transfer(Account toAccount, decimal amount)
        {
            if (!IsClosed && Balance >= amount)
            {
                Balance -= amount;
                toAccount.Balance += amount;
                Console.WriteLine($"£{amount} has been transferred to account {toAccount.AccountID}.");
            }
            else
            {
                Console.WriteLine("Transfer failed. Check account status or insufficient funds.");
            }
        }
    }
}
