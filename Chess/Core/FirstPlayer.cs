namespace Chess
{
    using Chess.Common;
    using Chess.Figures;
    using Chess.Interfaces;
    using System.Collections.Generic;

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
            this.Figures.Add(new Rook());
            this.Figures.Add(new Knight());
            this.Figures.Add(new Bishop());
            this.Figures.Add(new Queen());
            this.Figures.Add(new King());
            this.Figures.Add(new Bishop());
            this.Figures.Add(new King());
            this.Figures.Add(new Rook());

            for (int i = 0; i < 8; i++)
            {
                this.Figures.Add(new Pawn());
            }

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
