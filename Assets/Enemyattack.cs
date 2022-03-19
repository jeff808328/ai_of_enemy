using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyattack : MonoBehaviour
{
    Rigidbody2D rd;
    public GameObject Main;

    [SerializeField]
    private float Pushforce = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = Main.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            rd = collision.GetComponent<Rigidbody2D>();
            rd.velocity = new Vector2(Pushforce, 0);
        }
    }
}
