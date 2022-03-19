using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_get_command : MonoBehaviour
{
    [Header("¶ë¤J¼Ä¤H")]
    public GameObject Enemy_01;
    private int Condition = 0;

   

    private float[] Setting = new float[2];

    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Enemy_01.SendMessage("Enemy_get_state", Setting);
    }

    void Get_state(int state)
    {
        Setting[0] = state;
    }

    private void get_setting(float temp_long)
    {
        Setting[1] = temp_long;
    }
}
