using System;
using Microsoft.Xna.Framework;

namespace PolyhydraGames.MonoGame;

public static class VectorExtensions
{
    public static Vector2 FromMultiplierFactor(this Vector2 vector, float x, float y)
    {
        return new Vector2(vector.X * x, vector.Y * y);
    }

    public static float Magnitude(this Vector2 vector)
    {
        return vector.Length();
    }

    public static Vector2 NormalizeSafe(this Vector2 vector)
    {
        if (vector == Vector2.Zero)
        {
            return Vector2.Zero;
        }

        return Vector2.Normalize(vector);
    }

    public static float AngleBetween(this Vector2 source, Vector2 target)
    {
        var sourceNormalized = source.NormalizeSafe();
        var targetNormalized = target.NormalizeSafe();

        if (sourceNormalized == Vector2.Zero || targetNormalized == Vector2.Zero)
        {
            return 0f;
        }

        var dot = MathHelper.Clamp(Vector2.Dot(sourceNormalized, targetNormalized), -1f, 1f);
        return MathF.Acos(dot);
    }

    public static float Cross(this Vector2 source, Vector2 target)
    {
        return (source.X * target.Y) - (source.Y * target.X);
    }

    public static Vector2 Approach(this Vector2 source, Vector2 target, float maxDistanceDelta)
    {
        var delta = target - source;
        var distance = delta.Length();

        if (distance <= maxDistanceDelta || distance == 0f)
        {
            return target;
        }

        return source + (delta / distance * maxDistanceDelta);
    }
}
