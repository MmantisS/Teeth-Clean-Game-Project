using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeethCoordinates : MonoBehaviour
    
{
    // Start is called before the first frame update
    Transform trans;
    void Start()
    {
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(trans.position, new Vector3(1, 1, 1), Color.red);
        Debug.DrawRay(trans.position, trans.forward, Color.yellow) ;
        Debug.Log(trans.position);
        Debug.Log(trans.TransformPoint(trans.position));
    }
}
