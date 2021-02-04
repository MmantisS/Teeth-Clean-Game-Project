using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RayCaster : MonoBehaviour
{
    public Transform target;
    public GraphicRaycaster canvasRaycaster;
    public List<RaycastResult> list;
    public Vector2 screenPoint;

    void Update()
    {
        list = new List<RaycastResult>();
        screenPoint = Camera.main.WorldToScreenPoint(target.position);
        PointerEventData ed = new PointerEventData(EventSystem.current);
        ed.position = screenPoint;
        canvasRaycaster.Raycast(ed, list);

        if (list != null && list.Count > 0)
        {
            Debug.Log("Hit: " + list[0].gameObject.name);
        }
    }
}
