using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_follow : MonoBehaviour
{
    [SerializeField]
    private Transform target; //the target in which to chase

    [SerializeField]
    private bool follow_player;
    [SerializeField]
    private float distance;
    [SerializeField]
    private Transform thePlayer;

    //For the zombie moving around randomly
    [SerializeField]
    private bool idle;
    [SerializeField]
    private Transform minX;
    [SerializeField]
    private Transform maxX;
    [SerializeField]
    private Transform minY;
    [SerializeField]
    private Transform maxY;
    private float wait_time; // make private
    [SerializeField]
    private float start_wait_time;

    // Start is called before the first frame update
    void Start()
    {
        //gets the target or the player gameobject
        follow_player = false;
        thePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //this is for random movement when not following the player
        idle = true;
        wait_time = start_wait_time;
        target.position = new Vector2(Random.Range(minX.position.x, maxX.position.x), Random.Range(minY.position.y, maxY.position.y));
    }

    // Update is called once per frame
    void Update()
    {

        if (follow_player)
        {
            idle = false;
            target.position = thePlayer.position;
        }

        else if (idle)
        {
            //waits(wait_time) until to move to another position
            if (Vector2.Distance(transform.position, target.position) < 1.0f)
            {
                if (wait_time <= 0)
                {
                    target.position = new Vector2(Random.Range(minX.position.x, maxX.position.x), Random.Range(minY.position.y, maxY.position.y));
                    wait_time = start_wait_time;
                }
                else
                {
                    wait_time -= Time.deltaTime;
                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        //follows player if in circle collider
        if (collision.gameObject.tag == "Player")
        {
            idle = false;
            follow_player = true;

            if (Vector2.Distance(transform.position, target.position) > distance)
            {

                target.position = thePlayer.position;
            }

        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        //when player leaves circle collider, zombie stops following
        follow_player = false;
        idle = true;
    }


}
