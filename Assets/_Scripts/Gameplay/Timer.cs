using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using static UnityEngine.CullingGroup;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;
    float remainingTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
     {
         GameManager.Instance.RegisterTimer(this);
     }
    
    public void startTimer(float TimeInRound)
    {
        elapsedTime = 0;
        remainingTime = TimeInRound;
    }

    public void addTime(float addedTime)
    {
        remainingTime += addedTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            elapsedTime += Time.deltaTime;
            remainingTime -= Time.deltaTime; ;
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        } else if (remainingTime <= 0)
        {
            remainingTime = 0;
            GameManager.Instance.ChangeState(GameState.EndRound);
        }
        

    }
}
