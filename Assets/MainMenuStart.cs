using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuStart : MonoBehaviour
{
    public void SceneSwap()
    {
        SceneManager.LoadScene("PlayAreaScene");
    }
}
