namespace Chess
{
    using Chess.Figures;
    using Chess.Interfaces;
    using System;
    using System.Linq;

    public class Board
    {
        public Board(IPlayer firstPlayer, IPlayer secondPlayer, int size)
        {
            this.FirstPlayer = firstPlayer;
            this.SecondPlayer = secondPlayer;
            this.BoardSize = size;
        }

        public int BoardSize { get; }
        public IPlayer FirstPlayer { get; }
        public IPlayer SecondPlayer { get; }

        public IPlayer Winner { get; private set; }

        public bool MoveFigure(string currentPosition, string newPosition, IPlayer currentPlayer)
        {
            //check for InBoard
            var currentPos = new Position(currentPosition);
            if (!IsInBoard(currentPos)) throw new ArgumentException($"Coordinates otside board {currentPosition}");
            var newPos = new Position(newPosition);
            if (!IsInBoard(newPos)) throw new ArgumentException($"Coordinates otside board {newPosition}");

            //Check for current Figure
            // To Do ovveride the Equals func of Possition class for better comparation
            IFigure figure = currentPlayer.Figures.FirstOrDefault
                (x => x.Position.Width == currentPos.Width &&
                x.Position.Height == currentPos.Height);

            if (figure == null) throw new ArgumentException($"Player {currentPlayer.Name} doesn't have figure on {currentPosition}");

            //Move Figure
            if (figure.Move(new Position(newPosition), this))
            {
                // Basic check to take other player figure
                IPlayer oppositePlayer = GetOppositePlayer(currentPlayer);
                IFigure checkFigure = oppositePlayer.Figures.FirstOrDefault
                    (x => x.Position.Width == newPos.Width 
                    && x.Position.Height == newPos.Height);
                if (checkFigure != null)
                {
                    oppositePlayer.Figures.Remove(checkFigure);
                    currentPlayer.FiguresTaken.Add(checkFigure.StringRepresentation);
                    if (checkFigure is King) this.Winner = currentPlayer;
                }
                return true;
            }
            throw new ArgumentException($"Figure {figure.StringRepresentation}  on {currentPosition} cannot move to {newPosition}! Please follow chess rules!");
           // return false;
        }

        private IPlayer GetOppositePlayer(IPlayer currentPlayer)
        {
            if (this.FirstPlayer == currentPlayer) return this.SecondPlayer;
            return this.FirstPlayer;
        }

        private bool IsInBoard(Position checkPos)
        {
            if (this.BoardSize < checkPos.Height+1 || this.BoardSize < checkPos.Width) return false;
            if (checkPos.Height < 0 || checkPos.Width < 0) return false;
            return true;
        }
    }
}