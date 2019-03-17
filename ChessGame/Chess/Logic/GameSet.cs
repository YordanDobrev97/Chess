namespace Chess.Logic
{
    using Chess.Common;
    using ChessEngine;

    public static class GameSet
    {
        private const int x = 0;
        private const int y = 19;

        public static void Start()
        {
            bool isGameOverPlayer = false;

            UserData userData = new UserData();
            string selectedUserFigure = userData.InputUserData();

            Player firstPlayer = new Player();
            Player secondPlayer = new Player();

            Board board = new Board();
            board.LoadingGame();

            bool isTriedWrongMoveUser = false;

            while (!isGameOverPlayer)
            {
                ViewUser.SetCursorPosition(x, y);
                ViewUser.MessageUser("Enter your move: ");

                string moveUser = ViewUser.ConsoleReadLine();

                if (!Contracts.IsValidMoveOfUser(moveUser))
                {
                    ViewUser.ConsoleClear();
                    ViewUser.ViewUserInvalidMoveMessage();
                    board.LoadingGame();
                    isTriedWrongMoveUser = true;
                }
                else
                {
                    if (isTriedWrongMoveUser)
                    {
                        ViewUser.ConsoleClear();
                        board.LoadingGame();
                    }
                    else
                    {
                        UserData.MoveFigure(moveUser);
                    }
                }
            }
        }
        
    }
}
