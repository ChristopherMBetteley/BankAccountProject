using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountProject
{
    class ReserveAccount: Account
    {
        /////////////////////////////////////////
        //Fields
        /////////////////////////////////////////
        private string accountType;
        private int accountNumber;

        /////////////////////////////////////////
        //Properties
        /////////////////////////////////////////
        public string Type
        {
            get { return this.accountType; }
            set { this.accountType = value; }
        }
        public int Number
        {
            get { return this.accountNumber; }
            set { this.accountNumber = value; }
        }

        /////////////////////////////////////////
        //Constructors
        /////////////////////////////////////////
        public ReserveAccount()
        {

        }
        public ReserveAccount(Client user) : base (user)
        {
            this.Type = "Reserve";
            this.Number = accountNumberCalculation(user);
        }

        /////////////////////////////////////////
        //Methods
        /////////////////////////////////////////
        private int accountNumberCalculation(Client user)
        {
            int returnValue = user.PolicyNumber / 3;
            return returnValue;
        }
    }
}
