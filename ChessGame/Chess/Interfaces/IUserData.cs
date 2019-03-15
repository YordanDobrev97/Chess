namespace Chess.Interfaces
{
    public interface IUserData
    {
        string FirstColor { get; }
        string SecondColor { get; }

        string InputUserData();
    }
}
