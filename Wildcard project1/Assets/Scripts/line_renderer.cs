﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line_renderer : MonoBehaviour
{
    public Transform fire_point;
    public LineRenderer shot;
    public float shot_distance = 5f;
    public Vector3 length;
    public float seconds = 100.5f;
    public float time_since = 0f;
    public float start = 0;
    public float test_scalar = 1f;
    public float accuracy = 0f;
    public float damage = 1f;
    // Start is called before the first frame update
    public void Shoot()
    {
        float scalar = Random.Range(-accuracy, accuracy);
        start = Time.time;
        shot.SetPosition(0, new Vector3(0, 0, 0));
        shot.SetPosition(1, new Vector3(0, 0, 0));
        shot.startWidth = 0;
        shot.endWidth = 0;
        shot.startWidth = .1f;
        shot.endWidth = .1f;
        RaycastHit2D hit_info = Physics2D.Raycast(fire_point.position, fire_point.right + fire_point.up * (0.2f * scalar), shot_distance);
        shot.SetPosition(0, fire_point.position);
        if ((hit_info.collider != null) && (hit_info.collider.CompareTag("Enemy")))
        {
            enemy_controller health = hit_info.transform.GetComponent<enemy_controller>();
            health.damageEnemy(damage);
            shot.SetPosition(1, hit_info.point);
        }
        if ((hit_info.collider != null))
        {
            shot.SetPosition(1, hit_info.point);
        }
        else
        {
            length = (fire_point.up);
            shot.SetPosition(1, (fire_point.position + fire_point.right * shot_distance + fire_point.up * scalar));
        }
        StartCoroutine(wait());
        
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(.5f);
        shot.SetPosition(0, new Vector3(0, 0, 0));
        shot.SetPosition(1, new Vector3(0, 0, 0));
        shot.startWidth = 0;
        shot.endWidth = 0;
        
    }
    
}
