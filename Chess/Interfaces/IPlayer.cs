using System.Collections.Generic;
using Chess.Common;

namespace Chess.Interfaces
{
    public interface IPlayer
    {
        string Name { get; set; }

        Color Color { get; }
        List<IFigure> Figures { get; set; }

        void SaveCoordinates();
    }
}
