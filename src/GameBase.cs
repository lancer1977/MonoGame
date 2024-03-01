using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PolyhydraGames.MonoGame;

public abstract class GameBase : Game
{

    private Vector2 BoundaryDimension { get; }
    private SpriteBatch _spiteBatch;
    protected SpriteBatch SpriteBatch => _spiteBatch ?? (_spiteBatch = new SpriteBatch(GraphicsDevice));

    private DrawHelper _drawHelper;
    protected DrawHelper DrawHelper => _drawHelper ?? (_drawHelper = new DrawHelper(SpriteBatch));
    private readonly GraphicsDeviceManager _graphics;
    public GraphicsDeviceManager Graphics => _graphics;
    private readonly float _virtualWidth;
    private readonly float _virtualHeight;

    protected void SpriteBegin()
    {
        SpriteBatch.Begin(transformMatrix: Resolution.GetTransformationMatrix());
    }

    protected GameBase(int virtualWidth, int virtualHeight, bool isFullScreen = true, DisplayOrientation orientation = DisplayOrientation.Portrait)
    {
        Content.RootDirectory = "Content";
        _graphics = new GraphicsDeviceManager(this)
        {
            IsFullScreen = isFullScreen,
            SupportedOrientations = orientation,
            PreferredBackBufferWidth = Window.ClientBounds.Width,
            PreferredBackBufferHeight = Window.ClientBounds.Height
        };
        _virtualHeight = virtualHeight;
        _virtualWidth = virtualWidth;
        RefreshScale();
        Window.ClientSizeChanged += (o, e) => { RefreshScale(); };
        Graphics.ApplyChanges();
        Resolution.Init(ref _graphics, Color.Black);
        Resolution.SetVirtualResolution(virtualWidth, virtualHeight);
        Resolution.SetResolution(Window.ClientBounds.Width, Window.ClientBounds.Height, isFullScreen);
    }

    public void ResetScreenSize()
    {
        Graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        Graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        Resolution.SetResolution(Graphics.PreferredBackBufferWidth, Graphics.PreferredBackBufferHeight, _graphics.IsFullScreen);
        Graphics.ApplyChanges();
    }

    private void RefreshScale()
    {
        GameData.SetScale(new Vector2(Window.ClientBounds.Width / _virtualWidth, Window.ClientBounds.Height / _virtualHeight));

    }
}