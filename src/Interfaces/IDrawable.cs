using Microsoft.Xna.Framework;

namespace PolyhydraGames.MonoGame.Interfaces;

public interface IDrawable
{
    void Draw();
    void Move();
    void MoveTo(Vector2 pVector);
}