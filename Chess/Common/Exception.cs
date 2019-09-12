using System;

namespace Chess
{
    public class Exception
    {
        public static void ThrowInvalidMoveException()
        {
            throw new ArgumentException("Invalid move of pawn! Try again");
        }
    }
}
