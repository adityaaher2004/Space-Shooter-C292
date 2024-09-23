using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float y_pos;
    [SerializeField] GameObject laser;
    [SerializeField] GameObject bigLaser;
    GameObject tempLaser;

    [SerializeField] GameManager manager;
    [SerializeField] float moveSpeed;

    Vector3 spawnPosition;

    float xMin;
    float xMax;

    int maxHealth = 10;
    int startHealth = 5;
    public int currentHealth;

    int maxAbilityLevel = 20;
    int startPowerUp = 20;
    public int currentPowerUp;
    

    public int maxHealthLevel;
    int laserLevel;
    int speedLevel;

    int laserCost = 1;
    int speedCost = 1;
    

    private void Awake()
    {
        spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.15f, 0));
        currentHealth = startHealth;
        currentPowerUp = startPowerUp;

        maxHealthLevel = 1;
        laserLevel = 1;
        speedLevel = 1;

        tempLaser = laser;
    }

    // Start is called before the first frame update
    void Start()
    {
        xMin = Camera.main.ViewportToWorldPoint(new Vector3(0.15f, 0, 0)).x;
        xMax = Camera.main.ViewportToWorldPoint(new Vector3(0.85f, 0, 0)).x;
        y_pos = transform.position.y;
        GameManager.instance.setHealth(currentHealth);
        GameManager.instance.setLaserLevel(laserLevel);
        GameManager.instance.setSpeedLevel(speedLevel);
        GameManager.instance.setMaxHealthLevel(maxHealthLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey("left"))
        {
            if (!(transform.position.x < xMin))
            {
                if (currentPowerUp >= speedCost)
                {
                    transform.position += new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
                }
                else
                {
                    string abitliy = "Speed";
                    int remCost = speedCost - currentPowerUp;
                    displayInsufficientPowerUp(abitliy, remCost);
                }
            }
        }


        if (Input.GetKey("right"))
        {
            if (!(transform.position.x > xMax))
            {
                if (currentPowerUp >= speedCost)
                {
                    transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
                }
                else
                {
                    string abitliy = "Speed";
                    int remCost = speedCost - currentPowerUp;
                    displayInsufficientPowerUp(abitliy, remCost);
                }
            }
        }

        if (Input.GetKeyUp("left"))
        {
            if (currentPowerUp >= speedCost)
            {
                decreasePowerUp(speedCost);
            }
        }

        if (Input.GetKeyUp("right"))
        {
            if (currentPowerUp >= speedCost)
            {
                decreasePowerUp(speedCost);
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (currentPowerUp >= laserCost)
            {
                Instantiate(laser, transform.position, Quaternion.identity);
                decreasePowerUp(laserCost);
            }
            else
            {
                string abitliy = "Laser";
                int remCost = laserCost - currentPowerUp;
                displayInsufficientPowerUp(abitliy, remCost);
            }
        }

    }

    public void enemyHit(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            GameManager.instance.GameOver();
        }
        GameManager.instance.setHealth(currentHealth);
    }

    public void giveHealth()
    {
        if (currentHealth <= maxHealth)
        {
            currentHealth += 1;
        }
        GameManager.instance.setHealth(currentHealth);
    }

    public void givePowerUp()
    {
        currentPowerUp += 1;
        GameManager.instance.setPowerUp(currentPowerUp);
    }

    public void givePowerUp(int points)
    {
        currentPowerUp += points;
        GameManager.instance.setPowerUp(currentPowerUp);
    }

    public void decreasePowerUp()
    {
        currentPowerUp--;
        GameManager.instance.setPowerUp(currentPowerUp);
    }

    public void decreasePowerUp(int points)
    {
        currentPowerUp -= points;
        GameManager.instance.setPowerUp(currentPowerUp);
    }

    public void increaseLaserLevel()
    {
        if (currentPowerUp > 0)
        {
            PlayerLaser thisLaser = laser.gameObject.GetComponent<PlayerLaser>();
            if (laserLevel <= maxAbilityLevel)
            {
                laserLevel++;
                currentPowerUp--;

                if (laserLevel < 6)
                {
                    thisLaser.laserSpeed = thisLaser.laserSpeed * 1.2f;
                    laserCost = 1;
                }

                else if (laserLevel> 6)
                {
                    thisLaser.laserSpeed = thisLaser.laserSpeed * 1.2f;
                    laserCost = 3;
                }

                else
                {
                    laser = bigLaser;
                    laserCost = 3;
                }
            }
        }

        GameManager.instance.setLaserLevel(laserLevel);
        GameManager.instance.setPowerUp(currentPowerUp);
    }

    public void decreaseLaserLevel()
    {
        laserLevel--;
        currentPowerUp++;
        if (laserLevel == 5)
        {
            laser = tempLaser;
        }

        else
        {
            PlayerLaser thisLaser = laser.gameObject.GetComponent<PlayerLaser>();
            thisLaser.laserSpeed = thisLaser.laserSpeed * 0.8f;
        }

        GameManager.instance.setLaserLevel(laserLevel);
        GameManager.instance.setPowerUp(currentPowerUp);
    }

    public void increaseSpeedLevel()
    {
        if (currentPowerUp > 0)
        {
            if (speedLevel <= maxAbilityLevel)
            {
                speedLevel++;
                currentPowerUp--;
                moveSpeed = moveSpeed * 1.2f;
            }

        }

        GameManager.instance.setSpeedLevel(speedLevel);
        GameManager.instance.setPowerUp(currentPowerUp);
    }

    public void decreaseSpeedLevel()
    {
        Debug.Log("Ability Decreased");
        speedLevel--;
        currentPowerUp++;
        moveSpeed = moveSpeed * 0.8f;

        GameManager.instance.setSpeedLevel(speedLevel);
        GameManager.instance.setPowerUp(currentPowerUp);
    }

    public void increaseMaxHealthLevel()
    {
        if (currentPowerUp > 0)
        {
            if (maxHealthLevel <= maxAbilityLevel)
            {
                maxHealthLevel++;
                currentPowerUp--;
                maxHealthLevel += 5;
            }
        }

        GameManager.instance.setMaxHealthLevel(maxHealthLevel);
        GameManager.instance.setPowerUp(currentPowerUp);
    }

    public void decreaseMaxHealthLevel()
    {
        if (maxHealthLevel > 0)
        {
            maxHealthLevel--;
            currentPowerUp++;
            maxHealthLevel += 5;
        }

        GameManager.instance.setSpeedLevel(maxHealthLevel);
        GameManager.instance.setPowerUp(currentPowerUp);
    }

    public void displayInsufficientPowerUp(string ability, int cost)
    {
        GameManager.instance.insufficientTextActive("Insufficient Cost for " + ability + ", need more " + cost + " fuel");
    }
}
