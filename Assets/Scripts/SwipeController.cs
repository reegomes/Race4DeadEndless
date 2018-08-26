using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SwipeDirection
{
    None,Up,Down
}

public class SwipeController : MonoBehaviour
{
    public SwipeDirection Direction { set; get; }
    private static SwipeController instance;
    public static SwipeController Instance { get { return instance; } }
    private Vector3 posTouch;
    private float swipeY = 100f;
        
    private void Start()
    {
        instance = this;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            posTouch = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 deltaSwipe = posTouch - Input.mousePosition;
            if (Mathf.Abs(deltaSwipe.y) > swipeY)
            {
                if (deltaSwipe.y < 0)
                {
                    Direction = SwipeDirection.Up;
                    StartCoroutine("Reset");
                }
                else
                {
                    Direction = SwipeDirection.Down;
                    StartCoroutine("Reset");
                }
            }
        }
    }
    public bool IsSwiping(SwipeDirection dir)
    {
        if (dir == Direction)
        {
            return true;
        }
        else return false;
    }
    IEnumerator Reset(){
        yield return new WaitForSeconds (2f);
        Direction = SwipeDirection.None;
        StopCoroutine("Reset");
    }
}