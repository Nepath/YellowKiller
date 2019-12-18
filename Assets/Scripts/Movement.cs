using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Movement : NetworkBehaviour
{
    [SerializeField]
    public float Speed = 6f;
    public float JumpForce = 5.5f;
    public bool Grounded = false;
    public int JumpsLeft = 2;
    public bool facingRight = false;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (isLocalPlayer)
        {
            Jump();
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * Time.deltaTime * Speed;

            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mouse.x < transform.position.x && facingRight)
            {
                Flip();
            }
            else if (mouse.x > transform.position.x && !facingRight)
            {
                Flip();
            }

            Rotate();
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && (Grounded || JumpsLeft > 0))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            JumpsLeft--;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 flip = transform.localScale;
        flip.x *= -1;
        transform.localScale = flip;
    }

    void Rotate()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();
        float rot = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        if (facingRight)
            transform.rotation = Quaternion.Euler(0f, 0f, rot);
        else
            transform.rotation = Quaternion.Euler(0f, 0f, rot + 180);
    }

}
