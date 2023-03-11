using System;
using System.IO;
using System.Text;

namespace RunwithMe
{
    internal class Program
    {
        public string AddTimestamp()
        {
            return " - " + DateTime.Now;
        }

        static void Main(string[] args)
        {
            var responseDidTheyRun = new Char();
            var run = new Run();
            var errorloggingpath = "/Users/DulceAlvarado/Desktop/Log.txt";

            try
            {
                Console.WriteLine("Welcome to RunwithMe!");
                Console.WriteLine("\tDid you run today? Y/N");
                responseDidTheyRun = Console.ReadKey().KeyChar;
                
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                File.AppendAllText(errorloggingpath, e.Message);
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
                File.AppendAllText(errorloggingpath, "User entered a " + responseDidTheyRun + ", was an invalid character");
                return;
            }

            if (run.Ran == false) { return; }

            Console.WriteLine("Since you ran, how far did you run? Enter distance in miles");
            var responseHowFarRan = Console.ReadLine();
            if (decimal.TryParse(responseHowFarRan, out decimal howFarRan))
            {
                Console.WriteLine("You entered an invalid option, logging error and quitting");
                File.AppendAllText(errorloggingpath, "User entered a" + responseHowFarRan + ", was an invalid character");
                return;
            }
            run.Distance = howFarRan;

            int miles = 1;
            while (miles <= 5)
            {
                Console.WriteLine(miles);
                miles++;
                if (miles > 5)
                    break;
            }

            Console.WriteLine("How long did it take you to run?");
            if (!TimeSpan.TryParse(Console.ReadLine(), out TimeSpan HowLongRan))
            {
                Console.WriteLine("You entered an invalid option, logging error and quitting");
                File.AppendAllText(errorloggingpath, "User entered a" + HowLongRan + ", was an invalid character");
                return;
            
            run.Duration = HowLongRan;

            Console.WriteLine("Ran: = + run.Ran");
            Console.WriteLine("Distance:" + run.Distance);
            Console.WriteLine("Duration:" + run.Duration);

        }
        


