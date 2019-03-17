namespace Chess.Common
{
    public class Contracts : IContracts
    {
        public static bool IsValidMoveOfUser(string moveUser)
        {
            bool isValid = false;
            string typeFigure = moveUser.Split(' ')[0];



            return isValid;
        }
    }
}
