using Chess.Common;

namespace Chess
{
    public abstract class Controller
    {
        private static bool isFirstPlayer = true;

        public static void Start()
        {
            SystemSetting.SetSettingOfFontMsGothic();
            Painter.DrawBoard();
            Painter.DrawFigures(true);
            Painter.DrawFieldWithAliveFigures();

            Board board = new Board();

            Player peshoPlayer = new Player("Pesho");
            Player goshoPlayer = new Player("Gosho");

            Painter.GetPlayerName(peshoPlayer);

            string player = peshoPlayer.Name;

            while (true)
            {
                Painter.SetCursorPositionConsole(GlobalConstants.CursorWidthPositionOfConsole,
                    GlobalConstants.CursorHeightPositionOfConsole);

                Painter.WriteConsole($"{player} You're on the move ");

                string[] userMove = Painter.ReadFromConsole().Split();
                string currentPosition = userMove[0];
                string newPosition = userMove[1];

                try
                {
                    board.MoveFigure(currentPosition, newPosition, isFirstPlayer);

                    if (isFirstPlayer)
                    {
                        isFirstPlayer = false;
                        player = goshoPlayer.Name;
                    }
                    else
                    {
                        isFirstPlayer = true;
                        player = peshoPlayer.Name;
                    }

                    Painter.DrawFieldWithAliveFigures();
                }
                catch (System.Exception exception)
                {
                    Painter.ClearConsole();
                    Painter.DrawBoard();
                    Painter.DrawFigures(!GlobalConstants.DefaultSaveCordinatesFigures);
                    Painter.SetCursorPositionConsole(GlobalConstants.CursorWidthPositionOfConsole,
                        GlobalConstants.CursorHeightPositionOfConsole + 2);
                    Painter.WriteConsole(exception.Message);
                }   
            }
        }

        public static void SaveDefaultCoordinatesFigures()
        {
            CoordinatesOfFirstPlayer();

            CoordinatesOfSecondPlayer();
        }

        private static void CoordinatesOfSecondPlayer()
        {
            int startValuePawnPosition = GlobalConstants.StartValuePawnPosition;

            for (int i = 0; i < GlobalConstants.EndRowOfBoard; i++)
            {
                var currentPawn = Painter.figuresOfSecondPlayer[i];
                currentPawn.Position.Width = startValuePawnPosition;
                currentPawn.Position.Height = GlobalConstants.CurrentPawnPositionHeight;
                startValuePawnPosition += GlobalConstants.IncrementStartValuePawnPosition;
            }

            int startIndex = GlobalConstants.EndRowOfBoard;
            int positionFigure = GlobalConstants.StartValuePawnPosition;

            for (int i = 0; i < GlobalConstants.EndRowOfBoard; i++)
            {
                var currentFigure = Painter.figuresOfSecondPlayer[startIndex];
                currentFigure.Position.Width = positionFigure;
                currentFigure.Position.Height = GlobalConstants.PositionHeight;
                positionFigure += GlobalConstants.IncrementStartValuePawnPosition;
                startIndex++;
            }
        }

        private static void CoordinatesOfFirstPlayer()
        {
            int startDefaultPosition = GlobalConstants.StartValuePawnPosition;

            for (int i = 0; i < GlobalConstants.EndRowOfBoard; i++)
            {
                var figure = Painter.figuresOfFirstPlayer[i];
                figure.Position.Width = startDefaultPosition;
                figure.Position.Height = 2;
                startDefaultPosition += GlobalConstants.IncrementStartValuePawnPosition;
            }

            int pawnStartValue = GlobalConstants.StartValuePawnPosition;
            int startIndex = GlobalConstants.EndRowOfBoard;
            for (int i = 0; i < GlobalConstants.EndRowOfBoard; i++)
            {
                var pawn = Painter.figuresOfFirstPlayer[startIndex];
                pawn.Position.Width = pawnStartValue;
                pawn.Position.Height = GlobalConstants.StartValuePawnPosition; ;
                pawnStartValue += GlobalConstants.IncrementStartValuePawnPosition;
                startIndex++;
            }
        }
    }
}