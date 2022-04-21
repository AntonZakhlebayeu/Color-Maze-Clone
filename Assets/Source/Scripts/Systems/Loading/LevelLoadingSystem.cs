using UnityEngine;
using Kuhpik;
using Supyrb;

public class LevelLoadingSystem : GameSystem, IIniting
{
    [SerializeField] private string levelPath;

    private WinSignal winSignal;

    public void OnInit()
    {
        Signals.Get<WinSignal>(out winSignal);

        var level = Resources.Load<GameObject>(string.Format(levelPath));
        game.currentLevel = Instantiate(level);
    }
}
