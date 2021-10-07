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
                        EditACustomer();
                        break;
                    case "3":
                        ShowAllCustomers();
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
                Console.Clear();
                DisplayAllCustomers();
                var allCustomers = _customerRepo.ReviewAllCustomers();
                if (allCustomers.Count == 0)
                {
                    editCustomer = false;
                }
                else
                {
                    PrintColorMessage(ConsoleColor.Yellow, "\n\nWhat is the customer number to update: ");
                    int userInputCustomer = MakeSureUserEnteredANum();
                    var existingCustomerInfo = _customerRepo.GetOneCustomerByID(userInputCustomer);
                    if (existingCustomerInfo == null)
                    {
                        Console.WriteLine("We are not able to find that customer number.");
                        PauseProgram();
                        return;
                    }
                    Console.Clear();
                    DisplayOneCustomerByID(userInputCustomer);
                    Console.WriteLine("\n\nWhat would you like to do?\n\n" +
                            "1. Update the Full Name and Customer Type\n" +
                            "2. Update the First Name\n" +
                            "3. Update the Last Name\n" +
                            "4. Update the Customer Type\n");
                    PrintColorMessage(ConsoleColor.Yellow, "Select Option: ");
                    string userChoice = Console.ReadLine();
                    Customer updateCustomerInfo = new Customer();
                    switch (userChoice)
                    {
                        case "1":
                            var newInfo = UpdateAllInfo(updateCustomerInfo);
                            newInfo.CustomerID = existingCustomerInfo.CustomerID;
                            _customerRepo.UpdateAllCustomerInfo(existingCustomerInfo, newInfo);
                            Console.Clear();
                            DisplayOneCustomerByID(newInfo.CustomerID);
                            break;
                        case "2":
                            var newFirstName = UpdateFirstName(updateCustomerInfo);
                            newFirstName.CustomerID = existingCustomerInfo.CustomerID;
                            _customerRepo.UpdateCustomerFirstName(existingCustomerInfo, newFirstName.FirstName);
                            Console.Clear();
                            DisplayOneCustomerByID(newFirstName.CustomerID);
                            break;
                        case "3":
                            var newLastName = UpdateLastName(updateCustomerInfo);
                            newLastName.CustomerID = existingCustomerInfo.CustomerID;
                            _customerRepo.UpdateCustomerLastName(existingCustomerInfo, newLastName.LastName);
                            Console.Clear();
                            DisplayOneCustomerByID(newLastName.CustomerID);
                            break;
                        case "4":
                            var newType = UpdateType(updateCustomerInfo);
                            newType.CustomerID = existingCustomerInfo.CustomerID;
                            _customerRepo.UpdateCustomerType(existingCustomerInfo, newType.TypeOfCustomer);
                            Console.Clear();
                            DisplayOneCustomerByID(newType.CustomerID);
                            break;
                        default:
                            PrintColorMessage(ConsoleColor.Magenta, "Please enter between 1-4.");
                            Thread.Sleep(2000);
                            break;
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    editCustomer = CheckIfUserWantsToAddMore("\nWould you like to add update another customer? [Y or N]: ");
                    Console.ResetColor();
                }
            }
            PauseProgram();
        }
        public void ShowAllCustomers()
        {
            Console.Clear();
            DisplayAllCustomers();
            PauseProgram();
        }
        private void DisplayAllCustomers()
        {
            Console.WriteLine("A list of all Customers\n" +
              "******************************************\n");
            var allCustomers = _customerRepo.ReviewAllCustomers();
            if (allCustomers.Count == 0)
            {
                Console.WriteLine("Currently we don't have any badges listed.");
            }
            else
            {
                Console.WriteLine($"{"Customer ID",-15}{"First Name",-15}{"Last Name",-15}{"Type",-15}{"Email",-35}");
                foreach (var customer in allCustomers)
                {
                    Console.WriteLine($"{customer.CustomerID,-15}{customer.FirstName,-15}{customer.LastName,-15}{customer.TypeOfCustomer,-15}{customer.EmailMessage,-35}");
                }
            }
        }
        private Customer UpdateAllInfo(Customer newCustomerInfo)
        {
            PrintColorMessage(ConsoleColor.Yellow, "\nWhat is the new First Name: ");
            newCustomerInfo.FirstName = Console.ReadLine();

            PrintColorMessage(ConsoleColor.Yellow, "\nWhat is the new Last Name: ");
            newCustomerInfo.LastName = Console.ReadLine();

            PrintColorMessage(ConsoleColor.Yellow, "\nEnter the new type of customer: 1. Current, 2. Past, 3. Potential: ");
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
                newCustomerInfo.TypeOfCustomer = (CustomerType)userInputType;
            }
            return newCustomerInfo;
        }
        private Customer UpdateFirstName(Customer newCustomerInfo)
        {
            PrintColorMessage(ConsoleColor.Yellow, "\nWhat is the new First Name: ");
            newCustomerInfo.FirstName = Console.ReadLine();
            return newCustomerInfo;
        }
        private Customer UpdateLastName(Customer newCustomerInfo)
        {

            PrintColorMessage(ConsoleColor.Yellow, "\nWhat is the new Last Name: ");
            newCustomerInfo.LastName = Console.ReadLine();
            return newCustomerInfo;
        }
        private Customer UpdateType(Customer newCustomerInfo)
        {
            PrintColorMessage(ConsoleColor.Yellow, "\nEnter the new type of customer: 1. Current, 2. Past, 3. Potential: ");
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
                newCustomerInfo.TypeOfCustomer = (CustomerType)userInputType;
            }
            return newCustomerInfo;
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
        private void DisplayOneCustomerByID(int customerID)
        {
            Console.WriteLine("Customer Information\n" +
             "******************************************\n");
            var oneCustomer = _customerRepo.GetOneCustomerByID(customerID);
            Console.WriteLine($"{"Customer ID",-15}{"First Name",-20}{"Last Name",-20}{"Type",-15}{"Email",-35}");
            Console.WriteLine($"{oneCustomer.CustomerID,-15}{oneCustomer.FirstName,-20}{oneCustomer.LastName,-20}{oneCustomer.TypeOfCustomer,-15}{oneCustomer.EmailMessage,-35}");

        }
    }
}
