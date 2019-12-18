using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Crate : NetworkBehaviour
{
    private bool taken = false;

    [Command]
    void CmdPickUp()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!taken)
            {
                taken = true;
                int r = Random.Range(0, WeaponChange.weaponsAmount);
                collision.gameObject.GetComponent<WeaponChange>().CurrentWeapon = r;
                CmdPickUp();
            }
        }
    }
}
