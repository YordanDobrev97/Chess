namespace ChessEngine
{
    public static class Engine
    {
        public static void GetUserCommand(string userInput)
        {
            Processor processorCommand = new Processor();
            processorCommand.ProcessingUserCommand(userInput);
        }

        private static void StartDrawing() { }

        private static void MovingFigure(int currentPosition, int newPosition) { }

        private static void GetStrokePlayer() { }
    }
}
