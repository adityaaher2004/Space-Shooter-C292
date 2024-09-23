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
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI powerUpText;
    [SerializeField] TextMeshProUGUI insufficientPowerUpText;
    [SerializeField] GameObject gameOverText;

    [SerializeField] Player player;
    

    [SerializeField] TextMeshProUGUI laserLevelNumber;
    [SerializeField] TextMeshProUGUI speedLevelNumber;
    [SerializeField] TextMeshProUGUI maxHealthLevelNumber;

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
            SceneManager.LoadScene("MainScene");
        }
    }

    public void enemyCrossDefenceLine(int damage)
    {
        player.enemyHit(damage);
    }

    public void increaseScore(int pts)
    {
        score += pts;
        scoreText.text = "Score : " + score;
    }

    public void setHealth(int health)
    {
        healthText.text = "Health : "  + health;
    }

    public void setPowerUp(int points)
    {
        powerUpText.text = "" + points;
    }

    public void setLaserLevel(int points)
    {
        laserLevelNumber.text = "" + points;
    }

    public void setSpeedLevel(int points)
    {
        speedLevelNumber.text = "" + points;
    }

    public void setMaxHealthLevel(int points)
    {
        maxHealthLevelNumber.text = "" + points;
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverText.SetActive(true);
    }

    public void insufficientTextActive(string text)
    {
        insufficientPowerUpText.text = text;
    }

    public void insufficientTextInactive()
    {
        insufficientPowerUpText.text = "";
    }
}
