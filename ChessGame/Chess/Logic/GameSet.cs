namespace Chess.Logic
{
    using Chess.Common;
    using ChessEngine;

    public class GameSet : IGameSet
    {
        private const int x = 0;
        private const int y = 19;

        public void Start()
        {
            bool isGameOverPlayer = false;

            UserData userData = new UserData();
            string selectedFigure = userData.InputUserData();

            Player firstPlayer = new Player();
            
            Board board = new Board();
            board.LoadingBoard();

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
                    board.LoadingBoard();
                    isTriedWrongMoveUser = true;
                }
                else
                {
                    if (isTriedWrongMoveUser)
                    {
                        ViewUser.ConsoleClear();
                        board.LoadingBoard();
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
