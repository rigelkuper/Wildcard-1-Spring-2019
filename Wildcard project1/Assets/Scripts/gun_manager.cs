using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class gun_manager : MonoBehaviour
{
    public GameObject current_gun;
    public int current_index = 0;
    public Transform parent;



    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;
    public GameObject gun4;
    List<GameObject> temp_list;
    List<GameObject> gun_list;

    // Start is called before the first frame update
    void Start()
    {
        temp_list = new List<GameObject>();
        gun_list = new List<GameObject>();
        temp_list.Add(gun1);
        temp_list.Add(gun2);
        temp_list.Add(gun3);
        temp_list.Add(gun4);
        //yes I know it is hardcoded and ugly. Sue me
        foreach (GameObject go in temp_list)
        {
            if (go != null)
            {
                gun_list.Add(go);
            }
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("change_gun") || (Input.GetAxis("scroll") != 0))
        {
            current_index += (int)Input.GetAxis("change_gun") + Math.Sign(Input.GetAxis("scroll"));
        }

        if (current_index < 0)
        {
            current_index = gun_list.Count -1;
        }
        if (current_index >= gun_list.Count)
        {
            current_index = 0;
        }
        current_gun = gun_list[current_index];
        
        
        if (Input.GetButtonDown("change_gun") || (Input.GetAxis("scroll") != 0))
        {
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            //current_gun.transform.SetParent(parent);
            var gun = Instantiate(current_gun, parent.transform);
            gun.transform.SetParent(parent);
            
        }
        
    }
}
