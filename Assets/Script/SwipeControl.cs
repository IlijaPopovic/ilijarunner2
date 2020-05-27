using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControl : MonoBehaviour
{
    public bool up, left, right;
    private Vector2 beginingTumbPosition;
    private Vector2 endingTumbPosition;

    private void swipeDirection()
    {
        up = left = right = false;

        if(Input.touches.Length != 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                beginingTumbPosition = Input.touches[0].position;
            }
            else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                endingTumbPosition = Input.touches[0].position;

                Debug.Log(beginingTumbPosition - endingTumbPosition);

                if((beginingTumbPosition - endingTumbPosition).x == 0 && (beginingTumbPosition - endingTumbPosition).y == 0)
                {
                    up = true;
                }
                else if((beginingTumbPosition - endingTumbPosition).x < 0 && (beginingTumbPosition - endingTumbPosition).y < 0)
                {
                    right = true;
                }
                else if((beginingTumbPosition - endingTumbPosition).x > 0 && (beginingTumbPosition - endingTumbPosition).x > 0)
                {
                    left = true;
                }
            }
        }
    }
    private void Update() 
    {
        swipeDirection();
    }
}
