using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText;
    private ScoreKeeper scoreKeeper;

    void Awake()
    {
       scoreKeeper = FindObjectOfType<ScoreKeeper>(); 
    }

    public void DisplayFinalScore() 
    {
        finalScoreText.text = "Congratulations!\nYou got a score of: " + 
                        scoreKeeper.CalculateScore() + "%";
    }
}
