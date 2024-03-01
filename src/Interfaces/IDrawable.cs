using Microsoft.Xna.Framework;

namespace PolyhydraGames.Xna.Drawables
{
    public interface IDrawable
    {
        void Draw();
        void Move();
        void MoveTo(Vector2 pVector);
    }
}