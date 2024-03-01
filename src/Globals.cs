using Microsoft.Xna.Framework;
using PolyhydraGames.Xna.Drawables;

namespace PolyhydraGames.Xna
{
    public class GameData
    {
        private static readonly GameData _gameData = new GameData();
        public static GameData Data => _gameData;

        //DisplayFPS();
        public GameData()
        {
            DisplayFps = true;
            DisplayHelp = true;
            SetScale(new Vector2(1));

        }

        public static void SetScale(Vector2 vector)
        {
            Font.Scale = vector;
            SpriteBase.Scale = vector;
        }
        public int Level { get; set; }
        // public int blockCount { get; set; }
        public int Score { get; set; }
        public int Lives { get; set; }
        public bool Gameover { get; set; }
        public bool Running { get; set; }
        public int BlockColumns { get; set; }
        public int BlockRows { get; set; }
        public int BlockHeight { get; set; }
        public int BlockWidth { get; set; }
        public int LevelPattern { get; set; }
        public int Progress { get; set; }
        public bool DisplayHelp { get; set; }
        public bool DisplayFps { get; set; }
        public bool DebugMode { get; set; }
        public bool ExtraLife { get; set; }
        public bool HyperBall { get; set; }
        public bool LaserEnabled { get; set; }
        public int Tilt { get; set; }
        public bool FirstCredit { get; set; } 

        public readonly string[] Story = { "In the Night, Master Took Away My Mind", "Chaos He Breeds and Chaos I Embrace", "He Is The Eternal Blight which Commands me", "His will Shall Be Done This Night...", "They Shall All Pay, Their Order Is An Afront", "It Shall Be Their End", "Deliver Them....", "F'ah orr'e- ,wgah'nagl Cthulhu!!!" };
        public static int[] BlockPattern(int level)
        {
            switch (level)
            {
                case 2:
                    return new[] {
                                0, 1, 0, 1, 0, 1, 0, 1, 0, 1,
                                2, 0, 2, 0, 2, 0, 2, 0, 2, 0,
                                0, 3, 0, 3, 0, 3, 0, 3, 0, 3,
                                4, 0, 4, 0, 4, 0, 4, 0, 4, 0,
                                0, 5, 0, 5, 0, 5, 0, 5, 0, 5,
                                6, 0, 6, 0, 6, 0, 6, 0, 6, 0,
                                0, 7, 0, 7, 0, 7, 0, 7, 0, 7,
                                8, 0, 8, 0, 8, 0, 8, 0, 8, 0};

                case 1:
                    return new[]  {
                          1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                          2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
                          3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
                          4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
                          5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
                          6, 6, 6, 6, 6, 6, 6, 6, 6, 6,
                          7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
                          8, 8, 8, 8, 8, 8, 8, 8, 8, 8};

                case 3:
                    return new[]  {
                        1, 1, 0, 1, 1, 1, 1, 0, 1, 1,
                        2, 2, 0, 2, 2, 2, 2, 0, 2, 2,
                        3, 3, 0, 3, 3, 3, 3, 0, 3, 3,
                        4, 4, 0, 4, 4, 4, 4, 0, 4, 4,
                        5, 5, 0, 5, 5, 5, 5, 0, 5, 5,
                        6, 6, 0, 6, 6, 6, 6, 0, 6, 6,
                        7, 7, 0, 7, 7, 7, 7, 0, 7, 7,
                        8, 8, 0, 8, 8, 8, 8, 0, 8, 8
                    };

                default:
                    return new[] {
                          1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                          1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                          1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                          1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                          1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                          1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                          1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                          1, 1, 1, 1, 1, 1, 1, 1, 1, 1};


            }
        }
    }
}

