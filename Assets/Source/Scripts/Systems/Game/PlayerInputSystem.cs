using System.Numerics;
using Kuhpik;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerInputSystem : GameSystem, IUpdating
{
    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private Vector2 currentSwipe;

    public void OnUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            firstPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        }
        if(Input.GetMouseButtonUp(0))
        {
            secondPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);

            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            
            currentSwipe.Normalize();

            if(currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                game.SwipeDirection = Vector3.forward;
            }

            if(currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                game.SwipeDirection = Vector3.back;
            }

            if(currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                game.SwipeDirection = Vector3.left;
            }

            if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                game.SwipeDirection = Vector3.right;
            }
        }
    }
}