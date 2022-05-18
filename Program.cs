using System;

namespace E05_Calculadora_v04
{
    class Program
    {
        static void Main(string[] args)
        {
            string check = string.Empty;

            Calculadora.WriteMenu(true);

            // Loops the menu until x is pressed

            while (check != "x" && check != "X")
            {

                check = Calculadora.ReadMenu();

                Console.Clear();

                if (check == "x" || check == "X")
                    break;
                else

                if (Calculadora.KeyCheck(check))
                {
                    // Creates a new object eveytime it makes a calculation
                    // receiving three elements that were defined in the constructor
                    double a = Calculadora.ReadFirstValue();
                    double b = Calculadora.ReadSndValue();
                    Calculadora calc = new Calculadora(a, b, check);

                    Calculadora.PrintResult(Calculadora.GetResult(calc));
                    Console.Clear();
                    Calculadora.WriteMenu(true);
                }
                else
                {
                    Calculadora.WriteMenu(Calculadora.KeyCheck(check));
                }
            }
        }
    }
}
