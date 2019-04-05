namespace ChessEngine.Board.Figures
{
    public class Bishop : IFigure
    {
        public Bishop(string name)
        {
            this.Name = name;
        }

        public string StringRepresentation => "♗";

        public string Name { get; set; }
    }
}
