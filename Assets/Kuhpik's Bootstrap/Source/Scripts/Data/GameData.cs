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
    }
}