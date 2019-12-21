namespace Chess
{
    using Chess.Common;
    using Chess.Figures;
    using Chess.Interfaces;
    using System;
    using System.Collections.Generic;

    public class FirstPlayer : IPlayer
    {
        public FirstPlayer(string name, Color color)
        {
            this.Name = name;
            this.Color = color;
            this.Figures = new List<IFigure>();
            this.FiguresTaken = new List<string>();
        }

        public string Name { get; set; }

        public List<IFigure> Figures { get; set; }

        public List<string> FiguresTaken { get; set; }

        public Color Color { get; }

        public void SaveCoordinates()
        {
            var firstRook = new Rook(this,new Position("a1"));
            var firstKnight = new Knight(this, new Position("b1"));
            var firstBishop = new Bishop(this,new Position("c1"));
            var queen = new Queen(this, new Position("d1"));
            var king = new King(this, new Position("e1"));
            var secondBishop = new Bishop(this,new Position("f1"));
            var secondKnight = new Knight(this, new Position("g1"));
            var secondRook = new Rook(this, new Position("h1"));

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
                var currentWidth = 'a' + i;
                var pawn = new Pawn(this,new Position($"{(char)currentWidth}2"));
                pawn.HasInitialState = true;
                this.Figures.Add(pawn);
            }

            AddColorOfFigures();           
        }

        private void AddColorOfFigures()
        {
            foreach (var item in this.Figures)
            {
                item.Color = this.Color;
            }
        }
    }
}
