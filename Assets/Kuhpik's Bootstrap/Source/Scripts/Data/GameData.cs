using UnityEngine;

namespace Kuhpik
{
    /// <summary>
    /// Used to store game data. Change it the way you want.
    /// </summary>
    public class GameData
    {
        public GameObject currentLevel;
        public Transform player;

        public Vector3 SwipeDirection = Vector3.zero;

        private static int tilesColored = 0;

        public static int TilesColored() => tilesColored;
        public static void IncreaseTiles() => tilesColored++;
        public static void RestoreGameCondition() => tilesColored = 0;
    }
}