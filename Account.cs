using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountProject
{
    class Account
    {
        /////////////////////////////////////////
        //Fields
        /////////////////////////////////////////
        private string accountHolderName;
        private double accountBalance;

        /////////////////////////////////////////
        //Properties
        /////////////////////////////////////////
        public string AccountHolder
        {
            get { return this.accountHolderName; }
            set { this.accountHolderName = value; }
        }
        public double Balance
        {
            get { return this.accountBalance; }
            set { this.accountBalance = value; }
        }

        /////////////////////////////////////////
        //Constructors
        /////////////////////////////////////////
        public Account()
        {

        }//default Constructor
        public Account(Client user)
        {
            this.AccountHolder = user.FullName;
            this.Balance = 0;
        }

        /////////////////////////////////////////
        //Methods
        /////////////////////////////////////////
        
    }
}
