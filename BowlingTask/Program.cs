using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your rolls");

            string inputRolls = Console.ReadLine();

            Rolls list = new Rolls();
            Score score = new Score();

            List<int> resultRolls = list.GetListRolls(inputRolls);
            int totalPoints = score.CalculatePoints(resultRolls);
            score.ScoreOutput(resultRolls, totalPoints);
        }
    }
}
