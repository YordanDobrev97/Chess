namespace Chess.Core
{
    using Chess.Common;
    using Chess.Figures;
    using Chess.Interfaces;
    using System.Collections.Generic;

    public class SecondPlayer : IPlayer
    {
        public SecondPlayer(string name, Color color)
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

            this.Figures.Add(new Rook(this, new Position("a8")));
            this.Figures.Add(new Knight(this, new Position("b8")));
            this.Figures.Add(new Bishop(this,new Position("c8")));
            this.Figures.Add(new Queen(this, new Position("d8")));
            this.Figures.Add(new King(this, new Position("e8")));
            this.Figures.Add(new Bishop(this,new Position("f8")));
            this.Figures.Add(new Knight(this, new Position("g8")));
            this.Figures.Add(new Rook(this, new Position("h8")));

            for (int i = 0; i < 8; i++)
            {
                var currentWidth = 'a' + i;
                var pawn = new Pawn(this, new Position($"{(char)currentWidth}7"));
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
