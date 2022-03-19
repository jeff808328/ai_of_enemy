using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_patrol : MonoBehaviour
{
    [SerializeField]
    private bool Patorl_mode = true;
    [SerializeField]
    private bool Trace_mode = false; // 行為模式開關

    private Vector2 Now; // 計算下個位置

    public GameObject Next_point;
    public GameObject Next_player; // 儲存追蹤物件

    public Vector2 Pos_start; // 敵人角色起始點

    [SerializeField]
    private float Move_speed = 1; // 敵人角色移動速度

    void Start()
    {
        transform.position = Pos_start; //設定起始位置
    }

    private void Get_target(bool state) //設定行動模式
    {
        Trace_mode = state;
        Patorl_mode = !state;

        Next_point.SendMessage("Set_flag",state);
    }
      
    private void FixedUpdate()
    {
        if (Patorl_mode)
        {
            Now = Vector2.MoveTowards(transform.position, Next_point.transform.position, Time.deltaTime * Move_speed);      
        }
        else if(Trace_mode)
        {
            Now = Vector2.MoveTowards(transform.position, Next_player.transform.position, Time.deltaTime * Move_speed * 1.1f); 
        }

        transform.position = Now;    
    }
}
