using Microsoft.Xna.Framework;
using PolyhydraGames.Xna.Drawables;
using PolyhydraGames.Xna.Enums;
using PolyhydraGames.Xna.Interfaces;
using Point = Microsoft.Xna.Framework.Point;

namespace PolyhydraGames.Xna
{
    public class TargetDrawingStructure : ITargetDrawingStructure
    {
        public int CollisionThreshhold;
        public TargetDrawingStructure(Rectangle defaultRectangle)
        {
            SetBaseRectangle(defaultRectangle);
            UpdateSides();
         
        }

        public   Vector2 Origin { get;  } = new Vector2(0);
        //protected Vector2 OriginOffset;
        public void UpdateSides()
        {
            _leftSide = BaseRectangle.GetLeft(CollisionThreshhold);
            _rightSide = BaseRectangle.GetRight(CollisionThreshhold);
            _topSide = BaseRectangle.GetTop(CollisionThreshhold);
            _bottomSide = BaseRectangle.GetBottom(CollisionThreshhold);
        }
        /// <summary>
        /// Sets the origin.
        /// </summary>
        public void SetDefaultOrigin()
        {
         //   Origin = OriginOffset;
        }

        public void UpdateBase(Rectangle newLocation)
        {
            SetBaseRectangle(newLocation);
            UpdateSides();
        }
        public void SetLocation(Point vector2)
        {
            var rect = new Rectangle(vector2.X, vector2.Y, BaseRectangle.Width, BaseRectangle.Height);
            SetBaseRectangle(rect);
        }
        protected Rectangle BaseRectangle;

        private void SetBaseRectangle(Rectangle rect)
        {
            BaseRectangle = rect.ScaleSizeAndLocation(SpriteBase.Scale);

          //  OriginOffset = new Vector2(rect.Width / 2f, rect.Height / 2f);
        }

      
        public int X => BaseRectangle.X;

        public int Y => BaseRectangle.Y;

        public Rectangle GetSide(Side side)
        { 

            switch (side)
            {
                case Side.Left:
                    return _leftSide;
                case Side.Right:
                    return _rightSide;
                case Side.Top:
                    return _topSide;
                case Side.Bottom:
                    return _bottomSide;
                case Side.None:
                default:
                    return BaseRectangle;
            }
        }

        public Rectangle DrawTarget => BaseRectangle;

 

    

        protected Rectangle _leftSide;
        protected Rectangle _rightSide;
        protected Rectangle _topSide;
        protected Rectangle _bottomSide;
    

        public string Report => "X:" + X + " Y:" + Y +
                                " H:" + BaseRectangle.Height + "W:" + BaseRectangle.Width;




        public virtual bool MovingUp => false;
        public virtual bool MovingRight => false;


        public Rectangle LeftSide => _leftSide;

        public Rectangle RightSide => _rightSide;

        public Rectangle TopSide => _topSide;

        public Rectangle BottomSide => _bottomSide;

 
        public Rectangle Boundary { get; set; }

        public virtual bool MovingDown => false;

        public virtual bool MovingLeft => false;


        public void CheckBounds()
        {
            BaseRectangle.X = MathHelper.Clamp(BaseRectangle.X, 0, Boundary.Width - BaseRectangle.Width);
            BaseRectangle.Y = MathHelper.Clamp(BaseRectangle.Y, 0, Boundary.Height - BaseRectangle.Height);
  
        }

    
    }
}
