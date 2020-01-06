using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControl : MonoBehaviour
{
    bool swipeRight, swipeLeft, tap, dragging;
    Vector2 starttouch, swipedelta;

 

    private void Update()
    {
        tap = swipeLeft = swipeRight = false;
        #region MouseInputs

        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            dragging = true;
            starttouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Reset();
        }
        #endregion
        #region MobileInput

        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                dragging = true;
                starttouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                Reset();
            }

        }

        #endregion

        //Calculating SwipeDelta

        swipedelta = Vector2.zero;
        if (dragging)
        {
            if (Input.touches.Length > 0)
            {
                swipedelta = Input.touches[0].position - starttouch;
            }
            else if (Input.GetMouseButton(0))
            {
                swipedelta = (Vector2)Input.mousePosition - starttouch;
            }
        }

        if (swipedelta.magnitude > 150)
        {
            //direction
            float x = swipedelta.x;
            float y = swipedelta.y;
            //leftOrRight
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRight = true;
                }
            }

            Reset();
        }
    }

     private void Reset()
     {
            starttouch = swipedelta = Vector2.zero;
            dragging = false;
     }
    public Vector2 SwipeDelta { get { return swipedelta; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeLeft { get { return swipeLeft; } }
}

