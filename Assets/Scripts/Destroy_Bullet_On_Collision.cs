using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Destroy_Bullet_On_Collision : NetworkBehaviour
{
    Vector2 position;
    Vector2 position2;

    [SerializeField]
    public GameObject groundDestroyer;
    [SerializeField]
    public GameObject playerDestroyer;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground") {
            position= gameObject.transform.position;
            GameObject bullet = Instantiate(groundDestroyer, position, Quaternion.identity);
            NetworkServer.Spawn(bullet);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            int dmg = collision.gameObject.GetComponent<WeaponChange>().GetWeapon.Damage;
            collision.gameObject.GetComponent<PlayerAtributes>().DealDamage(dmg);
            position2 = gameObject.transform.position;
            GameObject bullet = Instantiate(playerDestroyer, position2, Quaternion.identity);
            NetworkServer.Spawn(bullet);
            Destroy(gameObject);
        }
    }
}


