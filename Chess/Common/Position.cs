namespace Chess
{
    using System;
    public class Position
    {
        private int width;
        private int height;

        public Position(string pos)
        {
            if (pos.Length != 2) throw new ArgumentException($"Invalid coordinates {pos}");
            this.Width = pos[0];
            this.Height = pos[1];
        }
        public int Width { get => this.width;
            set
            {
                this.width = value - 'a';
            }
        }

        public int Height { get => this.height;
            set
            {
                this.height = value -'1';
            }
        }

        public override string ToString()
        {
            var currentWidth = 'a' + this.Width;
            return $"{(char)currentWidth}{this.height+1}";
        }
    }
}
