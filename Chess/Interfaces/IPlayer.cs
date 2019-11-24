using System.Collections.Generic;

namespace Chess.Interfaces
{
    public interface IPlayer
    {
        string Name { get; set; }

        List<IFigure> Figures { get; set; }

        void SaveCoordinates();
    }
}
