using System;

namespace StringMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Please get this work finished by Monday.";
            Console.WriteLine(input);

            //1. Replace
            Console.WriteLine("\n//1. Replace");
            var replace = input.Replace("Monday", "Friday");
            Console.WriteLine(replace);

            //2. Remove
            Console.WriteLine("\n//2. Remove");
            var remove = input.Remove(30);
            Console.WriteLine(remove);

            //3. Split
            Console.WriteLine("\n//3. Split");
            string[] words = input.Split(' ');
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }

            //4. Join
            Console.WriteLine("\n//4. Join");
            Console.WriteLine(string.Join("---", words));

            //5. Substring
            Console.WriteLine("\n//5. Substring");
            var substring = input.Substring(33);
            Console.WriteLine(substring);

            //6. Insert and Lenght
            Console.WriteLine("\n//6. Insert and Lenght");
            var insert = input.Insert(input.Length, " Your job depends on it.");
            Console.WriteLine(insert);

            //7. Concat and Format
            Console.WriteLine("\n//7. Concat and Format");
            var firstname = "Cosmin";
            var lastname = "Butnaru";
            var fullname = string.Concat(firstname, " ", lastname);
            Console.WriteLine($"My full name is: {fullname}");
        }
    }
}
