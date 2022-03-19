using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_target : MonoBehaviour
{
    public float[] X_patrol_point = new float[5];
    public float[] Y_patrol_point = new float[5]; // 設定巡邏點

    private string Enemy_name; // 巡邏點專屬化
    private int Amount_patrol_point = 0; // 巡邏點總數
    private int Now_pos_index = 0; // 現在位置編號
    private bool Routine = false; // 巡邏狀態, false == 去
    private Vector2 Now; // 下個位置

    [SerializeField]
    public GameObject[] Jump_point = new GameObject[2]; // 設定彈跳點
    [SerializeField]
    private bool[] Jump_control = new bool[2]; // 設定彈跳點是否彈跳(去程)
    [SerializeField]
    private int Amount_jump_point = 0; // 彈跳點總數

    void Start()
    {
        Amount_patrol_point = X_patrol_point.Length; //計算巡邏點總數
        Amount_jump_point = Jump_point.Length; // 計算彈跳點總數

        Now = new Vector2(X_patrol_point[Now_pos_index], Y_patrol_point[Now_pos_index]); 
        transform.position = Now;//設定初始位置

        for (int i = 0; i < Amount_jump_point; i++)
            Jump_point[i].SendMessage("Get_state",Jump_control[i]); //設定 jump_point 初始狀態
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Now = new Vector2(X_patrol_point[Now_pos_index], Y_patrol_point[Now_pos_index]);
        transform.position = Now; //變更位置
    }

    private void Set_flag(bool state)
    {
        if(state)
        {
            for (int i = 0; i < Amount_jump_point; i++)
                Jump_point[i].SendMessage("Get_state", true);
        }
        else
        {
            if(!Routine)
            {
                for (int i = 0; i < Amount_jump_point; i++)
                    Jump_point[i].SendMessage("Get_state", Jump_control[i]);
            }
            else
            {
                for (int i = 0; i < Amount_jump_point; i++)
                    Jump_point[i].SendMessage("Get_state", !Jump_control[i]);
            }
        }
    }
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.tag == "enemy")
      { 
        if (!Routine)
        {
            Now_pos_index++;

            if(Now_pos_index == Amount_patrol_point - 1) //調整來回
            {
                Routine = true;
            }

            for (int i = 0; i < Amount_jump_point; i++)
                Jump_point[i].SendMessage("Get_state", Jump_control[i]);            
        }
        else if(Routine)
        {
            Now_pos_index--;

            if(Now_pos_index == 0)
            {
                Routine = false;
            }

            for (int i = 0; i < Amount_jump_point; i++)
                Jump_point[i].SendMessage("Get_state", !Jump_control[i]);             
        }     
      }
    }
}
