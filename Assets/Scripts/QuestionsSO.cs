using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Quiz Question", fileName ="New Question")]
public class QuestionsSO : ScriptableObject
{
    [SerializeField] [TextArea(2,6)]
    private string question = "Enter new question here";

    [SerializeField]
    private string[] answers = new string[4];

    [SerializeField]
    private int correctAnswerIndex;

    public string GetQuestion() 
    {
        return question;
    }

    public int GetCorrectAnswerIndex() {
        return correctAnswerIndex;
    }

    public string GetAnswer(int index) {
        return answers[index];
    }
}
