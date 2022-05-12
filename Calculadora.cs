using System;

namespace E05_Calculadora_v04
{
    class Calculadora
    {
        #region Variables
        public static string ver = "v4.2";
 
        #endregion

        #region Properties
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
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

        public Calculadora(int a, int b)
        {
            FirstNumber = a;
            SecondNumber = b;
            Operand = "";
            Result = 0;
        }
        // 2 values plus operand

        public Calculadora(int a, int b, string c)
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
            string[] operInvalid = new string[]
            {
                new string('*', 40),
                $"* MENU * Calculator {Calculadora.ver}",
                new string ('*', 40),
                "* Please insert a valid option",
                new string ('*', 40),
                "* (1) ADDITION",
                "* (2) SUBTRACTION",
                "* (3) MULTIPLICATION",
                "* (4) DIVISION",
                new string ('*', 40),
                "* (X) EXIT",
                new string ('*', 40)
            };

            string[] operValid = new string[]
            {
                new string('*', 40),
                $"* MENU * Calculator {Calculadora.ver}",
                new string ('*', 40),
                "* (1) ADDITION",
                "* (2) SUBTRACTION",
                "* (3) MULTIPLICATION",
                "* (4) DIVISION",
                new string ('*', 40),
                "* (X) EXIT",
                new string ('*', 40)
        };

            if (keyCheck)
            {
                for (int i = 0; i < operValid.GetLength(0); i++)
                {
                    Console.WriteLine(operValid[i]);
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

        public static int ReadFirstValue()
        {
            Console.Write("Write the first number: ");
            int fst = Convert.ToInt32(Console.ReadLine());
            return fst;
        }

        public static int ReadSndValue()
        {
            Console.Write("Write the second number: ");
            int snd = Convert.ToInt32(Console.ReadLine());
            return snd;
        }

        public static Calculadora GetResult(Calculadora c)
        {
            switch (c.Operand)
            {
                case "1": { c.Result = c.FirstNumber + c.SecondNumber; c.Operand = "+"; return c; }; 
                case "2": { c.Result = c.FirstNumber - c.SecondNumber; c.Operand = "-"; return c; }; 
                case "3": { c.Result = c.FirstNumber * c.SecondNumber; c.Operand = "x"; return c; }; 
                case "4": { c.Result = (double)c.FirstNumber / (double)c.SecondNumber; c.Operand = "/"; return c; };
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
