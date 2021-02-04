using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragOver : MonoBehaviour
{
    RectTransform rect;
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        CheckRay();
    }

    void CheckRay()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log(ray.origin);
        Debug.DrawRay(ray.origin,ray.direction, Color.yellow);
    }
}
