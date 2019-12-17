namespace Chess.Core
{
    using Chess.Common;
    using Chess.Figures;
    using Chess.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class SecondPlayer : IPlayer
    {
        private Color color;

        public SecondPlayer(string name, Color color)
        {
            this.Name = name;
            this.color = color;
            this.Figures = new List<IFigure>();
            GlobalConstants.FiguresOfSecondPlayer = Figures;
        }

        public string Name { get; set; }

        public List<IFigure> Figures { get; set; }

        public Color Color { get; }

        public void SaveCoordinates()
        {
            for (int i = 0; i < 8; i++)
            {
                var pawn = new Pawn(this);
                this.Figures.Add(pawn);
            }

            this.Figures.Add(new Rook());
            this.Figures.Add(new Knight());
            this.Figures.Add(new Bishop(this,new Position()));
            this.Figures.Add(new Queen());
            this.Figures.Add(new King());
            this.Figures.Add(new Bishop(this,new Position()));
            this.Figures.Add(new Knight());
            this.Figures.Add(new Rook());

            AddColorOfFigures();

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

        private void AddColorOfFigures()
        {
            foreach (var item in this.Figures)
            {
                var currentFigure = item;
                currentFigure.Color = Color.Yellow;
            }
        }
    }
}
