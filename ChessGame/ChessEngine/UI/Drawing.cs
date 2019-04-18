namespace ChessEngine.UI
{
    using ChessEngine.Board.Figures;
    using ChessEngine.Common;
    using System;
    using System.Collections.Generic;

    public class Drawing : Engine
    {
        /// <summary>
        /// Drawing figures of console
        /// </summary>
        public void DrawPlayground()
        {
            var startPointX = Engine.StartPointX = 2;
            var startPointY = Engine.StartPointY = 1;
            var postion = Engine.Position = 0;
            var postionFigureX = Engine.PositionFigureX = 5;
            var postionFigureY = Engine.PositionFigureY = 2;

            var isAddingAllFigures = cordinatesFigures.Count == Engine.MaxFigure;

            var figuresFront = Engine.GetFiguresOfPlayer();

            var figuresBack = Engine.GetFigureOfSecondPlayer();

            for (int row = 1; row <= StandartConstants.SIZE_ROW_BOARD; row++)
            {
                //if (row == StandartConstants.SIZE_ROW_BOARD)
                //{
                //    isLastRowForPrintLetterOfBoardConsole = true;
                //}

                DrawBox(startPointX, startPointY);

                if (IsCanSaveCordinateFirstPlayer(row) && !isAddingAllFigures)
                {
                    SaveFigureCordinates(figuresFront, postion, postionFigureX, postionFigureY);
                    postionFigureX += 9;
                    postion++;
                    //isCanCordinateFigure = true;
                }
                else if (IsCanSaveCordinateSecondPlayer(row) && !isAddingAllFigures)
                {
                    //isFirstPlayer = false;
                    SaveFigureCordinates(figuresBack, postion, postionFigureX, postionFigureY);
                    postionFigureX += 9;
                    postion++;
                    //isCanCordinateFigure = true;
                }
                else
                {
                    postion = 0;
                    //isCanCordinateFigure = false;
                }

                //DrawNumerics(numericXValue, numericYValue, numericsOfBoardRow);
                for (int i = 1; i < StandartConstants.SIZE_COL_BOARD; i++)
                {
                    startPointX += 9;
                    DrawBox(startPointX, startPointY);

                    //if (isCanChangeCordinateFigure)
                    //{
                    //    if (isFirstPlayer)
                    //    {
                    //        SaveFigureCordinates(figuresFront, postion, postionFigureX, postionFigureY);
                    //    }
                    //    else
                    //    {
                    //        SaveFigureCordinates(figuresBack, postion, postionFigureX, postionFigureY);
                    //    }
                    //    postionFigureX += 9;
                    //    postion++;

                    //}

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
                startPointX = Engine.DefaultValue;
                startPointY += 3;
                //numericYValue += 3;
                //numericsOfBoardRow--;
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
    }
}