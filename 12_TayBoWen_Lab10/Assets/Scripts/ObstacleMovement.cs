﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private float xSpeed = -4f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(xSpeed*Time.deltaTime, 0, 0f));
        if (transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }
}