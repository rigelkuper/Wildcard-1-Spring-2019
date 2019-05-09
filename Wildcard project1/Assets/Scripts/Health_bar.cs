using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_bar : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject player;
    Slider barSlider;
    float normalized;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        barSlider = GetComponent<Slider>();
        normalized = 0;
    }

    // Update is called once per frame
    void Update()
    {
        normalized = (float) player.GetComponent<char_health>().getHealth() / (float) player.GetComponent<playerLife>().maxHealth;
        barSlider.normalizedValue = normalized;
    }
}
