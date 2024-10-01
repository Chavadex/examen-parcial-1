using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    private bool clickedOnce = false;

    void Update()

    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!clickedOnce)
            {
                pause.SetActive(true);
                Time.timeScale = 0;
                clickedOnce = true;
            }
            else
            {
                pause.SetActive(false);
                Time.timeScale = 1;
                clickedOnce = false;
            }
        }
    }
}
