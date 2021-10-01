using Menu_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Menu_Repository_Tests
{
    [TestClass]
    public class MenuRepoTest
    {
        [TestMethod]
        public void AddToMealDirectory_ShouldGetCorrectBoolean()
        {
            Menu menuContent = new Menu();
            MenuRepo menuRepo = new MenuRepo();

            bool success = menuRepo.AddMealToDirectory(menuContent);

            Assert.IsTrue(success);
        }

        [TestMethod]
        public void GetAllMenuItems_ShouldReturnCorrectCollectList()
        {
            List<string> ingredients = new List<string>();
            ingredients.Add("Hamburger");

            Menu happyMeal = new Menu(1, "Happy Meal", "Yummy", ingredients, 4.99);
            MenuRepo menuRepo = new MenuRepo();

            menuRepo.AddMealToDirectory(happyMeal);

            List<Menu> menuList = menuRepo.GetAllMenuItems();
            bool success = menuList.Contains(happyMeal);

            Assert.IsTrue(success);
        }
        [TestMethod]
        public void GetOneMenuItemByMealNum_ShouldReturnCorrectContent()
        {
            List<string> ingredients = new List<string>();
            ingredients.Add("Hamburger");

            Menu happyMeal = new Menu(1, "Happy Meal", "Yummy", ingredients, 4.99);
            MenuRepo menuRepo = new MenuRepo();

            menuRepo.AddMealToDirectory(happyMeal);

            Menu searchResult = menuRepo.GetOneMenuItemByMealNum(1);

            Assert.AreEqual(happyMeal.MealName, searchResult.MealName);
        }
        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {
            List<string> ingredients = new List<string>();
            ingredients.Add("Hamburger");

            Menu happyMeal = new Menu(1, "Happy Meal", "Yummy", ingredients, 4.99);
            MenuRepo menuRepo = new MenuRepo();

            menuRepo.AddMealToDirectory(happyMeal);

            Menu mealToDelete = menuRepo.GetOneMenuItemByMealNum(1);

            bool removeResult = menuRepo.DeleteMenutItem(mealToDelete);

            Assert.IsTrue(removeResult);
        }
    }
}
