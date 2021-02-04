using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandlerColor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameObject;
    public bool isButtonPressed;
    private float colorChangePercent;
    private bool isColorChanged;
    private Color initialColor;

    public void Start()
    {
        initialColor = gameObject.GetComponent<Renderer>().material.color;
    }

    public void SetColor()
    {
        if (!isColorChanged)
        {
            var newColor = Color.red;
            isButtonPressed = true;
            if (colorChangePercent >= 0.95f)
            {
                isButtonPressed = false;
                isColorChanged = true;
            }
            gameObject.GetComponent<Renderer>().material.color = Color.Lerp(gameObject.GetComponent<Renderer>().material.color, newColor, 0.05f);
            colorChangePercent = Mathf.Lerp(colorChangePercent, 1, 0.05f);
        }
        else
        {
            isButtonPressed = true;
            if (colorChangePercent <= 0.00001f)
            {
                isButtonPressed = false;
                isColorChanged = false;
            }
            gameObject.GetComponent<Renderer>().material.color = Color.Lerp(gameObject.GetComponent<Renderer>().material.color, initialColor, 0.05f);
            colorChangePercent = Mathf.Lerp(colorChangePercent, 0, 0.05f);
        }
    }

    public void Update()
    {
        if (isButtonPressed)
        {
            SetColor();
        }
        Debug.Log(initialColor);
        Debug.Log(colorChangePercent);
        Debug.Log(isButtonPressed);
    }
}
