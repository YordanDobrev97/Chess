using Chess.Common;
using Chess.IO;

namespace Chess
{
    public class Controller
    {
        private Player peshoPlayer;
        private Player goshoPlayer;
        private Board board;
        private Player currentPlayer;

        public Controller(Player peshoPlayer, Player goshoPlayer, Player currentPlayer, Board board)
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
                Painter.SetCursorPositionConsole(GlobalConstants.CursorWidthPositionOfConsole,
                    GlobalConstants.CursorHeightPositionOfConsole);

                ConsoleIO.WriteConsole($"{currentPlayer.Name} You're on the move ");

                string[] userMove = ConsoleIO.ReadFromConsole().Split();
                string currentPosition = userMove[0];
                string newPosition = userMove[1];

                try
                {
                    board.MoveFigure(currentPlayer, currentPosition,  newPosition,GlobalConstants.IsFirstPlayer);

                    Painter.ClearConsole();
                    Painter.DrawBoard();
                    Painter.DrawFigures(false, peshoPlayer);
                    Painter.DrawFigures(false, goshoPlayer);

                    if (GlobalConstants.IsFirstPlayer)
                    {
                        GlobalConstants.IsFirstPlayer = false;
                        currentPlayer = goshoPlayer;
                    }
                    else
                    {
                        GlobalConstants.IsFirstPlayer = true;
                        currentPlayer = peshoPlayer;
                    }
                }
                catch (System.Exception exception)
                {
                    Painter.ClearConsole();
                    Painter.DrawBoard();
                    Painter.DrawFigures(!GlobalConstants.DefaultSaveCordinatesFigures, currentPlayer);
                    Painter.SetCursorPositionConsole(GlobalConstants.CursorWidthPositionOfConsole,
                        GlobalConstants.CursorHeightPositionOfConsole + 2);
                    ConsoleIO.WriteConsole(exception.Message);
                }
            }
        }
    }
}