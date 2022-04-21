using System.Collections;
using System.Collections.Generic;
using Kuhpik;
using UnityEngine;
using UnityEngine.UI;

public class WinUI : UIScreen
{
    [SerializeField] private Button restartButton;

    public override void Subscribe()
    {
        base.Subscribe();
        restartButton.onClick.AddListener(() => Bootstrap.GameRestart(0));
    }
}