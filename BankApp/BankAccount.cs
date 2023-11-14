using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class BankAccount
    {
        public decimal Balance { get; set; }
        public decimal BankAccountNumber { get; set; }
        public string Name { get; set; }


        //public BankAccount(decimal initialBalance)
        //{
        //    Balance = initialBalance;
        //    BankAccountNumber = 123456789;
        //}

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Deposit amount must be positive");
            }

            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Insufficient funds");
            }
            Balance -= amount;
        }


        public static List<BankAccount> TransferMoney(List<BankAccount> bankAccountList)
        {
            bankAccountList[0].Withdraw(200);
            bankAccountList[1].Deposit(200);

            return bankAccountList;
        }

        public bool VerifyAccountNumber()
        {
            bool verified = false;

            if (BankAccountNumber.ToString().Length == 9)
            {
                var bankAccountNumberToString = BankAccountNumber.ToString();
                var substringFirstThree = int.Parse(bankAccountNumberToString[..3]);

                if (substringFirstThree == 123)
                {
                    verified = true;
                }
            }

            return verified;
        }
    }
}
