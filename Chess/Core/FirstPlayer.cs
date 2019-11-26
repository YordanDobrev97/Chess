namespace Chess
{
    using Chess.Common;
    using Chess.Figures;
    using Chess.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FirstPlayer : IPlayer
    {
        private Color color;

        public FirstPlayer(string name, Color color)
        {
            this.Name = name;
            this.color = color;
            this.Figures = new List<IFigure>();
        }

        public string Name { get; set; }

        public List<IFigure> Figures { get; set; }

        public void SaveCoordinates()
        {
            var firstRook = new Rook();
            var firstKnight = new Knight();
            var firstBishop = new Bishop();
            var queen = new Queen();
            var king = new King();
            var secondBishop = new Bishop();
            var secondKnight = new Knight();
            var secondRook = new Rook();

            this.Figures.Add(firstRook);
            this.Figures.Add(firstKnight);
            this.Figures.Add(firstBishop);
            this.Figures.Add(queen);
            this.Figures.Add(king);
            this.Figures.Add(secondBishop);
            this.Figures.Add(secondKnight);
            this.Figures.Add(secondRook);

            for (int i = 0; i < 8; i++)
            {
                var pawn = new Pawn();
                this.Figures.Add(pawn);
            }

            AddColorOfFigures();

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

        private void AddColorOfFigures()
        {
            foreach (var item in this.Figures)
            {
                var currentFigure = item;
                currentFigure.Color = Color.DarkYellow;
            }
        }
    }
}
