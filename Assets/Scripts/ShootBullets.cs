using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
[System.Obsolete]
public class ShootBullets : NetworkBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float bulletSpeed;

    private bool mouse_down = false;

    private float fireRate = 0.5f;

    private int tryb =2; //1=pistolet 2= shotgun 3= karabin

    float nextFire;
    
    void Update()
    {
        if (this.isLocalPlayer)
        {
            OnPointerDown();
            OnPointerUp();
            if (mouse_down == true && Time.time > nextFire)
            {
                if (tryb == 1)
                {
                    fireRate = 0.5f;
                    nextFire = Time.time + fireRate;
                    CmdShoot();
                }
                else if (tryb == 2)
                {
                    fireRate = 1f;
                    nextFire = Time.time + fireRate;
                    CmdShootShotgun();
                }
                else if (tryb == 3)
                {
                    fireRate = 0.1f;
                    nextFire = Time.time + fireRate;
                    CmdShootRifle();
                }

            }
        }
    }
    [Command]
    void CmdShoot()
    {
        Vector2 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = diff * bulletSpeed;
        NetworkServer.Spawn(bullet);
        Destroy(bullet, 5.0f);
    }
    [Command]
    void CmdShootShotgun()
    {
        Vector2 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = diff * bulletSpeed;
        diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.x += 1;
        diff.y += 1;
        diff.Normalize();
        GameObject bullet1 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet1.GetComponent<Rigidbody2D>().velocity = diff * bulletSpeed;
        diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.x -= 1;
        diff.y -= 1;
        diff.Normalize();
        GameObject bullet2 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet2.GetComponent<Rigidbody2D>().velocity = diff * bulletSpeed;
        diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.x += 0.5f;
        diff.y += 0.5f;
        diff.Normalize();
        GameObject bullet3 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet3.GetComponent<Rigidbody2D>().velocity = diff * bulletSpeed;
        diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.x -= 0.5f;
        diff.y -= 0.5f;
        diff.Normalize();
        GameObject bullet4 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet4.GetComponent<Rigidbody2D>().velocity = diff * bulletSpeed;

        NetworkServer.Spawn(bullet);
        NetworkServer.Spawn(bullet1);
        NetworkServer.Spawn(bullet2);
        NetworkServer.Spawn(bullet3);
        NetworkServer.Spawn(bullet4);
        Destroy(bullet, 5.0f);
        Destroy(bullet1, 5.0f);
        Destroy(bullet2, 5.0f);
        Destroy(bullet3, 5.0f);
        Destroy(bullet4, 5.0f);
    }
    [Command]
    void CmdShootRifle()
    {
        var number = Random.Range(-50, 50);
        float recoilNumber = number / 35;
        Debug.Log(number);
        Vector2 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.x += recoilNumber;
        diff.y += recoilNumber;
        diff.Normalize();
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = diff * bulletSpeed;
        NetworkServer.Spawn(bullet);
        Destroy(bullet, 5.0f);
    }

    void OnPointerDown()
    {
        if (Input.GetMouseButtonDown(0))
            mouse_down = true;
    }
    void OnPointerUp()
    {
        if (Input.GetMouseButtonUp(0))
            mouse_down = false;
    }

}