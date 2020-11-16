using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingTask
{
    public class Score
    {
        public int CalculatePoints(List<int> resultRolls)
        {
            //This method gets the list from Rolls.cs and calculates separatedly the raw points 
            //(number of pins tanken down) and extra points (from strikes and spares).
            //The method returns the sum of both numbers.

            int[] arrayIntRolls = resultRolls.ToArray();

            int rawPoints = arrayIntRolls.Sum();
            int extraPoints = 0;

            for (int i = 0; i < 16; i++)
            {
                if (i % 2 == 0 & arrayIntRolls[i] == 10)
                {

                    if (arrayIntRolls[i + 2] == 10)
                    {
                        extraPoints = extraPoints + arrayIntRolls[i + 2] +
                        arrayIntRolls[i + 4];
                    }
                    else
                    {
                        extraPoints = extraPoints + arrayIntRolls[i + 2] +
                            arrayIntRolls[i + 3];
                    }
                }
            }

            if (resultRolls[16] == 10)
            {
                extraPoints = extraPoints +
                        arrayIntRolls[18] +
                        arrayIntRolls[19];
            }

            for (int i = 0; i < 18; i++)
            {
                if (i % 2 == 0 & arrayIntRolls[i] != 10 & arrayIntRolls[i] + arrayIntRolls[i + 1] == 10)
                {
                    extraPoints = extraPoints + arrayIntRolls[i + 2];
                }
            }

            int totalPoints = rawPoints + extraPoints;

            return totalPoints;
        }

        public void ScoreOutput(List<int> resultRolls, int totalPoints)
        {

            //This method gets the list from Rolls.cs and the score from Score.CalculatePoints
            //Then applies the rules for showing strikes, spares and gutter balls
            //Finally, it prints the game summary and the score in a fancy format.

            List<string> stringRollsList = resultRolls.ConvertAll<string>(delegate (int i) { return i.ToString(); });

            string[] stringRolls = stringRollsList.ToArray();

            for (int i = 0; i < stringRolls.Length; i++)
            {
                if (i % 2 != 0)
                {
                    int roll1 = Int32.Parse(stringRolls[i]);
                    int roll2 = Int32.Parse(stringRolls[i - 1]);
                    if (i != 20)
                    {
                        if (roll1 + roll2 == 10)
                        {
                            stringRolls[i] = "/";
                        }
                    }
                }
            }

            for (int i = 0; i < stringRolls.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (stringRolls[i] == "10")
                    {
                        stringRolls[i] = "X";
                        if (i != 18)
                        {
                            stringRolls[i + 1] = " ";
                        }
                    }
                }

                if (i % 2 != 0 || i == 20)
                {
                    if (stringRolls[i] == "0")
                    {
                        stringRolls[i] = "-";
                    }
                }
            }

            Console.WriteLine("|  f1  |  f2  |  f3  |  f4  |  f5  |  f6  |  f7  |  f8  |  f9  |   f10   |\r\n" +
            "| {0}, {1} | {2}, {3} | {4}, {5} | {6}, {7} | {8}, {9}" +
                " | {10}, {11} | {12}, {13} | {14}, {15} | {16}, {17} | {18}, {19}, {20} |\r\n" +
                "Score = {21}",
                stringRolls[0], stringRolls[1], stringRolls[2], stringRolls[3], stringRolls[4],
                stringRolls[5], stringRolls[6], stringRolls[7], stringRolls[8], stringRolls[9],
                stringRolls[10], stringRolls[11], stringRolls[12], stringRolls[13], stringRolls[14],
                stringRolls[15], stringRolls[16], stringRolls[17], stringRolls[18], stringRolls[19], stringRolls[20], totalPoints);

        }
    }
}
