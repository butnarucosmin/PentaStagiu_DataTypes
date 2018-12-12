using System;

namespace Retirement
{
    public class Person
    {
        private
            int age;
            int? gender = null;
        public enum Gender
        {
            Female,
            Male
        }
        public void RetirementCheck()
        {
            //Gender Determination
        START:
            Console.WriteLine("Please enter your gender(f for female / m for male)");
            var input = Console.ReadLine();
            if (input == "m")
            {
                gender = (int?) Gender.Male;
            }
            else if (input == "f")
            {
                gender = (int?) Gender.Female;
            }
            else
            {
                Console.WriteLine("Please try again");
                goto START;
            }

            // Age Determination
            DateTime dob = new DateTime();
            DateTime present = DateTime.Now;
            Console.WriteLine("Please enter your date of birth");
        DAY:
            Console.WriteLine("Day:");
            if (int.TryParse(Console.ReadLine(), out int day))
            {
                if(day <= 31 && day >= 1)
                {
                    goto MONTH;
                }
                else
                {
                    Console.WriteLine("Please enter a number between 1 and 31");
                    goto DAY;
                }
            }
            else
            {
                Console.WriteLine("Please enter a number between 1 and 31");
                goto DAY;
            }
        MONTH:
            Console.WriteLine("Month:");            
            if (int.TryParse(Console.ReadLine(), out int month))
            {
                if (month <= 12 && month >= 1)
                {
                    goto YEAR;
                }
                else
                {
                    Console.WriteLine("Please enter a number between 1 and 12");
                    goto MONTH;
                }
            }
            else
            {
                Console.WriteLine("Please enter a number between 1 and 12");
                goto MONTH;
            }
        YEAR:
            Console.WriteLine("Year:");
            if (int.TryParse(Console.ReadLine(), out int year))
            {
                dob = new DateTime(year, month, day);
                age = Convert.ToInt32(present.Subtract(dob).TotalDays / 365.2422);
                Console.WriteLine($"You are {age} years old.");
            }
            else
            {
                Console.WriteLine("Please enter a number");
                goto YEAR;
            }

            //Retirement check
            if ((age >= 65) || (age >= 63))
            {
                Console.WriteLine("You are retired.");
            }
            else if (gender == 0)
            {
                Console.WriteLine("You will retire at age 63");
            }
            else if (gender == 1)
            {
                Console.WriteLine("You will retire at age 65");
            }
        }
    }
}
