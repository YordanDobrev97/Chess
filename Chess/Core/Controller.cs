namespace Chess
{
    using Chess.Common;
    using Chess.Interfaces;
    using Chess.IO;
    using System;

    public class Controller
    {
        private IPlayer firstPlayer;
        private IPlayer secondPlayer;
        private Board board;
        private IPlayer currentPlayer;
        private Painter painter; // needs IPainter - ConsolePainter

        public Controller(Board board, Painter painter)
        {
            this.firstPlayer = board.FirstPlayer;
            this.secondPlayer = board.SecondPlayer;
            this.currentPlayer = board.FirstPlayer;
            this.board = board;
            this.painter = painter;
        }

        public void Start()
        {
            while (true)
            {
                ConsoleIO.SetCursorPositionConsole(GlobalConstants.CursorWidthPositionOfConsole,
                        GlobalConstants.CursorHeightPositionOfConsole);

                Console.ForegroundColor = ConsoleColor.White;
                ConsoleIO.WriteConsole($"{currentPlayer.Name} - You're on the move ");

                string[] userMove = ConsoleIO.ReadFromConsole().Split();
                string currentPosition = userMove[0];
                string newPosition = userMove[1];

                try
                {
                    board.MoveFigure(currentPosition, newPosition, this.currentPlayer == firstPlayer);
                    ConsoleIO.ClearConsole();
                    painter.DrawBoard(board);

                    if (this.currentPlayer == firstPlayer) this.currentPlayer = secondPlayer;
                    else this.currentPlayer = firstPlayer;
                }
                catch (System.Exception exception)
                {
                    ConsoleIO.SetCursorPositionConsole(1, 28);
                    Console.ForegroundColor = ConsoleColor.Red;
                    ConsoleIO.WriteConsole(exception.Message);
                    ConsoleIO.Sleep(3000);
                    ConsoleIO.ClearConsole();
                    Console.ForegroundColor = ConsoleColor.White;
                    painter.DrawBoard(board);
                }
            }
        }
    }
}
