using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuGuideHandler : MonoBehaviour
{
    bool isPopUpVisible = false;
    public GameObject PopUp;
    // Update is called once per frame
    public void ChangePopUpStatus()
    {
        isPopUpVisible = !isPopUpVisible;
        if (!isPopUpVisible)
        {
            PopUp.SetActive(isPopUpVisible);
        }
        else
        {
            PopUp.SetActive(isPopUpVisible);
        }
    }
}
