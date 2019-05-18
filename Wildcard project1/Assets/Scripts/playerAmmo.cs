using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAmmo : MonoBehaviour
{
    public int startingAmmo = 0;
    public int numOfGuns = 3;
    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;

    GameObject currentGunType;
    Dictionary<GameObject, int> ammo;
    gun_manager playerGuns;
    //int currentAmmo;
    // Start is called before the first frame update
    void Start()
    {
        //currentAmmo = startingAmmo;
        ammo = new Dictionary<GameObject, int>();
        playerGuns = GetComponent<gun_manager>();
        currentGunType = playerGuns.current_gun;

        ammo.Add(gun1, startingAmmo);
        ammo.Add(gun2, startingAmmo);
        ammo.Add(gun3, startingAmmo);
    }

    void Update()
    {
        currentGunType = playerGuns.current_gun;
        //Debug.Log(currentGunType.ToString());
    }

    public int getCurrentAmmo()
    {
        return ammo[currentGunType];
    }

    public void increaseAmmo(GameObject gunType, int amount)
    {
        //currentAmmo += amount;
        ammo[gunType] += amount;
    }

    public void decreaseAmmo(int amount)
    {
        if ((ammo[currentGunType] - amount) <= 0){
            ammo[currentGunType] = 0;
        } else {
            ammo[currentGunType] -= amount;
        }
    }
}
