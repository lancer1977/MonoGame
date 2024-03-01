using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PolyhydraGames.Xna.Interfaces;

namespace PolyhydraGames.Xna.Interactions
{
    public class MouseInterface : IGameInterface
    {
        private MouseState _myMouse;
        private MouseState _oldMouse;
        public Point Pointer { get; private set; }
        private void StoreOldValues()
        {
            _oldMouse = _myMouse;
        }

        public void Poll()
        {
            StoreOldValues();
            _myMouse = Mouse.GetState();
            Pointer = new Point(_myMouse.X, _myMouse.Y);
        }


        public bool MainButton => _myMouse.LeftButton == ButtonState.Pressed && _oldMouse.LeftButton == ButtonState.Released;

        public bool Back()
        {
            return false;
        }

    }
}