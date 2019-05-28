using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory_manager : MonoBehaviour
{
    public GameObject medkit_counter;
    public Button button;
    public int medkits = 0;
    public GameObject player;
    private int index = 0;
    public float y_val = 55f;
    public bool binoculars = false;
    public Camera m_OrthographicCamera;
    public int speedups = 0;
    public GameObject binoc_text;
    public GameObject speedup_counter;
    public GameObject speedup_bar;
    public float speedup_time = 3f;
    public float timer;
    private void Start()
    {
        timer = -1f;
        speedup_bar.GetComponent<Slider>().value = 0f;
    }
    void Update()
    {
        medkit_counter.GetComponent<Text>().text = " x " + medkits;
        if (!binoculars)
        {
            binoc_text.GetComponent<Text>().text = " None";
        }
        else
        {
            binoc_text.GetComponent<Text>().text = " Lvl 1";
        }

        speedup_counter.GetComponent<Text>().text = " x " + speedups;
        if ((0f <= timer) && (timer <= speedup_time))
        {
            timer += Time.deltaTime;
            speedup_bar.GetComponent<Slider>().value = 1f - (timer / speedup_time);
        }
        if (timer >= speedup_time)
        {
            char_movement mvmt = player.transform.GetComponent<char_movement>();
            mvmt.speed = 7;
            rotate rotator = player.transform.GetComponent<rotate>();
            rotator.rotationSpeed = 5;
        }

    }
    public void use_medkit()
    {
        if ((medkits > 0))
        {
            medkits -= 1;
            playerLife heal = player.transform.GetComponent<playerLife>();
            heal.healPlayer(5);
        }
    }
    public void use_binoculars()
    {
        if ((binoculars))
        {
            if (m_OrthographicCamera.orthographicSize == 5.0f)
            {
                m_OrthographicCamera.orthographicSize = 10.0f;
            }
            else if (m_OrthographicCamera.orthographicSize == 10.0f)
            {
                m_OrthographicCamera.orthographicSize = 5.0f;
            }
        }
    }
    public void use_speedups()
    {
        if ((speedups > 0))
        {
            speedups -= 1;
            char_movement mvmt = player.transform.GetComponent<char_movement>();
            mvmt.speed += 4;
            rotate rotator = player.transform.GetComponent<rotate>();
            rotator.rotationSpeed += 4;
            timer = 0f;
            speedup_bar.GetComponent<Slider>().value = 0f;
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.CompareTag("medkit"))
        {
            medkits += 1;
            Destroy(col.gameObject);
        }
        if (col.CompareTag("binoculars"))
        {
            binoculars = true;
            Destroy(col.gameObject);
        }
        if (col.CompareTag("speedups"))
        {
            speedups += 1;
            Destroy(col.gameObject);
        }
    }
    
    
    
}
