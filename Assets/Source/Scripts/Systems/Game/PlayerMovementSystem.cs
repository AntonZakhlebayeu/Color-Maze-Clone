using System.Collections;
using DG.Tweening;
using Kuhpik;
using UnityEngine;

public class PlayerMovementSystem : GameSystem, IIniting, IUpdating
{
    [SerializeField] private LayerMask tileLayerMask;
    [SerializeField] private float moveTime;
    [SerializeField] private float punchTime;
    [SerializeField] private Vector3 normalScale;
    
    private RaycastHit movePoint;
    private Vector3 correctedPoint;
    private Vector3 dragPoint;
    private Vector3 scalePoint;
    private Sequence sequence;

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
                {
                    correctedPoint = movePoint.collider.bounds.ClosestPoint(movePoint.point) + new Vector3(0.5f, 0, 0);
                    dragPoint = correctedPoint + new Vector3(0.1f, 0f, 0f);
                    scalePoint = new Vector3(normalScale.x-0.25f, normalScale.y, normalScale.z);
                }
                else if (game.SwipeDirection == Vector3.right)
                {
                    correctedPoint = movePoint.collider.bounds.ClosestPoint(movePoint.point) + new Vector3(-0.5f, 0, 0);
                    dragPoint = correctedPoint + new Vector3(-0.1f, 0f, 0f);
                    scalePoint = new Vector3(normalScale.x - 0.25f, normalScale.y, normalScale.z);
                }
                else if (game.SwipeDirection == Vector3.forward)
                {
                    correctedPoint = movePoint.collider.bounds.ClosestPoint(movePoint.point) + new Vector3(0, 0, -0.5f);
                    dragPoint = correctedPoint + new Vector3(0f, 0f, -0.1f);
                    scalePoint = new Vector3(normalScale.x, normalScale.y, normalScale.z - 0.25f);
                }
                else
                {
                    correctedPoint = movePoint.collider.bounds.ClosestPoint(movePoint.point) + new Vector3(0, 0, 0.5f);
                    dragPoint = correctedPoint + new Vector3(0f, 0f, 0.1f);
                    scalePoint = new Vector3(normalScale.x, normalScale.y, normalScale.z - 0.25f);
                }
                
                sequence = DOTween.Sequence();
                
                sequence.Append(game.player.DOMove(correctedPoint, moveTime));
                sequence.Join(game.player.DOScale(scalePoint, moveTime));
                sequence.Append(game.player.DOMove(dragPoint, punchTime));
                sequence.Join(game.player.DOScale(normalScale, punchTime));
                sequence.Append(game.player.DOMove(correctedPoint, punchTime));

                DOTween.Play(sequence);

                game.SwipeDirection = Vector3.zero;
            }
        }
    }
}
