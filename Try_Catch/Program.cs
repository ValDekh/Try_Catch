using System;
using System.Globalization;

namespace Try_Catch
{
  
    
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person p = new Person {Name = "Tom", Age = 17};
            }
            catch (PersonalException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"Некорректное значение: {ex.Value} ");
            }
           
        }
    }

    class PersonalException : ArgumentException
    {
        public int Value { get; }

        public PersonalException(string message, int val) : base(message)
        {
            Value = val;
        }
    }

    class Person
    {
        private int age;
        public string Name { get; set; }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 18)
                {
                    throw new PersonalException("Нету 18", value);
                }
                else
                {
                    age = value;
                }
            }
        }
    }
}