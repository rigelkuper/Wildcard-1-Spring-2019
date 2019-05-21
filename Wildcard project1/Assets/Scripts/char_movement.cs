using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class char_movement : MonoBehaviour
{
    public float speed = 10.0f;
    public Rigidbody2D rb;

    void Update()
    {
        float horiz = Input.GetAxis("Horizontal") * speed;
        float vert = Input.GetAxis("Vertical") * speed;
        rb.velocity = new Vector3(horiz, vert);
    }
    public void SpeedUp(float time)
    {

        speed += 4;
        StartCoroutine(timer(time));
        
        
    }
    IEnumerator timer(float time)
    {
        yield return new WaitForSeconds(time);
        speed -= 4;
    }
}
