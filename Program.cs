namespace GuessTheWord
{
    internal class Program
    {
        static bool isRandomWord = true;
        static string word = "";
        static List<char> guesses = new List<char> { };

        static public void setGameMode()
        {
            bool isValidInput = false;
            Console.WriteLine("Welcome to 'Guess the word!' \nDo you want to type your own word to guess?");
            while (!isValidInput)
            {
                Console.WriteLine("Type 'Y' if you want to type your own word or 'N' if you want a randomly selected word");
                string randomOrNot = Console.ReadLine().ToUpper();
                if (randomOrNot == "Y") { isValidInput = true; isRandomWord = true;  }
                else if (randomOrNot == "N") { isValidInput = true; isRandomWord = false; }
            }
            Console.Clear();
        }

        static void getWordFromHost()
        {
            Console.WriteLine("Host, please enter a word for the guest to guess: ");
            bool isValidWord = false;
            while (!isValidWord)
            {
                Console.WriteLine("Please enter only letters.  \nGive it another Try...");
                word = Console.ReadLine();
                isValidWord = word.Length > 0 && word.All(Char.IsLetter);
            }
            word = word.ToUpper();
        }

        static void getWordFromFile()
        {
            Random random = new Random();
            // TODO: check if file exists and ask the host option if it does not.
            var path = Path.Combine(@"..\..\..\words.txt");
            
            string[] words = File.ReadAllLines(path);
            word = words[random.Next(words.Length)].ToUpper();
        }

        static void getPlayerGuess()
        {
            bool isValidGuess = false;
            string userInput = "";
            while (!isValidGuess) 
            {
                Console.WriteLine("Enter 1 letter, please:");
                userInput = Console.ReadLine();
                isValidGuess = userInput.Length == 1 && userInput.All(Char.IsLetter);
            }
            guesses.Add(Convert.ToChar(userInput.ToUpper()));
        }

        static string getCurrentWord()
        {
            string currentWord = "";
            foreach (char letter in word)
            {
                if (guesses.Contains(letter)) currentWord+= letter;
                else currentWord += "-";
            }
            return currentWord;
        }

        static void StartGame()
        {
            bool isGameEnded = false;
            int attempts = 1;

            Console.Clear();
            string currentWord = getCurrentWord();
            Console.WriteLine($"Attempt # {attempts}. Word to guess: {currentWord}");

            while (!isGameEnded)
            {
                attempts++;
                getPlayerGuess();
                Console.Clear();
                currentWord = getCurrentWord();
                Console.WriteLine($"Attempt # {attempts}. Word to guess: {currentWord}");
                isGameEnded = currentWord.Equals(word);
            }
            Console.WriteLine($"You win! Only {attempts} attempts used");
        }

        static void Main(string[] args)
        { 
            setGameMode();
            if (isRandomWord) getWordFromFile();
            else getWordFromHost();
            StartGame();
        }
    }
}