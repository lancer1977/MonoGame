namespace PolyhydraGames.MonoGame;

public static class Methods
{
    static readonly Random Ran = new Random();

    public static int Roll(int low, int high)
    {
        return Ran.Next(low, high + 1);
    }
}