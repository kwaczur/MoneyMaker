using System; // korzystamy z Console

namespace MoneyMaker
{
    class MainClass
    {
        public static void Main(string[] args) // punkt startowy programu
        {
            // INPUT
            Console.WriteLine("Welcome to Money Maker!"); // wyświetla tekst
            Console.WriteLine("Enter an amount to convert to coins:"); // prosi o podanie kwoty

            string totalAsString = Console.ReadLine(); // pobiera kwotę jako tekst


            // VALIDATION
            bool isValid = decimal.TryParse(totalAsString, out decimal totalAsDecimal); // próbuje zamienić tekst na decimal i sprawdza poprawność

            while (!isValid || totalAsDecimal <= 0) // powtarza, jeśli wartość jest niepoprawna lub <= 0
            {
                Console.WriteLine("Please enter a valid number."); // informuje o błędnej wartości
                totalAsString = Console.ReadLine(); // ponownie pobiera tekst
                isValid = decimal.TryParse(totalAsString, out totalAsDecimal); // ponownie sprawdza i konwertuje
            }


            // CONFIGURATION
            int[] denominations =
            {
                50000, 20000, 10000, 5000, 2000, 1000, 500,
                200, 100, 50, 20, 10, 5, 2, 1
            }; // nominały zapisane w groszach


            // CALCULATION
            int totalInGrosze = (int)(totalAsDecimal * 100); // zamienia złote na grosze

            foreach (int denomination in denominations) // przechodzi po każdym nominale
            {
                int howMany = totalInGrosze / denomination; // oblicza ile razy mieści się nominał

                if (howMany > 0) // sprawdza, czy potrzebujemy tego nominału
                {
                    if (denomination >= 100) // jeżeli nominał jest większy lub równy 100 groszy
                    {
                        Console.WriteLine($"{howMany} x {denomination / 100} zł"); // dzieli liczbę przez 100 i wyświetla zł
                    }
                    else
                    {
                        Console.WriteLine($"{howMany} x {denomination} gr."); // wyświetla liczbę gr
                    }
                }
                totalInGrosze = totalInGrosze % denomination; // zostawia resztę kwoty
            }
        }
    }
}