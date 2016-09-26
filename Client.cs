using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountProject
{
    class Client
    {
        //**********************
        //fields
        //**********************
        private string clientFirstName;
        private string clientLastName;
        private string clientFullNameFormatted;
        private int clientAge;
        private int clientPolicyNumber;

        //**********************
        //Properties
        //**********************
        public string FirstName
        {
            get { return this.clientFirstName; }
            set { this.clientFirstName = value; }
        }
        public string LastName
        {
            get { return this.clientLastName; }
            set { this.clientLastName = value; }
        }
        public string FullName
        {
            get { return this.clientFullNameFormatted; }
            set { this.clientFullNameFormatted = value; }
        }
        public int PolicyNumber
        {
            get { return this.clientPolicyNumber; }
            set { this.clientPolicyNumber = value; }
        }
        public int Age
        {
            get { return this.clientAge; }
            set { this.clientAge = value; }
        }


        //**********************
        //Constructors
        //**********************
        public Client()//default Constructor
        {
        }
        public Client(string firstName, string lastName, int age)
        {
            this.FirstName = nameFormatting(firstName);
            this.LastName = nameFormatting(lastName);
            this.FullName = this.FirstName + " " + this.LastName;
            this.Age = age;
            this.PolicyNumber = policyNumberCalculation(age);
        }


        //**********************
        //Methods
        //**********************
        public string nameFormatting(string originalName)
        {
            string formattedName;
            string firstLetter;
            string remainingLetters;

            firstLetter = originalName.Substring(0, 1);
            firstLetter = firstLetter.ToUpper();
            remainingLetters = originalName.Remove(0, 1);
            remainingLetters = remainingLetters.ToLower();
            formattedName = firstLetter + remainingLetters;
            return formattedName;
        }
        public int policyNumberCalculation(int age)
        {
            int newPolicyNumber = age * 1023;
            return newPolicyNumber;
        }
    }
}
