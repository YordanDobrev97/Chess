using System.Collections.Generic;

namespace ChessEngine.Board.Figures
{
    public interface IFigure
    {
        string StringRepresentation { get; }

        string Name { get; set; }

        bool IsBeginState { get; }
    }
}
