using System;
using ChessEngine;

namespace Chess.Logic
{
    public static class GameSet
    {
        public static void Start()
        {

            bool isGameOverPlayer = false;
            UserData userData = new UserData();
            string selectedUserFigure = userData.InputUserData();

            Player firstPlayer = new Player();
            Player secondPlayer = new Player();

            Board board = new Board();
            board.LoadingGame();

            while (!isGameOverPlayer)
            {

            }
        }
    }
}
