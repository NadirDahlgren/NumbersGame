namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //** INTRO **//

            Random diceRoll = new Random();                                 // Declaring a new random variable for the correct number.
            bool playAgain = true;                                          // Bool which decides if the game could repeat. 
            while (playAgain)                                               // While-iteration for the game. 
            {
                int randomAmount, randomNumber, userChoice, guessCount = 0; // Declaring different integer-variables for the program. 
                bool hasWon = false;                                        // Bool for checking if the user has won. 
                Console.WriteLine                                           // Game-menu
                    ("Välkommen! Jag tänker på ett nummer mellan 1-20. Kan du gissa vilket? Du får fem försök.\n" +
                    "\nOm du vill byta svårighetsgrad så kan du skriva antalet nummer som skall slumpas fram själv av datorn. " +
                    "\n[1]. Gå vidare med samma svårighetsgrad " +
                    "\n[2]. Välj en egen svårighetsgrad");
                userChoice = GetValidNumber();                              // Checking input from the user. 

            //** DIFFICULTY **//

                if (userChoice == 2)
                {
                    Console.WriteLine("Hur många nummer vill du att datorn ska slumpa mellan?");
                    randomAmount = GetValidNumber();                         // Checking input from the user. 
                    randomNumber = diceRoll.Next(1, randomAmount + 1);       // New variable with random-amount. 
                    Console.Clear();
                    Console.WriteLine($"Programmet slumpar ett tal mellan 1 och {randomAmount}.");
                }
                else
                {
                    randomNumber = diceRoll.Next(1, 21);                    // Regular-value for the diceroll. 
                }

            //** GUESSING GAME **//

                while (guessCount < 5)                                      // Iteration for the counting of the guesses. 
                {
                    Console.WriteLine("Ange ett tal för gissning:");
                    hasWon = GuessCheck(randomNumber);                      // Method for checking the users guessing. 
                    guessCount++;                                           // Add one to the guess count to keep track of the guesses. 

                    if (hasWon)                                             // If guesscheck is true, break the iteration. 
                    {
                        break;                                              // Iteration is over.
                    }
                }
                if (!hasWon)                                                // If user hasnt won in five rounds. 
                {
                    Console.WriteLine("Tyvärr, du lyckades inte gissa talet på fem försök!");
                }

            //** PLAY AGAIN **//

                Console.WriteLine("Vill du spela igen? Tryck 1 för Ja eller 2 för Nej."); 
                int choice;                                                 // New int variable for the replay. 
                choice = GetValidNumber();                                  // Checking input from the user. 
                if (choice == 1)                                            // If the player chooses 1, the game loop starts again.
                {
                    playAgain = true;
                    Console.Clear();
                }
                else                                                        // Or else, the game is over.
                {
                    playAgain = false;
                }
            }
            Console.WriteLine("Tack för att du spelade!");
        }
        static bool GuessCheck(int randomNumber)                        // Bool-method with int as a parameter for checking the guesses. 
        {
            int userNumber;
            userNumber = GetValidNumber();                                 // Checking input from the user.
            if (randomNumber == userNumber)                                 // If the users input matches the random number, the user wins the game.
            {
                Console.WriteLine("Wohoo! Du klarade det!");
                return true;                                                // Returns true from the method since the user has won the game.
            }
            else if (userNumber < randomNumber && userNumber >= randomNumber - 2)   // Else-if statement for hinting the player. 
            {
                Console.WriteLine("Det bränns! Du gissade lite för lågt.");
            }
            else if (userNumber > randomNumber && userNumber <= randomNumber + 2)  // Else-if statement for hinting the player. 
            {
                Console.WriteLine("Det bränns! Du gissade lite för högt.");
            }
            else if (userNumber < randomNumber)                             // Else-if statement for hinting the player. 
            {
                Console.WriteLine("Tyvärr, du gissade för lågt!");
            }
            else // Else statement for hinting the player. 
            {
                Console.WriteLine("Tyvärr, du gissade för högt!");
            }
            return false;                                                   // Bool method returns false if the player didnt get the correct answer.
        }
        static int GetValidNumber()                                     // Int-method to get the valid number from the user. 
        {
            int userNumber;
            while (!int.TryParse(Console.ReadLine(), out userNumber))       // While-iteration for wrong input. 
            {
                Console.WriteLine("Du måste skriva ett heltal. Försök igen:");
            }
            return userNumber;                                              // Returns the integer. 
        }
    }
}