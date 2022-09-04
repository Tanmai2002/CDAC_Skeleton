using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    bool timerActive = false;
    float currentTime;
    public int startMinutes;
    public Text currentTimeText;

    bool TimerEnded=true;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startMinutes * 60;   
           
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                if(TimerEnded){
                    TimerEnded=false;
                    GameManager.instance.timerEnded();
                    

                }
                currentTime = 0;
                
            }
            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            currentTimeText.text = time.Minutes.ToString("00") + ":" + time.Seconds.ToString("00");
        }
        
    }

    public void StartTimer(){
        timerActive = true;
    }

    public void StopTimer(){
        timerActive = false;
    }
}
