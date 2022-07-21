using DigitalBank.Core.Contracts;
using DigitalBank.Core.Services;


namespace DigitalBankTest.Core.Entities
{
    [TestClass]
    public class TransactionServiceTest
    {
        //positive
        [TestMethod]
        public void GetTransactionHistory_Valid_ShouldSucceed()
        {
            //Arrange
            TransactionService transactionService = new TransactionService();
            var Description = $"All transaction history for {DateTime.Now.ToShortDateString()}";
            List<Transaction> transaction = new List<Transaction>();
            var owner = new Owner("Aveshek", "Kumar");
            var openingBalance = new Amount { Value = 500, Currency = CurrencyType.INR };
            var account = new Account(owner, openingBalance);
            transaction.Add(new Transaction(openingBalance, DateTime.Now, account.Transactions.First().Note, TransactionType.Credit));

            //Act
            var result = transactionService.GetTransactionHistory(transaction);
            var matchingNoteFound = result.TransactionHistory.Contains("Initial amount.", StringComparison.CurrentCultureIgnoreCase);

            //Assert
            Assert.AreEqual(Description, result.Description);
            Assert.IsTrue(matchingNoteFound);


            // var description = $"All transaction history for {DateTime.Now.ToShortDateString()}";
            ////var header = "Date\t\tAmount\tBalance\tType\tNote";
            //var account = new Account(new Owner("Avishek", "Kumar"), new Amount { Value = 500, Currency = CurrencyType.INR });
            //ITransactionService transactionService = new TransactionService();

            //// Act
            //var transactionHistory = transactionService.GetTransactionHistory(account.Transactions);
            //var matchingNoteFound = transactionHistory.TransactionHistory.Contains("Initial amount.", StringComparison.CurrentCultureIgnoreCase);

            //Assert.AreEqual(description, transactionHistory.Description);
            //Assert.IsTrue(matchingNoteFound);

        }

        //Negative
        //[TestMethod]
        //public void GetTransactionHistory_INValid_ShouldSucceed()
        //{
        //}
    }
}
