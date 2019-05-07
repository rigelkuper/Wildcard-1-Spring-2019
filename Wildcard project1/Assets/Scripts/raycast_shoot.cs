using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Start()
    {
        shot.SetPosition(0, new Vector3(0, 0, 0));
        shot.SetPosition(0, new Vector3(0, 0, 0));
        shot.startWidth = 0;
        shot.endWidth = 0;
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && (time_since <= 0))
        {
            for (int i = 0; i < num_shots; i++)
            {
                Shoot();
                time_since = seconds;
            }
            
        }
        time_since -= Time.deltaTime;
    }
    void Shoot()
    {
        GameObject go;
        go = Instantiate(line) as GameObject;
        
        
        StartCoroutine(wait(go));
    }
    IEnumerator wait(GameObject go)
    {
        yield return new WaitForSeconds(.5f);
        Destroy(go);
    }
    
}
