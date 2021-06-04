using System;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool go = true;
            while (go == true)

            {
                Random r = new Random();
                int secret = r.Next(1, 101);
                int tries = 0;
                Console.WriteLine("This version uses user input");
                string response = "";
                while (response != "Match!")
                {
                    int num = GetUserGuess();

                    response = Guess(num, secret);
                    Console.WriteLine(response);
                    Console.WriteLine();
                    tries++;
                }

                Console.WriteLine($"it took you {tries} tries to guess {secret}");

                //Random Method algorithm test
                Console.WriteLine("Guesse One");
                int guess1 = Random(secret);
                Console.WriteLine(guess1);
                Console.WriteLine();

                //BruteForce Method algorithm test
                Console.WriteLine("Guesse Two");
                int guess2 = BruteForce(secret);
                Console.WriteLine(guess2);
                Console.WriteLine();



                Console.WriteLine();
                Console.WriteLine("This version guesses starting at one and ticks up to 100");
                int current = 1;
                response = "";
                while (response != "Match!")
                {
                    response = Guess(current, secret);
                    if (response != "Match!")
                    {
                        current++;
                    }
                }
                Console.WriteLine($"The linear Guesser took {current} times to guess the number {secret} ");

                go = PlayAgain();

            }
        }
        //User input method
        public static int GetUserGuess()
        {
            while (true)
            {
                Console.WriteLine("Please guess a number between 1 and 100 and I will tell how close you are");
                try
                {
                    int num = int.Parse(Console.ReadLine());
                    if (num < 1)
                    {
                        throw new Exception("That number is too small, please input a number between 1 and 100");
                    }
                    else if (num > 100)
                    {
                        throw new Exception("That number is too large, please input a number between 1 and 100");
                    }
                    return num;

                }
                catch (FormatException)
                {
                    Console.WriteLine("That was not a valid number please try again");
                    continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }
        // Output Method
        public static string Guess(int guess, int secretNum)
        {
            if (guess == secretNum)
            {
                return "Match!";
            }
            int diff = guess - secretNum;
            diff = Math.Abs(diff);

            if (guess > secretNum)
            {
                if (diff > 10)
                {
                    return "Way too high!";
                }
                else
                {
                    return "too high!";
                }
            }
            else
            {
                if (diff > 10)
                {
                    return "Way too low!";
                }
                else
                {
                    return "too low!";
                }
            }


        }//Random Method
        public static int Random(int numGuess)
        {
            int computer = 0;
            int guesses = 0;

            while (computer != numGuess)
            {
                guesses++;
                Random Guess = new Random();
                computer = Guess.Next(1, 101);

                if (computer > numGuess || computer < numGuess)
                {

                }
                else
                {
                    Console.WriteLine($"Guesses = {guesses}");
                    computer = numGuess;
                }
            }
            return computer;


        }//Brute Force Method
        public static int BruteForce(int numGuess)
        {
            int computer = 0;
            int guesses = 0;
            int goDown = 100;
            while (computer != numGuess)
            {
                guesses++;
                computer = goDown--;

                if (computer > numGuess || computer < numGuess)
                {

                    //Console.WriteLine(computerGuess);
                }
                else
                {
                    Console.WriteLine($"Guesses = {guesses}");
                    computer = numGuess;
                }
            }
            return computer;

        }
        public static bool PlayAgain()
        {
            Console.WriteLine("Do you want to play again? y/n");
            string input = Console.ReadLine();

            if(input == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}