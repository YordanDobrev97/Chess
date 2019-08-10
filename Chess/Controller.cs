using System;
using System.Collections.Generic;
using Chess.Figures;
using Chess.Interfaces;

namespace Chess
{
    public abstract class Controller
    {
        public const int DEFAULT_VALUE = 8;

        private static IFigure[,] board = new IFigure[DEFAULT_VALUE, DEFAULT_VALUE];
        
        public static void Start()
        {
            IntilizateFigures();
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

        private static void IntilizatePawns(int dimension)
        {
            for (int i = 0; i < DEFAULT_VALUE; i++)
            {
                board[dimension, i] = new Pawn();
            }
        }

        private static void IntilizateFigures()
        {
            board[0, 0] = new Rook();
            board[0, 1] = new Knight();
            board[0, 2] = new Bishop();
            board[0, 3] = new Queen();
            board[0, 4] = new King();
            board[0, 5] = new Bishop();
            board[0, 6] = new Knight();
            board[0, 7] = new Rook();
            IntilizatePawns(1); // pawns of first player

            IntilizatePawns(6); // pawns of second player
            board[7, 0] = new Rook();
            board[7, 1] = new Knight();
            board[7, 2] = new Bishop();
            board[7, 3] = new Queen();
            board[7, 4] = new King();
            board[7, 5] = new Bishop();
            board[7, 6] = new Knight();
            board[7, 7] = new Rook();
        }
    }
}