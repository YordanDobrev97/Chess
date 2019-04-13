using ChessEngine.Board.Figures;
using ChessEngine.Common;
using System.Collections.Generic;

namespace ChessEngine.Board
{
    public class Board
    {
        private readonly IFigure[,] IFigure = 
            new IFigure[StandartConstants.SIZE_ROW_BOARD,StandartConstants.SIZE_COL_BOARD];

        private Dictionary<IFigure[], Point> freeCoordinates = new Dictionary<IFigure[], Point>();

        public void SaveCordinatesFigure(IFigure figure)
        {
            
        }

    }
}
