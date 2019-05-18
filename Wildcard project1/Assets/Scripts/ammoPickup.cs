using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoPickup : MonoBehaviour
{
    public int increaseAmount = 5;
    public GameObject targetGun;

    bool pickedUp;
    System.Type targetType;

    void Start()
    {
        pickedUp = false;
        targetType = targetGun.GetType();
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player" && pickedUp == false){
            //Debug.Log("Player touched ammo pickup");
            other.gameObject.GetComponent<playerAmmo>().increaseAmmo(targetGun, increaseAmount);
            pickedUp = true;
            Destroy(gameObject);
        }

    }
}
