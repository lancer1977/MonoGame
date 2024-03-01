using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PolyhydraGames.Xna.Interfaces;

namespace PolyhydraGames.Xna.Drawables
{
    public class Sprite : SpriteBase
    { 
        public override ITargetDrawingStructure TargetRectangle => _targetRectangle;
        private readonly TargetDrawingStructure _targetRectangle;
         
        public Sprite(Texture2D texture2D, Rectangle target, IDrawHelper helper) : base(helper)
        {
            Texture = texture2D;
            _targetRectangle = new TargetDrawingStructure(target);
            Color = Color.White;
        }
    }
}
