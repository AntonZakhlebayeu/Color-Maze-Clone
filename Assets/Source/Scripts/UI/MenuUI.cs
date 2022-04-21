using System.Collections;
using System.Collections.Generic;
using Kuhpik;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : UIScreen
{
    [SerializeField] private Button startButton;

    public override void Subscribe()
    {
        base.Subscribe();
        startButton.onClick.AddListener(() => 
            Bootstrap.ChangeGameState(EGamestate.Game));
    }
}
