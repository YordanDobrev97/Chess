namespace ChessEngine
{
    using ChessEngine.Board.Figures;
    using ChessEngine.ContorllerMoving;
    using ChessEngine.UI;
    using System;

    public abstract class Game
    {
        public static bool IsFirstPlayer { get; set; }

        public static void Start()
        {
            IsFirstPlayer = true;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
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
                    MovingPawns(drawing, oldPostion, newPosition);
                    IsFirstPlayer = false;
                }
                else
                {
                    if(TryMoveWrongFigure(oldPostion, newPosition))
                    {
                        try
                        {
                            Exception.ThrowExceptionFigureWrong();
                        }
                        catch (System.Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        
                    }
                    IsFirstPlayer = true;
                }
                

                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Enter your move: ");
                inputUser = Console.ReadLine();

                Console.OutputEncoding = System.Text.Encoding.Unicode;
            }
        }

        private static bool TryMoveWrongFigure(string oldPostion, string newPosition)
        {
            throw new NotImplementedException();
        }

        private static void MovingPawns(Drawing drawing, string oldPostion, string newPosition)
        {
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
                        if (ValidMoving.ValidMovePawn(newPosition))
                        {
                            Drawing.SaveFigureCordinates(newPosition, 0);
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
                        Drawing.SaveFigureCordinates(newPosition, 1);
                        Console.Clear();
                        drawing.DrawPlayground();
                        drawing.DrawFigures();
                    }
                    break;
                case "a4":
                    if (ValidMoving.ValidMovePawn(newPosition))
                    {
                        Drawing.SaveFigureCordinates(newPosition, 2);
                        Console.Clear();
                        drawing.DrawPlayground();
                        drawing.DrawFigures();
                    }
                    break;
                case "a5":
                    if (ValidMoving.ValidMovePawn(newPosition))
                    {
                        Drawing.SaveFigureCordinates(newPosition, 3);
                        Console.Clear();
                        drawing.DrawPlayground();
                        drawing.DrawFigures();
                    }
                    break;
            }
        }
    }
}
