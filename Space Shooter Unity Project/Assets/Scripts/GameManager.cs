using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    int score = 0;
    bool isGameOver = false;
    public static GameManager instance;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject gameOverText;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && isGameOver)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void increaseScore(int pts)
    {
        score += pts;
        scoreText.text = "Score : " + score;
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverText.SetActive(true);
    }
}
