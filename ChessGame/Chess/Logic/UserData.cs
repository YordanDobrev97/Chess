namespace Chess.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class UserData
    {
        private Stack<string> moves;
        private static string firstColor = "Red";
        private static string secondColor = "Blue";

        public UserData()
        {
            this.moves = new Stack<string>();
        }

        public string InputUserData()
        {
            ChoiceOfFiguresMessage();
            string inputFigure = Console.ReadLine();
            ValidateInputUser(inputFigure);

            Console.Clear();

            return inputFigure;
        }

        private static void ChoiceOfFiguresMessage()
        {
            Console.Write($"Choose color of figures: {firstColor} or {secondColor}? ");
        }

        private void ValidateInputUser(string inputUser)
        {
            while (true)
            {
                try
                {
                    if (inputUser != firstColor && inputUser != secondColor)
                    {
                        throw new ArgumentException("Invalid figures!");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid choose for your figure!");
                    Console.Clear();
                    Console.WriteLine("Please valid color figure!");
                    Thread.Sleep(1000);
                    ChoiceOfFiguresMessage();
                    inputUser = Console.ReadLine();
                }
                
            }
        }
    }
}
