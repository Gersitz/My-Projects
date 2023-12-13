using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    public class GuessTheNumber
    {
        private int randomNumber;
        private int[] guessedNumbers;
        private int attempts;
        private bool gameActive;
        private bool? guide;

        public static int RandomNumber { get; set; }
        public static int[] GuessedNumbers { get; set; }
        public static int Attempts { get; set; }
        private bool GameActive { get; set; }
        private bool? Guide { get; set; }


        public GuessTheNumber()
        {
            RandomNumber = randomNumber;
            GuessedNumbers = guessedNumbers;
            Attempts = attempts;
            GameActive = gameActive;
            Guide = guide;
        }

        public void SetupNumberGame()
        {
            Console.WriteLine("Please enter the lowest number of the range you have to guess.");
            int minNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter the highest number of the range you have to guess.");
            int maxNumber = Convert.ToInt32(Console.ReadLine());

            int targetNumber = GenerateNumber(minNumber, maxNumber);
            Attempts = 0;
            Guide = null;
            if (maxNumber - minNumber >= 10)
            {
                Console.WriteLine("Do you want to activate a guide to tell you how close you are with your guess? (Y/N)");
                string input = Console.ReadLine();
                while (Guide == null)
                {
                    switch (input)
                    {
                        case "y":
                        case "Y":
                            {
                                Guide = true;
                                Console.WriteLine("I will tell you how close your guesses are.");
                                break;
                            }
                        case "n":
                        case "N":
                            {
                                Guide = false;
                                Console.WriteLine("I won't tell you how close your guesses are.");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Please answer with Y for Yes or N for No!");
                                break;
                            }
                    }
                }
            }
        }

        private static int GenerateNumber(int minNumber, int maxNumber)
        {
            Random random = new Random();
            RandomNumber = random.Next(minNumber, maxNumber + 1);
            return RandomNumber;
        }

        public void StartGame()
        {
            int target = RandomNumber;
            gameActive = true;
            Console.WriteLine("I generated a number. Start to guess!");
            while (gameActive == true)
            {
                if (int.TryParse(Console.ReadLine(), out int guess))
                {
                    Attempts++;
                    if (guess == target)
                    {
                        if (Attempts == 1)
                        {
                            Console.WriteLine("Correct! You guessed my number on your first attempt!");
                        }
                        else
                        {
                            Console.WriteLine($"Correct! You guessed my number in {Attempts} attempts!");
                        }
                        gameActive = false;
                    }
                    else
                    {
                        if (Guide == true)
                        {
                            if (Math.Abs(target - guess) <= 2)
                            {
                                Console.WriteLine("You almost have it!");
                            }
                            else if (target * 0.05 >= Math.Abs(target - guess))
                            {
                                Console.WriteLine("Very close! Try again!");
                            }
                            else if (target * 0.10 >= Math.Abs(target - guess))
                            {
                                Console.WriteLine("Close! Try again.");
                            }
                            else
                            {
                                Console.WriteLine("Wrong. Try again!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong. Try again!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Please only enter whole numbers.");
                }
            }
        }
    }
}
