using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Destroy_Bullet_On_Collision : NetworkBehaviour
{
    Vector2 position;

    [SerializeField]
    public GameObject groundDestroyer;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground") {
            position= gameObject.transform.position;
            GameObject bullet = Instantiate(groundDestroyer, position, Quaternion.identity);
            NetworkServer.Spawn(bullet);
            Destroy(gameObject);
    }
    }
    // Start is called before the first frame update

}


