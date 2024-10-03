using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject pausePanel;

    [SerializeField] private string sceneName;

    private void Start()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        SetPause();
    }
    private void SetPause()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Retry()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void NextStage()
    {

        int actualScene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(actualScene + 1);

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
