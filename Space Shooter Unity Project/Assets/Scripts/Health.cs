using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] float speed = 10f;

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
            player.giveHealth();

        }
    }
}
