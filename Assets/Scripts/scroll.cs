
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{
    void Update()
    {
        transform.position += new Vector3(-0.5f * Time.deltaTime, 0);

        if(transform.position.x < -1.442)
		{
            transform.position = new Vector3(1.442f, transform.position.y);
		}
    }
}
