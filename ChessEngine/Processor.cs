using System.Linq;

namespace ChessEngine
{
    public class Processor
    {
        private const int possibleValuesCount = 8;
        public void ProcessingUserCommand(string userInput)
        {
            string[] possibleValues = new string[]
            {
                "a", "b", "c", "d", "e", "f", "g", "h"
            };

            string[] move = userInput.Split('-');
            string currentFigure = move[0];
            string placeOfCurrentFigure = move[1];

            bool contains = true;
            foreach (var value in possibleValues)
            {
                if (!currentFigure.Contains(value) || !placeOfCurrentFigure.Contains(value))
                {
                    contains = false;
                }
                else
                {
                    contains = true;
                    break;
                }
            }

            if (!contains)
            {
                Exception.ThrowExceptionForInvalidMove();
            }
        }
    }
}
