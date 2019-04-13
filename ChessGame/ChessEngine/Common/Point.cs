namespace ChessEngine.Common
{
    public class Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.IsCanUsing = false;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public bool IsCanUsing { get; set; }
    }
}
