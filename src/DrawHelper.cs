
using Microsoft.Xna.Framework.Graphics;
using PolyhydraGames.Xna.Drawables;

namespace PolyhydraGames.Xna
{
    public interface IDrawHelper
    {
        void Draw(SpriteBase sprite);
    }

    public class DrawHelper :IDrawHelper
    {
        private readonly SpriteBatch _batch;

        public DrawHelper(SpriteBatch batch)
        {
            _batch = batch;
        }

        public void Draw(SpriteBase sprite)
        {  

            _batch.Draw(sprite.Texture, sprite.TargetRectangle.DrawTarget,sprite.SourceRectangle, sprite.Color,sprite.Rotation,sprite.Origin,SpriteEffects.None,1);
        }

   
    }
}