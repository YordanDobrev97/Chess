namespace Chess.Common
{
    public class Contracts : IContracts
    {
        public static bool IsValidMoveOfUser(string moveUser)
        {
            bool isValid = false;
            char typeFigure = moveUser.Split(' ')[0][0];

            switch (typeFigure)
            {
                case 'P':
                    isValid = true;
                    break;
                case 'R':
                    isValid = true;
                    break;
                case 'H':
                    isValid = true;
                    break;
                case 'Q':
                    isValid = true;
                    break;
                case 'K':
                    isValid = true;
                    break;
                case 'O':
                    isValid = true;
                    break;
            }

            return isValid;
        }
    }
}
