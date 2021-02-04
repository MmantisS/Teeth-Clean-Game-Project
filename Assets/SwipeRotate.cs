using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class SwipeRotate : MonoBehaviour
{
    public GameObject UIController;
    public GameObject rotatingObject;
    Quaternion rotationY;
    Vector2 touchPosition;
    float rotateSppedModifier = 0.1f;
    

    private void Start()
    {
        GameObject UIController = GameObject.Find("UIController");
    }
    void Update()
    {
        Debug.Log(UIController);
        if (!UIController.GetComponent<UIInteractionConrol>().UIisInteractedWith)
        {
            if (Input.touchCount > 0)
            {
                Touch touch0 = Input.GetTouch(0);

                if (touch0.phase == TouchPhase.Moved)
                {
                    rotationY = Quaternion.Euler(0f, -touch0.deltaPosition.x * rotateSppedModifier, 0f);
                    gameObject.transform.rotation = rotationY * gameObject.transform.rotation;
                }

            }
        }
    }
}
