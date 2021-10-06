using Email_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Email_Console
{
    public class EmailUI
    {
        private Customer_Repo _customerRepo = new Customer_Repo();
        public void Run()
        {
            RunMenu();
        }
        private void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine
                    (
                        "Komodo Insurance Customer and Email Application\n" +
                        "****************************************************************\n\n" +
                        "1. Add a customer\n" +
                        "2. Edit a customer\n" +
                        "3. List all customers\n" +
                        "4. Remove a customer\n" +
                        "5. Exit"
                    );
                PrintColorMessage(ConsoleColor.Yellow, "\nPlease enter the number of your selection: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddACustomer();
                        break;
                    case "2":
                        ;
                        break;
                    case "3":
                        ;
                        break;
                    case "4":
                        ;
                        break;
                    case "5":
                        isRunning = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("\nPlease enter a valid number between 1-5");
                        Thread.Sleep(2000);
                        Console.ResetColor();
                        break;
                }
            }
        }
        private void AddACustomer()
        {
            bool addCustomer = true;
            while (addCustomer)
            {
                Console.Clear();

                Customer newCustomer = new Customer();
                Console.WriteLine("Information for the New Customer\n" +
                    "********************************************\n\n");

                PrintColorMessage(ConsoleColor.Yellow, "Please enter the first name: ");
                newCustomer.FirstName = Console.ReadLine();

                PrintColorMessage(ConsoleColor.Yellow, "\nPlease enter the last name: ");
                newCustomer.LastName = Console.ReadLine();

                PrintColorMessage(ConsoleColor.Yellow, "\nEnter the type of customer: 1. Current, 2. Past, 3. Potential: ");
                bool checkUserGaveCorrectType = true;
                while (checkUserGaveCorrectType)
                {
                    int userInputType = MakeSureUserEnteredANum();
                    if (userInputType == 1 || userInputType == 2 || userInputType == 3)
                    {
                        checkUserGaveCorrectType = false;
                    }
                    else
                    {
                        PrintColorMessage(ConsoleColor.Red, "The customer type must be either 1 for Current,2 for Past or 3 for Potential. \n" +
                            "Please enter the claim type number again: ");
                    }
                    newCustomer.TypeOfCustomer = (CustomerType)userInputType;
                }
                _customerRepo.AddACustomer(newCustomer);
                Console.Clear();
                Console.WriteLine("The Customer was Added\n" +
                   "********************************************\n\n");

                Console.ForegroundColor = ConsoleColor.Yellow;
                addCustomer = CheckIfUserWantsToAddMore("\nWould you like to add another customer? [Y or N]: ");
                Console.ResetColor();
            }
            PauseProgram();
        }
        private void EditACustomer()
        {
            bool editCustomer = true;
            while (editCustomer)
            {

            }
        }
        static void PrintColorMessage(ConsoleColor color, string message)
        {
            //Change text color
            Console.ForegroundColor = color;
            //text
            Console.Write(message);
            //reset color
            Console.ResetColor();
        }
        private bool CheckIfUserWantsToAddMore(string messageToContinue)
        {
            Console.Write(messageToContinue);
            string answer = Console.ReadLine().ToUpper();
            if (answer == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void PauseProgram()
        {
            Console.WriteLine("\n\nPress any key to return to Main Menu...");
            Console.ReadKey();
        }
        private int MakeSureUserEnteredANum()
        {
            bool checkUserGaveWrongNum = true;
            while (checkUserGaveWrongNum)
            {
                string stringInput = Console.ReadLine();
                if (!int.TryParse(stringInput, out int uniqueId))
                {
                    PrintColorMessage(ConsoleColor.Cyan, "Please enter a number: ");
                    continue;
                }
                else
                {
                    return Int32.Parse(stringInput);
                }
            }
            return 0;
        }
    }
}
