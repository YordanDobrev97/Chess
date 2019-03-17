namespace ChessEngine.Engine.Figures
{
    using System.Collections.Generic;
    using Chess.Figures;
    using Chess.Interfaces;

    public class Officer : ISymbolRepresentation, IFigure, IRule
    {
        public string Representation => Constants.OfficerRepresentation;
        public string Name => "Officer";
        public int Healt => Constants.HealFigure;

        public string RulePerMove { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
