using Chess.Figures;
using Chess.Interfaces;
using System.Collections.Generic;

namespace ChessEngine.Engine.Figures
{
    public class Rook : ISymbolRepresentation, IFigure, IRule
    {
        public string Representation => Constants.RookRepresentation;
        public string Name => "Rook";
        public int Healt => Constants.HealFigure;

        public string RulePerMove { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
