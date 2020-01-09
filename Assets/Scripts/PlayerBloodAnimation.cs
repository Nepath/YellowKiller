using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerBloodAnimation : NetworkBehaviour
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
            float x =0.1f, y=0.1f, z=0.1f;
            x += 0.6f;
            y += 0.6f;
            z += 0.6f;
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
