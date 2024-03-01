using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PolyhydraGames.MonoGame.Interfaces;

namespace PolyhydraGames.MonoGame.Interactions;

public class TouchInterface : IGameInterface
{
    private readonly TouchInput _touchInput;
    private bool _mainButton;
    public Point Pointer { get; private set; }

    public bool MainButton
    {
        get => _mainButton;
        private set
        {
            if (value == true)
            {
                Debug.WriteLine("Tapped!");
            }
            _mainButton = value;
        }
    }

    public TouchInterface()
    {
          
        _touchInput = new TouchInput();
         
    }
 
    public void Poll()
    { 
        _touchInput.Update();
        MainButton = _touchInput.Tapped;
        Pointer = new Point(  _touchInput.LastPosition.X,   _touchInput.LastPosition.Y);
    }
  
    public bool Back()
    {
        return GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed;
    }
}