using System;

namespace BankAccountNS
{
    /// <summary>
    /// Bank account demo class:
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// Variables of BankAccount defined:
        /// </summary>
        protected readonly string m_customerName;
        protected double m_balance;


        private BankAccount() { }

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        public string CustomerName
        {
            get { return m_customerName; }
        }

        public double Balance
        {
            get { return m_balance; }
        }

        /// <summary>
        /// Debit method behaviour defined:
        /// </summary>
        /// <param name="amount"></param>
        public void Debit(double amount)
        {
            // If the amount debited is larger than the biginning balance the method throws an exception. 
            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount");
            }
            // If the amount debited is smaller than zero the method throws an exception. 
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }
            // If the correct amount is debited, the amount is subtracted from the biginning balance. 
            m_balance -= amount; 
        }
        /// <summary>
        /// Credit method behaviour defined:
        /// </summary>
        /// <param name="amount"></param>
        public void Credit(double amount)
        {
            // If the amount credited is smaller than zero, the method throws an expection. 
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }
            // If the correct amount is credited, the amount is added to the biginning balance. 
            m_balance += amount;
        }

        /// <summary>
        /// This method transfers money from another account to this account:
        /// </summary>
        /// <param name="from"></param>
        /// <param name="amount"></param>
        public void Transfer(BankAccount from, double amount)
        {
            // If the amount being transferred is larger than the amount in the account transferred from, the mothod throws an exeption 
            // of "Insufficient Funds"
            if (amount > from.Balance)
            {
                throw new ArgumentOutOfRangeException("Insufficient Funds");
            }
            // If the amount being transferred is smaller than zero, the mothod throws an exception
            // of "Transfer Amount needs to be greater than 0"
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Transfer Amount needs to be greater than 0");
            }
            
            // transfer money to this account
            m_balance += amount;
            // debit money from another account
            from.Debit(amount);
        }
    }
}