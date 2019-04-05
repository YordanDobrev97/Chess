namespace ChessEngine.UI
{
    using ChessEngine.Board.Figures;
    using ChessEngine.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Drawing
    {
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
        private Dictionary<List<IFigure>, Point> cordinatesFigures;

        public Drawing()
        {
            this.cordinatesFigures = new Dictionary<List<IFigure>, Point>();
        }

        public void DrawPlayground()
        {
            var figuresFront = new IFigure[]
            {
                new Rook( "Rook1Front"),
                new Кnight("Knight1Front"),
                new Bishop("Bishop1Front"),
                new Queen("QueenFront"),
                new King("KingFront"),
                new Bishop("Bishop2Front"),
                new Кnight("Knight2Front"),
                new Rook("Rook2Front"),
                new Pawn("Pawn1Front"),
                new Pawn("Pawn2Front"),
                new Pawn("Pawn3Front"),
                new Pawn("Pawn4Front"),
                new Pawn("Pawn5Front"),
                new Pawn("Pawn6Front"),
                new Pawn("Pawn7Front"),
                new Pawn("Pawn8Front"),


            };

            var figuresBack = new IFigure[]
            {
                new Pawn("Pawn1Back"),
                new Pawn("Pawn2Back"),
                new Pawn("Pawn3Back"),
                new Pawn("Pawn4Back"),
                new Pawn("Pawn5Back"),
                new Pawn("Pawn6Back"),
                new Pawn("Pawn7Back"),
                new Pawn("Pawn8Back"),
                new Rook("Rook1Back"),
                new Кnight("Knight1Back"),
                new Bishop("Bishop1Back"),
                new Queen("QueenBack"),
                new King("KingBack"),
                new Bishop("Bishop2Back"),
                new Кnight("Knight2Back"),
                new Rook("Rook2Back")
            };

            for (int row = 1; row <= SIZE_ROW; row++)
            {
                if (row == SIZE_ROW)
                {
                    isLastRowForPrintLetterOfBoardConsole = true;
                }

                DrawBox(startPointX, startPointY);

                if (IsCanSaveCordinateFirstPlayer(row))
                {
                    SaveFigureCordinates(figuresFront, postion, postionFigureX, postionFigureY);
                    postionFigureX += 9;
                    postion++;
                    isCanCordinateFigure = true;
                }
                else if (IsCanSaveCordinateSecondPlayer(row))
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

                DrawNumerics(numericXValue, numericYValue, numericsOfBoardRow);
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

                    DrawCurrentLetter(isLastRowForPrintLetterOfBoardConsole,
                        startXLetterOfBoard, startPointY, letterOfBoardCol);

                    if (isLastRowForPrintLetterOfBoardConsole)
                    {
                        startXLetterOfBoard += 9;
                        letterOfBoardCol++;
                    }

                    if (i == 7 && row == SIZE_ROW)
                    {
                        DrawCurrentLetter(isLastRowForPrintLetterOfBoardConsole,
                        startXLetterOfBoard, startPointY, letterOfBoardCol);
                    }
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

        private void SaveFigureCordinates(IFigure[] figures, int postion, int postionFigureX, int postionFigureY)
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
