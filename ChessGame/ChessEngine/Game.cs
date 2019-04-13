namespace ChessEngine
{
    using ChessEngine.Board.Figures;
    using ChessEngine.ContorllerMoving;
    using ChessEngine.UI;
    using System;

    public abstract class Game
    {
        public string FirstPlayer { get; set; }// down player
        public string SecondPlayer { get; set; } // up player

        public static void Start()
        {
            Drawing drawing = new Drawing();
            drawing.DrawPlayground();

            drawing.DrawFigures();

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Enter your move: ");
            string inputUser = Console.ReadLine();

            while (true)
            {
                var moveUser = inputUser.Split(' ');
                var oldPostion = moveUser[0];
                var newPosition = moveUser[1];

                switch (oldPostion)
                {
                    case "a1":
                        try
                        {
                            ValidMoving.ValidMoveOfRook(newPosition);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "a2":
                        try
                        {
                            if(ValidMoving.ValidMovePawn(newPosition))
                            {
                                Drawing.SaveFigureCordinates(newPosition);
                                Console.Clear();
                                drawing.DrawPlayground();
                                drawing.DrawFigures();
                            }
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Enter your move: ");
                inputUser = Console.ReadLine();
            }
        }
    }
}
