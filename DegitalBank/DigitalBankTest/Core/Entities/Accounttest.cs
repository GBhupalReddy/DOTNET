namespace DigitalBankTest.Core.Entities
{
    [TestClass]
    public class Accounttest
    {
        [TestMethod]
        public void Account_ValidOpeningBalance_ShouldSucceed()
        {
            //Arrange
            var owner = new Owner("Aveshek", "Kumar");
            var openingBalance = new Amount { Value = 500, Currency = CurrencyType.INR };
            ulong expectedAccountNumber = 1000000000000000;

            // Act
            var account = new Account(owner, openingBalance);

            // Assert
            Assert.AreEqual<decimal>(openingBalance.Value, account.Balance);
            Assert.AreEqual("Initial amount.", account.Transactions.First().Note);
            Assert.AreEqual(expectedAccountNumber, account.Number);
        }
        //negative Test Case for Account Creation
        [TestMethod]
        public void Account_InvalidOpeningBlance_ShouldThrowError()
        {
            //Arrange
            var owner = new Owner("Avshek", "Kumar");
            var openingBlance = new Amount { Value = -300, Currency = CurrencyType.INR };

            //Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Account(owner, openingBlance));

        }
        //positive Teat Case for Deposit
        [TestMethod]
        public void Deposit_ValidAmount_ShouldSucceed()
        {
            // Arrange
            decimal depositAmount = 300m;
            decimal expectedBalance = 800;
            var account = new Account(new Owner("Avishek", "Kumar"), new Amount { Value = 500, Currency = CurrencyType.INR });

            // Act
            var depositResult = account.Deposite(new Amount { Value = 300, Currency = CurrencyType.INR }, DateTime.Now, "Depositing valid amount.");

            // Assert
            Assert.IsTrue(depositResult);
            Assert.AreEqual(expectedBalance, account.Balance);
        }
        //Negative Test Case for Deposit
        [DataTestMethod]
        [DataRow(0d)]
        [DataRow(-1.5)]
        public void Deposit_AmountZeroOrLess_ShouldThrowError(double depositeAmount)
        {
            //Arrange
            var account = new Account(new Owner("Avishek", "Kumar"), new Amount { Value = 500, Currency = CurrencyType.INR });

            //Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Deposite(new Amount { Value = (decimal)depositeAmount, Currency = CurrencyType.INR }, DateTime.Now, "depositing valid amount."));
        }

        //Positive Test Case for Withdraw
        [TestMethod]
        public void Withdraw_ValidAmount_ShouldSucceed()
        {
            // Arrange
            decimal withdeawAmount = 300m;
            decimal expectedBalance = 200;
            var account = new Account(new Owner("Avishek", "Kumar"), new Amount { Value = 500, Currency = CurrencyType.INR });

            //Act
            var withdrawReault = account.Withdraw(new Amount { Value = 300, Currency = CurrencyType.INR }, DateTime.Now, "withdraw valid amount.");

            //Assert

            Assert.IsTrue(withdrawReault);
            Assert.AreEqual(expectedBalance, account.Balance);
        }

        //negative Test Case for Withdraw
        [DataTestMethod]
        [DataRow(600)]
        [DataRow(-100)]
        public void Withdraw_ValidAmount_ShouThrowError(double withdeawAmount)
        {

            //Arrange
            var account = new Account(new Owner("Avishek", "Kumar"), new Amount { Value = 500, Currency = CurrencyType.INR });
            if (withdeawAmount < 0)
            {
                //Act & Assert
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Withdraw(new Amount { Value = (decimal)withdeawAmount, Currency = CurrencyType.INR }, DateTime.Now, "withdraw valid amount."));
            }
            if (withdeawAmount >= 500)
            {
                //Act & Assert
                Assert.ThrowsException<InvalidOperationException>(() => account.Withdraw(new Amount { Value = (decimal)withdeawAmount, Currency = CurrencyType.INR }, DateTime.Now, "withdraw valid amount."));
            }


        }
    }
}
