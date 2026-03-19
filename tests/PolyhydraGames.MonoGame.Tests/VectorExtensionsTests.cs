using Microsoft.Xna.Framework;
using NUnit.Framework;

namespace PolyhydraGames.MonoGame.Tests;

public class VectorExtensionsTests
{
    [Test]
    public void Magnitude_ReturnsVectorLength()
    {
        var vector = new Vector2(3f, 4f);

        Assert.That(vector.Magnitude(), Is.EqualTo(5f).Within(0.0001f));
        Assert.That(vector.Length(), Is.EqualTo(5f).Within(0.0001f));
    }

    [Test]
    public void NormalizeSafe_ReturnsNormalizedVector_ForNonZeroVector()
    {
        var vector = new Vector2(3f, 4f);

        var normalized = vector.NormalizeSafe();

        Assert.Multiple(() =>
        {
            Assert.That(normalized.X, Is.EqualTo(0.6f).Within(0.0001f));
            Assert.That(normalized.Y, Is.EqualTo(0.8f).Within(0.0001f));
            Assert.That(normalized.Length(), Is.EqualTo(1f).Within(0.0001f));
        });
    }

    [Test]
    public void NormalizeSafe_ReturnsZeroVector_ForZeroVector()
    {
        var normalized = Vector2.Zero.NormalizeSafe();

        Assert.That(normalized, Is.EqualTo(Vector2.Zero));
    }

    [Test]
    public void AngleBetween_ReturnsExpectedAngle_ForPerpendicularVectors()
    {
        var angle = Vector2.UnitX.AngleBetween(Vector2.UnitY);

        Assert.That(angle, Is.EqualTo(MathHelper.PiOver2).Within(0.0001f));
    }

    [Test]
    public void AngleBetween_ReturnsZero_WhenEitherVectorIsZero()
    {
        var angle = Vector2.Zero.AngleBetween(Vector2.UnitY);

        Assert.That(angle, Is.EqualTo(0f).Within(0.0001f));
    }

    [Test]
    public void Cross_ReturnsSignedScalarCrossProduct()
    {
        var cross = Vector2.UnitX.Cross(Vector2.UnitY);

        Assert.That(cross, Is.EqualTo(1f).Within(0.0001f));
    }

    [Test]
    public void FromMultiplierFactor_ScalesVectorComponents()
    {
        var result = new Vector2(2f, 3f).FromMultiplierFactor(4f, 5f);

        Assert.That(result, Is.EqualTo(new Vector2(8f, 15f)));
    }

    [Test]
    public void DotProduct_UsesFrameworkImplementation_ForCommonVectorOperationCoverage()
    {
        var dot = Vector2.Dot(new Vector2(1f, 2f), new Vector2(3f, 4f));

        Assert.That(dot, Is.EqualTo(11f).Within(0.0001f));
    }

    [Test]
    public void Lerp_ReturnsIntermediatePoint_ForCommonVectorOperationCoverage()
    {
        var lerped = Vector2.Lerp(Vector2.Zero, new Vector2(10f, 20f), 0.25f);

        Assert.That(lerped, Is.EqualTo(new Vector2(2.5f, 5f)));
    }

    [Test]
    public void Approach_MovesTowardsTarget_ByMaximumDistanceDelta()
    {
        var approached = Vector2.Zero.Approach(new Vector2(10f, 0f), 3f);

        Assert.That(approached, Is.EqualTo(new Vector2(3f, 0f)));
    }

    [Test]
    public void Approach_ReturnsTarget_WhenAlreadyWithinMaximumDistanceDelta()
    {
        var approached = new Vector2(8f, 0f).Approach(new Vector2(10f, 0f), 3f);

        Assert.That(approached, Is.EqualTo(new Vector2(10f, 0f)));
    }
}
