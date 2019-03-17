namespace ChessEngine.Engine.Figures
{
    using System.Collections.Generic;
    using Chess.Figures;
    using Chess.Interfaces;

    public class King : ISymbolRepresentation, IFigure, IRule
    {
        public string Representation => Constants.KingRepresentation;
        public string Name => "King";
        public int Healt => Constants.HealFigure;

        public string RulePerMove { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
