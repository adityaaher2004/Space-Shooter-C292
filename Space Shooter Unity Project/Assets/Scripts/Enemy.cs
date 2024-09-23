using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 2f;

    [SerializeField] GameManager manager;

    int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float minEnemyHeight = Camera.main.ViewportToWorldPoint(new Vector3(0, -1.15f, 0)).y;
        if (transform.position.y < minEnemyHeight)
        {
            Destroy(gameObject);
        }
        transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Player player = collision.gameObject.GetComponent<Player>();
            player.enemyHit(damage);

        }
        else if (collision.gameObject.tag == "Laser" || collision.gameObject.tag == "Big Laser")
        {
            // Check and destroy enemy only if it is on screen
            Vector3 enemyPos = Camera.main.WorldToViewportPoint(transform.position);

            if (enemyPos.y >= 0f && enemyPos.y <= 1f) 
            { 
                GameManager.instance.increaseScore(10);
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Last Defence Line")
        {
            GameManager.instance.enemyCrossDefenceLine(1);
        }
    }
}
