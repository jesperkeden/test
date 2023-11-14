using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Test
{

    public class BankAccountFixture
    {
        public BankAccount RegularAccount { get; set; } = new BankAccount();

        public BankAccountFixture()
        {
            RegularAccount.Balance = 500;
            RegularAccount.BankAccountNumber = 123456789;
            RegularAccount.Name = "Jesper";

        }

    }
}
