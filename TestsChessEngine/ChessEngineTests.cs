using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsChessEngine
{
    [TestClass]
    public class ChessEngineTests
    {
        [TestMethod]
        public void CheckValidUserCommandWithOneUpMove()
        {
            string userCommand = "a2-a3";
            string containsResult = "a";

            StringAssert.Contains(userCommand, containsResult);
        }

        [TestMethod]
        public void CheckValidUserCommandWithTwoUpMove()
        {
            string userCommand = "a2-a4";
            string containsResult = "a";

            StringAssert.Contains(userCommand, containsResult);
        }

        [TestMethod]
        public void CheckValidUserCommandWithFourUpMove()
        {
            string userCommand = "a2-a6";
            string containsResult = "a";

            StringAssert.Contains(userCommand, containsResult);
        }

        [TestMethod]
        public void CheckValidUserCommandWithFiveUpMove()
        {
            string userCommand = "a2-a7";
            string containsResult = "a";

            StringAssert.Contains(userCommand, containsResult);
        }

        [TestMethod]
        public void CheckValidUserCommandWithEightUpMove()
        {
            string userCommand = "a2-a8";
            string containsResult = "a";

            StringAssert.Contains(userCommand, containsResult);
        }

        [TestMethod]
        public void CheckNotValidUserCommandWithEightUpMove()
        {
            string userCommand = "ak-ad";
            string containsResult = "k";

            StringAssert.Contains(userCommand, containsResult);
        }
    }
}
