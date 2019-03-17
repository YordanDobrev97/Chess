
namespace ChessEngine.Engine.Figures
{
    using System.Collections.Generic;
    using Chess.Figures;
    using Chess.Interfaces;

    public class Horse : ISymbolRepresentation, IFigure, IRule
    {
        public string Representation => Constants.HorseRepresentation;

        public string Name => "Horse";

        public int Healt => Constants.HealFigure;

        public string RulePerMove { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
