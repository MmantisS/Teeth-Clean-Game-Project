﻿using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragControl : MonoBehaviour
{


    // touch offset allows ball not to shake when it starts moving
    float deltaX, deltaY;


    // reference to Rigidbody2D component
    Rigidbody2D rb;

    //reference to initial coordinates
    RectTransformUtility rect;

    // ball movement not allowed if you touches not the ball at the first time
    bool moveAllowed = false;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rect = GetComponent<RectTransformUtility>();
    }


    // Update is called once per frame
    void Update()
    {
        // Initiating touch event
        // if touch event takes place
        if (Input.touchCount > 0)
        {


            // get touch position
            Touch touch = Input.GetTouch(0);


            // obtain touch position
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);


            // get touch to take a deal with
            switch (touch.phase)
            {


                // if you touches the screen
                case TouchPhase.Began:

                    // if you touch the ball
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {


                        // get the offset between position you touches
                        // and the center of the game object
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;


                        // if touch begins within the ball collider
                        // then it is allowed to move
                        moveAllowed = true;


                        // restrict some rigidbody properties so it moves
                        // more  smoothly and correctly
                        rb.freezeRotation = true;
                        rb.velocity = new Vector2(0, 0);
                        rb.gravityScale = 0;
                        GetComponent<CircleCollider2D>().sharedMaterial = null;
                    }
                    break;


                // you move your finger
                case TouchPhase.Moved:
                    // if you touches the ball and movement is allowed then move
                    if (GetComponent<CircleCollider2D>() == Physics2D.OverlapPoint(touchPos) && moveAllowed)
                        rb.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
                    break;


                // you release your finger
                case TouchPhase.Ended:


                    // restore initial parameters
                    // when touch is ended
                    moveAllowed = false;
                    rb.freezeRotation = false;
                    rb.MovePosition(Vector2.zero);
                    break;
            }
        }
    }
}