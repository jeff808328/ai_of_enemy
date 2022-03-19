using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float Time_begin; //小節起始時間
    private float Time_now; // 現在時間
    private float Sub_com; // 小節進行度
    private float Sub_temp_long;  // 一拍長度

    [SerializeField]
    private GameObject Clock;
    [SerializeField]
    private GameObject Enemy_manager;

    [Header("小節長度 單位:秒")]
    public float Sub_long; // 小節長度 單位:秒
    [Header("小節拍數")]
    public float Sub_temp; // 小節拍數
   
    void On_temp()
    {
        Clock_rotate();
        Enemy_manager.SendMessage("Get_state", 2);
    }

    void During_temp()
    {
        Enemy_manager.SendMessage("Get_state", 1);
    }

    void Clock_rotate()
    {
        Clock.SendMessage("Rotate",Sub_temp);
    }


    void Start()
    {
        Time_begin = Time.time;

        Sub_temp_long = Sub_long / Sub_temp;

        Enemy_manager.SendMessage("get_setting", Sub_temp_long);
    }

    private void FixedUpdate()
    {
        Time_now = Time.time;

        Sub_com = (Time_now - Time_begin) / Sub_long;

        if (Sub_com % Sub_temp_long == 0)
            On_temp();
        else
            During_temp();
    }
}
