using Chess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Core
{
    public class ConsoleGame : IGame
    {
        public void Start()
        {
            SystemSetting.SetSettingOfFontMsGothic();
            Player peshoPlayer = new Player("Pesho");
            peshoPlayer.SaveCoordinatesOfFirstPlayer();

            Player goshoPlayer = new Player("Gosho");
            goshoPlayer.SaveCoordinatesOfSecondPlayer();

            Painter.DrawBoard();
            Painter.DrawFigures(true, peshoPlayer);
            Painter.DrawFigures(true, goshoPlayer);

            Board board = new Board(peshoPlayer, goshoPlayer);

            Player currentPlayer = peshoPlayer;//first

            Controller controller = new Controller(peshoPlayer, goshoPlayer, currentPlayer, board);
            controller.Start();
            
        }
    }
}
