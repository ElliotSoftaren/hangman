# Hangman

A console version of Hangman in C#, guess a random 7-letter word one letter at a time 
before the ASCII gallows finishes drawing. Made while learning C#.

## How it works

- The game picks a random 7-letter word from a curated word list
- Guess one letter at a time
- Correct guesses reveal that letter's position(s) in the word
- Wrong guesses add another piece to the ASCII hangman drawing
- 9 wrong guesses and it's game over
- Guessing the same letter twice gets rejected instead of wasting a turn
- After winning or losing, choose to play again or quit

## Built with

- C#
- .NET Framework

## Running it

Clone the repo, open `Hangman.sln` in Visual Studio, and hit Run
