namespace ChessEngine.Engine.Figures
{
    using Chess.Common;
    using Chess.Figures;
    using Chess.Interfaces;

    public class Pawn : ISymbolRepresentation, IFigure, IMoving
    {
        private const int MAX_MOVE = 2;
        public Pawn()
        {
        }

        public string Representation => Constants.PawnRepresentation;
        public string Name => "Pawn";
        public int Healt => Constants.HealFigure;

        public void Move(int count)
        {
            if (count > MAX_MOVE)
            {
                ViewUser.MessageUser("Invalid Move Of Pawn");
            }
            else
            {
                ViewUser.SetCursorPosition(2, 15);

            }
        }

        public void Validate()
        {
            
        }
    }
}
