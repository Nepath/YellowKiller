using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeaponChange : NetworkBehaviour
{
    private int weaponNumber;
    static public int weaponsAmount;
    public GameObject[] Weapons;

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

    public Vector3 GetBarrelPosition
    {
        get
        {
            return Weapons[weaponNumber].transform.GetChild(0).transform.position;
        }
    }



    void Start()
    {
        //firing rate, accurancy (0.26 is +-30 degrees), mag size, firing mode (1 - single, 2 - shotgun, 3 - fullauto), dmg
        Weapon Pistol = new Weapon(0.5f, 0.13f, 9999, 1, 12); //pistol
        Weapon MachineGun = new Weapon(0.1f, 0.2f, 30, 3, 10); //machine gun
        Weapon Shotgun = new Weapon(1, 0.25f, 6, 2, 15); //shotgun
        Weapon SniperRifle = new Weapon(1.2f, 0.02f, 6, 1, 85); //sniper rifle

        WeaponTypes = new Weapon[] { Pistol, MachineGun, Shotgun, SniperRifle };
        weaponsAmount = WeaponTypes.Length;
        CurrentWeapon = 0;
    }

    [Command]
    void CmdWeaponOnChange(int num)
    {
        for(int i = 0; i < weaponsAmount; i++)
        {
            if (i == num)
                Weapons[i].SetActive(true);
            else
                Weapons[i].SetActive(false);
        }
    }
}
