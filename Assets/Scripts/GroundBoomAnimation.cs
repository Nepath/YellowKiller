using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GroundBoomAnimation : NetworkBehaviour
{
    float boomRate = 2;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        /// if (Time.time > boomRate)
            {
                float x, y, z;
                x = (float)i / 100;
                y = (float)i / 100;
                z = (float)i / 100;
                Vector3 vector = new Vector3(x, y, z);
                transform.localScale = vector;
                boomRate = Time.time + boomRate;
            }
        if (i >= 10)
        {
            Destroy(this.gameObject);
        }
        i++;
    }
}
