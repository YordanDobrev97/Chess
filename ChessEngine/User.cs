namespace ChessEngine
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public static class User
    {
        public static void WriteUserCommand()
        {
            Console.SetCursorPosition(0, 17);
            Console.Write("Enter your move: ");
            string userInput = Console.ReadLine();

            Engine.GetUserCommand(userInput);
        }
    }
}
