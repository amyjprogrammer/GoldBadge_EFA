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
                        ShowAllOutings();
                        break;
                    case "2":
                        AddAnOuting();
                        break;
                    case "3":
                        CostOfOutings();
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
        private void ShowAllOutings()
        {
            Console.Clear();
            DisplayAllOutings();
            PauseProgram();
        }
        private void AddAnOuting()
        {
            bool addOuting = true;
            while (addOuting)
            {
                Console.Clear();

                Outings createOuting = new Outings();
                Console.WriteLine("Information for the New Outing\n" +
                    "********************************************\n\n");
                PrintColorMessage(ConsoleColor.White, "Please select the Event Type Number: \n1. Golf \n2. Bowling \n3. Amusement Park \n4. Concert \n");
                PrintColorMessage(ConsoleColor.Yellow, "Your selection: ");
                bool checkUserGaveCorrectType = true;
                while (checkUserGaveCorrectType)
                {
                    int userInputEvent = MakeSureUserEnteredANum();
                    if (userInputEvent == 1 || userInputEvent == 2 || userInputEvent == 3 || userInputEvent == 4)
                    {
                        checkUserGaveCorrectType = false;
                    }
                    else
                    {
                        PrintColorMessage(ConsoleColor.Red, "The event type must be either 1 for Golf, 2 for Bowling, 3 for Amusement Park or 4 for Concert. \n" +
                            "Please enter the event type number again: ");
                    }
                    createOuting.TypeOfEvent = (EventType)userInputEvent;
                }

                PrintColorMessage(ConsoleColor.Yellow, "\nPlease enter the number of people attended: ");
                int userInputAttended = MakeSureUserEnteredANum();
                createOuting.NumPeopleAttended = userInputAttended;

                PrintColorMessage(ConsoleColor.Yellow, "\nPlease enter the date for the event like 5/21/21: ");
                string userInputDate = CheckUserInputForDateTime();
                createOuting.DateOfEvent = DateTime.Parse(userInputDate);

                PrintColorMessage(ConsoleColor.Yellow, "\nPlease enter the total cost for the event: ");
                double userInputTotalCost = MakeSureUserEnteredADoubleNum();
                createOuting.CostOfEvent = userInputTotalCost;

                _outingsRepo.AddOutingToDirectory(createOuting);
                Console.Clear();

                Console.WriteLine("This Outing was added.\n" +
                    "********************************************\n\n");

                Console.ForegroundColor = ConsoleColor.Yellow;
                addOuting = CheckIfUserWantsToAddMore("\nWould you like to add another event? [Y or N]: ");
                Console.ResetColor();
            }
            PauseProgram();
        }
        private void CostOfOutings()
        {
            Console.Clear();
            CostForEachEventType();
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
                string userInput = Console.ReadLine();
                DateTime dt;
                var isValidDate = DateTime.TryParse(userInput, out dt);
                if (isValidDate)
                {
                    return userInput;
                }
                else
                {
                    PrintColorMessage(ConsoleColor.Red, "Incorrect Information Given. Enter the date like 5/21/21.  \nPlease enter the date again: ");
                }
            }
            return "0";
        }
        private void DisplayAllOutings()
        {
            Console.WriteLine("A list of all Outings\n" +
               "******************************************\n");
            List<Outings> listOfAllOutings = _outingsRepo.GetAllOutings();
            if (listOfAllOutings.Count == 0)
            {
                Console.WriteLine("Currently we don't have any Outings listed.");
            }
            else
            {
                Console.WriteLine($"{"Event Type",-25}{"Attended",-15}{"Date",-15}{"Cost Per Person",-25}{"Cost for Event",-20}");
                Console.WriteLine($"{"__________",-25}{"________",-15}{"____",-15 }{"_______________",-25}{"______________",-20}");

                foreach (var outingsContent in listOfAllOutings)
                {
                    Console.WriteLine($"{outingsContent.TypeOfEvent,-25}{outingsContent.NumPeopleAttended,-15}{outingsContent.DateOfEvent.ToShortDateString(),-15}${outingsContent.CostPerPersonForEvent,-25}${outingsContent.CostOfEvent,-20}");
                }
            }
        }
        private string CostForEachEventType()
        {
            Console.WriteLine("A list of Costs for Each Event Type\n" +
               "******************************************\n");
            List<Outings> listOfAllOutings = _outingsRepo.GetAllOutings();

            if (listOfAllOutings.Count == 0)
            {
                Console.WriteLine("Currently we don't have any Outings listed.");
            }
            else 
            {
                double parkCount = 0;
                foreach (var outing in listOfAllOutings)
                {
                    if (outing.TypeOfEvent == EventType.Amusement_Park)
                    {
                        parkCount = parkCount + outing.CostOfEvent;
                        
                    }
                }
                Console.WriteLine($"The cost for the Amusement Parks Outings was ${parkCount}.");

                double bowlingCount = 0;
                foreach (var outing in listOfAllOutings)
                {
                    if (outing.TypeOfEvent == EventType.Bowling)
                    {
                        bowlingCount = bowlingCount + outing.CostOfEvent;

                    }
                }
                Console.WriteLine($"\nThe cost for the Bowling Outings was ${bowlingCount}.");

                double concertCount = 0;
                foreach (var outing in listOfAllOutings)
                {
                    if (outing.TypeOfEvent == EventType.Concert)
                    {
                        concertCount = concertCount + outing.CostOfEvent;

                    }
                }
                Console.WriteLine($"\nThe cost for the Concert Outings was ${concertCount}.");

                double golfCount = 0;
                foreach (var outing in listOfAllOutings)
                {
                    if (outing.TypeOfEvent == EventType.Golf)
                    {
                        golfCount = golfCount + outing.CostOfEvent;

                    }
                }
                Console.WriteLine($"\nThe cost for the Golf Outings was ${golfCount}.");

                Console.Write("\n*************************************************\n" +
                    "The total cost for all outings is $");
                double totalCost = _outingsRepo.TotalCostForOutings();
                Console.Write(totalCost + ".\n\n");
            }
            return "0";
        }
    }
}
