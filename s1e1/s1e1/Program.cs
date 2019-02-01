﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace s1e1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Current date (year/month/day): " + DateTime.Now.ToString("yyyy/MM/dd"));
            Console.WriteLine("Number of days elapsed since start of the year: " + DateTime.Now.DayOfYear);
            var year = DateTime.Now.Year;
            while (year<DateTime.MaxValue.Year)
            {
                year++;
                if (DateTime.IsLeapYear(year) && new DateTime(year, 01, 01).DayOfWeek.Equals(DayOfWeek.Tuesday))
                {
                    Console.WriteLine("Next leap year that starts with a Tuesday: " + year);
                    break;
                }
            }

            //email validation - using System.Net.Mail for this because regex stuff looks too scarry
            Console.WriteLine("Please enter e-mail address");
            try
            {
                MailAddress m = new MailAddress(Console.ReadLine());
                Console.WriteLine("Email address is valid");
            }
            catch
            {
                Console.WriteLine("Entered value is not a valid email address");
            }

            //general error in case of user-input shenaniganz, no time to consider all the weird options
            Console.WriteLine("Enter space-separated numbers to calculate total sum (e.g. 1 34.5 -100)");
            try
            {
                List<double> numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
                Console.WriteLine("Sum: " + numbers.Sum());
            }
            catch
            {
                Console.WriteLine("Invalid data was entered");
            }
            Console.WriteLine("Press ENTER to exit the app");
            Console.ReadLine();
        }
    }
}
