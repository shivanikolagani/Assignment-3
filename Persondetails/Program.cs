
using DocumentFormat.OpenXml.Office2019.Excel.ThreadedComments;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Persondetails
{
    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }

        public Person(string name, string address, int age)
        {
            Name = name;
            Address = address;
            Age = age;
        }
    }

    public class PersonImplementation
    {
        public string GetName(IList<Person> person)
        {
            string result = "";
            foreach (Person p in person)
            {
                result += $"{p.Name} {p.Address} ";
            }
            return result.Trim();
        }

        public double Average(IList<Person> person)
        {
            int totalAge = 0;
            foreach (Person p in person)
            {
                totalAge += p.Age;
            }
            return (double)totalAge / person.Count;
        }

        public int Max(IList<Person> person)
        {
            int maxAge = person[0].Age;
            foreach (Person p in person)
            {
                if (p.Age > maxAge)
                {
                    maxAge = p.Age;
                }
            }
            return maxAge;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            IList<Person> person = new List<Person>()
        {
            new Person("Aarya", "A2101", 69),
            new Person("Daniel", "D104", 40),
            new Person("Ira", "H801", 25),
            new Person("Jennifer", "11704", 33),
        };

            PersonImplementation personImplementation = new PersonImplementation();

            Console.WriteLine(personImplementation.GetName(person));
            Console.WriteLine(personImplementation.Average(person));
            Console.WriteLine(personImplementation.Max(person));
        }
    }
}



