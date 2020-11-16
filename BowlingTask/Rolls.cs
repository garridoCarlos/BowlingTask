using System.Collections.Generic;
using System.Linq;

namespace BowlingTask
{
    public class Rolls
    {
        public List<int> GetListRolls(string inputRolls)
        {

            //This method gets the user input and returns an object List with 21 items 
            //(every possible roll in a bowling match)
            //This list is going to be used by the rest of the program  to calculate the score
            //and give format to the output.

            char[] delimiterChars = { ',', '\t' };
            string[] rolls = inputRolls.Split(delimiterChars);
            int[] intRolls = rolls.Select(int.Parse).ToArray();

            List<int> listRolls = ((int[])intRolls).ToList();

            List<int> resultRolls = new List<int>();

            while (listRolls.Count() != 0)
            {
                int firstRoll = listRolls.First();
                listRolls.RemoveAt(0);

                if (firstRoll == 10)
                {
                    resultRolls.Add(10);
                    resultRolls.Add(0);

                }
                else
                {
                    if (listRolls.Count() > 0)
                    {
                        int secondRoll = listRolls.First();
                        resultRolls.Add(firstRoll);
                        resultRolls.Add(secondRoll);
                        listRolls.RemoveAt(0);

                    }
                }
            }

            while (resultRolls.Count() < 21)
            {
                resultRolls.Add(0);
            }

            if (resultRolls.Count() > 21)
            {
                resultRolls.RemoveAt(19);
            }

            return resultRolls;
        }
    }
}
