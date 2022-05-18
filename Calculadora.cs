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
            operInvalid.Enqueue("* (1) ADDITION");
            operInvalid.Enqueue("* (2) SUBTRACTION");
            operInvalid.Enqueue("* (3) MULTIPLICATION");
            operInvalid.Enqueue("* (4) DIVISION");
            operInvalid.Enqueue(new string('*', 40));
            operInvalid.Enqueue("* (X) EXIT");
            operInvalid.Enqueue(new string('*', 40));

            Queue<string> operValid = new Queue<string>();

            operValid.Enqueue(new string('*', 40));
            operValid.Enqueue($"* MENU * Calculator {Calculadora.ver}");
            operValid.Enqueue(new string('*', 40));
            operValid.Enqueue("* (1) ADDITION");
            operValid.Enqueue("* (2) SUBTRACTION");
            operValid.Enqueue("* (3) MULTIPLICATION");
            operValid.Enqueue("* (4) DIVISION");
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
            if (c == "1" || c == "2" || c == "3" || c == "4")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string ReadMenu()
        {
            string menuKey = Console.ReadLine();
            return menuKey;
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

        public static Calculadora GetResult(Calculadora c)
        {
            switch (c.Operand)
            {
                case "1":
                    {
                        c.Result = c.FirstNumber + c.SecondNumber;
                        c.Operand = "+";
                        return c;
                    };

                case "2":
                    {
                        c.Result = c.FirstNumber - c.SecondNumber;
                        c.Operand = "-";
                        return c;
                    };

                case "3":
                    {
                        c.Result = c.FirstNumber * c.SecondNumber;
                        c.Operand = "x";
                        return c;
                    };

                case "4":
                    {
                        try
                        {
                            c.Result = c.FirstNumber / c.SecondNumber;
                            c.Operand = "/";
                            return c;
                        }
                        catch (DivideByZeroException)
                        {
                            Console.WriteLine("Should not divide by zero!");
                            Console.WriteLine("Press enter to continue...");
                            Console.WriteLine();
                            return c;
                        }

                    };
                default: return c;
            }
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
