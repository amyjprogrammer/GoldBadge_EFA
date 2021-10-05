using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Repository
{
    //First and Last Name must be at least one character (stop an enter)
    public class Customer
    {
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value.Length < 1 || value.Any(x => !char.IsLetter(x)))
                    throw new FormatException("First Name must be at least one character in the alphabet with no special characters.");
                else
                    _firstName = value;
            }
        }
        private string _lastName;
        private int _iDNumber;

        public string LastName
        {
            get => _lastName;
            set
            {
                if (value.Length < 1 || value.Any(x => !char.IsLetter(x)))
                    throw new FormatException("Last Name must be at least one character in the alphabet with no special characters.");
                else
                    _lastName = value;
            }
        }
        public string FullName
        {
            get
            {
                string fullName = FirstName + " " + LastName;
                return fullName;
            }
        }
        
        public int IDNumber 
        { 
            get => _iDNumber; 
            set
            {
                if(TryParse.value)
            } 
        }

    }
}
