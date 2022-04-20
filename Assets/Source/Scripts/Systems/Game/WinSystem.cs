using Kuhpik;
using Supyrb;
using UnityEngine;

public class WinSystem : GameSystem
{
    public static void SetWinState()
    {
        Bootstrap.ChangeGameState(EGamestate.Win);
        GameData.RestoreGameCondition();
    }
}
