using System;
using System.Globalization;

namespace Retirement
{
    public class Person
    {
        private int age;
        private Gender gender;

        public enum Gender
        {
            Female,
            Male
        }
        public void RetirementCheck()
        {
            //Gender Determination
            do
            {
                Console.WriteLine("Please enter your gender(f for female / m for male)");
                var input = Console.ReadKey();

                if (input.Key == ConsoleKey.M)
                {
                    gender = Gender.Male;
                    break;
                }
                else if (input.Key == ConsoleKey.F)
                {
                    gender = Gender.Female;
                    break;
                }
                else
                {
                    Console.WriteLine("\nPlease try again");
                    continue;
                }

            } while (true);

            // Age Determination
            DateTime birthDay = new DateTime();
            CultureInfo provider = CultureInfo.InvariantCulture;

            do
            {
                Console.WriteLine("\nEnter your Birthdate(DD/MM/YYYY)");
                string value = Console.ReadLine();
                string format = "dd/MM/yyyy";               

                try
                {
                    birthDay = DateTime.ParseExact(value, format, provider);
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} is not in the correct format.", value);
                    continue;
                }

                if (birthDay > DateTime.Today)
                {
                    Console.WriteLine("Invalid option. Try again!");
                    continue;
                }
                else
                {
                    age = DateTime.Now.Year - birthDay.Year;

                    if ((birthDay.Month > DateTime.Now.Month) || (birthDay.Month == DateTime.Now.Month && birthDay.Day > DateTime.Now.Day))
                        age--;

                    break;
                }
            } while (true);

            //Retirement check
            const int maleRetirementAge = 65;
            const int femaleRetirementAge = 63;

            if ((gender == Gender.Male) && (age >= maleRetirementAge) || (gender == Gender.Female) && (age >= femaleRetirementAge))
            {
                Console.WriteLine("You are retired.");
            }
            else if ((gender == Gender.Female) && (age < femaleRetirementAge))
            {
                Console.WriteLine($"You are {age} years old.");
                Console.WriteLine($"You will retire at age {femaleRetirementAge}");
            }
            else if ((gender == Gender.Male) && (age < maleRetirementAge))
            {
                Console.WriteLine($"You are {age} years old.");
                Console.WriteLine($"You will retire at age {maleRetirementAge}");
            }
        }
    }
}
