using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_view : MonoBehaviour
{
    [SerializeField]
    private GameObject Main;

    private GameObject player;

    private bool tracing = false;

    public float Tracing_dis = 4;

    private float dis;

    void Start()
    {

    }
    
    void FixedUpdate()
    {
        transform.position = Main.transform.position;

        if(tracing)
        {
            dis = (Main.transform.position - player.transform.position).sqrMagnitude;

            if (dis > Tracing_dis)
            {
                Main.SendMessage("Get_target", false);
                player = null;
                tracing = false;

                Debug.Log("rr");
            }
        }
       
    }

    private void OnTriggerEnter2D(Collider2D obj)
    { 
        if (obj.tag == "Player")
        {
            Main.SendMessage("Get_target",true);
            player = obj.gameObject;
            tracing = true;

            Debug.Log("ww");
        }
    }
}
