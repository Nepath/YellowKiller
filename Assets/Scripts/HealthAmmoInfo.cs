using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HealthAmmoInfo : NetworkBehaviour
{
    public Text AmmoText;
    public Text HealthText;
    public Text GameOverText;

    int hp;
    void Start()
    {

        GameOverText.gameObject.SetActive(false);

    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (this.isLocalPlayer)
        {
            hp = GetComponent<PlayerAtributes>().health;


            try
            {
                AmmoText.text = GetComponent<ShootBullets>().magSize.ToString();
                HealthText.text = hp.ToString();
            }
            catch (Exception)
            {

            }
            if(hp <= 0)
            {
                GameOverText.gameObject.SetActive(true);
                GetComponent<Movement>().Speed = 0;
                GetComponent<Movement>().JumpForce = 0;
                GetComponent<ShootBullets>().GameOverCheck = true;
                if (Input.GetKeyDown("y"))
                    {
                    GetComponent<Movement>().Speed = 6;
                    GetComponent<Movement>().JumpForce = 5.5f;
                    GetComponent<ShootBullets>().GameOverCheck = true;
                    GetComponent<PlayerAtributes>().health = 100;
                    GameOverText.gameObject.SetActive(false);
                    this.transform.position = new Vector2(0f, 0f);
                    GetComponent<WeaponChange>().CurrentWeapon = 0;
                    GetComponent<ShootBullets>().GameOverCheck = false;
                    GetComponent<ShootBullets>().mouse_down = false;
                }
            }
        }
    }
}
