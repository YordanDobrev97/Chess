namespace ChessEngine.Board.Figures
{
    public interface IFigure
    {
        string StringRepresentation { get; }

        string Name { get; set; }
    }
}
