namespace Chess.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class UserData
    {
        private List<string> moves;
        public UserData()
        {
            this.moves = new List<string>();
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
            Console.Write("Choose color of figures: Black or White? ");
        }

        private void ValidateInputUser(string inputUser)
        {
            while (true)
            {
                try
                {
                    if (inputUser != "Black" && inputUser != "White")
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
