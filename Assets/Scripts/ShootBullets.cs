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

    private float magSize;

    private int tryb = 2; //1=pistolet 2= shotgun 3= karabin
    AudioSource asource;

    [SerializeField]
    AudioClip m4a1_Sound;
    [SerializeField]
    AudioClip pistol_Sound;
    [SerializeField]
    AudioClip snipe_Sound;
    [SerializeField]
    AudioClip shotgun_sound;

    Weapon weapon;

    float nextFire;

    Vector3 BarrelPosition
    {
        get
        {
            return transform.GetComponent<WeaponChange>().GetBarrelPosition;
        }
    }

    private void Start()
    {
        asource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (this.isLocalPlayer)
        {
            if (magSize < 1)
            {
                this.GetComponent<WeaponChange>().CurrentWeapon = 0;
            }

            OnPointerDown();
            OnPointerUp();
            if (mouse_down == true && Time.time > nextFire && magSize > 0)
            {
                if (tryb == 1)
                {
                    if (GetComponent<WeaponChange>().CurrentWeapon == 0)
                    {
                        asource.PlayOneShot(pistol_Sound);
                    }
                    else
                    {
                        asource.PlayOneShot(snipe_Sound);
                    }
                    nextFire = Time.time + fireRate;
                    CmdShoot();
                }
                else if (tryb == 2)
                {
                    asource.PlayOneShot(shotgun_sound);
                    nextFire = Time.time + fireRate;
                    CmdShootShotgun();
                }
                else if (tryb == 3)
                {
                    asource.PlayOneShot(m4a1_Sound);
                    nextFire = Time.time + fireRate;
                    CmdShootRifle();
                }
                magSize -= 1;

            }
        }
    }

    [Command]
    void CmdShoot()
    {
        Vector2 diff = Accurancy();
        GameObject bullet = Instantiate(bulletPrefab, BarrelPosition, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = diff * bulletSpeed;
        NetworkServer.Spawn(bullet);
        Destroy(bullet, 5.0f);
    }

    [Command]
    void CmdShootShotgun()
    {
        Vector2 diff;

        for (int i = 0; i < 5; i++)
        {
            diff = Accurancy();

            GameObject bullet = Instantiate(bulletPrefab, BarrelPosition, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = diff * bulletSpeed;

            NetworkServer.Spawn(bullet);
            Destroy(bullet, 5.0f);
        }
    }

    [Command]
    void CmdShootRifle()
    {
        Vector2 diff = Accurancy();
        GameObject bullet = Instantiate(bulletPrefab, BarrelPosition, Quaternion.identity);
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

    public void OnWeaponChanged()
    {
        weapon = this.GetComponent<WeaponChange>().GetWeapon;
        tryb = weapon.FiringMode;
        magSize = weapon.MagSize;
        fireRate = weapon.FiringRate;
    }

    Vector2 Accurancy()
    {
        Vector2 player = transform.position;//new Vector2(transform.GetComponent<WeaponChange>().GetBarrelPosition.x, transform.GetComponent<WeaponChange>().GetBarrelPosition.y);
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float a = mouse.y - player.y;
        float b = mouse.x - player.x;
        float tan = a / b;
        float angle = Mathf.Atan(tan);

        angle += Random.Range(-weapon.Accurancy, weapon.Accurancy);
        tan = Mathf.Tan(angle);
        a = tan * b;

        Vector2 diff = new Vector2(b, a);
        diff.Normalize();

        return diff;
    }
}