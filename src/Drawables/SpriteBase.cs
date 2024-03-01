using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PolyhydraGames.MonoGame.Enums;
using PolyhydraGames.MonoGame.Interfaces;

namespace PolyhydraGames.MonoGame.Drawables;

public abstract class SpriteBase
{
    protected SpriteBase(IDrawHelper helper)
    {
        SetScale(1);
        _helper = helper;
    }
    protected string Name { get; set; }
    private readonly IDrawHelper _helper;
    private Texture2D _texture;

    public Texture2D Texture
    {
        get => _texture;
        protected set
        {
            _texture = value;
            SourceRectangle = value.Bounds;
        }
    }

    public Vector2 Origin => TargetRectangle?.Origin ?? new Vector2(0, 0);
    public float Rotation { get; set; }
    public Color Color { get; set; }
    public static Vector2 Scale;
    protected int MyEffect { get; set; }
    public bool Attacking { get; set; }
    public bool Hostile { get; set; }
    public int Health { get; set; }
    public int ConditionDuration { get; set; }


    public bool Alive { get; set; }


    public abstract ITargetDrawingStructure TargetRectangle { get; }

    public void SetScale(int val)
    {
        switch (val)
        {
            case 0:
                Scale = new Vector2(.5f, .5f);
                break;
            case 1:
                Scale = new Vector2(1f, 1f);
                break;
            case 2:
                Scale = new Vector2(1.5f, 1.5f);
                break;
        }
    }





    public bool CollidedWith(SpriteBase other)
    {
        return TargetRectangle.DrawTarget.Intersects(other.TargetRectangle.DrawTarget);
    }

    public HorizontalSide CollidedWithHorizontal(SpriteBase other)
    {
        var rect = TargetRectangle.DrawTarget;
        return rect.CollisionHorizontal(other.TargetRectangle.DrawTarget);
    }


    public virtual Rectangle SideTop => TargetRectangle.TopSide;

    public virtual Rectangle SideBottom => TargetRectangle.BottomSide;

    public virtual Rectangle SideLeft => TargetRectangle.LeftSide;

    public virtual Rectangle SideRight => TargetRectangle.RightSide;


    public void Draw()
    {
        _helper.Draw(this);
    }

    public int Height => TargetRectangle.DrawTarget.Height;

    public int Width => TargetRectangle.DrawTarget.Width;
    public Rectangle? SourceRectangle { get; private set; }
}