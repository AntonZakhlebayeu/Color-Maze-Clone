using UnityEngine;
using Kuhpik;

public class LevelLoadingSystem : GameSystem, IIniting
{
    [SerializeField] private string levelPath;

    public void OnInit()
    {
        var level = Resources.Load<GameObject>(string.Format(levelPath));

        game.currentLevel = Instantiate(level);
    }
}
