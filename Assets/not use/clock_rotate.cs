using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clock_rotate : MonoBehaviour
{
    private float cal; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Rotate(float temp)
    {
        transform.Rotate(0, 0, -(360/temp));
    }
}
