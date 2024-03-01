using Microsoft.Xna.Framework;
using PolyhydraGames.MonoGame.Enums;

namespace PolyhydraGames.MonoGame;

public static class RectangleCollisionExtensions
{
 
    public static HorizontalSide CollisionHorizontal(this Rectangle attacker,Rectangle target)
    { 
        var result = GetQuadrant(3, target.Width + (attacker.Width), target.X - attacker.Width, attacker.X );
        return (HorizontalSide)result;
    }

    public static int GetQuadrant(int segments, int width, int x1, int x2)
    {
        var x = x2 - x1;
        if (x > width || x < 0) return segments;
        var frac = (double)x / width;
        var result = Math.Abs(frac * segments);
        return (int)result;
    }

    public static VerticalSide CollisionVertical(this Rectangle attacker, Rectangle target)
    {
        var result = GetQuadrant(3, target.Height, target.Y, attacker.Y);
           
        return (VerticalSide)result;
    }
}