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

            while (check != "x")
            {

                check = Calculadora.ReadMenu();

                Console.Clear();

                if (check == "x")
                    break;
                else

                if(Calculadora.KeyCheck(check))
                {
                    // Creates a new object eveytime it makes a calculation
                    // receiving three elements that were defined in the constructor

                    Calculadora calc = new Calculadora(Calculadora.ReadFirstValue(), Calculadora.ReadSndValue(), check);
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
