using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeToCompleteQuestion = 30f;
    [SerializeField] private float timeToShowAnswer = 10f;

    public bool isAnsweringQuestion = false;
    public bool loadNextQuestion = false;
    public float fillFraction;
    private float timerValue;


    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer() {
        timerValue = 0;
    }

    private void UpdateTimer() 
    {
        timerValue -= Time.deltaTime;

        // If player is answering question
        if (isAnsweringQuestion) {
            // Set timer to time to show question once time runs out
            if (timerValue > 0) {
                fillFraction = timerValue / timeToCompleteQuestion;
            } else {
                isAnsweringQuestion = false;
                timerValue = timeToShowAnswer;           
            }
        } else {
            if (timerValue > 0) {
                fillFraction = timerValue / timeToShowAnswer;
            } else {
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }

        //Debug.Log(timerValue);
    }
}
