using Menu_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Menu_Repository_Tests
{
    [TestClass]
    public class MenuTests
    {
        [TestMethod]
        public void SetMealNumber_ShouldGetCorrectNum()
        {
            //Arrange
            var content = new Menu();

            //Act
            content.MealNumber = 1;

            //Assert
            int expected = 1;
            int actual = content.MealNumber;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetMealName_ShouldSetCorrectString()
        {
            var content = new Menu();

            content.MealName = "Happy Meal";

            string expected = "Happy Meal";
            string actual = content.MealName;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetMealDescription_ShouldSetCorrectString()
        {
            var content = new Menu();

            content.MealDescription = "Yummy";

            string expected = "Yummy";
            string actual = content.MealDescription;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetMealIngredients_ShouldReturnCorrectList()
        {
            var content = new Menu();
            List<string> ingredients = new List<string>();
            ingredients.Add("Hamburger");

            content.MealIngredients = ingredients;

            List<string> expected = ingredients;
            List<string> actual = content.MealIngredients;

            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetMealPrice_ShouldReturnCorrectPrice()
        {
            var content = new Menu();

            content.MealPrice = 5.99;

            double expected = 5.99;
            double actual = content.MealPrice;

            Assert.AreEqual(expected, actual);
        }
    }
}
