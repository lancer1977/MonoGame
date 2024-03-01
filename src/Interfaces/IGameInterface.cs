using Microsoft.Xna.Framework;

namespace PolyhydraGames.Xna.Interfaces
{
    public interface IGameInterface
    {
        bool MainButton { get; }
        Point Pointer { get; }
        void Poll();
        bool Back();
    }
}