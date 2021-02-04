using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandlerTransform : MonoBehaviour
{
    public GameObject gameObject;
    public Mesh morphingObject;
    private Mesh initialMesh;
    private bool isMorphed;

    private void Start()
    {
        initialMesh = gameObject.GetComponent<MeshFilter>().mesh;
    }

    public void MorphInto()
    {
        if (!isMorphed)
        {
            gameObject.GetComponent<MeshFilter>().mesh = morphingObject;
            isMorphed = true;
        }
        else
        {
            gameObject.GetComponent<MeshFilter>().mesh = initialMesh;
            isMorphed = false;
        }

    }
}
