using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_control : MonoBehaviour
{
    Rigidbody2D rd;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(14, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            rd.velocity = new Vector2(0, 10);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x - 1,transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x + 1, transform.position.y);
        }
    }
}
