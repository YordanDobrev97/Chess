namespace ChessEngine.Board.Figures
{
    public class Кnight : IFigure
    {
        public Кnight(string name)
        {
            this.Name = name;
        }
        public string StringRepresentation => "♘";

        public string Name { get; set; }
    }
}
