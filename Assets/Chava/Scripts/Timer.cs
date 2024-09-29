using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;  // 
    [SerializeField] private float startTime;      // Aqui pueden moverle el tiempo si quieren, esta en segundos

    private float currentTime;         
    private bool timerRunning = false; 

    void Start()
    {
       
        currentTime = startTime;
        StartTimer();
    }

    void Update()
    {
        
        if (timerRunning && currentTime > 0)
        {
            currentTime -= Time.deltaTime;  
            UpdateTimerDisplay(currentTime);

            if (currentTime <= 0)
            {
                currentTime = 0;
                TimerComplete();  
            }
        }
    }

    
    public void StartTimer()
    {
        timerRunning = true;
    }

    
    public void StopTimer()
    {
        timerRunning = false;
    }

    
    public void ResetTimer()
    {
        currentTime = startTime;
        UpdateTimerDisplay(currentTime);
        StartTimer();  
    }

    
    private void UpdateTimerDisplay(float time)
    {
        
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);
        int milliseconds = Mathf.FloorToInt((time * 1000F) % 1000);

        
        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

    
    private void TimerComplete()
    {
        Debug.Log("Se acabo el tiempo");
        SceneManager.LoadScene("DefeatScreen");
    }
}
