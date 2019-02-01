using System;

namespace Retirement
{
    public class Person
    {
        private
            int age;
        Gender gender;

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
                gender = Gender.Male;
            }
            else if (input == "f")
            {
                gender = Gender.Female;
            }
            else
            {
                Console.WriteLine("Please try again");
                goto START;
            }

            // Age Determination
            DateTime dateOfBirth = new DateTime();
            DateTime present = DateTime.Now;
            Console.WriteLine("Please enter your date of birth");
        DAY:
            Console.WriteLine("Day:");
            if (int.TryParse(Console.ReadLine(), out int day))
            {
                if (day <= 31 && day >= 1)
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
                dateOfBirth = new DateTime(year, month, day);
                age = present.Year - dateOfBirth.Year;

                if (present.Month < dateOfBirth.Month || (present.Month == dateOfBirth.Month && present.Day < dateOfBirth.Day))
                    age--;
                Console.WriteLine($"You are {age} years old.");
            }
            else
            {
                Console.WriteLine("Please enter a number");
                goto YEAR;
            }

            //Retirement check
            const int maleRetirementAge = 65;
            const int femaleRetirementAge = 63;

            if ((gender == Gender.Male) && (age >= maleRetirementAge) || (gender == Gender.Female) && (age >= femaleRetirementAge))
            {
                Console.WriteLine("You are retired.");
            }
            else if ((gender == Gender.Female) && (age < femaleRetirementAge))
            {
                Console.WriteLine($"You will retire at age {femaleRetirementAge}");
            }
            else if ((gender == Gender.Male) && (age < maleRetirementAge))
            {
                Console.WriteLine($"You will retire at age {maleRetirementAge}");
            }
        }
    }
}
