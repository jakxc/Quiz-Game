using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Quiz quiz;
    private EndGame endGame;

    void Awake()
    {
        quiz = FindObjectOfType<Quiz>();
        endGame = FindObjectOfType<EndGame>();        
    }

    // Start is called before the first frame update
    void Start()
    {
        quiz.gameObject.SetActive(true);
        endGame.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (quiz.isComplete) {
            quiz.gameObject.SetActive(false);
            endGame.gameObject.SetActive(true);    
            endGame.DisplayFinalScore();
        }
    }

    public void onReplayLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
