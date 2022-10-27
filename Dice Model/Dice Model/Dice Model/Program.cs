//Dice Model (IGME E5) 
//Name: Kelly Chen | kc4509@g.rit.edu

//A program that uses OOP to model m-sided dice rolled n times

using System;
using System.Security.Cryptography.X509Certificates;

namespace DiceModel
{
    //blueprint for a dice
    public class Dice
    {
        //number of sides the dice has
        public int numOfSides;
        //the result that is rolled for that dice
        public int result;
    }
    class Program
    {
        //Generates the numbers rolled on the dices
        static void Play()
        {
            Random rnd = new Random();
            //number of dices rolled
            int numOfDice = 0;
            //holds the string of # of sides of eachh die before it gets turned into an array
            string temp = "";
            //number of times the dice is rolled
            int numOfRolls = 0;
            //count of number of rolls
            int count = 0;
            //string array holding how many sides each dice have
            string[] diceSides = new string[numOfDice];

            Console.WriteLine("Enter the number of dice: ");
            numOfDice = Convert.ToInt32(Console.ReadLine());
            while (numOfDice <= 0)
            {
                Console.WriteLine("Number has to be greater than 0!");
                Console.WriteLine("Enter the number of dice: ");
                numOfDice = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Enter the sides of each die: ");
            temp = Console.ReadLine();
            diceSides = temp.Split(' ');
            while (diceSides.Length != numOfDice)
            {
                Console.WriteLine("Inccorect input of sides!");
                Console.WriteLine("Enter the sides of each die: ");
                temp = Console.ReadLine();
                diceSides = temp.Split(' ');
            }

            //Console.WriteLine(diceSides[0]);
            Dice[] dies = new Dice[numOfDice];
            int[] results = new int[numOfDice];
            Console.WriteLine("How many times do you want to roll the dice? ");
            numOfRolls = Convert.ToInt32(Console.ReadLine());

            for (int x = 0; x < numOfRolls; x++)
            {
                for (int i = 0; i < numOfDice; i++)
                {
                    dies[i] = new Dice();
                    dies[i].numOfSides = Convert.ToInt32(diceSides[i]);
                    //Console.WriteLine(Convert.ToInt32(diceSides[i]));
                    dies[i].result = rnd.Next(1, Convert.ToInt32(diceSides[i]) + 1);
                    results[i] = dies[i].result;
                }
                count = x + 1;
                Console.WriteLine("The result of roll " + count + ": " + string.Join(", ", results));
            }

            
        }
        //main function
        public static void Main(string[] args)
        {
            //string holding users input on wanting to play again or not
            string answer = "yes";

            while (answer == "yes"||answer == "y")
            {
                DiceModel.Program.Play();
                Console.WriteLine("Do you want to go again? ");
                answer = Console.ReadLine();
                if (answer == "y" || answer == "yes")
                {
                    DiceModel.Program.Play();
                    Console.WriteLine("Do you want to go again? ");
                    answer = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Bye!");
                    return;
                }
            }
        }
    }
}