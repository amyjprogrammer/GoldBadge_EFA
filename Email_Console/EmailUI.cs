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
                        ;
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

            }
            PauseProgram();
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
    }
}
