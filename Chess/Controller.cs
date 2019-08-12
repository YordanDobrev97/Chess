using System;
using System.Collections.Generic;
using Chess.Interfaces;

namespace Chess
{
    public abstract class Controller
    {
        public const int DEFAULT_VALUE = 8;
        
        public static void Start()
        {
            Board board = new Board();
            board.MoveFigure("a2", "a3"); // test move pawn

            Painter.DrawBoard();
            Painter.DrawFigures();

            while (true)
            {
                Console.SetCursorPosition(2, 26);

                Console.Write("Enter your move: ");
                string userMove = Console.ReadLine();
            }
        }

        public static void SaveDefaultCordinatesFigures<T>()
        {
            CordinatesOfFirstPlayer<T>();

            CordinatesOfSecondPlayer<T>();
        }

        private static void CordinatesOfSecondPlayer<T>()
        {
            int startValuePawnPosition = 5;
            for (int i = 0; i < 8; i++)
            {
                var currentPawn = Painter.figuresOfSecondPlayer[i];
                SaveDefaultCordinatesFigures<T>(currentPawn, startValuePawnPosition, 20);
                startValuePawnPosition += 10;
            }

            int startIndex = 8;
            int positionFigure = 5;
            for (int i = 0; i < 8; i++)
            {
                var currentFigure = Painter.figuresOfSecondPlayer[startIndex];
                SaveDefaultCordinatesFigures<T>(currentFigure, positionFigure, 23);
                positionFigure += 10;
                startIndex++;
            }
        }

        private static void CordinatesOfFirstPlayer<T>()
        {
            int position = 5; // default start value
            for (int i = 0; i < 8; i++)
            {
                var figure = Painter.figuresOfFirstPlayer[i]; //figures[i];
                SaveDefaultCordinatesFigures<T>(figure, position, 2);
                position += 10;
            }

            //save cordinates of pawns
            int pawnStartValue = 5;
            int startIndex = 8;
            for (int i = 0; i < 8; i++)
            {
                var pawn = Painter.figuresOfFirstPlayer[startIndex]; // get pawn
                SaveDefaultCordinatesFigures<T>(pawn, pawnStartValue, 5);
                pawnStartValue += 10;
                startIndex++;
            }
        }

        private static void SaveDefaultCordinatesFigures<T>(IFigure figure, int positionWitdh, int positionHeight)
        {
            var currentFigure = new Tuple<IFigure>(figure);
            Painter.cordinatesOfFigures[currentFigure] = new Dictionary<int, int>();
            Painter.cordinatesOfFigures[currentFigure].Add(positionWitdh, positionHeight);
        }
    }
}