using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtributes : MonoBehaviour
{
    int health;
    float speed;
    float jumpForce;
    int deaths = 0;

    public GameObject Respawner;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        speed = 6f;
        jumpForce = 5.5f;

        this.GetComponent<Movement>().Speed = speed;
        this.GetComponent<Movement>().JumpForce = jumpForce;
    }

    public void DealDamage(int x)
    {
        health -= x;
        if(health <= 0)
        {
            Death();
        }
    }

    public void AdjustSpeed(float x)
    {
        speed += x;
        this.GetComponent<Movement>().Speed = speed;
    }
    public void AdjustJump(float x)
    {
        jumpForce += x;
        this.GetComponent<Movement>().JumpForce = jumpForce;
    }

    void Death()
    {
        Vector3 pos = Respawner.GetComponent<CreateRespawn>().GetRandomRespawn();
        health = 100;
        deaths++;
        transform.position = pos;
    }
}
