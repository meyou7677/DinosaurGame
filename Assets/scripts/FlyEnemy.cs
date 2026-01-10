using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlyEnemy : MonoBehaviour
{

    private Rigidbody m_rb;
    public float range;
    public float frecuency;
    private Vector3 m_position;
    private float moving_timer;
    private float moving_time = 2;
    private int moving_direction = 1;
    public float moving_speed;
    public float min_time;
    public float max_time;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moving_timer += Time.deltaTime;
        float y = Mathf.Sin(Time.realtimeSinceStartup * frecuency) * range;
        if(moving_timer >= moving_time)
        {
            int R = UnityEngine.Random.Range(0, 2);
            if (R == 0)
            {
                moving_direction = -1;
            }
            else
            {
                moving_direction = 1;
            }
            moving_time = UnityEngine.Random.Range(min_time, max_time);
            moving_timer = 0;
        }
        m_rb.MovePosition(new Vector3(transform.position.x , m_position.y + y, transform.position.z + moving_direction * moving_speed * Time.deltaTime));
        
    }
}
