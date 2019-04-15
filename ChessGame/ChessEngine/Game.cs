namespace ChessEngine
{
    using ChessEngine.Board.Figures;
    using ChessEngine.UI;
    using System;

    public abstract class Game
    {
        public static bool IsFirstPlayer { get; set; }

        public static void Start()
        {
            IsFirstPlayer = true;
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

                if (IsFirstPlayer)
                {
                    MovingFigureOfFirstPlayer(drawing, oldPostion, newPosition);
                    IsFirstPlayer = false;
                }
                else
                {

                    switch (oldPostion)
                    {
                        case "a7":
                            try
                            {
                                if (ValidMoving.ValidMovePawn(newPosition))
                                {
                                    Drawing.SaveFigureCordinates(newPosition, 8, IsFirstPlayer);
                                    Console.Clear();
                                    drawing.DrawPlayground();
                                    drawing.DrawFigures();
                                }
                            }
                            catch (System.Exception)
                            {

                                throw;
                            }
                            break;
                    }

                    IsFirstPlayer = true;
                }
                
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Enter your move: ");
                inputUser = Console.ReadLine();
            }
        }

        private static bool TryMoveWrongFigure(string oldPostion, string newPosition)
        {
            throw new NotImplementedException();
        }

        private static void MovingFigureOfFirstPlayer(Drawing drawing, string oldPostion, string newPosition)
        {
            switch (oldPostion)
            {
                case "a2":
                    try
                    {
                        if (ValidMoving.ValidMovePawn(newPosition))
                        {
                            Drawing.SaveFigureCordinates(newPosition, 0, true);
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
                case "a3":
                    if (ValidMoving.ValidMovePawn(newPosition))
                    {
                        Drawing.SaveFigureCordinates(newPosition, 1, true);
                        Console.Clear();
                        drawing.DrawPlayground();
                        drawing.DrawFigures();
                    }
                    break;
                case "a4":
                    if (ValidMoving.ValidMovePawn(newPosition))
                    {
                        Drawing.SaveFigureCordinates(newPosition, 2, true);
                        Console.Clear();
                        drawing.DrawPlayground();
                        drawing.DrawFigures();
                    }
                    break;
                case "a5":
                    if (ValidMoving.ValidMovePawn(newPosition))
                    {
                        Drawing.SaveFigureCordinates(newPosition, 3, true);
                        Console.Clear();
                        drawing.DrawPlayground();
                        drawing.DrawFigures();
                    }
                    break;
            }
        }
    }
}
