namespace ChessEngine.Common
{
    public struct Point
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
