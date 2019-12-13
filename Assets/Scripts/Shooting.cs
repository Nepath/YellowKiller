using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private Transform gun_Shot;

    [SerializeField]
    private GameObject bullet;

    GameObject firedBullet;
    private Transform fire_point_position;
    float _currentLife;
    bool mouse_down = false;
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        OnPointerDown();
        OnPointerUp();

        if (mouse_down==true)
        {
            
                if (GameObject.Find("Head").GetComponent<Movement>().facingRight == true)
                {
                    firedBullet = Instantiate(bullet, gun_Shot.position, gun_Shot.rotation);
                    firedBullet.GetComponent<Rigidbody2D>().velocity = gun_Shot.right * 30f;
                    Destroy(firedBullet, 20);
                }
                else
                {
                    gun_Shot.transform.Rotate(0, 180, 0);
                    firedBullet = Instantiate(bullet, gun_Shot.position, gun_Shot.rotation);
                    firedBullet.GetComponent<Rigidbody2D>().velocity = gun_Shot.right * 50f;
                    gun_Shot.transform.Rotate(0, 180, 0);
                    Destroy(firedBullet, 50);

                }
            
            //firedBullet.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0f, 0f) * Time.deltaTime ;
        }
    }
    void OnPointerDown()
    {
        if(Input.GetMouseButtonDown(0))
        mouse_down = true;
    }
    void OnPointerUp()
    {
        if (Input.GetMouseButtonUp(0))
            mouse_down = false;
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //    {
    //        Destroy(firedBullet);
    //        Debug.Log("poszlo");

    //    }

    //}
}
