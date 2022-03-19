using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    [SerializeField]
    public GameObject Starting_flag; 
    [SerializeField]
    private GameObject Next_flag; 

    private Vector2 Next_position;
    private float Condition;
    Rigidbody2D rd;

    [Header("調整移動速度")]
    public float Enemy_move_speed = 1f;

    private float Sub_temp_long;  // 一拍長度

    void Start()
    {
        transform.position = Starting_flag.transform.position;
        rd = GetComponent<Rigidbody2D>();
    }

    void Enemy_get_state(float[] state)
    {
        Condition = state[0];
        Sub_temp_long = state[1];
    }
    void Enemy_get_next_position(GameObject pos)
    {
        Next_flag= pos;
    }

    private void FixedUpdate()
    {
        if (Condition == 1)
            movement01_walk();
        else if (Condition == 2)
            movement02_stop();
    }

    void movement01_walk()
    {
        Next_position = Vector2.Lerp(transform.position, Next_flag.transform.position, (Enemy_move_speed + 3f) * Time.deltaTime/Sub_temp_long);
        transform.position = Next_position;
    }

    void movement02_stop()
    {     
        float stop_time = Time.time + 50f ;
        
        while(stop_time <= Time.time)
        {
            Debug.Log("tt");
            Next_position = Vector2.Lerp(transform.position, Next_flag.transform.position, Enemy_move_speed * Time.deltaTime);
            transform.position = Next_position;
        }    
    }

    void movement03_jump()
    {
        rd.AddForce(Vector3.up * 400);

        movement01_walk();
    }
}
