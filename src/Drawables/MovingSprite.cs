using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PolyhydraGames.Xna;
using PolyhydraGames.Xna.Drawables;
using PolyhydraGames.Xna.Enums;
using PolyhydraGames.Xna.Interfaces;

namespace PolyhydraGames.MonoGame.Drawables
{
    public class MovingSprite: SpriteBase
    {
        protected bool RequiresUpdates;
        public Vector2 BaseSpeed { get; set; }
        public override ITargetDrawingStructure TargetRectangle => Hitbox;
        public MovingTargetDrawingStructure Hitbox { get; }

 
        public bool Hyper { get; set; }
        public void Move()
        {
            Hitbox.Move(Hyper);
            if(RequiresUpdates)
                Hitbox.UpdateSides();
        }
        public Impact ImpactOuter(Sprite victim)
        {
            var impact = new Impact();
            var attacker = Hitbox;
            if (!attacker.DrawTarget.Intersects(victim.TargetRectangle.DrawTarget))
            { 
                return impact;
            }

            if (attacker.MovingUp)
            {
                impact.Bottom = CollidedWithSide(victim, Side.Bottom);
            }
            else if (attacker.MovingDown)
            {
                impact.Top = CollidedWithSide(victim, Side.Top);
            }


            if (attacker.MovingRight)
            {
                impact.Left = CollidedWithSide(victim, Side.Left);
            }
            else if (attacker.MovingLeft)
            {
                impact.Right  = CollidedWithSide(victim, Side.Right );
            }

            return impact;
        }

        public Impact ImpactInner(Sprite victim)
        {
            var impact = new Impact();

            if (Hitbox.MovingUp)
            {
                impact.Top = CollidedWithSide(victim, Side.Top);
            }
            else if (Hitbox.MovingDown)
            {
                impact.Bottom = CollidedWithSide(victim, Side.Bottom);
            }


            if (Hitbox.MovingRight)
            {
                impact.Right = CollidedWithSide(victim, Side.Right);
            }
            else if (Hitbox.MovingLeft)
            {
                impact.Left = CollidedWithSide(victim, Side.Left);
            }

            return impact;
        }
 
        /// <summary>
        /// Tests if MY hitbox intersects with a specific side of another containers hitbox.
        /// </summary>
        /// <param name="other">target sprite</param>
        /// <param name="side">side of the rectangle</param>
        /// <returns></returns>
        public bool CollidedWithSide(SpriteBase other, Side side)
        {
            // if (!CollidedWith(other)) return false;
            Rectangle rect2;
            switch (side)
            {

                case Side.Top:
                    rect2 = other.SideTop;
                    break;

                case Side.Bottom:
                    rect2 = other.SideBottom;
                    break;
                case Side.Left:
                    rect2 = other.SideLeft;
                    break;
                case Side.Right:
                    rect2 = other.SideRight;
                    break;
                default:
                    rect2 = new Rectangle(0, 0, 0, 0);
                    break;
            }
             
            return TargetRectangle.DrawTarget.Intersects(rect2);
        }
 
        /// <summary>
        /// Each item has an Update method that fires
        /// We choose to test that the object is within the bounds?
        /// </summary>
        /// <param name="gt"></param>
        public virtual void Update(GameTime gt)
        {
            TargetRectangle.CheckBounds();
        }


        public MovingSprite(Texture2D texture2D, Point location, Rectangle boundary, IDrawHelper helper) : base(helper)
        {
            Texture = texture2D;
            Hitbox = new MovingTargetDrawingStructure(new Rectangle(location.X, location.Y, Texture.Width , Texture.Height),10);
            Color = Color.White; 
            Hitbox.Boundary = boundary;
        }

  
 
        public void LoadDraw(Texture2D obj, Point pos)
        {
            Texture = obj; 
            Hitbox.UpdateBase(new Rectangle(pos.X, pos.Y, Texture.Width, Texture.Height));
            Draw();
        }

    }
}