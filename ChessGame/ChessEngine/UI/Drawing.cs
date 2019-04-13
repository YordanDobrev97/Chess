namespace ChessEngine.UI
{
    using ChessEngine.Board.Figures;
    using ChessEngine.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Drawing
    {
        private const int MAX_FIGURE_TOTAL = 32;
        private int numericsOfBoardRow = 8;
        private char letterOfBoardCol = 'a';
        private int numericXValue = 0;
        private int numericYValue = 2;
        private int startXLetterOfBoard = 5;
        private int postionFigureX = 5;
        private int postionFigureY = 2;
        private bool isLastRowForPrintLetterOfBoardConsole = false;
        private const int DEFAULT_VALUE = 2;
        private int SIZE_ROW = StandartConstants.SIZE_ROW_BOARD;
        private int SIZE_COLUM = StandartConstants.SIZE_COL_BOARD;
        private int startPointX = 2;
        private int startPointY = 1;
        private int postion = 0;
        private bool isCanCordinateFigure = false;
        private bool isFirstPlayer = true;
        private bool isAddingAllFigures = false;
        private static Dictionary<List<IFigure>, Point> cordinatesFigures;

        public Drawing()
        {
            cordinatesFigures = new Dictionary<List<IFigure>, Point>();
            this.isAddingAllFigures = cordinatesFigures.Count == MAX_FIGURE_TOTAL;
        }

        /// <summary>
        /// Returns cordinates of figures
        /// </summary>
        public static Dictionary<List<IFigure>, Point> CordinatesFigures
        {
            get
            {
                return cordinatesFigures;
            }
            set
            {
                cordinatesFigures = value ?? throw new ArgumentException("Value not can be null!");
            }
        }

        public static bool IsCanChangeCordinatesOfFigures { get; set; }

        /// <summary>
        /// Drawing figures of console
        /// </summary>
        public void DrawPlayground()
        {
            startPointX = 2;
            startPointY = 1;
            postion = 0;
            postionFigureX = 5;
            postionFigureY = 2;
            this.isAddingAllFigures = cordinatesFigures.Count == MAX_FIGURE_TOTAL;

            var figuresFront = GetFiguresOfPlayer(true);

            var figuresBack = GetFiguresOfPlayer(false);

            for (int row = 1; row <= SIZE_ROW; row++)
            {
                if (row == SIZE_ROW)
                {
                    isLastRowForPrintLetterOfBoardConsole = true;
                }

                DrawBox(startPointX, startPointY);

                if (IsCanSaveCordinateFirstPlayer(row) && !isAddingAllFigures)
                {
                    SaveFigureCordinates(figuresFront, postion, postionFigureX, postionFigureY);
                    postionFigureX += 9;
                    postion++;
                    isCanCordinateFigure = true;
                }
                else if (IsCanSaveCordinateSecondPlayer(row) && !isAddingAllFigures)
                {
                    isFirstPlayer = false;
                    SaveFigureCordinates(figuresBack, postion, postionFigureX, postionFigureY);
                    postionFigureX += 9;
                    postion++;
                    isCanCordinateFigure = true;
                }
                else
                {
                    postion = 0;
                    isCanCordinateFigure = false;
                }

                //DrawNumerics(numericXValue, numericYValue, numericsOfBoardRow);
                for (int i = 1; i < SIZE_COLUM; i++)
                {
                    startPointX += 9;
                    DrawBox(startPointX, startPointY);

                    if (isCanCordinateFigure)
                    {
                        if (isFirstPlayer)
                        {
                            SaveFigureCordinates(figuresFront, postion, postionFigureX, postionFigureY);
                        }
                        else
                        {
                            SaveFigureCordinates(figuresBack, postion, postionFigureX, postionFigureY);
                        }
                        postionFigureX += 9;
                        postion++;

                    }

                    //DrawCurrentLetter(isLastRowForPrintLetterOfBoardConsole,
                    //    startXLetterOfBoard, startPointY, letterOfBoardCol);

                    //if (isLastRowForPrintLetterOfBoardConsole)
                    //{
                    //    startXLetterOfBoard += 9;
                    //    letterOfBoardCol++;
                    //}

                    //if (i == 7 && row == SIZE_ROW)
                    //{
                    //    DrawCurrentLetter(isLastRowForPrintLetterOfBoardConsole,
                    //    startXLetterOfBoard, startPointY, letterOfBoardCol);
                    //}
                }

                postionFigureX = 5;
                postionFigureY += 3;
                startPointX = DEFAULT_VALUE;
                startPointY += 3;
                numericYValue += 3;
                numericsOfBoardRow--;
                Console.WriteLine();
            }
        }

        private static IFigure[] GetFiguresOfPlayer(bool isFirstPlayer)
        {
            var backFlagFigure = isFirstPlayer ? "Front" : "Back";

            if (isFirstPlayer)
            {
                return new IFigure[]
               {
                    new Rook($"Rook1{backFlagFigure}"),
                    new Кnight($"Knight1{backFlagFigure}"),
                    new Bishop($"Bishop1{backFlagFigure}"),
                    new Queen($"Queen{backFlagFigure}"),
                    new King($"King{backFlagFigure}"),
                    new Bishop($"Bishop2{backFlagFigure}"),
                    new Кnight($"Knight2{backFlagFigure}"),
                    new Rook($"Rook2{backFlagFigure}"),
                    new Pawn($"Pawn1{backFlagFigure}"),
                    new Pawn($"Pawn2{backFlagFigure}"),
                    new Pawn($"Pawn3{backFlagFigure}"),
                    new Pawn($"Pawn4{backFlagFigure}"),
                    new Pawn($"Pawn5{backFlagFigure}"),
                    new Pawn($"Pawn6{backFlagFigure}"),
                    new Pawn($"Pawn7{backFlagFigure}"),
                    new Pawn($"Pawn8{backFlagFigure}"),
                };
            }

            return new IFigure[]
            {
                new Pawn($"Pawn1{backFlagFigure}"),
                new Pawn($"Pawn2{backFlagFigure}"),
                new Pawn($"Pawn3{backFlagFigure}"),
                new Pawn($"Pawn4{backFlagFigure}"),
                new Pawn($"Pawn5{backFlagFigure}"),
                new Pawn($"Pawn6{backFlagFigure}"),
                new Pawn($"Pawn7{backFlagFigure}"),
                new Pawn($"Pawn8{backFlagFigure}"),
                new Rook($"Rook1{backFlagFigure}"),
                new Кnight($"Knight1{backFlagFigure}"),
                new Bishop($"Bishop1{backFlagFigure}"),
                new Queen($"Queen{backFlagFigure}"),
                new King($"King{backFlagFigure}"),
                new Bishop($"Bishop2{backFlagFigure}"),
                new Кnight($"Knight2{backFlagFigure}"),
                new Rook($"Rook2{backFlagFigure}"),
            };
        }

        internal static object GetProperty(Drawing obj, string nameProperty)
        {
            return obj.GetType().GetProperty(nameProperty).GetValue(obj);
        }

        public void DrawFigures()
        {
            foreach (var item in cordinatesFigures)
            {
                var x = item.Value.X;
                var y = item.Value.Y;

                var stringRepresentationOfFigure = item.Key[0].StringRepresentation;
                Console.SetCursorPosition(x, y);
                Console.WriteLine(stringRepresentationOfFigure);
            }
        }

        private bool IsCanSaveCordinateSecondPlayer(int row)
        {
            return row == 7 || row == 8;
        }

        private static bool IsCanSaveCordinateFirstPlayer(int row)
        {
            return row == 1 || row == 2;
        }

        private static Tuple<int, int> ChangeCordinatesOfPawn(string newPostion)
        {
            Drawing.IsCanChangeCordinatesOfFigures = true;
            switch (newPostion)
            {
                case "a3":
                    return new Tuple<int, int>(5, 17);

            }
            return new Tuple<int, int>(0, 0);
        }

        public static void SaveFigureCordinates(string newPosition)
        {
            var newCordinatesOfPawn = ChangeCordinatesOfPawn(newPosition);

            if (IsFirstPlayerPlay())
            {
                var currentPawn = GetFiguresOfPlayer(false);
                var figuresWithCordinates = cordinatesFigures;
                IFigure figureForChange = null;
                //Point point = new Point();
                foreach (var item in figuresWithCordinates)
                {
                    var equalName = item.Key[0].Name == currentPawn[0].Name;
                    if (equalName)
                    {
                        //point = item.Value;
                        var point = figuresWithCordinates.Values.ToList()[16];
                        point.X = newCordinatesOfPawn.Item1;
                        point.Y = newCordinatesOfPawn.Item2;
                        break;
                    }
                }
                
            }
            else
            {

            }
            
        }

        private static bool IsFirstPlayerPlay()
        {
            return true;
        }

        private static void SaveFigureCordinates(IFigure[] figures, int postion, int postionFigureX, int postionFigureY)
        {
            if (postion > figures.Length - 1)
            {
                postion = 0;
            }

            Console.SetCursorPosition(postionFigureX, postionFigureY);
            var currentFigureFront = figures[postion];
            Point currentPointOfRow = new Point(postionFigureX, postionFigureY);
            var figure = new List<IFigure>();
            figure.Add(currentFigureFront);

            cordinatesFigures.Add(figure, currentPointOfRow);
        }

        private void DrawCurrentLetter(bool isLastRowForPrintLetterOfBoardConsole, int startPointX, int startPointY, char letterOfBoardCol)
        {
            if (isLastRowForPrintLetterOfBoardConsole)
            {
                SetCursorOfConsole(startPointX, startPointY + 3);
                Console.Write(letterOfBoardCol);
            }
        }

        private void DrawNumerics(int startPointX, int startPointY, int numericsOfBoardRow)
        {
            SetCursorOfConsole(startPointX, startPointY);
            Console.Write(numericsOfBoardRow);
        }

        private void DrawBox(int x, int y)
        {
            int dashesCount = 8;
            int spacesCount = 6;

            SetCursorOfConsole(x, y);
            Console.WriteLine(new string('=', dashesCount));

            SetCursorOfConsole(x, y + 1);
            Console.Write("|");
            Console.Write(new string(' ', spacesCount));
            Console.WriteLine("|");

            y++;

            SetCursorOfConsole(x, y + 1);
            Console.WriteLine(new string('=', dashesCount));
        }

        private static void SetCursorOfConsole(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
    }
}
