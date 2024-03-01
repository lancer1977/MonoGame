namespace PolyhydraGames.Xna.Enums;

public struct Impact
{
    public bool Top;
    public bool Bottom;
    public bool Left;
    public bool Right;
    
    public bool Vertical => Top || Bottom;
    public bool Horizontal => Left || Right;
    public bool Any => Horizontal || Vertical; 
    public Impact()
    {
        Top = Bottom = Left = Right = false;
    }
}