using System.Collections;
using System.Collections.Generic;
using Kuhpik;
using NaughtyAttributes;
using Supyrb;
using UnityEngine;

public class OnTileAreaExitSystem : GameSystem
{
    [SerializeField] [Tag] private string tileTag;
    
    private Color onTileAreaExit = new Color(248.0f / 255.0f, 214.0f / 255.0f, 0f);

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tileTag))
        {
            SetTheMaterial(other);
        }
    }

    private void SetTheMaterial(Collider other)
    {
        if (other.GetComponent<MeshRenderer>().material.color != onTileAreaExit)
        {
            GameData.IncreaseTiles();
            other.GetComponent<MeshRenderer>().material.color = onTileAreaExit;
            if (GameData.TilesColored() >= 29)
            {
                WinSystem.SetWinState();
                
            }
        }
    }
}
