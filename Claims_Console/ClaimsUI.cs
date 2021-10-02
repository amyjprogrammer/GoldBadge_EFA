using Claims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Console
{
    public class ClaimsUI
    {
        private Claims_Repo _claimsRepo = new Claims_Repo();
        public void Run()
        {
            RunMenu(true);
        }
        private void RunMenu(bool isRunning)
        {
            while (isRunning)
            {
                Console.Clear();

                //The main menu with options to go to Agent or Manager Menu
                Console.WriteLine
                    (
                        "Welcome to the Komodo Claims Department Application\n" +
                        "****************************************************************\n\n" +
                        "1. Show Claims Agent Menu\n" +
                        "2. Show Claims Manager Menu\n" +
                        "3. Exit"
                    );
                PrintColorMessage(ConsoleColor.Green, "\nPlease enter the number of your selection: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AgentMenu();
                        break;
                    case "2":
                        ManagerMenu();
                        break;
                    case "3":
                        isRunning = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("\nPlease enter a valid number between 1-3.\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        Console.ResetColor();
                        break;
                }
            }
        }
        private void AgentMenu()
        {
            bool isAgentRunning = true;
            while (isAgentRunning)
            {
                Console.Clear();

                //Developer Menu
                Console.WriteLine
                    (
                        "Claims Agent Menu\n" +
                        "*********************************************\n\n" +
                        "1. See all claims\n" +
                        "2. Take care of next claim\n" +
                        "3. Enter a new claim\n" +
                        "4. Main Menu\n"
                    );
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Choose a menu item: ");
                Console.ResetColor();
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":

                        break;
                    case "2":

                        break;
                    case "3":

                        break;
                    case "4":
                        isAgentRunning = false;
                        RunMenu(false);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("\nPlease enter a valid number between 1-4.\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        Console.ResetColor();
                        break;
                }
            }
        }
        private void ManagerMenu()
        {
            bool isManagerRunning = true;
            while (isManagerRunning)
            {
                Console.Clear();

                //DevTeam Menu
                Console.WriteLine
                    (
                        "Claims Manager Menu\n" +
                        "**************************************\n\n" +
                        "1. Show all Developer Teams with Developers\n" +
                        "2. Add new Developer Team and Assign Multiple Developers\n" +
                        "3. Update Developer on Team\n" +
                        "4. Edit Developer Team\n" +
                        "5. Delete Developer Team\n" +
                        "6. Main Menu\n"
                    );
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nEnter the number of your selection: ");
                Console.ResetColor();
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":

                        break;
                    case "2":

                        break;
                    case "3":

                        break;
                    case "4":

                        break;
                    case "5":

                        break;
                    case "6":
                        isManagerRunning = false;
                        RunMenu(false);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("\nPlease enter a valid number between 1-6.\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        Console.ResetColor();
                        break;
                }
            }

        }
        private void CreateNewClaim()
        {
            bool createNewClaim = true;
            while (createNewClaim)
            {
                Console.Clear();

                //newing up a Claim
                Claims newClaim = new Claims();
                Console.WriteLine("Information for the New Claim\n" +
                    "********************************************\n\n");
                PrintColorMessage(ConsoleColor.Yellow, "Enter the claim id: ");

                //while loop to make sure the claim id is unique
                bool checkUserDidNotGiveUniqueId = true;
                while (checkUserDidNotGiveUniqueId)
                {
                    int userInput = MakeSureUserEnteredANum();
                    bool uniqueClaimId = MakeSureGaveUniqueId(userInput);
                    if (uniqueClaimId == true)
                    {
                        checkUserDidNotGiveUniqueId = false;
                    }
                    else
                    {
                        PrintColorMessage(ConsoleColor.Blue, "\nThe claim id must be unique. \n" +
                            "Please enter another number: ");
                    }
                    newClaim.ClaimID = userInput;
                }

                PrintColorMessage(ConsoleColor.Yellow, "\nEnter the claim type number: 1. Car, 2. Home, 3. Theft]: ");
                bool checkUserGaveCorrectType = true;
                while (checkUserGaveCorrectType)
                {
                    int userInputClaimType = MakeSureUserEnteredANum();
                    if (userInputClaimType == 1 || userInputClaimType == 2 || userInputClaimType == 3)
                    {
                        checkUserGaveCorrectType = false;
                    }
                    else
                    {
                        PrintColorMessage(ConsoleColor.Blue, "\nThe claim type must be either 1 for Car,2 for Home or 3 for Theft. \n" +
                            "Please enter the claim type number again: ");
                    }
                    newClaim.TypeOfClaim = (ClaimType)userInputClaimType;
                }
                PrintColorMessage(ConsoleColor.Yellow, "\nEnter a claim description: ");
                newClaim.Description = Console.ReadLine();
                PrintColorMessage(ConsoleColor.Yellow, "\nAmount of Damage: ");
                newClaim.ClaimAmount = MakeSureUserEnteredADoubleNum();
                PrintColorMessage(ConsoleColor.Yellow, "\nDate of Accident: ");

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
                    PrintColorMessage(ConsoleColor.Cyan, "\nPlease enter a number: ");
                    continue;
                }
                else
                {
                    return Int32.Parse(stringInput);
                }
            }
            return 0;
        }
        private bool MakeSureGaveUniqueId(int uniqueId)
        {
            Claims checkUniqueId = _claimsRepo.GetOneClaimFromDirectory(uniqueId);
            if (checkUniqueId != null)
            {
                return false;
            }
            else
            {
                return true;
            }
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
                    PrintColorMessage(ConsoleColor.Cyan, "\nPlease enter a number: ");
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

    }
}
