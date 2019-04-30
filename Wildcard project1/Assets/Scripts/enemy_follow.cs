using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_follow : MonoBehaviour
{
    //For moving and following player
    [SerializeField]
    private float speed; //speed for zombie
    [SerializeField]
    private float distance; //how far away the zombie should be from the player; just incase the zombie pushes the player
    private Transform target; //the target in which to chase
    [SerializeField]
    private bool follow_player;

    //For the zombie moving around randomly
    private bool idle;
    [SerializeField]
    private Transform move_spots;
    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float minY;
    [SerializeField]
    private float maxY;
    private float wait_time;
    [SerializeField]
    private float start_wait_time;

    // Start is called before the first frame update
    void Start()
    {
        follow_player = false;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        idle = true;
        wait_time = start_wait_time;
    }

    // Update is called once per frame
    void Update()
    {
        if (follow_player)
        {
            idle = false;

            var relativePosition = target.position - transform.position;
            var angle = Mathf.Atan2(relativePosition.y, relativePosition.x) * Mathf.Rad2Deg - 90;
            var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = rotation;
        }
        else if (idle)
        {
            transform.position = Vector2.MoveTowards(transform.position, move_spots.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, move_spots.position) < 0.2f)
            {
                if (wait_time <= 0)
                {
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
        if (collision.gameObject.tag == "Player")
        {
            idle = false;

            if (Vector2.Distance(transform.position, target.position) > distance)
            {
                follow_player = true;
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }

        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        follow_player = false;
        idle = true;
    }
}
