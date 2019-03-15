namespace Chess.Logic
{
    using Chess.Common;
    using Chess.Interfaces;
    using ChessEngine.Engine.Figures;
    using System.Collections.Generic;


    public class UserData : IUserData
    {
        private Stack<string> moves;
        private string firstColor;
        private string secondColor;
        
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
            this.FirstColor = firstColor;
            this.SecondColor = secondColor;
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
            int count = moveUserParams[0][1] - '0';
            switch (move)
            {
                case 'P':
                    IMoving figure = new Pawn();
                    figure.Move(count);
                    break;
            }
        }
    }
}
