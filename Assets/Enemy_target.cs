using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_target : MonoBehaviour
{
    public float[] X_patrol_point = new float[5];
    public float[] Y_patrol_point = new float[5]; // �]�w�����I

    private string Enemy_name; // �����I�M�ݤ�
    private int Amount_patrol_point = 0; // �����I�`��
    private int Now_pos_index = 0; // �{�b��m�s��
    private bool Routine = false; // ���ު��A, false == �h
    private Vector2 Now; // �U�Ӧ�m

    [SerializeField]
    public GameObject[] Jump_point = new GameObject[2]; // �]�w�u���I
    [SerializeField]
    private bool[] Jump_control = new bool[2]; // �]�w�u���I�O�_�u��(�h�{)
    [SerializeField]
    private int Amount_jump_point = 0; // �u���I�`��

    void Start()
    {
        Amount_patrol_point = X_patrol_point.Length; //�p�⨵���I�`��
        Amount_jump_point = Jump_point.Length; // �p��u���I�`��

        Now = new Vector2(X_patrol_point[Now_pos_index], Y_patrol_point[Now_pos_index]); 
        transform.position = Now;//�]�w��l��m

        for (int i = 0; i < Amount_jump_point; i++)
            Jump_point[i].SendMessage("Get_state",Jump_control[i]); //�]�w jump_point ��l���A
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Now = new Vector2(X_patrol_point[Now_pos_index], Y_patrol_point[Now_pos_index]);
        transform.position = Now; //�ܧ��m
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

            if(Now_pos_index == Amount_patrol_point - 1) //�վ�Ӧ^
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
