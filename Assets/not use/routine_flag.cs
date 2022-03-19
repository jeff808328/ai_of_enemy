using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class routine_flag : MonoBehaviour
{
    public GameObject Flag_before;
    public GameObject Flag_next;
    private GameObject Flag_save;

    public bool flag_message_junp = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.SendMessage("Enemy_get_next_position", Flag_next);

        if (flag_message_junp)
            collision.SendMessage("movement03_jump");

        Flag_save = Flag_next;
        Flag_next = Flag_before;
        Flag_before = Flag_save;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
