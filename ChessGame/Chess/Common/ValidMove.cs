using System.Collections.Generic;

namespace Chess.Common
{
    public class ValidMove
    {
        List<string> validMovePerPawn { get; set; }

        private void AddValidMovePawn()
        {
            for (int i = 1; i <=8; i++)
            {
                this.validMovePerPawn.Add($"P{i}");
            }
        }
    }
}
