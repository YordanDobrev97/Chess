namespace Chess
{
    using Chess.Common;
    using Chess.Interfaces;
    using Chess.IO;

    public class Controller
    {
        private IPlayer peshoPlayer;
        private IPlayer goshoPlayer;
        private Board board;
        private IPlayer currentPlayer;

        public Controller(IPlayer peshoPlayer, IPlayer goshoPlayer, IPlayer currentPlayer, Board board)
        {
            this.peshoPlayer = peshoPlayer;
            this.goshoPlayer = goshoPlayer;
            this.currentPlayer = currentPlayer;
            this.board = board;
        }

        public void Start()
        {
            while (true)
            {
                ConsoleIO.SetCursorPositionConsole(GlobalConstants.CursorWidthPositionOfConsole,
                        GlobalConstants.CursorHeightPositionOfConsole);

                ConsoleIO.WriteConsole($"{currentPlayer.Name} You're on the move ");

                string[] userMove = ConsoleIO.ReadFromConsole().Split();
                string currentPosition = userMove[0];
                string newPosition = userMove[1];

                try
                {
                    board.MoveFigure(currentPosition,  newPosition,GlobalConstants.IsFirstPlayer);

                    ConsoleIO.ClearConsole();
                    Painter.DrawBoard();
                    Painter.DrawFigures(false, peshoPlayer, 0);
                    Painter.DrawFigures(false, goshoPlayer, 1);

                    if (GlobalConstants.IsFirstPlayer)
                    {
                        GlobalConstants.IsFirstPlayer = false;
                        currentPlayer = peshoPlayer;
                    }
                    else
                    {
                        GlobalConstants.IsFirstPlayer = true;
                        currentPlayer = goshoPlayer;
                    }
                }
                catch (System.Exception exception)
                {
                    ConsoleIO.SetCursorPositionConsole(82, 5);
                    ConsoleIO.WriteConsole(exception.Message);
                    ConsoleIO.Sleep(3000);
                    ConsoleIO.ClearConsole();
                    Painter.DrawBoard();
                    Painter.DrawFigures(true, peshoPlayer, 0);
                    Painter.DrawFigures(true, goshoPlayer, 1);
                }
            }
        }
    }
}
