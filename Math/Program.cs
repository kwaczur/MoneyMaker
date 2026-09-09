using System;

namespace MoneyMaker
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // INPUT
            Console.WriteLine("Welcome to Money Maker!");
            Console.WriteLine("Enter an amount to convert to coins: ");

            string totalAsString = Console.ReadLine();
            
            // VALIDATION
                // Zabezpieczenie przed niewpisaniem liczby lub liczby mniejszej niż 0
                bool isValid = decimal.TryParse(totalAsString, out decimal totalAsDecimal);

                while (!isValid || totalAsDecimal <= 0) 
                {
                    Console.WriteLine("Please enter a valid number.");
                    totalAsString  = Console.ReadLine();
                    isValid = decimal.TryParse(totalAsString, out totalAsDecimal);
                }
            // CONFIGURATION
            
            int goldCoin = 10;
            int silverCoin = 5;
            int bronzeCoin = 1;
            
            // CALCULATION
            int howManyG = (int)Math.Floor(totalAsDecimal / goldCoin);
            int remainder = (int)(totalAsDecimal % goldCoin);

            int howManyS = remainder / silverCoin;
            remainder = remainder - howManyS * silverCoin;

            int howManyB = remainder / bronzeCoin;

            int howManyCoins = howManyB + howManyG + howManyS;


            // OUTPUT

            Console.WriteLine("Jest to:");
            Console.WriteLine($"Złote monety: {howManyG}");
            Console.WriteLine($"Srebrne monety: {howManyS}");
            Console.WriteLine($"Brązowe monety: {howManyB}");
            Console.WriteLine($"Liczba wszystkich monet: {howManyCoins}");
        }
    }
}