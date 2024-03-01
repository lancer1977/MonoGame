using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IDrawable = PolyhydraGames.MonoGame.Interfaces.IDrawable;

namespace PolyhydraGames.MonoGame.Drawables;

public class Font : IDrawable
{
    private readonly bool _3d;
    private readonly string _text;
    private readonly Color _myColor;
    private readonly SpriteFont _font;
    private readonly SpriteBatch _spriteBatch;
    private readonly Vector2 _velocity;
    private Vector2 _position;
    private readonly float _rotation;
    private readonly Vector2 _origin;
    public static Vector2 Scale;
    private readonly SpriteEffects _effects;
    private float _layerDepth;

    public Font(SpriteFont pFont, string ptext, Vector2 startPoint, SpriteBatch spritebatch, Color pColor, bool pD3D)
    {
            _font = pFont;
            _position = startPoint;
            _spriteBatch = spritebatch;
            _myColor = pColor;
            _3d = pD3D;
            _text = ptext;
            _velocity = new Vector2(0, 0); 
            _origin = new Vector2(0,0);
            _rotation = 0;
            _effects = SpriteEffects.None;
        }

    public void Draw()
    {
            Draw(_text);
        }
    public void Draw(string text)
    {
            Draw(text, _position);
        }
    public void Draw(string text, Vector2 pPosition)
    {
            Draw(text, _position, _myColor);
        }

    public void Draw(string text, Vector2 location, Color color)
    {
            if (_3d)
            {
                _spriteBatch.DrawString(_font, text, location + new Vector2(1, 1), Color.Black, _rotation, _origin, Scale, _effects, _layerDepth);
            }

            _spriteBatch.DrawString(_font, text, location, color, _rotation, _origin, Scale, _effects, _layerDepth);
        }



    public void Move()
    {
            _position += _velocity;
        }

    public void MoveTo(Vector2 pVector)
    {
            _position = pVector;
        }
}