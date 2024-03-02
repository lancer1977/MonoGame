using Microsoft.Xna.Framework;

namespace PolyhydraGames.MonoGame.Interfaces;

public interface IGameState
{
    void Update(GameTime gameTime);
    void Initialize();
    void CheckInput();
    void Draw(GameTime gameTime);
}

