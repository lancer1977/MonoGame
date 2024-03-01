using Microsoft.Xna.Framework;
using PolyhydraGames.Xna.Enums;
using PolyhydraGames.Xna.Interfaces;

namespace PolyhydraGames.Xna
{
    public class MovingTargetDrawingStructure : TargetDrawingStructure, ITargetDrawingStructure
    {
        // public override Vector2 Origin => new Vector2(OriginOffset.X + BaseRectangle.X, OriginOffset.Y + BaseRectangle.Y);
        private readonly int _velocityThreshhold;  
        public MovingTargetDrawingStructure(Rectangle defaultRectangle, int speedThreshold) : base(defaultRectangle)
        {
            _velocityThreshhold = speedThreshold;
            UpdateBase(defaultRectangle);
        }
 
        public void Move(bool hyper)
        {
          
            BaseRectangle.X += (int)Velocity.X;
            BaseRectangle.Y += (int)Velocity.Y; 
            if(hyper)
                Move(false); 
        }
        public void ReverseVelocity(DirectionDelta segment)
        {
            switch (segment)
            {
                case DirectionDelta.X:
                    Velocity = new Vector2(Velocity.X * -1, Velocity.Y);
                    break;
                case DirectionDelta.Y:
                    Velocity = new Vector2(Velocity.X, Velocity.Y * -1);
                    break;
                case DirectionDelta.XY:
                    Velocity = new Vector2(Velocity.X * -1, Velocity.Y * -1);
                    break;
            }
        } 
        public override bool MovingUp => Velocity.Y < 0;
        public override bool MovingDown => Velocity.Y > 0;
        public override bool MovingRight => Velocity.X > 0;
        public override bool MovingLeft=> Velocity.X < 0;
        private Vector2 _velocity;

        public Vector2 Velocity
        {
            get => _velocity;
            set
            {
                _velocity = value;
                if (_velocity.X > _velocityThreshhold)
                    _velocity.X = _velocityThreshhold;
                if (_velocity.Y > _velocityThreshhold)
                    _velocity.Y = _velocityThreshhold;
                if (_velocity.X < -_velocityThreshhold)
                    _velocity.X = -_velocityThreshhold;
                if (_velocity.Y < -_velocityThreshhold)
                    _velocity.Y = -_velocityThreshhold;

            }
        }
    }
}