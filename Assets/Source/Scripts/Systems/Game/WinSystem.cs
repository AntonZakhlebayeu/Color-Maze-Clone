using System;
using Kuhpik;
using Supyrb;
using UnityEngine;

public class WinSystem : GameSystem, IIniting
{

    public void OnInit()
    {
        Signals.Get<WinSignal>().AddListener(SetWinState);
    }
    
    private void SetWinState()
    {
        Bootstrap.ChangeGameState(EGamestate.Win);
    }

    private void OnDisable()
    {
        Signals.Get<WinSignal>().RemoveListener(SetWinState);
    }
}
