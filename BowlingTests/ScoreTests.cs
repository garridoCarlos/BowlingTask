using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingTask;
using System.Collections.Generic;

namespace BowlingTests
{
    [TestClass]
    public class ScoreTests
    {
        [TestMethod]
        public void CalculatePoints_PlayerGetsGutterBall_GetsZeroPoints()
        {

            //Arrange
            int expected = 0;
            int[] rolls = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            List<int> resultRolls = new List<int>(rolls);
            Score playerScore = new Score();

            //act
            int actual = playerScore.CalculatePoints(resultRolls);

            //Assert
            Assert.AreEqual(expected, actual, "Score is not 0");
        }

        [TestMethod]
        public void CalculatePoints_PlayerGetAllStrikes_Gets300Points()
        {

            //Arrange
            int expected = 300;
            int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            List<int> resultRolls = new List<int>(rolls);
            Score playerScore = new Score();

            //act
            int actual = playerScore.CalculatePoints(resultRolls);

            //Assert
            Assert.AreEqual(expected, actual, "Score is not 300");
        }

        [TestMethod]
        public void CalculatePoints_PlayerGetsAllSpares_GetsZeroPoints()
        {

            //Arrange
            int expected = 135;
            int[] rolls = { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            List<int> resultRolls = new List<int>(rolls);
            Score playerScore = new Score();

            //act
            int actual = playerScore.CalculatePoints(resultRolls);

            //Assert
            Assert.AreEqual(expected, actual, "Score is not 135");
        }
    }
}
