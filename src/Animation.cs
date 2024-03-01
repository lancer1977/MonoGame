using PolyhydraGames.Xna.Drawables;
using PolyhydraGames.Xna.Enums;

namespace PolyhydraGames.Xna
{
    public class Animation
    {
        private readonly Sprite _owner;
        public Animation(Sprite sprite)
        {
            _owner = sprite;
        }
        public void Animate()
        {
            if (!_owner.Alive) return;
            if (CurrentAnimationDone && _owner.Attacking) { ResumeNormalState(); }
            //ApplyTileSet();
            StartFrame = (int)Face * Columns;
            EndFrame = ((int)Face * Columns) + (Columns - 1);
            FrameCounter += 1;
            if (FrameCounter <= AnimationSpeedThreshhold) return;
            FrameCounter = 0;
            if (!AnimationFlag) return;
            CurrentAnimationFrame += 1;
            if (CurrentAnimationFrame < StartFrame) CurrentAnimationFrame = StartFrame;


            if (CurrentAnimationFrame <= EndFrame) return;
            CurrentAnimationFrame = StartFrame;
            CurrentAnimationDone = true;
        }
        public void ResumeNormalState()
        {
            AnimationState = NextState; 
        }

        public int CurrentAnimationFrame { get; set; }
        public AnimationState NormalState;

        public Animation()
        {
            throw new System.NotImplementedException();
        }

        public AnimationState NextState { get; set; }
        public AnimationState AnimationState { get; set; }
        public Direction Face { get; set; }
        private int FrameCounter { get; set; }
        public int AnimationSpeedThreshhold { get; set; }
        public int StartFrame { get; set; }
        public int EndFrame { get; set; }
        public bool AnimationFlag { get; set; }
        public bool CurrentAnimationDone { get; set; }
        public bool Subpicture { get; set; }
        public int Columns { get; set; }
    }
}