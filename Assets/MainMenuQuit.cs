using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuQuit : MonoBehaviour
{
    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
