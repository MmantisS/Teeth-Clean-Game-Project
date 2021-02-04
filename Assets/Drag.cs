using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IEndDragHandler
{
    Transform pos;
    Vector3 initialPos;
    bool isBeingDragged;
    GameObject objectHit;
    ChangeMaterial script;
    public bool isFirstInSequence;
    GameObject UIController;

    public void Start()
    {
        pos = GetComponent<Transform>();
        initialPos = pos.position;
        UIController = GameObject.Find("UIController");
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        isBeingDragged = true;
        UIController.GetComponent<UIInteractionConrol>().UIisInteractedWith = true;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        isBeingDragged = false;
        UIController.GetComponent<UIInteractionConrol>().UIisInteractedWith = false;
        transform.position = initialPos;
        if (script != null)
        {
            script.isOverlapping = false;
        }
    }
    void CheckRay()
    {
            Ray ray = Camera.main.ScreenPointToRay(pos.position);
            RaycastHit Hit;
        if (Physics.Raycast(ray, out Hit) && isBeingDragged)
        {
            objectHit = Hit.collider.gameObject;
            script = objectHit.GetComponent<ChangeMaterial>();
            if (script != null)
            {
                if (isFirstInSequence && !script.isState1Done)
                    script.ChangeToState1();
                else if (!isFirstInSequence && script.isState1Done && !script.isState2Done)
                    script.ChangeToState2();
                Debug.Log(objectHit.name);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckRay();
    }
}
