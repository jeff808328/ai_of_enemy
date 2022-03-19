using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_patrol : MonoBehaviour
{
    [SerializeField]
    private bool Patorl_mode = true;
    [SerializeField]
    private bool Trace_mode = false; // �欰�Ҧ��}��

    private Vector2 Now; // �p��U�Ӧ�m

    public GameObject Next_point;
    public GameObject Next_player; // �x�s�l�ܪ���

    public Vector2 Pos_start; // �ĤH����_�l�I

    [SerializeField]
    private float Move_speed = 1; // �ĤH���Ⲿ�ʳt��

    void Start()
    {
        transform.position = Pos_start; //�]�w�_�l��m
    }

    private void Get_target(bool state) //�]�w��ʼҦ�
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
