using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PolyhydraGames.MonoGame.Interfaces;

namespace PolyhydraGames.MonoGame.Interactions;

public class KeyboardInterface : IGameInterface
{
    private KeyboardState _myKeyboard;
    private KeyboardState _oldKeyboard;
    public Point Pointer { get; private set; }

    public void Poll()
    {
        _oldKeyboard = _myKeyboard;
        _myKeyboard = Keyboard.GetState();
    }
    public bool Back()
    {
        return _myKeyboard.IsKeyDown(Keys.Escape);
    }

    public bool MainButton => _myKeyboard.IsKeyDown(Keys.Space);
}