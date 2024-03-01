using Microsoft.Xna.Framework;

namespace PolyhydraGames.MonoGame.Interfaces;

public interface IGameInterface
{
    bool MainButton { get; }
    Point Pointer { get; }
    void Poll();
    bool Back();
}