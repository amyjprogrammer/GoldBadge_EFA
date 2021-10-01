using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Repository
{
   
    public class MenuRepo
    {
        //field
        protected readonly List<Menu> _menuDirectory = new List<Menu>();

        //Create
        public bool AddMealToDirectory(Menu menuContent)
        {
            int startingCount = _menuDirectory.Count;

            _menuDirectory.Add(menuContent);

            bool wasAddedToMenu = (_menuDirectory.Count > startingCount) ? true : false;
            return wasAddedToMenu;
        }

        //Read
        public List<Menu> GetAllMenuItems()
        {
            return _menuDirectory;
        }
        public Menu GetOneMenuItemByMealNum(int mealNum)
        {
            foreach (Menu menuContent in _menuDirectory)
            {
                if(menuContent.MealNumber == mealNum)
                {
                    return menuContent;
                }
            }
            return null;
        }

        //Delete
        public bool DeleteMenutItem(Menu existingMenu)
        {
            bool result = _menuDirectory.Remove(existingMenu);
            return result;
        }
    }
}
