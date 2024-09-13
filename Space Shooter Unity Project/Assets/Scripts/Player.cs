using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float y_pos;
    [SerializeField] GameObject laser;
    // Start is called before the first frame update
    void Start()
    {
        y_pos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(pos.x, y_pos, 0);

        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(laser, transform.position, Quaternion.identity);
        }

    }
}
