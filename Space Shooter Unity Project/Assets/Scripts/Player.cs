using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float y_pos;
    [SerializeField] GameObject laser;
    [SerializeField] GameManager manager;
    [SerializeField] float moveSpeed;

    Vector3 spawnPosition;

    float xMin;
    float xMax;

    int maxHealth = 10;
    public int currentHealth;

    int currentPowerUp = 0;

    private void Awake()
    {
        spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.15f, 0));
        currentHealth = 5;
    }

    // Start is called before the first frame update
    void Start()
    {
        xMin = Camera.main.ViewportToWorldPoint(new Vector3(0.15f, 0, 0)).x;
        xMax = Camera.main.ViewportToWorldPoint(new Vector3(0.85f, 0, 0)).x;
        y_pos = transform.position.y;
        GameManager.instance.setHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey("left"))
        {
            if (!(transform.position.x < xMin))
            {
                transform.position += new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
            }
        }

        if (Input.GetKey("right"))
        {
            if (!(transform.position.x > xMax))
            {
                transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(laser, transform.position, Quaternion.identity);
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
}
