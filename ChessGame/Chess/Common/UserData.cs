namespace Chess.Logic
{
    using Chess.Common;
    using Chess.Interfaces;
    using ChessEngine;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class UserData : IUserData
    {
        private Stack<string> moves;
        private string firstColor;
        private string secondColor;
        private const int MAX_WIDTH_LEFT = 30;
        private readonly static List<int> intervalValues = new List<int>();

        public string FirstColor
        {
            get
            {
                return this.firstColor;
            }
            private set
            {
                this.firstColor = "Red";
            }

        }

        public string SecondColor
        {
            get
            {
                return this.secondColor;
            }
            private set
            {
                this.secondColor = "Blue";
            }
        }

        public UserData()
        {
            this.moves = new Stack<string>();
            SetIntervalSetCursion();
            this.FirstColor = firstColor;
            this.SecondColor = secondColor;
        }

        private void SetIntervalSetCursion()
        {
            for (int i = 2; i <=30; i+=4)
            {
                intervalValues.Add(i);
            }
        }

        public ReadOnlyCollection<int> GetIntervalSetPositionCursor()
        {
            ReadOnlyCollection<int> interval = new ReadOnlyCollection<int>(intervalValues);

            return interval;
        }

        public string InputUserData()
        {
            ChoiceOfFiguresMessage();
            string inputFigure = ViewUser.ConsoleReadLine();
            ValidateInputUser(inputFigure);
            ViewUser.ConsoleClear();

            return inputFigure;
        }

        private void ChoiceOfFiguresMessage()
        {
            ViewUser.MessageUser($"Choose color of figures: {FirstColor} or {SecondColor}? ");
        }

        private void ValidateInputUser(string inputUser)
        {
            bool isValidDataOfUser = false;
            while (!isValidDataOfUser)
            {
                try
                {
                    if (inputUser != firstColor && inputUser != SecondColor)
                    {
                        ViewUser.ViewException();
                    }
                    else
                    {
                        isValidDataOfUser = true;
                    }
                }
                catch
                {
                    ViewUser.MessageUser("Invalid choose for your figure!");
                    ViewUser.ConsoleClear();
                    ViewUser.MessageUser("Please valid color figure!");
                    ViewUser.SleepConsole(1000);
                    ChoiceOfFiguresMessage();
                    inputUser = ViewUser.ConsoleReadLine();
                }
            }
        }

        public static void MoveFigure(string moveUser)
        {
            string[] moveUserParams = moveUser.Split(' ');
            char move = moveUserParams[0][0];
            int numberFigure = moveUserParams[0][1] - '0';
            int count = int.Parse(moveUserParams[1]);

            switch (move)
            {
                case 'P':
                    if(ValidMove.IsValidMovePawn(moveUserParams[0]) && ValidMove.IsValidCountPawn(count))
                    {
                        int position = intervalValues[numberFigure - 1];
                        MoveEngine.MovePawn(position, 15);
                        //TODO...
                        //Add remove old pawn and save new pawn with new position

                    }
                    else
                    {
                        ViewUser.MessageUser("Invalid move");
                    }
                    break;
            }
        }
    }
}
