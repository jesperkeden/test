namespace BankApp.Test
{
    [Collection(nameof(BankAccountCollection))]
    public class BankAppTests
    {

        readonly BankAccount _sut;

        public BankAppTests(BankAccountFixture bankAccountFixture)
        {
            _sut = bankAccountFixture.RegularAccount;
        }


        [Theory]
        [InlineData(123456789)]
        [InlineData(123456729)]
        [InlineData(123456759)]
        [InlineData(123446789)]
        [InlineData(123456781)]
        public void CanVerifyAccountNumber(decimal accountNumber)
        {
            // Arrange            
            _sut.BankAccountNumber = accountNumber;

            // Act
            var actual = _sut.VerifyAccountNumber();

            // Assert
            Assert.True(actual);
        }


        [Theory]
        [InlineData(1234567895)]
        [InlineData(122456729)]
        [InlineData(2234567595)]
        [InlineData(323446789)]
        [InlineData(1234567119)]
        public void CanVerifyFalseAccount(decimal accountNumber)
        {
            // Arrange
            _sut.BankAccountNumber = accountNumber;

            // Act
            var actual = _sut.VerifyAccountNumber();

            // Assert
            Assert.False(actual);
        }

        [Fact]
        public void CanSendMoneyBetweenAccounts()
        {
            // Arrange
            var jespersAccount = new BankAccount();
            var andreasAccount = new BankAccount();

            jespersAccount.Balance = 500;
            andreasAccount.Balance = 500;

            var bankAccountList = new List<BankAccount>
            {
                jespersAccount,
                andreasAccount
            };

            // Act
            bankAccountList = BankAccount.TransferMoney(bankAccountList);
            // Assert
            Assert.NotEqual(bankAccountList[0].Balance, bankAccountList[1].Balance);

        }

        [Theory]
        [InlineData(123, 45, 168)]
        [InlineData(100, 50, 150)]
        [InlineData(200, 200, 400)]
        public void CanDepositMoney(decimal initialBalance, decimal depositAmount, decimal expectedBalance)
        {
            // Arrange
            _sut.Balance = initialBalance;

            // Act
            _sut.Deposit(depositAmount);

            // Assert
            Assert.Equal(expectedBalance, _sut.Balance);
        }

        [Theory]
        [InlineData(500, 50, 450)]
        [InlineData(100, 9, 91)]
        public void CanWithdrawMoney(decimal initialBalance, decimal withdrawAmount, decimal expected)
        {
            // Arrange
            _sut.Balance = initialBalance;
            // Act
            _sut.Withdraw(withdrawAmount);

            // Assert
            Assert.Equal(expected, _sut.Balance);
        }

        [Fact]
        public void CannotDepositNegativeAmount()
        {
            // Arrange            

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _sut.Deposit(-50));
        }

        [Fact]
        public void CannotWithdrawNegativeAmount()
        {
            // Arrange

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _sut.Withdraw(-50));
        }

        [Theory]
        [InlineData(100, 200)]
        [InlineData(50, 51)]
        public void CannotWithdrawAmountGreaterThanBalance(decimal initialBalance, decimal withdrawalAmount)
        {
            // Arrange
            _sut.Balance = initialBalance;

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _sut.Withdraw(withdrawalAmount));
        }


    }
}