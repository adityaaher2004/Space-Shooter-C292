using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    [SerializeField] public float laserSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float maxLaserHeight = Camera.main.ViewportToWorldPoint(new Vector3(0, 1.15f, 0)).y;
        if (transform.position.y > maxLaserHeight)
        {
            Destroy(gameObject);
        }
        transform.position += new Vector3(0, laserSpeed, 0) * Time.deltaTime;
    }
}
