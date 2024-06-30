using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public float timer;
    public TextMeshProUGUI timerText;
    void Start()
    {
        
    }

    
    void Update()
    {
        timer-= Time.deltaTime;
        timerText.text = timer.ToString("F0");
        
        if(timer < 0)
        {
            timerText.text = timer.ToString("END");
            Time.timeScale = 0;
        }

        
    }
}
