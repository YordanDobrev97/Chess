namespace Chess
{
    public abstract class Controller
    {
        private static bool isFirstPlayer = true;
        public const int DEFAULT_VALUE = 8;
        public static void Start()
        {
            SystemSetting.SetSettingOfFontMsGothic();
            Painter.DrawBoard();
            Painter.DrawFigures(true);
            Painter.DrawFieldWithAliveFigures();

            Board board = new Board();

            Player peshoPlayer = new Player("Pesho");
            Player goshoPlayer = new Player("Gosho");
            string player = peshoPlayer.Name;

            while (true)
            {
                Painter.SetCursorPositionConsole(2, 27);
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
                    Painter.DrawFigures(false);
                    Painter.SetCursorPositionConsole(2, 29);
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
            int startValuePawnPosition = 5;
            for (int i = 0; i < 8; i++)
            {
                var currentPawn = Painter.figuresOfSecondPlayer[i];
                currentPawn.Position.Width = startValuePawnPosition;
                currentPawn.Position.Height = 20;
                startValuePawnPosition += 10;
            }

            int startIndex = 8;
            int positionFigure = 5;
            for (int i = 0; i < 8; i++)
            {
                var currentFigure = Painter.figuresOfSecondPlayer[startIndex];
                currentFigure.Position.Width = positionFigure;
                currentFigure.Position.Height = 23;
                positionFigure += 10;
                startIndex++;
            }
        }

        private static void CoordinatesOfFirstPlayer()
        {
            int startDefaultPosition = 5;
            for (int i = 0; i < 8; i++)
            {
                var figure = Painter.figuresOfFirstPlayer[i];
                figure.Position.Width = startDefaultPosition;
                figure.Position.Height = 2;
                startDefaultPosition += 10;
            }

            //save coordinates of pawns
            int pawnStartValue = 5;
            int startIndex = 8;
            for (int i = 0; i < 8; i++)
            {
                var pawn = Painter.figuresOfFirstPlayer[startIndex];
                pawn.Position.Width = pawnStartValue;
                pawn.Position.Height = 5;
                pawnStartValue += 10;
                startIndex++;
            }
        }
    }
}