using System;
using System.Collections.Generic;

namespace E05_Calculadora_v04
{
    class Calculadora
    {
        /*
         * V4.3
         * **********
         * - Collection used to menu construction
         * - Added try...catch to handle exceptions
         * 
         * v4.4
         * **********
         * - Remake of calculation method to use a dictionary
         */

        #region Variables
        public static string ver = "v4.3";


        #endregion

        #region Properties
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public string Operand { get; set; }
        public double Result { get; set; }
        #endregion

        #region Constructors
        // Clear Constructor
        public Calculadora()
        {
            FirstNumber = 0;
            SecondNumber = 0;
            Operand = "";
            Result = 0;
        }
        // 2 values

        public Calculadora(double a, double b)
        {
            FirstNumber = a;
            SecondNumber = b;
            Operand = "";
            Result = 0;
        }
        // 2 values plus operand

        public Calculadora(double a, double b, string c)
        {
            FirstNumber = a;
            SecondNumber = b;
            Operand = c;
            Result = 0;
        }

        #endregion

        #region Methods
        // Complete
        public static void WriteMenu(bool keyCheck)
        {
            Queue<string> operInvalid = new Queue<string>();

            operInvalid.Enqueue(new string('*', 40));
            operInvalid.Enqueue($"* MENU * Calculator {Calculadora.ver}");
            operInvalid.Enqueue(new string('*', 40));
            operInvalid.Enqueue("* Please insert a valid option");
            operInvalid.Enqueue(new string('*', 40));
            operInvalid.Enqueue("* (+) ADDITION");
            operInvalid.Enqueue("* (-) SUBTRACTION");
            operInvalid.Enqueue("* (*) MULTIPLICATION");
            operInvalid.Enqueue("* (/) DIVISION");
            operInvalid.Enqueue(new string('*', 40));
            operInvalid.Enqueue("* (X) EXIT");
            operInvalid.Enqueue(new string('*', 40));

            Queue<string> operValid = new Queue<string>();

            operValid.Enqueue(new string('*', 40));
            operValid.Enqueue($"* MENU * Calculator {Calculadora.ver}");
            operValid.Enqueue(new string('*', 40));
            operValid.Enqueue("* (+) ADDITION");
            operValid.Enqueue("* (-) SUBTRACTION");
            operValid.Enqueue("* (*) MULTIPLICATION");
            operValid.Enqueue("* (/) DIVISION");
            operValid.Enqueue(new string('*', 40));
            operValid.Enqueue("* (X) EXIT");
            operValid.Enqueue(new string('*', 40));

            if (keyCheck)
            {
                foreach (string item in operValid)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                foreach (string item in operInvalid)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public static bool KeyCheck(string c)
        {
            if (c == "+" || c == "-" || c == "*" || c == "/")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static double ReadFirstValue()
        {
            try
            {
                Console.Write("Write the first number: ");
                double fst = Convert.ToDouble(Console.ReadLine());
                return fst;
            }
            catch (FormatException)
            {
                Console.WriteLine("Please insert a valid number!");
                Console.WriteLine("Press enter to continue...");
                Console.WriteLine();
                Console.ReadKey();
                return ReadFirstValue();
            }
        }

        public static double ReadSndValue()
        {
            try
            {
                Console.Write("Write the second number: ");
                double snd = Convert.ToDouble(Console.ReadLine());
                return snd;
            }
            catch (FormatException)
            {
                Console.WriteLine("Please insert a valid number!");
                Console.WriteLine("Press enter to continue...");
                Console.WriteLine();
                Console.ReadKey();
                return ReadSndValue();
            }
        }

        public static double GetResult(Calculadora c)
        {
            double res = 0;

            Dictionary<string, double> options = new Dictionary<string, double>()
            {
                {"+", (c.FirstNumber + c.SecondNumber) },
                {"-", (c.FirstNumber - c.SecondNumber) },
                {"*", (c.FirstNumber * c.SecondNumber) },
                {"/", (c.FirstNumber / c.SecondNumber) }
            };

            res = options[c.Operand];

            return res;
        }

        public static void PrintResult(Calculadora c)
        {
            Console.Clear();
            Console.WriteLine($"{c.FirstNumber} {c.Operand} {c.SecondNumber} = {c.Result}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        #endregion
    }
}
