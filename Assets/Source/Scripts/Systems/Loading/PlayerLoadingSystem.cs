using Kuhpik;
using NaughtyAttributes;
using UnityEngine;

public class PlayerLoadingSystem : GameSystem, IIniting
{
    [SerializeField] [Tag] private string playerTag;
    
    public void OnInit()
    {
        game.player = GameObject.FindWithTag(playerTag).transform;
    }
}
