using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material firstMaterial;
    public Material secondMaterial;
    public bool isOverlapping;
    public bool isState1Done;
    public bool isState2Done;
    Renderer rend;
    float duration = 0.05f;
    Material initialMaterial;
    float isDone;
    void Start()
    {
        rend = GetComponent<Renderer>();
        initialMaterial = rend.material;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeToState1()
    {
        if (firstMaterial != null)
        {
            float lerp = Mathf.PingPong(Time.time, duration) / duration;
            rend.material.Lerp(initialMaterial, firstMaterial, 0.02f);
            isDone = Mathf.Lerp(isDone, 1, 0.04f);
            if (isDone > 0.90f)
            {
                isDone = 0;
                isState1Done = true;
                rend.material = firstMaterial;
            }
        }
    }

    public void ChangeToState2()
    {
        if (secondMaterial != null)
        {
            float lerp = Mathf.PingPong(Time.time, duration) / duration;
            rend.material.color = Color.Lerp(rend.material.color, secondMaterial.color, 0.02f);
            isDone = Mathf.Lerp(isDone, 1, 0.04f);
            if (isDone > 0.90f)
            {
                isDone = 0;
                isState2Done = true;
                rend.material = secondMaterial;
            }
        }
    }
}
