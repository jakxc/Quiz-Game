using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    private QuestionsSO currentQuestion;
    [SerializeField] private List<QuestionsSO> questions = new List<QuestionsSO>();

    [SerializeField] private TextMeshProUGUI questionText;

    [Header("Answers")]
    [SerializeField] private GameObject[] answerButtons;
    public bool hasAnswered = true;
    [SerializeField] private int correctAnswerIndex;

    [Header("Button Sprites")]
    [SerializeField] private Sprite defaultAnswerSprite;
    [SerializeField] private Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] private Image timerImage;
    private Timer timer;

    [Header("Score")]
    [SerializeField] private TextMeshProUGUI scoreText;
    private ScoreKeeper scoreKeeper;

    [Header("ProgressBar")]
    [SerializeField] private Slider progressBar;

    public bool isComplete ;

    void Awake()
    {   
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
    }

    void Update() 
    {
        timerImage.fillAmount = timer.fillFraction;
        
        if (timer.loadNextQuestion) {                
            if (progressBar.value == progressBar.maxValue) {
                isComplete = true;
                return;
            }
            
            hasAnswered = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        } else if (!hasAnswered && !timer.isAnsweringQuestion) {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    public void OnAnswerSelected(int index) {
        hasAnswered = true;
        DisplayAnswer(index);
        
        SetButtonState(false);
        timer.CancelTimer();
        scoreText.text = "Score: " + scoreKeeper.CalculateScore() + "%";
    }

    private void DisplayAnswer(int index) {
        Image buttonImage;

        if (index == currentQuestion.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            scoreKeeper.SetCorrectAnswers();
        } else
        {
             correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();
             string correctAnswer = currentQuestion.GetAnswer(correctAnswerIndex);
             
             questionText.text = "Sorry, the correct answer was:\n" + correctAnswer;
             buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
             buttonImage.sprite = correctAnswerSprite;
        }
    }

    private void GetNextQuestion() {
        if (questions.Count > 0) {
            SetButtonState(true);
            SetDefaultButtonSprite();
            GetRandomQuestion();
            progressBar.value++;
            DisplayQuestion();
        }
    }

    private void GetRandomQuestion() {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];

        if (questions.Contains(currentQuestion)) {
            questions.Remove(currentQuestion);
        }
    }

    private void SetDefaultButtonSprite()
    {
        for (int i = 0; i < answerButtons.Length; i++) {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }

    private void DisplayQuestion() {
        questionText.text = currentQuestion.GetQuestion();
        scoreKeeper.SetQuestionSeen();

        for (int i = 0; i < answerButtons.Length; i++) {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }

    private void SetButtonState(bool state) {
        for (int i = 0; i < answerButtons.Length; i++) {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
}
