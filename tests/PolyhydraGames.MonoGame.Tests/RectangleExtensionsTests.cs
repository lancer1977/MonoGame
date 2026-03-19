using Microsoft.Xna.Framework;
using NUnit.Framework;

namespace PolyhydraGames.MonoGame.Tests;

public class RectangleExtensionsTests
{
    [Test]
    public void IntersectsAabb_ReturnsTrue_ForOverlappingRectangles()
    {
        var a = new Rectangle(0, 0, 10, 10);
        var b = new Rectangle(5, 5, 10, 10);

        Assert.That(a.IntersectsAabb(b), Is.True);
    }

    [Test]
    public void IntersectsAabb_ReturnsFalse_ForSeparatedRectangles()
    {
        var a = new Rectangle(0, 0, 10, 10);
        var b = new Rectangle(20, 20, 5, 5);

        Assert.That(a.IntersectsAabb(b), Is.False);
    }

    [Test]
    public void ContainsPoint_ReturnsTrue_WhenPointInside()
    {
        var rect = new Rectangle(10, 10, 20, 20);

        Assert.That(rect.ContainsPoint(new Point(15, 15)), Is.True);
    }

    [Test]
    public void ContainsPoint_ReturnsFalse_WhenPointOutside()
    {
        var rect = new Rectangle(10, 10, 20, 20);

        Assert.That(rect.ContainsPoint(new Point(35, 35)), Is.False);
    }

    [Test]
    public void IntersectsWithPadding_ReturnsTrue_WhenPaddingCreatesIntersection()
    {
        var a = new Rectangle(0, 0, 10, 10);
        var b = new Rectangle(12, 0, 10, 10);

        Assert.That(a.IntersectsWithPadding(b, 3), Is.True);
    }

    [Test]
    public void IntersectsWithPadding_ReturnsFalse_WhenStillTooFarApart()
    {
        var a = new Rectangle(0, 0, 10, 10);
        var b = new Rectangle(30, 0, 10, 10);

        Assert.That(a.IntersectsWithPadding(b, 2), Is.False);
    }

    [Test]
    public void IntersectsAabb_HandlesZeroSizedAndNegativeCoordinateEdgeCases()
    {
        var zero = new Rectangle(-5, -5, 0, 0);
        var normal = new Rectangle(-10, -10, 20, 20);

        Assert.That(zero.IntersectsAabb(normal), Is.True);
        Assert.That(normal.ContainsPoint(new Point(-1, -1)), Is.True);
    }
}
