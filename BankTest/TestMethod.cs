using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;
using Bank;
using System;

namespace BankTests
{

    /// <summary>
    /// Unit Test methods to verify the behavior of Debit method of BankAccount class:
    /// </summary>
    [TestClass]
    public class TestMethod
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            // Declare variable amounts:
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            // Subtracts debit amount from account
            account.Debit(debitAmount);

            // Assert
            // Ensures that the expected amount is equal to the actual amount, if not, method throws expection. 
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, "Account not debited correctly");
        }


        /// <summary>
        /// This method tests adding the credit amount to your balance
        /// Ensures that the right amount is credited from your balance
        /// </summary>
        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = 4.55;
            double expected = 16.54;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            // Adds the credit amount to the account. 
            account.Credit(creditAmount);

            // Assert
            // Ensures that the expected amount is equal to the actual amount, otherwise the method throws "Account not credited correctly" exception
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, "Account not credited correctly");
        }

        /// <summary>
        /// Transfer method test:
        /// </summary>
        [TestMethod]
        public void Transfer_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double transferAmount= 3.84;
            double expectedFrom = 8.15;
            double expectedTo = 15.83;
            BankAccount accountFrom = new BankAccount("Mr. Bryan Walton", beginningBalance);
            BankAccount accountTo = new BankAccount("Mr. Nathan", beginningBalance);

            // Act
            // Transfer amount from accountFrom to accountTo
            accountTo.Transfer(accountFrom, transferAmount);

            // Assert
            // Ensures the expecedFrom amount is equal to the actualFrom are equal, if not, an exception is thrown
            double actualFrom = accountFrom.Balance;
            Assert.AreEqual(expectedFrom, actualFrom, "Account From not transferred correctly");
            // Ensures the expecedTo amount is equal to the actualTo are equal, if not, "Account To not transferred correctly" exception is thrown
            double actualTo = accountTo.Balance;
            Assert.AreEqual(expectedTo, actualTo, "Account To not transferred correctly");

        }
        /// <summary>
        /// Testing incorrect transfer:
        /// Transfer invalid amount:
        /// </summary>

        [TestMethod]
        public void Transfer_WithInvalidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double transferAmount = 15.84;

            BankAccount accountFrom = new BankAccount("Mrs. Alice", beginningBalance);
            BankAccount accountTo = new BankAccount("Mr. John", beginningBalance);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => accountTo.Transfer(accountFrom, transferAmount));
        }
        /// <summary>
        /// Testing added accumulated intered added to account balance:
        /// </summary>
        [TestMethod]
        public void Interest_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double interestAmount = 0.05;
            double expected = 12.5895;
            SavingAccount account = new SavingAccount("Mr. Bryan Walton", beginningBalance, interestAmount);

            // Act
            account.AccumulateInterest();

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.01, "Interest not accumulated correctly");
        }

    }
}
