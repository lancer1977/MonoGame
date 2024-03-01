using Microsoft.Xna.Framework;

namespace PolyhydraGames.Xna.Interfaces
{
    public interface ITargetDrawingStructure
    {
        void CheckBounds();
        Rectangle Boundary { get; set; }
        Rectangle TopSide { get;  }
        Rectangle BottomSide { get; }
        Rectangle LeftSide { get; }
        Rectangle RightSide { get; } 
        Rectangle DrawTarget { get; }
        int X { get; }
        int Y { get; }
        Vector2 Origin { get; }
        void UpdateSides();
        void SetDefaultOrigin();
    }
}