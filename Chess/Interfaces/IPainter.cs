using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Interfaces
{
    public interface IPainter
    {
        void DrawBoard(Board board);

        void DrawAdminPanel();
    }
}
