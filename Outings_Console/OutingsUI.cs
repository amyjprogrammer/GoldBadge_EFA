using Outings_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Outings_Console
{
    public class OutingsUI
    {
        private Outings_Repo _outingsRepo = new Outings_Repo();
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

                //The main menu with options to go to Dev or DevTeam
                Console.WriteLine
                    (
                        "Welcome to the Komodo Company Outings\n" +
                        "****************************************************************\n\n" +
                        "1. Show All Outings\n" +
                        "2. Add an Outing\n" +
                        "3. Review Costs for the Outings\n" +
                        "4. Exit"
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
                        isRunning = false;
                        break;
                    default:
                        PrintColorMessage(ConsoleColor.Magenta, "\nPlease enter a valid number between 1-4.");
                        Thread.Sleep(2000);
                        break;
                }
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
        private double MakeSureUserEnteredADoubleNum()
        {
            bool checkUserGaveWrongNum = true;
            while (checkUserGaveWrongNum)
            {
                string stringInput = Console.ReadLine();
                if (!double.TryParse(stringInput, out double uniqueId))
                {
                    PrintColorMessage(ConsoleColor.Cyan, "Please enter a number: ");
                    continue;
                }
                else
                {
                    return Convert.ToDouble(stringInput);
                }
            }
            return 0;
        }
        private void PauseProgram()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        private string CheckUserInputForDateTime()
        {
            bool checkUserInputForWrongDate = true;
            while (checkUserInputForWrongDate)
            {
                string userInputForAccident = Console.ReadLine();
                DateTime dt;
                var isValidDate = DateTime.TryParse(userInputForAccident, out dt);
                if (isValidDate)
                {
                    return userInputForAccident;
                }
                else
                {
                    PrintColorMessage(ConsoleColor.Red, "Incorrect Information Given. Enter the date like 5/21/21.  \nPlease enter the date again: ");
                }
            }
            return "0";
        }
        private void ShowAllOutings()
        {
            Console.WriteLine("A list of all Outingss\n" +
               "******************************************\n");
            List<Outings> listOfAllOutings = _outingsRepo.GetAllOutings();
            if (listOfAllOutings.Count == 0)
            {
                Console.WriteLine("Currently we don't have any Outings listed.");
            }
            /*else
            {
                Console.WriteLine($"{"ClaimID",-10}{"Type",-15}{"Description",-30}{"Amount",-15}{"Date of Accident",-20}{"Date of Claim",-20}{"IsValid",-15}");
                Console.WriteLine($"{"_______",-10}{"____",-15}{"___________",-30 }{"______",-15}{"________________",-20}{"_____________",-20}{"_______",-15}");
                foreach (var claimsContent in queueofAllClaims)
                {
                    Console.WriteLine($"{claimsContent.ClaimID,-10}{claimsContent.TypeOfClaim,-15}{claimsContent.Description,-30}${claimsContent.ClaimAmount,-15}{claimsContent.DateOfIncident.ToShortDateString(),-20}{claimsContent.DateOfClaim.ToShortDateString(),-20}{claimsContent.IsValid,-15}");
                }
                int index = 1;
                foreach (var outingsContent in listOfAllOutings)
                {
                    Console.WriteLine($"{index}. Full name: {devContent.FullName}: Id- {devContent.IdNumber}");
                    index++;
                }
            }*/
        }
    }
}
