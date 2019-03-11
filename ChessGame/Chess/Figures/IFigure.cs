using System.Collections.Generic;

namespace ChessEngine.Engine.Figures
{
    public interface IFigure
    {
        string Name { get; }

        List<string> ValidMoves { get; }

        void AddValidMove();
    }
}
