using Menu_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Menu_Console
{
    public class MenuUI
    {
        private MenuRepo _menuRepo = new MenuRepo();
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
                            "Welcome to the Komodo Cafe Menu Application\n" +
                            "****************************************************************\n\n" +
                            "1. Show all Menu Items\n" +
                            "2. Add Menu Items\n" +
                            "3. Delete Menu Items\n" +
                            "4. Exit"
                        );
                PrintColorMessage(ConsoleColor.DarkCyan, "\nPlease enter the number of your selection: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        SeeAllMenuItems();
                        break;
                    case "2":
                        AddMenuItem();
                        break;
                    case "3":
                        DeleteMenuItem();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        PrintColorMessage(ConsoleColor.DarkMagenta, "\nPlease enter a valid number between 1-4.\n");
                        Thread.Sleep(2000);
                        break;
                }
            }
        }
        public void AddMenuItem()
        {

            bool addNewMenuItem = true;
            while (addNewMenuItem)
            {
                Console.Clear();

                //newing up the Menu
                Menu menu = new Menu();
                Console.WriteLine("Information for the New Menu Item\n" +
                        "********************************************\n\n");
                PrintColorMessage(ConsoleColor.Yellow, "Please enter the new name: ");
                menu.MealName = Console.ReadLine();
                PrintColorMessage(ConsoleColor.Yellow, "\nPlease enter the meal number: ");

                //Making sure user enter a unique number
                bool checkUserGaveWrongNum = true;
                while (checkUserGaveWrongNum)
                {
                    int userInputForNewMenuItem = MakeSureUserEnteredANum();
                    bool verifyIfUniqueMenuNum = MakeSureGaveUniqueId(userInputForNewMenuItem);
                    if (verifyIfUniqueMenuNum == true)
                    {
                        checkUserGaveWrongNum = false;
                    }
                    else
                    {
                        PrintColorMessage(ConsoleColor.Blue, "The Menu Item number must be unique. \n" +
                            "Please enter another number: ");
                    }
                    menu.MealNumber = userInputForNewMenuItem;
                }

                PrintColorMessage(ConsoleColor.Yellow, "\nPlease enter the description: ");
                menu.MealDescription = Console.ReadLine();

                List<string> listOfIngredients = new List<string>();
                //added the option to add all the Ingredients at once
                /*bool addIngredients = true;
                while (addIngredients)
                {
                    PrintColorMessage(ConsoleColor.Yellow, "\nPlease enter an ingredient for this menu item: ");
                    string ingredient = Console.ReadLine();
                    listOfIngredients.Add(ingredient);
                    menu.MealIngredients = listOfIngredients;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    addIngredients = CheckIfUserWantsToAddMore("\nWould you like to add more ingredients? [Y or N]: ");
                    Console.ResetColor();
                }*/

                Console.WriteLine("\nPlease enter your ingredients by adding a coma like burger,fries,soda.");
                PrintColorMessage(ConsoleColor.Yellow, "Ingredient list: ");
                string splitList = Console.ReadLine();
                listOfIngredients = splitList.Split(',').ToList();
                menu.MealIngredients = listOfIngredients;

                PrintColorMessage(ConsoleColor.Yellow, "\nPlease enter the price: ");
                double userInputForNewPrice = MakeSureUserEnteredADoubleNum();
                menu.MealPrice = userInputForNewPrice;

                _menuRepo.AddMealToDirectory(menu);
                Console.Clear();
                Console.WriteLine("This Menu Item was added.\n" +
                    "********************************************\n\n");
                DisplayOneMenuItem(menu);
                Console.ForegroundColor = ConsoleColor.Yellow;
                addNewMenuItem = CheckIfUserWantsToAddMore("\nWould you like to add another menu item? [Y or N]: ");
                Console.ResetColor();
            }
            PauseProgram();
        }
        public void SeeAllMenuItems()
        {
            Console.Clear();
            Console.WriteLine("A list of all the Menu Items\n" +
              "******************************************\n");
            List<Menu> listOfAllMenuItems = _menuRepo.GetAllMenuItems();
            if (listOfAllMenuItems.Count == 0)
            {
                Console.WriteLine("Currently we don't have any Menu Items listed.");
            }
            else
            {
                Console.WriteLine($"{"Meal Name",-30} {"Meal Number",-15} {"Meal Price",-15} {"Meal Description",-30} ");
                var index = 1;
                foreach (Menu menuItemContent in listOfAllMenuItems)
                {
                    Console.WriteLine($"{index}. {menuItemContent.MealName,-30} {menuItemContent.MealNumber,-15} {menuItemContent.MealPrice,-15} {menuItemContent.MealDescription,-30}");
                    index++;
                }
                PrintColorMessage(ConsoleColor.Yellow, "\nWould you like to see the Menu Ingredients for one of the Meals? [Y or N]: ");
                string userAnswer = Console.ReadLine().ToUpper();
                if (userAnswer == "Y")
                {
                    PrintColorMessage(ConsoleColor.Yellow, "\nWhat Meal Number would you like to look at?: ");
                    int mealNum = MakeSureUserEnteredANum();
                    Menu menuItem = _menuRepo.GetOneMenuItemByMealNum(mealNum);
                    if (menuItem == null)
                    {
                        PrintColorMessage(ConsoleColor.DarkBlue, "\nWe are not able to find that Meal Number.");
                        PauseProgram();
                        return;
                    }
                    Console.Clear();
                    Console.WriteLine($"********************************************\n" +
                        $"Ingredients for {menuItem.MealName}\n");
                    var indexNum = 1;
                    for (int i = 0; i < menuItem.MealIngredients.Count; i++)
                    {
                        Console.WriteLine($"{indexNum}. {menuItem.MealIngredients[i]}");
                        indexNum++;
                    }
                }
                else
                {
                    return;
                }
            }
            PauseProgram();
        }
        public void DeleteMenuItem()
        {
            bool removeMenuItem = true;
            while (removeMenuItem)
            {
                Console.Clear();
                DisplayAllMenuItems();
                //Double check if any items to remove
                List<Menu> listOfAllMenuItems = _menuRepo.GetAllMenuItems();
                if (listOfAllMenuItems.Count == 0)
                {
                    removeMenuItem = false;
                }
                else
                {
                    PrintColorMessage(ConsoleColor.Yellow, "\nPlease enter the Meal Number you would like to remove: ");

                    //Making sure user enters a number
                    int userNumInput = MakeSureUserEnteredANum();
                    Menu existingMenuItems = _menuRepo.GetOneMenuItemByMealNum(userNumInput);
                    if (existingMenuItems == null)
                    {
                        PrintColorMessage(ConsoleColor.DarkBlue, "\nWe are not able to find that Meal Number.");
                        PauseProgram();
                        return;
                    }
                    PrintColorMessage(ConsoleColor.Red, $"\nAre you sure you want to delete {existingMenuItems.MealName}?\n");
                    PrintColorMessage(ConsoleColor.Yellow, "Please confirm with Yes or No: ");
                    string userAnswer = Console.ReadLine().ToUpper();
                    if (userAnswer == "YES")
                    {
                        Console.Clear();
                        _menuRepo.DeleteMenutItem(existingMenuItems);
                        Console.WriteLine("This menu item was removed.\n" +
                                "*******************************************\n");
                        DisplayOneMenuItem(existingMenuItems);
                        PauseProgram();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"*****************************************\n\n" +
                            $"{existingMenuItems.MealName} was not deleted.");
                        PauseProgram();
                        return;
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    removeMenuItem = CheckIfUserWantsToAddMore("\nWould you like to remove another Menu Item? [Y or N]: ");
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
        private bool MakeSureGaveUniqueId(int uniqueId)
        {
            Menu checkUniqueId = _menuRepo.GetOneMenuItemByMealNum(uniqueId);
            if (checkUniqueId != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void DisplayAllMenuItems()
        {
            Console.WriteLine("A list of all the Menu Items\n" +
              "******************************************\n");
            List<Menu> listOfAllMenuItems = _menuRepo.GetAllMenuItems();
            if (listOfAllMenuItems.Count == 0)
            {
                Console.WriteLine("Currently we don't have any Menu Items listed.");
            }
            else
            {
                Console.WriteLine($"{"Meal Name",-30} {"Meal Number",-15} {"Meal Price",-15} {"Meal Description",-30} ");
                var index = 1;
                foreach (Menu menuItemContent in listOfAllMenuItems)
                {
                    Console.WriteLine($"{index}. {menuItemContent.MealName,-30} {menuItemContent.MealNumber,-15} {menuItemContent.MealPrice,-15} {menuItemContent.MealDescription,-30}");
                    index++;
                }
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
        private void DisplayOneMenuItem(Menu menuInfo)
        {
            Console.WriteLine($"Menu Name: {menuInfo.MealName} - Menu Number: {menuInfo.MealNumber}");
        }
        private void PauseProgram()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
