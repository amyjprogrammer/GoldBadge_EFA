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
            MenuRepo _menuRepo = new MenuRepo();

            bool success = _menuRepo.AddMealToDirectory(menuContent);

            Assert.IsTrue(success);
        }

        [TestMethod]
        public void GetAllMenuItems_ShouldReturnCorrectCollectList()
        {
            List<string> ingredients = new List<string>();
            ingredients.Add("Hamburger");

            Menu happyMeal = new Menu(1, "Happy Meal", "Yummy", ingredients, 4.99);
            MenuRepo _menuRepo = new MenuRepo();

            _menuRepo.AddMealToDirectory(happyMeal);

            List<Menu> menuList = _menuRepo.GetAllMenuItems();
            bool success = menuList.Contains(happyMeal);

            Assert.IsTrue(success);
        }
        [TestMethod]
        public void GetOneMenuItemByMealNum_ShouldReturnCorrectContent()
        {
            List<string> ingredients = new List<string>();
            ingredients.Add("Hamburger");

            Menu happyMeal = new Menu(1, "Happy Meal", "Yummy", ingredients, 4.99);
            MenuRepo _menuRepo = new MenuRepo();

            _menuRepo.AddMealToDirectory(happyMeal);

            Menu searchResult = _menuRepo.GetOneMenuItemByMealNum(1);

            Assert.AreEqual(happyMeal.MealName, searchResult.MealName);
        }
        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {
            List<string> ingredients = new List<string>();
            ingredients.Add("Hamburger");

            Menu happyMeal = new Menu(1, "Happy Meal", "Yummy", ingredients, 4.99);
            MenuRepo _menuRepo = new MenuRepo();

            _menuRepo.AddMealToDirectory(happyMeal);

            Menu mealToDelete = _menuRepo.GetOneMenuItemByMealNum(1);

            bool removeResult = _menuRepo.DeleteMenutItem(mealToDelete);

            Assert.IsTrue(removeResult);
        }
    }
}
