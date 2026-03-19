using System.Runtime.CompilerServices;
using NUnit.Framework;
using PolyhydraGames.MonoGame.Drawables;
using PolyhydraGames.MonoGame.Enums;

namespace PolyhydraGames.MonoGame.Tests;

public class AnimationTests
{
    [Test]
    public void Animate_DoesNothing_WhenOwnerIsDead()
    {
        var owner = CreateOwner(alive: false);
        var animation = CreateAnimation(owner);

        animation.Animate();

        Assert.Multiple(() =>
        {
            Assert.That(animation.CurrentAnimationFrame, Is.EqualTo(0));
            Assert.That(animation.StartFrame, Is.EqualTo(0));
            Assert.That(animation.EndFrame, Is.EqualTo(0));
            Assert.That(animation.CurrentAnimationDone, Is.False);
        });
    }

    [Test]
    public void Animate_AdvancesFrame_AfterThresholdIsReached()
    {
        var owner = CreateOwner(alive: true);
        var animation = CreateAnimation(owner, columns: 4, face: Direction.South, threshold: 1);

        animation.Animate();
        animation.Animate();

        Assert.Multiple(() =>
        {
            Assert.That(animation.StartFrame, Is.EqualTo(8));
            Assert.That(animation.EndFrame, Is.EqualTo(11));
            Assert.That(animation.CurrentAnimationFrame, Is.EqualTo(8));
            Assert.That(animation.CurrentAnimationDone, Is.False);
        });
    }

    [Test]
    public void Animate_DoesNotAdvanceFrame_WhenAnimationFlagIsDisabled()
    {
        var owner = CreateOwner(alive: true);
        var animation = CreateAnimation(owner, columns: 4, face: Direction.East, threshold: 0);
        animation.AnimationFlag = false;

        animation.Animate();

        Assert.Multiple(() =>
        {
            Assert.That(animation.StartFrame, Is.EqualTo(12));
            Assert.That(animation.EndFrame, Is.EqualTo(15));
            Assert.That(animation.CurrentAnimationFrame, Is.EqualTo(0));
            Assert.That(animation.CurrentAnimationDone, Is.False);
        });
    }

    [Test]
    public void Animate_WrapsToStartFrame_AndMarksAnimationDone_WhenPastEndFrame()
    {
        var owner = CreateOwner(alive: true);
        var animation = CreateAnimation(owner, columns: 4, face: Direction.West, threshold: 0);
        animation.CurrentAnimationFrame = 7;

        animation.Animate();

        Assert.Multiple(() =>
        {
            Assert.That(animation.StartFrame, Is.EqualTo(4));
            Assert.That(animation.EndFrame, Is.EqualTo(7));
            Assert.That(animation.CurrentAnimationFrame, Is.EqualTo(4));
            Assert.That(animation.CurrentAnimationDone, Is.True);
        });
    }

    [Test]
    public void Animate_ResumesNormalState_WhenAttackAnimationCompletes()
    {
        var owner = CreateOwner(alive: true, attacking: true);
        var animation = CreateAnimation(owner, threshold: 0);
        animation.AnimationState = AnimationState.Attack;
        animation.NextState = AnimationState.Walk;
        animation.CurrentAnimationDone = true;

        animation.Animate();

        Assert.That(animation.AnimationState, Is.EqualTo(AnimationState.Walk));
    }

    private static Animation CreateAnimation(
        Sprite owner,
        int columns = 4,
        Direction face = Direction.North,
        int threshold = 0)
    {
        return new Animation(owner)
        {
            Columns = columns,
            Face = face,
            AnimationSpeedThreshhold = threshold,
            AnimationFlag = true,
            NextState = AnimationState.Standup,
            AnimationState = AnimationState.Standup,
        };
    }

    private static Sprite CreateOwner(bool alive, bool attacking = false)
    {
        var owner = (Sprite)RuntimeHelpers.GetUninitializedObject(typeof(Sprite));
        owner.Alive = alive;
        owner.Attacking = attacking;
        return owner;
    }
}
