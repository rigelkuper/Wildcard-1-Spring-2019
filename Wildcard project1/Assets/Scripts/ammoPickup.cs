using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoPickup : MonoBehaviour
{
    public int increaseAmount = 5;

    void onTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player" && !other.isTrigger){
            other.gameObject.GetComponent<playerAmmo>().increaseAmmo(increaseAmount);
        }

    }
}
