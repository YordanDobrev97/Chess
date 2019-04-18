using ChessEngine.Board.Figures;
using ChessEngine.Common;
using ChessEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessEngine
{
    public class Engine
    {
        private const int MAX_FIGURE_TOTAL = 32;
        private const int DEFAULT_VALUE = 2;

        private int numericsOfBoardRow = 8;
        private char letterOfBoardCol = 'a';
        private int numericXValue = 0;
        private int numericYValue = 2;
        private int startXLetterOfBoard = 5;
        private bool isLastRowForPrintLetterOfBoardConsole = false;
        private int SIZE_ROW = StandartConstants.SIZE_ROW_BOARD;
        private int SIZE_COLUM = StandartConstants.SIZE_COL_BOARD;
        private bool isCanChangeCordinateFigure = false;
        private bool isFirstPlayer = true;
        private bool isAddingAllFigures = false;

        private static int startPointX = 2;
        private static int startPointY = 1;
        private static int postion = 0;
        private static int postionFigureX = 5;
        private static int postionFigureY = 2;

        public Engine()
        {
            this.isAddingAllFigures = cordinatesFigures.Count == MAX_FIGURE_TOTAL;
        }

        public static int StartPointX
        {
            get
            {
                return startPointX;
            }
            set
            {
                if (value < 2)
                {
                    Exception.ThrowExceptionNotSetValidValue();
                }
                startPointX = value;
            }
        }

        public static int StartPointY
        {
            get
            {
                return startPointX;
            }
            set
            {
                if (value < 1)
                {
                    Exception.ThrowExceptionNotSetValidValue();
                }
                startPointX = value;
            }
        }

        public static int Position
        {
            get
            {
                return postion;
            }
            set
            {
                if (value < 0)
                {
                    Exception.ThrowExceptionNotSetValidValue();
                }
                postion = value;
            }
        }

        public static int PositionFigureX
        {
            get
            {
                return postionFigureX;
            }
            set
            {
                if (value < 5)
                {
                    Exception.ThrowExceptionNotSetValidValue();
                }
                postionFigureX = value;
            }

        }

        public static int PositionFigureY
        {
            get
            {
                return postionFigureY;
            }
            set
            {
                if (value < 2)
                {
                    Exception.ThrowExceptionNotSetValidValue();
                }
                postionFigureY = value;
            }
        }

        public static int MaxFigure => MAX_FIGURE_TOTAL;

        public static int DefaultValue => DEFAULT_VALUE;

        public static Dictionary<List<IFigure>, Point> cordinatesFigures = 
            new Dictionary<List<IFigure>, Point>();

        public static bool IsCanChangeCordinatesOfFigures { get; set; }

        public static void SaveFigureCordinates(IFigure[] figures, int postion, int postionFigureX, int postionFigureY)
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

        public bool IsCanSaveCordinateSecondPlayer(int row)
        {
            return row == 7 || row == 8;
        }

        public static void SetCursorOfConsole(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        public static bool IsCanSaveCordinateFirstPlayer(int row)
        {
            return row == 1 || row == 2;
        }

        public static IFigure[] GetFigureOfSecondPlayer()
        {
            var backFlagFigure = "Back";

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

        public static IFigure[] GetFiguresOfPlayer()
        {
            var backFlagFigure = "Front";
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

        public static void SaveFigureCordinates(string newPosition, int figureNumber, bool isFirstPlayer)
        {
            Tuple<int, int> newCordinatesOfPawn = null;
            if (isFirstPlayer)
            {
                newCordinatesOfPawn = Engine.ChangeCordinatesOfPawnFirstPlayer(newPosition);
            }
            else
            {
                newCordinatesOfPawn = Engine.ChangeCordinatesOfPawnSecondPlayer(newPosition);
            }
            //cordinatesFigures
            var figuresWithCordinates = cordinatesFigures;

            if (isFirstPlayer)
            {
                var currentPawn = GetFiguresOfPlayer();
                ChangeCordinatesOfCurrentFigure(figureNumber, newCordinatesOfPawn, figuresWithCordinates, currentPawn);
            }
            else
            {
                var currentPawn = GetFigureOfSecondPlayer();
                ChangeCordinatesOfCurrentFigure(figureNumber, newCordinatesOfPawn, figuresWithCordinates, currentPawn);
            }
        }
        
        private static Tuple<int, int> ChangeCordinatesOfPawnSecondPlayer(string newPosition)
        {
            switch (newPosition)
            {
                case "a6":
                    return new Tuple<int, int>(5, 8);
            }
            return new Tuple<int, int>(0, 0);
        }

        private static void ChangeCordinatesOfCurrentFigure(int figureNumber, Tuple<int, int> newCordinatesOfPawn, Dictionary<List<IFigure>, Point> figuresWithCordinates, IFigure[] currentPawn)
        {
            int counter = 0;
            foreach (var item in figuresWithCordinates)
            {
                var equalName = item.Key[0].Name == currentPawn[figureNumber].Name;
                if (equalName)
                {
                    var point = figuresWithCordinates.Values.ToList()[counter];
                    point.X = newCordinatesOfPawn.Item1;
                    point.Y = newCordinatesOfPawn.Item2;
                    break;
                }
                counter++;
            }
        }

        private static Tuple<int, int> ChangeCordinatesOfPawnFirstPlayer(string newPostion)
        {
            Drawing.IsCanChangeCordinatesOfFigures = true;
            switch (newPostion)
            {
                case "a3":
                    return new Tuple<int, int>(5, 17);
                case "a4":
                    return new Tuple<int, int>(5, 14);
                case "a5":
                    return new Tuple<int, int>(5, 11);
                case "a6":
                    return new Tuple<int, int>(5, 8);

            }
            return new Tuple<int, int>(0, 0);
        }
    }
}
