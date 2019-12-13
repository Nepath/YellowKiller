using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Bullet_On_Collision : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"chuj {collision.gameObject.tag}");
        if (collision.gameObject.tag == "Ground") { 
        Destroy(gameObject);
    }
    }
    // Start is called before the first frame update

}
    

