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
        private IPainter painter;

        public Controller(Board board, IPainter painter)
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
                this.painter.DrawMessage($"{currentPlayer.Name} - You're on the move ");

                string[] userMove = ConsoleIO.ReadFromConsole().Split(); 

                try
                {
                    string currentPosition = userMove[0];
                    string newPosition = userMove[1];
                    if (board.MoveFigure(currentPosition, newPosition, currentPlayer))
                    {
                        painter.DrawBoard(board);

                        //swap player if move is valid
                        if (this.currentPlayer == firstPlayer) this.currentPlayer = secondPlayer;
                        else this.currentPlayer = firstPlayer;
                    }
                }
                catch (System.Exception exception)
                {
                    painter.DrawErrorMessage(exception.Message);
                    ConsoleIO.Sleep(3000);
                    painter.DrawBoard(board);
                }
            }
        }
    }
}
