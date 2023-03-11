using System;
using System.IO;
using System.Text;

namespace RunwithMe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var responseDidTheyRun = new Char();
            var run = new Run();

            try
            {
                Console.WriteLine("Welcome to RunwithMe!");
                Console.WriteLine("\tDid you run today? Y/N");
                responseDidTheyRun = Console.ReadKey().KeyChar;
                
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            
            if (responseDidTheyRun == 'y')
            {
                run.Ran = true;
                Console.WriteLine("Thanks for running!");
            }
            else if (responseDidTheyRun == 'n')
            {
                run.Ran = false;
                Console.WriteLine("You should run more.");
            }
            else
            {
                Console.WriteLine("You entered an invalid option, logging error and quitting");
                return;
            }

            if (run.Ran == false) { return; }

            Console.WriteLine("Since you ran, how far did you run? Enter distance in miles");
            var responseHowFarRan = Console.ReadLine();
            if (decimal.TryParse(responseHowFarRan, out decimal howFarRan))
            {
                Console.WriteLine("You entered an invalid option, logging error and quitting");
                return;
            }
            run.Distance = howFarRan;

            Console.WriteLine("How long did it take you to run?");
            if (!TimeSpan.TryParse(Console.ReadLine(), out TimeSpan HowLongRan))
            {
                Console.WriteLine("You entered an invalid option, logging error and quitting");
                return;
            }
            run.Duration = HowLongRan;

            Console.WriteLine("Ran: = + run.Ran");
            Console.WriteLine("Distance:" + run.Distance);
            Console.WriteLine("Duration:" + run.Duration);

        }
    }
}
