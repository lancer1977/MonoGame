using Microsoft.Xna.Framework;

namespace PolyhydraGames.MonoGame;

public static class VectorExtensions
{
    public static Vector2 FromMultiplierFactor(this Vector2 vector, float x, float y)
    {
        return new Vector2(vector.X * x, vector.Y * y);
    }
}