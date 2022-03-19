using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_jump : MonoBehaviour
{
    private Rigidbody2D Enemy_rd;

    private string Enemy_name;

    [SerializeField]
    private float Jump_force_patrol;

    [SerializeField]
    private float Jump_force_trace;

    private bool On;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (On & collision.tag == "enemy")
        {
            Enemy_rd = collision.GetComponent<Rigidbody2D>();
            Enemy_rd.velocity = new Vector2(0, Jump_force_patrol);
        }
    }

    void Get_state(bool Jump_switch)
    {
        On = Jump_switch;
    }
}
