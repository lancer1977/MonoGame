using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PolyhydraGames.MonoGame.Drawables;

public class Background : Sprite
{
    private static int count;

    public Background(Texture2D pTexture, Rectangle destination, IDrawHelper batch) : base(pTexture, destination, batch)
    {
        count += 1;
        Name = "Background " + count;
    }


}