using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{

    public void PlayBtn()
    {
        SceneManager.LoadScene(2);
    }
    public void ExitBtn()
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }
}
