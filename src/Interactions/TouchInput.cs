using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

namespace PolyhydraGames.XNA.Interactions
{
    public class TouchInput
    {
        public bool Up { get; set; }
        public bool Down { get; set; }
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Tapped { get; set; }
        public Point LastPosition { get; private set; }

        public bool AnySwipe
        {
            get { return (Up | Down | Left | Right); }
        }
        public void Update()
        {
            Reset(); 
            while (TouchPanel.IsGestureAvailable)
            {
                var gesture = TouchPanel.ReadGesture();
                Down = (gesture.Delta.Y > 0);
                Up = (gesture.Delta.Y < 0);
                Right = (gesture.Delta.X > 0);
                Left = (gesture.Delta.X < 0);
                Tapped = (gesture.GestureType == GestureType.Tap);
                LastPosition = new Point((int)gesture.Position.X, (int)gesture.Position.Y);
            }
        }
          private void Reset()
          {
              Down = Up = Right = Left = Tapped = false;
          }
    }
}