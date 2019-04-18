using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast_shoot : MonoBehaviour
{
    public float damage = 1.0f;
    public float fire_rate = .25f;
    public float weapon_range = 50f;
    public float hit_force = 100f;


    public Transform gun_end;
    private GameObject hand;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    private LineRenderer shot_line;
    private float next_fire;
    void Start()
    {
        shot_line = GetComponent<LineRenderer>();
    }
    void Update()
    {
        if (Input.GetAxis("Fire1") > 0 && (Time.time > next_fire))
        {
            next_fire = Time.time + fire_rate;
            StartCoroutine(ShotEffect());
            RaycastHit hit;
        }

        Vector3 rayOrigin = new Vector3(0, 0, 0); //fix me I'm wrong
        shot_line.SetPosition(0, gun_end.position);
        //if (Physics.Raycast(rayOrigin, hand.transform.forward, out hit, weapon_range))
        //{}

    }
    private IEnumerator ShotEffect()
    {
        shot_line.enabled = true;
        yield return shotDuration;
        shot_line.enabled = false;
    }
}
