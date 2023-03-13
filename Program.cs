using System.Diagnostics;

namespace GuessTheWord
{
    internal class Program
    {
        static bool isRandomWord = true;
        static string word = "";

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
        }
        static void setWord()
        { 
            if (isRandomWord) 
            {
                word = "random";
            } else {
                Console.WriteLine("Host, please enter a word for the guest to guess: ");
                word = Console.ReadLine();
            }
        }
        
        static void Main(string[] args)
        { 
            setGameMode();
            Console.Clear();
            setWord();

        }
    }
}