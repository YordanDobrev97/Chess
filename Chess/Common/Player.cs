using Chess.Common;
using Chess.Figures;
using Chess.Interfaces;
using System.Collections.Generic;

namespace Chess
{
    public class Player
    {
        public Player(string name)
        {
            this.Name = name;
            this.Figures = new List<IFigure>();
        }

        public string Name { get; set; }

        public List<IFigure> Figures { get; set; }

        public void SaveCoordinatesOfSecondPlayer()
        {
            for (int i = 0; i < 8; i++)
            {
                this.Figures.Add(new Pawn());
            }

            this.Figures.Add(new Rook());
            this.Figures.Add(new Knight());
            this.Figures.Add(new Bishop());
            this.Figures.Add(new Queen());
            this.Figures.Add(new King());
            this.Figures.Add(new Bishop());
            this.Figures.Add(new King());
            this.Figures.Add(new Rook());


            int startValuePawnPosition = GlobalConstants.StartValuePawnPosition;

            for (int i = 0; i < GlobalConstants.EndRowOfBoard; i++)
            {
                var currentPawn = this.Figures[i];
                currentPawn.Position.Width = startValuePawnPosition;
                currentPawn.Position.Height = GlobalConstants.CurrentPawnPositionHeight;
                startValuePawnPosition += GlobalConstants.IncrementStartValuePawnPosition;
            }

            int startIndex = GlobalConstants.EndRowOfBoard;
            int positionFigure = GlobalConstants.StartValuePawnPosition;

            for (int i = 0; i < GlobalConstants.EndRowOfBoard; i++)
            {
                var currentFigure = this.Figures[startIndex];
                currentFigure.Position.Width = positionFigure;
                currentFigure.Position.Height = GlobalConstants.PositionHeight;
                positionFigure += GlobalConstants.IncrementStartValuePawnPosition;
                startIndex++;
            }
        }

        public void SaveCoordinatesOfFirstPlayer()
        {
            for (int i = 0; i < 8; i++)
            {
                this.Figures.Add(new Pawn());
            }

            this.Figures.Add(new Rook());
            this.Figures.Add(new Knight());
            this.Figures.Add(new Bishop());
            this.Figures.Add(new Queen());
            this.Figures.Add(new King());
            this.Figures.Add(new Bishop());
            this.Figures.Add(new King());
            this.Figures.Add(new Rook());

            int startDefaultPosition = GlobalConstants.StartValuePawnPosition;

            for (int i = 0; i < GlobalConstants.EndRowOfBoard; i++)
            {
                var figure = this.Figures[i];
                figure.Position.Width = startDefaultPosition;
                figure.Position.Height = 2;
                startDefaultPosition += GlobalConstants.IncrementStartValuePawnPosition;
            }

            int pawnStartValue = GlobalConstants.StartValuePawnPosition;
            int startIndex = GlobalConstants.EndRowOfBoard;
            for (int i = 0; i < GlobalConstants.EndRowOfBoard; i++)
            {
                var pawn = this.Figures[startIndex];
                pawn.Position.Width = pawnStartValue;
                pawn.Position.Height = GlobalConstants.StartValuePawnPosition;
                pawnStartValue += GlobalConstants.IncrementStartValuePawnPosition;
                startIndex++;
            }
        }
    }
}
