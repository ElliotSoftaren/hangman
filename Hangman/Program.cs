using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            string wordListText = client.DownloadString("https://gist.githubusercontent.com/ElliotSoftaren/4eca0dfda93a394bb3fdb4c79461f089/raw/2bfbd1811e115ab370557c8caf65c45915bddbaa/hangman-words-7letter.txt");
            string[] words = wordListText.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Random rnd = new Random();
            string secretWord = words[rnd.Next(words.Length)];

            int asciiChoose, playOrQuit;
            string asciiArt, stringGuess, wrongGuesses;
            char guess, letter1, letter2, letter3, letter4, letter5, letter6, letter7;

            char secretLetter1 = secretWord[0];
            char secretLetter2 = secretWord[1];
            char secretLetter3 = secretWord[2];
            char secretLetter4 = secretWord[3];
            char secretLetter5 = secretWord[4];
            char secretLetter6 = secretWord[5];
            char secretLetter7 = secretWord[6];

            letter1 = letter2 = letter3 = letter4 = letter5 = letter6 = letter7 = '_';

            asciiChoose = 0;
            asciiArt = wrongGuesses = "";
            stringGuess = $" {letter1}{letter2}{letter3}{letter4}{letter5}{letter6}{letter7}";

            if (asciiChoose == 0) { asciiArt = ("\r\n\r\n\r\n \r\n \r\n \r\n========="); }
            if (asciiChoose == 1) { asciiArt = ("      +\r\n      |\r\n      |\r\n      |\r\n      |\r\n      |\r\n========="); }
            if (asciiChoose == 2) { asciiArt = ("  +---+\r\n      |\r\n      |\r\n      |\r\n      |\r\n      |\r\n========="); }
            if (asciiChoose == 3) { asciiArt = ("  +---+\r\n  |   |\r\n      |\r\n      |\r\n      |\r\n      |\r\n========="); }
            if (asciiChoose == 4) { asciiArt = ("  +---+\r\n  |   |\r\n  O   |\r\n      |\r\n      |\r\n      |\r\n========="); }
            if (asciiChoose == 5) { asciiArt = ("  +---+\r\n  |   |\r\n  O   |\r\n  |   |\r\n      |\r\n      |\r\n========="); }
            if (asciiChoose == 6) { asciiArt = ("  +---+\r\n  |   |\r\n  O   |\r\n /|   |\r\n      |\r\n      |\r\n========="); }
            if (asciiChoose == 7) { asciiArt = ("  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n      |\r\n      |\r\n========="); }
            if (asciiChoose == 8) { asciiArt = ("  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n /    |\r\n      |\r\n========="); }
            if (asciiChoose == 9) { asciiArt = ("  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n / \\  |\r\n      |\r\n========="); }

            Console.WriteLine("Hello, welcome to Hangman. You will be given a random word, and you will enter a letter one by one.");
            Console.WriteLine("You can guess as many letters as you want, but if you get 9 letters wrong, it's game over.");
            Console.WriteLine("(enter to continue)");
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Guess a letter.\n");
            Console.WriteLine(asciiArt);
            Console.WriteLine("");
            Console.WriteLine(stringGuess);
            Console.WriteLine("");
            Console.WriteLine("Wrong guesses: " + wrongGuesses);

            while (true)
            {
                while (!char.TryParse(Console.ReadLine(), out guess))
                {
                    Console.Clear();
                    Console.WriteLine("Invalid letter! Guess a letter.\n");
                    Console.WriteLine(asciiArt);
                    Console.WriteLine("");
                    Console.WriteLine(stringGuess);
                    Console.WriteLine("");
                    Console.WriteLine("Wrong guesses: " + wrongGuesses);
                }

                if (wrongGuesses.Contains(guess.ToString()) || guess == letter1 || guess == letter2 || guess == letter3 || guess == letter4 || guess == letter5 || guess == letter6 || guess == letter7)
                {
                    Console.Clear();
                    Console.WriteLine("You already guessed that letter! Try a different one.\n");
                    Console.WriteLine(asciiArt);
                    Console.WriteLine("");
                    Console.WriteLine(stringGuess);
                    Console.WriteLine("");
                    Console.WriteLine("Wrong guesses: " + wrongGuesses);
                    continue;
                }

                else if (asciiChoose == 8)
                {
                    asciiArt = ("  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n / \\  |\r\n      |\r\n=========");
                    Console.Clear();
                    Console.WriteLine("You lost! The correct word was " + secretWord + ".\n");
                    Console.WriteLine(asciiArt);
                    Console.WriteLine("");
                    Console.WriteLine("Enter 1 to play again, else to quit");
                    while (!int.TryParse(Console.ReadLine(), out playOrQuit))
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid character!\n");
                        Console.WriteLine(asciiArt);
                        Console.WriteLine("");
                        Console.WriteLine("Enter 1 to play again, else to quit");
                    }

                    if (playOrQuit == 1)
                    {
                        secretWord = words[rnd.Next(words.Length)];
                        secretLetter1 = secretWord[0];
                        secretLetter2 = secretWord[1];
                        secretLetter3 = secretWord[2];
                        secretLetter4 = secretWord[3];
                        secretLetter5 = secretWord[4];
                        secretLetter6 = secretWord[5];
                        secretLetter7 = secretWord[6];
                        letter1 = letter2 = letter3 = letter4 = letter5 = letter6 = letter7 = '_';
                        asciiChoose = 0;
                        wrongGuesses = "";
                        stringGuess = $" {letter1}{letter2}{letter3}{letter4}{letter5}{letter6}{letter7}";
                        asciiArt = ("\r\n\r\n\r\n \r\n \r\n \r\n=========");
                        Console.Clear();
                        Console.WriteLine("Guess a letter.\n");
                        Console.WriteLine(asciiArt);
                        Console.WriteLine("");
                        Console.WriteLine(stringGuess);
                        Console.WriteLine("");
                        Console.WriteLine("Wrong guesses: " + wrongGuesses);
                    }

                    else
                    {
                        Console.Clear();
                        Console.WriteLine("See you next time.");
                        Thread.Sleep(3000);
                        break;
                    }
                }

                else if (guess == secretLetter1 || guess == secretLetter2 || guess == secretLetter3 || guess == secretLetter4 || guess == secretLetter5 || guess == secretLetter6 || guess == secretLetter7)
                {
                    if (guess == secretLetter1) { letter1 = secretLetter1; }
                    if (guess == secretLetter2) { letter2 = secretLetter2; }
                    if (guess == secretLetter3) { letter3 = secretLetter3; }
                    if (guess == secretLetter4) { letter4 = secretLetter4; }
                    if (guess == secretLetter5) { letter5 = secretLetter5; }
                    if (guess == secretLetter6) { letter6 = secretLetter6; }
                    if (guess == secretLetter7) { letter7 = secretLetter7; }
                    stringGuess = $" {letter1}{letter2}{letter3}{letter4}{letter5}{letter6}{letter7}";

                    if (letter1 == secretLetter1 && letter2 == secretLetter2 && letter3 == secretLetter3 && letter4 == secretLetter4 && letter5 == secretLetter5 && letter6 == secretLetter6 && letter7 == secretLetter7)
                    {
                        Console.Clear();
                        Console.WriteLine("Congratulations, you won! The word was " + secretWord + ".\n");
                        Console.WriteLine(asciiArt);
                        Console.WriteLine("");
                        Console.WriteLine(stringGuess);
                        Console.WriteLine("");
                        Console.WriteLine("Enter 1 to play again, else to quit.");
                        while (!int.TryParse(Console.ReadLine(), out playOrQuit))
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid character!\n");
                            Console.WriteLine("Enter 1 to play again, else to quit.");
                        }

                        if (playOrQuit == 1)
                        {
                            secretWord = words[rnd.Next(words.Length)];
                            secretLetter1 = secretWord[0];
                            secretLetter2 = secretWord[1];
                            secretLetter3 = secretWord[2];
                            secretLetter4 = secretWord[3];
                            secretLetter5 = secretWord[4];
                            secretLetter6 = secretWord[5];
                            secretLetter7 = secretWord[6];
                            letter1 = letter2 = letter3 = letter4 = letter5 = letter6 = letter7 = '_';
                            asciiChoose = 0;
                            wrongGuesses = "";
                            stringGuess = $" {letter1}{letter2}{letter3}{letter4}{letter5}{letter6}{letter7}";
                            asciiArt = ("\r\n\r\n\r\n \r\n \r\n \r\n=========");
                            Console.Clear();
                            Console.WriteLine("Guess a letter.\n");
                            Console.WriteLine(asciiArt);
                            Console.WriteLine("");
                            Console.WriteLine(stringGuess);
                            Console.WriteLine("");
                            Console.WriteLine("Wrong guesses: " + wrongGuesses);
                            continue;
                        }

                        else
                        {
                            Console.Clear();
                            Console.WriteLine("See you next time.");
                            Thread.Sleep(3000);
                            break;
                        }
                    }

                    Console.Clear();
                    Console.WriteLine("Correct letter! Guess another letter.\n");
                    Console.WriteLine(asciiArt);
                    Console.WriteLine("");
                    Console.WriteLine(stringGuess);
                    Console.WriteLine("");
                    Console.WriteLine("Wrong guesses: " + wrongGuesses);
                    continue;
                }

                else
                {
                    wrongGuesses += guess + " ";
                    asciiChoose += 1;
                    if (asciiChoose == 0) { asciiArt = ("\r\n\r\n\r\n \r\n \r\n \r\n========="); }
                    if (asciiChoose == 1) { asciiArt = ("      +\r\n      |\r\n      |\r\n      |\r\n      |\r\n      |\r\n========="); }
                    if (asciiChoose == 2) { asciiArt = ("  +---+\r\n      |\r\n      |\r\n      |\r\n      |\r\n      |\r\n========="); }
                    if (asciiChoose == 3) { asciiArt = ("  +---+\r\n  |   |\r\n      |\r\n      |\r\n      |\r\n      |\r\n========="); }
                    if (asciiChoose == 4) { asciiArt = ("  +---+\r\n  |   |\r\n  O   |\r\n      |\r\n      |\r\n      |\r\n========="); }
                    if (asciiChoose == 5) { asciiArt = ("  +---+\r\n  |   |\r\n  O   |\r\n  |   |\r\n      |\r\n      |\r\n========="); }
                    if (asciiChoose == 6) { asciiArt = ("  +---+\r\n  |   |\r\n  O   |\r\n /|   |\r\n      |\r\n      |\r\n========="); }
                    if (asciiChoose == 7) { asciiArt = ("  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n      |\r\n      |\r\n========="); }
                    if (asciiChoose == 8) { asciiArt = ("  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n /    |\r\n      |\r\n========="); }
                    if (asciiChoose == 9) { asciiArt = ("  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n / \\  |\r\n      |\r\n========="); }
                    Console.Clear();
                    Console.WriteLine("Wrong letter! Guess another letter.\n");
                    Console.WriteLine(asciiArt);
                    Console.WriteLine("");
                    Console.WriteLine(stringGuess);
                    Console.WriteLine("");
                    Console.WriteLine("Wrong guesses: " + wrongGuesses);
                }
            }
        }
    }
}