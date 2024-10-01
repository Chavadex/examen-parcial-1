using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MenuManager : MonoBehaviour
{

    [SerializeField] private TMP_InputField textName;

    public void PlayBtn()
    {
        SceneManager.LoadScene(2);
    }
    public void ExitBtn()
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }

    public void SaveInfo()
    {
        string userName = textName.text;
        PlayerPrefs.SetString("UserName", userName);
        string newUsername = PlayerPrefs.GetString("UserName", "");
        Debug.Log(newUsername);
    }
}
