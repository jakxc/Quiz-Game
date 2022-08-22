using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int correctAnswers = 0;

    private int questionsSeen = 0;

    public int GetCorrectAnswers() {
        return correctAnswers;
    }

    public void SetCorrectAnswers() {
        correctAnswers++;
    }

    public int GetQuestionsSeen() {
        return questionsSeen;
    }

    public void SetQuestionSeen() {
        questionsSeen++;
    }

    public int CalculateScore() {
        return Mathf.RoundToInt(correctAnswers / (float)questionsSeen * 100);
    }
}
