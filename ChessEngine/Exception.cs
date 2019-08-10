﻿using System;

namespace ChessEngine
{
    public static class Exception
    {
        public static void ThrowExceptionForInvalidMove()
        {
            throw new ArgumentException("Invalid move!");
        }

        public static void ThrowExceptionFigureBlockFromOtherFigure()
        {
            throw new ArgumentException("This figure is block from other!");
        }

        public static void ThrowExceptionFigureWrong()
        {
            throw new ArgumentException("Sorry, this  current figure not our!");
        }

        internal static void ThrowExceptionNotSetValidValue()
        {
            throw new NotImplementedException();
        }
    }
}