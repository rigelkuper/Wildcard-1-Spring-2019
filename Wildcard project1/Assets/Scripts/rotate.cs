﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float mouseAngle = 0; 
    public float rotationSpeed = 5.0f;

    private Vector2 mouseDirection;
    private Quaternion rotator;

    // Update is called once per frame
    void Update()
    {
        mouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        mouseAngle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg - 90; //conversion from radians to degrees
        rotator = Quaternion.AngleAxis(mouseAngle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotator, rotationSpeed * Time.deltaTime);
    }
}
