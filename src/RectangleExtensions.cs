using Microsoft.Xna.Framework;

namespace PolyhydraGames.MonoGame;

public static class RectangleExtensions
{
    public static bool IntersectsAabb(this Rectangle rect, Rectangle other)
    {
        return rect.Intersects(other);
    }

    public static bool ContainsPoint(this Rectangle rect, Point point)
    {
        return rect.Contains(point);
    }

    public static bool IntersectsWithPadding(this Rectangle rect, Rectangle other, int padding)
    {
        var padded = rect;
        padded.Inflate(padding, padding);
        return padded.Intersects(other);
    }

    public static Rectangle ScaleSizeAndLocation(this Rectangle rect, Vector2 xy)
    {
        return new Rectangle((int)(rect.Location.X * xy.X), (int)(rect.Location.Y * xy.Y), (int)(rect.Size.X * xy.X), (int)(rect.Size.Y * xy.Y));
    }
    public static Rectangle GetBottom(this Rectangle rect, int threshhold = 0)
    {
        return new Rectangle(rect.Location.X, rect.Location.Y + rect.Size.Y + (threshhold / 2), rect.Size.X, threshhold);
    }

    public static Rectangle GetTop(this Rectangle rect, int threshhold = 0)
    {
        return new Rectangle(rect.Location.X, rect.Location.Y + (threshhold / 2), rect.Size.X, threshhold);

    }

    public static Rectangle GetRight(this Rectangle rect, int threshhold = 0)
    {
        return new Rectangle(rect.Location.X + rect.Size.X - (threshhold / 2), rect.Location.Y, threshhold, rect.Size.Y);
    }

    public static Rectangle GetLeft(this Rectangle rect, int threshhold = 0)
    {
        return new Rectangle(rect.Location.X - (threshhold / 2), rect.Location.Y, threshhold, rect.Size.Y);
    }
}