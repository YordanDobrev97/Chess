namespace Chess.Logic
{
    using Chess.Common;
    using ChessEngine;

    public class EntryPointGame : IEntryPointGame
    {
        private const int x = 0;
        private const int y = 19;
        private int startWidth = 0;
        private int startHeight = 2;
        private int initilizationValueY = 3;

        public void Start()
        {
            bool isGameOverPlayer = false;

            UserData userData = new UserData();
            string selectedFigureOfUser = userData.InputUserData();

            Player firstPlayer = new Player();
            
            Board board = new Board();
            board.LoadingFigures();

            board.InitilizateBoard(startWidth, startHeight);
            DrawingBoardConsole.DrawFigureOfBoard(selectedFigureOfUser, initilizationValueY);
            bool isTriedWrongMoveUser = false;

            while (!isGameOverPlayer)
            {
                ViewUser.SetCursorPosition(x, y);
                ViewUser.MessageUser("Enter your move: ");

                string moveUser = ViewUser.ConsoleReadLine();

                if (!Contracts.IsValidMoveOfUser(moveUser))
                {
                    ViewUser.ConsoleClear();
                    ViewUser.ViewUserInvalidMovementMessage();
                    board.LoadingFigures();
                    isTriedWrongMoveUser = true;
                }
                else
                {
                    if (isTriedWrongMoveUser)
                    {
                        ViewUser.ConsoleClear();
                        board.LoadingFigures();
                    }
                    else
                    {
                        UserData.GetParseInputUser(moveUser);
                    }
                }
            }
        }
        
    }
}
