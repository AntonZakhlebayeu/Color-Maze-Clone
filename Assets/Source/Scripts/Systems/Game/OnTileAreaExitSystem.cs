using System.Collections;
using System.Collections.Generic;
using Kuhpik;
using NaughtyAttributes;
using Supyrb;
using UnityEngine;

public class OnTileAreaExitSystem : GameSystem
{
    [SerializeField] [Tag] private string tileTag;
    [SerializeField] private Color onTileAreaExit = new Color(248.0f / 255.0f, 214.0f / 255.0f, 0f);
    
    private int tilesColored = 0;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tileTag))
        {
            SetTheMaterial(other);
        }
    }

    private void SetTheMaterial(Collider other)
    {
        if (other.GetComponent<MeshRenderer>().material.color == onTileAreaExit) return;
        
        tilesColored++;
        other.GetComponent<MeshRenderer>().material.color = onTileAreaExit;
        if (tilesColored >= 29)
        {
            LevelLoadingSystem.winSignal.Dispatch();
        }
    }
}
