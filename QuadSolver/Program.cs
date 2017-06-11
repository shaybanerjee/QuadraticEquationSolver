using System;

namespace QuadSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            string wReadValue = "";
            while (true)
            {
                Console.WriteLine("Enter Expression or type 'Done' to quit: ");
                Console.WriteLine("Expression in the form: ax^2+bx+c:");
                wReadValue = Console.ReadLine();
                if (wReadValue == "Done")
                    break;
                Solver.SolveExp(wReadValue);
            }
            
        }
    }
}