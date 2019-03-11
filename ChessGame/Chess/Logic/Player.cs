using ChessEngine.Engine.Figures;

namespace Chess
{
    public class Player
    {
        private Rook firstRook;
        private Horse firstHorse;
        private Officer firstOfficer;
        private Queen queen;
        private King king;
        private Officer secondOfficer;
        private Horse secondHorse;
        private Rook secondRook;
        private Pawn pawn;

        public Player()
        {
            this.firstRook = new Rook();
            this.firstHorse = new Horse();
            this.firstOfficer = new Officer();
            this.queen = new Queen();
            this.king = new King();
            this.secondOfficer = new Officer();
            this.secondHorse = new Horse();
            this.secondRook = new Rook();
            this.pawn = new Pawn();
        }
    }
}
