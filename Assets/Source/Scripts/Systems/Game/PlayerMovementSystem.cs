using DG.Tweening;
using Kuhpik;
using UnityEngine;

public class PlayerMovementSystem : GameSystem, IIniting, IUpdating
{
    [SerializeField] private LayerMask tileLayerMask;
    
    private RaycastHit movePoint;
    private Vector3 correctedPoint;
    
    public void OnInit()
    {
        DOTween.Init();
    }
    
    public void OnUpdate()
    {
        if (game.SwipeDirection != Vector3.zero)
        {
            if (Physics.Raycast(game.player.position, game.SwipeDirection, out movePoint, Mathf.Infinity, tileLayerMask))
            {
                if (game.SwipeDirection == Vector3.left)
                    correctedPoint = movePoint.collider.bounds.ClosestPoint(movePoint.point) + new Vector3(0.5f, 0, 0);
                else if(game.SwipeDirection == Vector3.right)
                    correctedPoint = movePoint.collider.bounds.ClosestPoint(movePoint.point) + new Vector3(-0.5f, 0, 0);
                else if(game.SwipeDirection == Vector3.forward)
                    correctedPoint = movePoint.collider.bounds.ClosestPoint(movePoint.point) + new Vector3(0, 0, -0.5f);
                else
                    correctedPoint = movePoint.collider.bounds.ClosestPoint(movePoint.point) + new Vector3(0, 0, 0.5f);

                game.player.DOMove(correctedPoint, 0.5f);
                game.SwipeDirection = Vector3.zero;
            }
        }
    }
}
