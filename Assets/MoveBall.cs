using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MoveBall : NetworkBehaviour
{
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.isLocalPlayer)
        {
            float movement = Input.GetAxis("Horizontal");
            GetComponent<Rigidbody2D>().velocity = new Vector2(movement * speed, 0.0f);
        }
    }
}
