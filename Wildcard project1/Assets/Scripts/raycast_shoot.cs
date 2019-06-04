using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class raycast_shoot : MonoBehaviour
{
    public Transform fire_point;
    public LineRenderer shot;
    public float shot_distance = 5f;
    public Vector3 length;
    public float seconds = 100.5f;
    public float time_since = 0f;
    public GameObject line;
    public int num_shots = 1;
    private bool shoot_bool = false;
    private int frame_counter = 0;
    private int current_frame = -6;
    private bool final_shoot = true;
    playerAmmo ammo;
    void Start()
    {
        shot.SetPosition(0, new Vector3(0, 0, 0));
        shot.SetPosition(0, new Vector3(0, 0, 0));
        shot.startWidth = 0;
        shot.endWidth = 0;
        ammo = GetComponentInParent<playerAmmo>();
    }
    void Update()
    {
        inventory_manager can_fire = GetComponentInParent<inventory_manager>();
        //Debug.Log(can_fire.clicked.ToString() + (Input.GetButton("Fire1") && (time_since <= 0) && (ammo.getCurrentAmmo() > 0) && (can_fire.clicked)).ToString());
        frame_counter += 1;
        
        if (Input.GetButton("Fire1") && (time_since <= 0) && (ammo.getCurrentAmmo() > 0) && (can_fire.clicked))
        {
            for (int i = 0; i < num_shots; i++)
            {
                Shoot();
                current_frame = frame_counter;
                time_since = seconds;
            }
            ammo.decreaseAmmo(1);
        }
        if (!can_fire.clicked)
        {
            Debug.Log(current_frame.ToString() +" " +  frame_counter.ToString());
        }
        time_since -= Time.deltaTime;
    }
    void Shoot()
    {
        GameObject go;
        go = Instantiate(line) as GameObject;
        line_renderer lr = go.transform.GetComponent<line_renderer>();
        lr.Shoot();
        
        StartCoroutine(wait(go));
    }
    IEnumerator wait(GameObject go)
    {
        yield return new WaitForSeconds(.5f);
        Destroy(go);
    }
    
}
