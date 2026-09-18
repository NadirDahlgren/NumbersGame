namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random diceRoll = new Random(); // Declaring a new random variable for the correct numbre. 
            int randomNumber = diceRoll.Next(1, 20); // Declaring the random number for the user. 
            Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får fem försök.");
            int guessNumber;
            int guessCount = 0; // du kan ocmså skriva ihop dessa int variabel i en rad
            
            while (guessCount < ) // lägger en loop som håller koll på alla gissningar. 
            {
                while (!int.TryParse(Console.ReadLine(), out guessNumber)) // loop för felinmatning
                {
                    Console.WriteLine("Du måste skriva ett heltal. Försök igen:");
                }
                GuessCheck(guessNumber, randomNumber);
                guessCount++;

            }
            Console.WriteLine("Spelet är slut. Du har gissat antal gissningar. ");



        }

        static void GuessCheck(int a, int b)
        {
            if (a == b)
            {
                Console.WriteLine("Grattis! Du har gissat rätt");
            }
            else if (a > b)
            {
                Console.WriteLine("Försök igen! Talet är för stort.");
            }
            else
            {
                Console.WriteLine("Försök igen! Talet är för litet");
            }



        }
    }
}
