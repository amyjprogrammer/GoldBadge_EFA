using Badge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Badge_Console
{
    class BadgeUI
    {
        private Badge_Repo _badgeRepo = new Badge_Repo();
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
                        "Hello Security Admin, What would you like to do?\n" +
                        "****************************************************************\n\n" +
                        "1. Add a badge\n" +
                        "2. Edit a badge\n" +
                        "3. List all badges\n" +
                        "4. Remove a badge\n" +
                        "5. Exit"
                    );
                PrintColorMessage(ConsoleColor.Yellow, "\nPlease enter the number of your selection: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        UpdateABadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        RemoveABadge();
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
        private void AddABadge()
        {
            bool addBadge = true;
            while (addBadge)
            {
                Console.Clear();

                var createBadge = new Badge();
                Console.WriteLine("Information for the New Badge\n" +
                    "********************************************\n\n");

                PrintColorMessage(ConsoleColor.Yellow, "What is the number on the badge: ");
                int userInputBadgeNum = MakeSureUserEnteredANum();
                createBadge.BadgeID = userInputBadgeNum;

                List<string> doorAccess = new List<string>();
                /*bool addDoors = true;
                while (addDoors)
                {
                    PrintColorMessage(ConsoleColor.Yellow, "\nList a door that it needs access to: ");
                    string userInputDoor = Console.ReadLine();
                    doorAccess.Add(userInputDoor);
                    createBadge.DoorName = doorAccess;

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    addDoors = CheckIfUserWantsToAddMore("\nAny other doors? [Y or N]: ");
                    Console.ResetColor();
                }*/

                Console.WriteLine("\nPlease enter your list of doors by adding a coma like A5,B1,C9.");
                PrintColorMessage(ConsoleColor.Yellow, "Door List: ");
                string splitList = Console.ReadLine();
                doorAccess = splitList.Split(',').ToList();
                createBadge.DoorName = doorAccess;

                _badgeRepo.AddNewBadgeID(createBadge);

                Console.Clear();
                Console.WriteLine("New Badge was Added\n" +
                   "********************************************\n\n");

                Console.ForegroundColor = ConsoleColor.Yellow;
                addBadge = CheckIfUserWantsToAddMore("Would you like to add another badge? [Y or N]: ");
                Console.ResetColor();
            }
            PauseProgram();
        }
        private void ListAllBadges()
        {
            Console.Clear();
            ShowAllBadges();
            PauseProgram();
        }
        private void UpdateABadge()
        {
            bool updateBadge = true;
            while (updateBadge)
            {
                Console.Clear();
                ShowAllBadges();

                //double check if any badges listed
                var allBadges = _badgeRepo.ReadAllBadges();
                if (allBadges.Count == 0)
                {
                    updateBadge = false;
                }
                else
                {
                    PrintColorMessage(ConsoleColor.Yellow, "\n\nWhat is the badge number to update: ");
                    int userInputBadge = MakeSureUserEnteredANum();
                    var existingBadgeInfo = _badgeRepo.ReadOneBadgeByID(userInputBadge);
                    if (existingBadgeInfo == null)
                    {
                        Console.WriteLine("We are not able to find that badge number.");
                        PauseProgram();
                        return;
                    }
                    Console.Write($"\nBadge {userInputBadge} has access to ");
                    foreach (var door in existingBadgeInfo.DoorName)
                    {
                        Console.Write($"{door} ");
                    }
                    Console.WriteLine("\n\nWhat would you like to do?\n\n" +
                        "1. Remove a door\n" +
                        "2. Add a door\n");
                    PrintColorMessage(ConsoleColor.Yellow, "Select Option: ");
                    string userChoice = Console.ReadLine();
                    switch (userChoice)
                    {
                        case "1":
                            RemoveDoor(existingBadgeInfo, userInputBadge);
                            break;
                        case "2":
                            AddDoor(existingBadgeInfo, userInputBadge);
                            break;
                        default:
                            PrintColorMessage(ConsoleColor.Magenta, "Please enter either 1 or 2.");
                            Thread.Sleep(2000);
                            break;
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    updateBadge = CheckIfUserWantsToAddMore("\n\nWould you like to update another badge? [Y or N]: ");
                    Console.ResetColor();
                }
            }
            PauseProgram();
        }
        private void RemoveABadge()
        {
            bool removeBadge = true;
            while (removeBadge)
            {

                Console.Clear();
                ShowAllBadges();

                //double check if any badges listed
                var allBadges = _badgeRepo.ReadAllBadges();
                if (allBadges.Count == 0)
                {
                    removeBadge = false;
                }
                else
                {
                    PrintColorMessage(ConsoleColor.Yellow, "\n\nWhat is the badge number you would like to remove: ");
                    int userInputBadge = MakeSureUserEnteredANum();
                    var existingBadgeInfo = _badgeRepo.ReadOneBadgeByID(userInputBadge);
                    if (existingBadgeInfo == null)
                    {
                        Console.WriteLine("We are not able to find that badge number.");
                        PauseProgram();
                        return;
                    }
                    PrintColorMessage(ConsoleColor.Red, $"\nAre you sure you want to remove this badge?\nPlease confirm with Yes or No: ");
                    string userAnswer = Console.ReadLine().ToLower();
                    if (userAnswer == "yes")
                    {
                        Console.Clear();
                        _badgeRepo.ReadOneBadgeByID(userInputBadge);
                        Console.WriteLine("This badge was removed.\n" +
                            "*******************************************\n");
                    }
                    else if (userAnswer == "no")
                    {
                        Console.WriteLine($"\nBadge {userInputBadge} was not deleted.");
                        PauseProgram();
                        return;
                    }
                    else
                    {
                        return;
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    removeBadge = CheckIfUserWantsToAddMore("\nWould you like to remove another badge? [Y or N]");
                    Console.ResetColor();
                }
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
        private void PauseProgram()
        {
            Console.WriteLine("\n\nPress any key to return to Main Menu...");
            Console.ReadKey();
        }
        private void ShowAllBadges()
        {
            Console.WriteLine("A list of all Badges\n" +
               "******************************************\n");
            var allBadges = _badgeRepo.ReadAllBadges();
            if (allBadges.Count == 0)
            {
                Console.WriteLine("Currently we don't have any badges listed.");
            }
            else
            {
                Console.WriteLine($"{"Badge #",-20}{"Door Access",-35}");
                foreach (var badge in allBadges)
                {
                    Console.Write($"\n{badge.Key,-20}");
                    for (int i = 0; i < badge.Value.DoorName.Count; i++)
                    {
                        Console.Write($"{badge.Value.DoorName[i]} ");
                    }
                }

            }
        }
        private void RemoveDoor(Badge badge, int badgeInfo)
        {
            PrintColorMessage(ConsoleColor.Yellow, "\nWhich door would you like to remove: ");
            string userInputDoor = Console.ReadLine();
            _badgeRepo.DeleteDoorsFromBadge(badgeInfo, userInputDoor);
            Console.WriteLine($"\nDoor {userInputDoor} was removed.");
            Console.Write($"{badgeInfo} has access to ");
            foreach (var door in badge.DoorName)
            {
                Console.Write($"{door} ");
            }
        }
        private void AddDoor(Badge badge, int badgeInfo)
        {
            PrintColorMessage(ConsoleColor.Yellow, "\nWhich door would you like to add: ");
            string userInputDoor = Console.ReadLine();
            _badgeRepo.AddDoorToBadge(badgeInfo, userInputDoor);
            Console.WriteLine($"\nDoor {userInputDoor} was added.");
            Console.Write($"{badgeInfo} has access to ");
            foreach (var door in badge.DoorName)
            {
                Console.Write($"{door} ");
            }
        }
    }
}
