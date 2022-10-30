using BankAccountNS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    /// <summary>
    /// Single inheritance...
    /// base class: BankAccount
    /// derived class: SavingAccount
    /// </summary>
    public class SavingAccount : BankAccount
    {
        public SavingAccount(string customerName, double balance, double interestRate) : base(customerName, balance) {
            m_interestRate = interestRate;
        }

        private double m_interestRate;

        public double InterestRate
        {
            get { return m_interestRate; }
        }
        /// <summary>
        /// Adding accumulated interest on biginning balance amount
        /// </summary>
        public void AccumulateInterest()
        {
            m_balance = m_balance * (1 + m_interestRate);
        }
    }
}
