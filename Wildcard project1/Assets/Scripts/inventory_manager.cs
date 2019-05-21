using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory_manager : MonoBehaviour
{
    public GameObject medkit_counter;
    public int medkits = 0;
    public GameObject player;
    public GameObject selector;
    private int index = 0;
    public float y_val = 55f;
    public bool binoculars = false;
    public Camera m_OrthographicCamera;
    public int speedups = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //binoculars that change camera zoom
        //energy drink that changes player speed/rotation speed

        medkit_counter.GetComponent<Text>().text = "x" + medkits;

        if (Input.GetButtonDown("change_item"))
        {
            index += 1;
            if (index >= 3)
            {
                index = 0;
            }
        }
        if (Input.GetButtonDown("use_item"))
        {
            UseItem();
        }
        MoveSelector();

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
    
    IEnumerator timer(float time, char_movement mvmt, rotate rotator)
    {
        yield return new WaitForSeconds(time);
        mvmt.speed -= 4;
        rotator.rotationSpeed -= 4;
    }
    public void UseItem()
    {
        if ((index == 0) && (medkits > 0))
        {
            medkits -= 1;
            playerLife heal = player.transform.GetComponent<playerLife>();
            heal.healPlayer(5);
        }
        if ((index ==1) && (binoculars))
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
        if ((index == 2) && (speedups > 0))
        {
            speedups -= 1;
            char_movement mvmt = player.transform.GetComponent<char_movement>();
            mvmt.speed += 4;
            rotate rotator = player.transform.GetComponent<rotate>();
            rotator.rotationSpeed += 4;
            StartCoroutine(timer(5f, mvmt, rotator));
            
        }
    }
    public void MoveSelector()
    {
        //105
        //1 = 47
        //2 = -16
        
        if (index == 0)
        {
            y_val = 275f;
        }
        if (index == 1)
        {
            y_val = 165.5f;
        }
        if (index == 2)
        {
            y_val = 75.6f;
        }
        //Debug.Log(selector.GetComponent<RectTransform>().localPosition);
        //selector.GetComponent<RectTransform>().SetPositionAndRotation(new Vector3(27.3f, y_val, 0.0f), new Quaternion(0.0f, 0.0f, 0.7f, 0.7f));
        // selector.GetComponent<RectTransform>().InverseTransformVector(new Vector3(27.3f, y_val, 0.0f));
        selector.GetComponent<RectTransform>().position = new Vector3(34.8f, y_val, 0.0f);
    }
}
