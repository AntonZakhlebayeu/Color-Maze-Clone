using UnityEngine;
using Kuhpik;
using Supyrb;

public class LevelLoadingSystem : GameSystem, IIniting
{
    [SerializeField] private string levelPath;

    public static WinSignal winSignal;

    public void OnInit()
    {
        var level = Resources.Load<GameObject>(string.Format(levelPath));

        Signals.Get<WinSignal>(out winSignal);
        
        game.currentLevel = Instantiate(level);
    }
}
