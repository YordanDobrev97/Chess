namespace Chess.Logic
{
    using Chess.Common;

    public class MovementEngine
    {
        public static void MovePawn(int position, int top)
        {
            ViewUser.ConsoleClear();

            string chooseOfUser = UserData.ChooseFigureOfUser;
            DrawingBoardConsole.DrawFigureOfBoard(chooseOfUser, 3);
        }
    }
}
