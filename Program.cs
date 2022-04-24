namespace HangMan
{
    internal class Program
    {
        //Wrong guess visual
        private static void printHangman(int wrong)
        {
            if (wrong == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n+---+");
                Console.WriteLine("|    ");
                Console.WriteLine("|    ");
                Console.WriteLine("|    ");
                Console.WriteLine("===   ");
            }
            else if (wrong == 1)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n+---+");
                Console.WriteLine("|   O");
                Console.WriteLine("|    ");
                Console.WriteLine("|    ");
                Console.WriteLine("===   ");
            }
            else if (wrong == 2)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n+---+");
                Console.WriteLine("|   O");
                Console.WriteLine("|   |");
                Console.WriteLine("|    ");
                Console.WriteLine("===   ");
            }
            else if (wrong == 3)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n+---+");
                Console.WriteLine("|   O");
                Console.WriteLine("|  /|");
                Console.WriteLine("|    ");
                Console.WriteLine("===   ");
            }
            else if (wrong == 4)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n+---+");
                Console.WriteLine("|   O");
                Console.WriteLine("|  /|\\");
                Console.WriteLine("|    ");
                Console.WriteLine("===   ");
            }
            else if (wrong == 5)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n+---+");
                Console.WriteLine("|   O");
                Console.WriteLine("|  /|\\");
                Console.WriteLine("|  /");
                Console.WriteLine("===   ");
                Console.WriteLine("Bob is almost dead, you have one last try!");
            }
            else if (wrong == 6)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n+---+");
                Console.WriteLine("|   O");
                Console.WriteLine("|  /|\\");
                Console.WriteLine("|  / \\");
                Console.WriteLine("===   ");
                Console.WriteLine(" You have killed Bob =)");
            }

        }

        private static int printWord(List<char> guessedLetters, String randomWord)
        {
            int counter = 0;
            int rightLetters = 0;
            Console.Write("\r\n");
            foreach (char c in randomWord)
            {
                if (guessedLetters.Contains(c))
                {
                    Console.Write(c + " ");
                    rightLetters += 1;
                }
                else
                {
                    Console.Write("  ");
                }
                counter += 1;
            }
            return rightLetters;
        }

        private static void printLines(String randomWord)
        {
            Console.Write("\r");
            foreach (char c in randomWord)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 ");
            }
        }

        private static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("This is HangMan, you should know the game but if you do not, you have to guess the word by typing letters before Bob dies =)");
            Console.WriteLine("-----------------------------------------");

            Random random = new Random();
            List<string> wordBank = new List<string> { "picture", "powder", "jelly", "conductor", "grain", "learn", "module", "press", "policeman", "soul", "review", "angle", "conductor", "density" };
            int index = random.Next(wordBank.Count);
            String randomWord = wordBank[index];

            foreach (char x in randomWord)
            {
                Console.Write("_ ");
            }

            int lengthOfWordToGuess = randomWord.Length;
            int amountOfTimesWrong = 0;
            List<char> currentLettersGuessed = new List<char>();
            int currentLettersRight = 0;

            while (amountOfTimesWrong != 6 && currentLettersRight != lengthOfWordToGuess)
            {
                Console.Write("\nLetters guessed so far: ");
                foreach (char letter in currentLettersGuessed)
                {
                    Console.Write(letter + " ");
                }
                Console.Write("\nGuess a letter: ");
                char letterGuessed = Console.ReadLine()[0];
                // Check if that letter has already been guessed
                if (currentLettersGuessed.Contains(letterGuessed))
                {
                    Console.Write("\r\n You have already guessed this letter, try a new one");
                    printHangman(amountOfTimesWrong);
                    currentLettersRight = printWord(currentLettersGuessed, randomWord);
                    printLines(randomWord);
                }
                else
                {
                    // Check if letter is in randomWord
                    bool right = false;
                    for (int i = 0; i < randomWord.Length; i++) { if (letterGuessed == randomWord[i]) { right = true; } }

                    // Right letter
                    if (right)
                    {
                        printHangman(amountOfTimesWrong);
                        currentLettersGuessed.Add(letterGuessed);
                        currentLettersRight = printWord(currentLettersGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                    // Wrong letter
                    else
                    {
                        amountOfTimesWrong += 1;
                        currentLettersGuessed.Add(letterGuessed);
                        // Update drawing
                        printHangman(amountOfTimesWrong);
                        // Print word
                        currentLettersRight = printWord(currentLettersGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                }
            }
            Console.WriteLine("\r\nThe game is over!");
        }
    }
}