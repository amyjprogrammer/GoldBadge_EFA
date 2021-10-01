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
                        // Show all Menu Items;
                        break;
                    case "2":
                        //Add Menu Items;
                        break;
                    case "3":
                        //delete menu items;
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
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Please enter a number: ");
                    Console.ResetColor();
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
                var index = 1;
                foreach (Menu menuItemContent in listOfAllMenuItems)
                {
                    Console.WriteLine($"{index}. Menu Item: {menuItemContent.MealName}- Meal Number: {menuItemContent.MealNumber}");
                    index++;
                }
            }
        }
    }
}
