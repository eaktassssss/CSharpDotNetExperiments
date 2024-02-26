using DotNetInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DotNetInterfaces
{
    public class Person : IComparable<Person>, ICloneable , IEquatable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public static List<Person> All()
        {
            List<Person> persons = new List<Person>
        {
            new Person("Alice", 30),
            new Person("Bob", 25),
            new Person("Charlie", 35)
        };

            return persons;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public int CompareTo(Person? other)
        {
            return other.Age.CompareTo(Age);
        }
        public bool Equals(Person? other)
        {
            if (other is null)
                return false;
            else
                return Name == other.Name && Age == other.Age;
        }
    }
}
