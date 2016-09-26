using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankAccountProject
{
    class Program
    {
        static void Main(string[] args)
        {

            Client user;
            CheckingAccount checking;
            SavingsAccount savings;
            ReserveAccount reserve;
            int menuOption;

            Console.WriteLine("Welcome");


            user = createClient();
            checking = new CheckingAccount(user);
            savings = new SavingsAccount(user);
            reserve = new ReserveAccount(user);
            createDataFile(checking, savings, reserve);
            while (true)
            {
                menuOption = mainMenu();
                switch (menuOption)
                {
                    case 1:
                        clientInformation(user);

                        break;
                    case 2:
                        accountBallance(checking, savings, reserve);

                        break;
                    case 3:
                        DepositFunds(checking, savings, reserve);
                        break;
                    case 4:
                        WithdrawFunds(checking, savings, reserve);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
            
            Console.ReadKey();
        }

        static int mainMenu()
        {
            int menuOption;
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1.View Client Information");
            Console.WriteLine("2.View Account Balance");
            Console.WriteLine("3.Deposit Funds");
            Console.WriteLine("4.Withdraw Funds");
            Console.WriteLine("5.Exit");
            menuOption = int.Parse(Console.ReadLine());
            return menuOption;

        }
        static void clientInformation(Client user)
        {
            Console.WriteLine("Name - " + user.FullName);
            Console.WriteLine("Age - " + user.Age);
            Console.WriteLine("Policy # - " + user.PolicyNumber);
            Console.ReadKey();

        }
        static Client createClient()
        {
            int userAge;
            string userFirstName;
            string userLastName;
            Client user;


            Console.WriteLine("Please enter your first name.");
            userFirstName = Console.ReadLine();
            Console.WriteLine("Please enter your last name.");
            userLastName = Console.ReadLine();
            Console.WriteLine("Please enter your age.");
            userAge = int.Parse(Console.ReadLine());
            user = new Client(userFirstName, userLastName, userAge);
            return user;

        }

        static void accountBallance(CheckingAccount checking, SavingsAccount savings, ReserveAccount reserve)
        {
            Console.WriteLine("Chekcing balance: " + checking.Balance);
            Console.WriteLine("Savings balance: " + savings.Balance);
            Console.WriteLine("Reserve balance: " + reserve.Balance);
            Console.ReadKey();
        }

        static void DepositFunds(CheckingAccount checking, SavingsAccount savings, ReserveAccount reserve)
        {
            int menuOption;
            double ammount;
            

            Console.WriteLine("Which account would you like to make a deposit in?");
            Console.WriteLine("1. Checkings");
            Console.WriteLine("2. Savings");
            Console.WriteLine("3. Reserve");
            menuOption = int.Parse(Console.ReadLine());
            Console.WriteLine("How much would you like to deposit?");
            ammount = double.Parse(Console.ReadLine());
            switch (menuOption)
            {
                case 1:
                    checking.Balance = checking.Balance + ammount;
                    string checkingFileName = checking.AccountHolder + "_" + checking.Type + "_" + checking.Number + ".txt";
                    StreamWriter checkingWriter = new StreamWriter(checkingFileName, true);
                    checkingWriter.WriteLine(DateTime.Now + " -> " + "+" + ammount.ToString() + " -> New Balance = " + checking.Balance);
                    checkingWriter.Close();
                    break;
                case 2:
                    savings.Balance = savings.Balance + ammount;
                    string savingsFileName = savings.AccountHolder + "_" + savings.Type + "_" + savings.Number + ".txt";
                    StreamWriter savingsWriter = new StreamWriter(savingsFileName, true);
                    savingsWriter.WriteLine(DateTime.Now + " -> " + "+" + ammount.ToString() + " -> New Balance = " + checking.Balance);
                    savingsWriter.Close();
                    break;
                case 3:
                    reserve.Balance = reserve.Balance + ammount;
                    string reserveFileName = reserve.AccountHolder + "_" + reserve.Type + "_" + reserve.Number + ".txt";
                    StreamWriter reserverWriter = new StreamWriter(reserveFileName, true);
                    reserverWriter.WriteLine(DateTime.Now + " -> " + "+" + ammount.ToString() + " -> New Balance = " + reserve.Balance);
                    reserverWriter.Close();
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
        }
        static void WithdrawFunds(CheckingAccount checking, SavingsAccount savings, ReserveAccount reserve)
        {
            int menuOption;
            double ammount;
            Console.WriteLine("Which account would you like to make a withdraw from?");
            Console.WriteLine("1. Checkings");
            Console.WriteLine("2. Savings");
            Console.WriteLine("3. Reserve");
            menuOption = int.Parse(Console.ReadLine());
            Console.WriteLine("How much would you like to withdraw?");
            ammount = double.Parse(Console.ReadLine());
            switch (menuOption)
            {
                case 1:
                    checking.Balance = checking.Balance - ammount;
                    string checkingFileName = checking.AccountHolder + "_" + checking.Type + "_" + checking.Number + ".txt";
                    StreamWriter checkingWriter = new StreamWriter(checkingFileName, true);
                    checkingWriter.WriteLine(DateTime.Now + " -> " + "-" + ammount.ToString() + " -> New Balance = " + checking.Balance);
                    checkingWriter.Close();
                    break;
                case 2:
                    savings.Balance = savings.Balance - ammount;
                    string savingsFileName = savings.AccountHolder + "_" + savings.Type + "_" + savings.Number + ".txt";
                    StreamWriter savingsWriter = new StreamWriter(savingsFileName, true);
                    savingsWriter.WriteLine(DateTime.Now + " -> " + "-" + ammount.ToString() + " -> New Balance = " + checking.Balance);
                    savingsWriter.Close();
                    break;
                case 3:
                    reserve.Balance = reserve.Balance - ammount;
                    string reserveFileName = reserve.AccountHolder + "_" + reserve.Type + "_" + reserve.Number + ".txt";
                    StreamWriter reserverWriter = new StreamWriter(reserveFileName, true);
                    reserverWriter.WriteLine(DateTime.Now + " -> " + "-" + ammount.ToString() + " -> New Balance = " + reserve.Balance);
                    reserverWriter.Close();
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
        }

        static void createDataFile(CheckingAccount checking, SavingsAccount savings, ReserveAccount reserve)
        {
            string checkingFileName = checking.AccountHolder + "_" + checking.Type+ "_" + checking.Number +  ".txt";
            StreamWriter checkingWriter = new StreamWriter(checkingFileName);
            checkingWriter.WriteLine("Account Holder: " +checking.AccountHolder);
            checkingWriter.WriteLine("Account Number: " + checking.Number);
            checkingWriter.WriteLine("Account Type:   " + checking.Type);
            checkingWriter.Close();
            string savingsFileName = savings.AccountHolder + "_" + savings.Type + "_" + savings.Number + ".txt";
            StreamWriter savingsWriter = new StreamWriter(savingsFileName);
            savingsWriter.WriteLine("Account Holder: " + savings.AccountHolder);
            savingsWriter.WriteLine("Account Number: " + savings.Number);
            savingsWriter.WriteLine("Account Type:   " + savings.Type);
            savingsWriter.Close();
            string reserveFileName = reserve.AccountHolder + "_" + reserve.Type + "_" + reserve.Number + ".txt";
            StreamWriter reserveWriter = new StreamWriter(reserveFileName);
            reserveWriter.WriteLine("Account Holder: " + reserve.AccountHolder);
            reserveWriter.WriteLine("Account Number: " + reserve.Number);
            reserveWriter.WriteLine("Account Type:   " + reserve.Type);
            reserveWriter.Close();
        }
    }
}
