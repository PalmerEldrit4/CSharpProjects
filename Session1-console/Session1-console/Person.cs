using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session1_console
{
    class Person
    {
        public Person(string name, int age, string city)
        {
            Name = name;
            Age = age;
            City = city;
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length < 2 || value.Length > 100)
                {
                    throw new ArgumentException("Name must be between 2 and 100 characters");
                }
                _name = value;
            }
        }

        private int _age;
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < 0 || value > 180)
                {
                    throw new ArgumentException("The age needs to be between 1 and 180");
                }
                _age = value;
            }
        }

        private string _city;
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                if (value.Length < 2 || value.Length > 100)
                {
                    throw new ArgumentException("City must be between 2 and 100 characters");
                }
                _city = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} is {1} y/o and lives in {2}", Name, Age, City);
        }
    }
}
