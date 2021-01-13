using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session1_console
{
    class Program
    {
        static List<Person> people = new List<Person>();
        const string DatafileName = @"..\..\people.txt";
        static void Main(string[] args)
        {
            //an example of generic classes
            //GenericClass<bool> genericClass = new GenericClass<bool>();
            //genericClass.Data = false;
            if (LoadFromFile())
            {
                while (true)
                {
                    int choice = GetMenuChoices();
                    switch (choice)
                    {
                        case 1:
                            //you need to ask user to enter the information
                            Console.WriteLine("Please enter the name");
                            string name = Console.ReadLine();
                            Console.WriteLine("Please enter the age");
                            string ageStr = Console.ReadLine();
                            int age;
                            if (!int.TryParse(ageStr, out age))
                            {
                                Console.WriteLine("Please enter a number for age");
                                return;
                            }
                            Console.WriteLine("Please enter the city");
                            string city = Console.ReadLine();
                            //try
                            //{
                            //    Person person = new Person(name, age, city);
                            //    AddPersonInfo(person);
                            //}
                            //catch (ArgumentException exc)
                            //{
                            //    Console.WriteLine("Pleaes enter the values correctly");
                            //    Console.WriteLine(exc.Message);
                            //}
                            Person person = new Person(name, age, city);
                            AddPersonInfo(person);


                            break;
                        case 2:
                            ListAllPersonsInfo();
                            break;
                        case 3:
                            //ask user to give the name
                            Console.WriteLine("Please enter a name");
                            string searchName = Console.ReadLine();
                            Console.WriteLine(FindPersonByName(searchName));
                            break;
                        case 4:
                            Console.WriteLine("Please enter a number for age");
                            string searchAgeText = Console.ReadLine();
                            int searchAge;
                            if (!int.TryParse(searchAgeText, out searchAge))
                            {
                                Console.WriteLine("the age is not correct");
                                return;
                            }
                            List<Person> peopleFound = FindPersonYoungerThan(searchAge);
                            foreach (Person p in peopleFound)
                            {
                                Console.WriteLine(p);
                            }
                            break;
                        case 0:
                            SaveToFile(people);
                            return;
                        default:
                            Console.WriteLine("invalid Number");
                            break;
                    }
                }

            }

            Console.ReadLine();

        }

        private static void AddPersonInfo(Person person)
        {
            people.Add(person);
            Console.WriteLine("the person is added");
        }

        private static void ListAllPersonsInfo()
        {
            foreach (Person p in people)
            {
                Console.WriteLine(p);
            }
        }

        private static string FindPersonByName(string name)
        {
            //we know the people are in the List<Person> NO LINQ
            foreach (Person person in people)
            {
                if (person.Name.Contains(name))
                {
                    return $"the person is found {person.Name}";
                }
            }
            return $"{name} is not found";
        }

        private static List<Person> FindPersonYoungerThan(int age)
        {
            List<Person> foundPeople = new List<Person>();
            foreach (Person person in people)
            {
                if (person.Age < age)
                {
                    foundPeople.Add(person);
                }
            }

            return foundPeople;
        }


        private static bool LoadFromFile()
        {
            try
            {
                using (var sr = new StreamReader(DatafileName))
                {
                    // Read the stream as a string, and write the string to the console.
                    string personLine;
                    while ((personLine = sr.ReadLine()) != null)
                    {
                        string[] parameters = personLine.Split(';');
                        int age;
                        if (!int.TryParse(parameters[1], out age))
                        {
                            Console.WriteLine("a problem happened");
                            return false;
                        }
                        //Person p = new Person(parameters[0], age, parameters[2]);
                        people.Add(new Person(parameters[0], age, parameters[2]));
                    }
                }

            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }

            return true;
        }

        private static void SaveToFile(List<Person> listPeople)
        {
            using (StreamWriter outputFile = new StreamWriter(DatafileName))
            {
                foreach (Person person in listPeople)
                {
                    //outputFile.WriteLine(person.Name+";"+person.Age+";"+person.City);
                    //interpolated string 
                    outputFile.WriteLine($"{person.Name};{person.Age};{person.City}");
                }
            }


        }

        private static int GetMenuChoices()
        {
            while (true)
            {
                Console.Write(
@"1- Add Person Info
2-List persons info
3-Find a person by name
4-Find all persons younger than age
0-Exit          
");
                string ChoiceStr = Console.ReadLine();
                int choice;
                if (!int.TryParse(ChoiceStr, out choice))
                {
                    Console.WriteLine("Value must be a number between 0 to 4 ");
                    continue;
                }
                return choice;
            }
        }
    }
}
