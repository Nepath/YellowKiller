using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeaponChange : NetworkBehaviour
{
    private int weaponNumber;
    static public int weaponsAmount;
    public Sprite[] Weapons;

    Weapon[] WeaponTypes;
    public int CurrentWeapon
    {
        set
        {
            if (0 <= value && value < weaponsAmount)
            {
                weaponNumber = value;
                CmdWeaponOnChange(value);

                this.GetComponent<ShootBullets>().OnWeaponChanged();
            }
        }
        get
        {
            return weaponNumber;
        }
    }
    public Weapon GetWeapon
    {
        get
        {
            return WeaponTypes[weaponNumber];
        }
    }



    void Start()
    {
        Weapon Pistol = new Weapon(0.5f, 0.13f, 9999, 1); //pistol        0.26 is 30 degrees
        Weapon MachineGun = new Weapon(0.1f, 0.2f, 30, 3); //machine gun
        Weapon Shotgun = new Weapon(1, 0.25f, 6, 2); //shotgun
        Weapon SniperRifle = new Weapon(1.2f, 0.05f, 6, 1); //sniperRifle

        WeaponTypes = new Weapon[] { Pistol, MachineGun, Shotgun, SniperRifle };
        weaponsAmount = WeaponTypes.Length;
        CurrentWeapon = 0;
    }

    [Command]
    void CmdWeaponOnChange(int i)
    {
        Transform children = this.transform.Find("Gun");
        children.GetComponent<SpriteRenderer>().sprite = Weapons[i];
    }
}
