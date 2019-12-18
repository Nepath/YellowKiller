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
            }
        }
        get
        {
            return weaponNumber;
        }
    }

    void Start()
    {
        Weapon Pistol = new Weapon(3, 2, 12, 1); //pistol
        Weapon MachineGun = new Weapon(1, 3, 30, 3); //machine gun
        Weapon Shotgun = new Weapon(8, 8, 6, 2); //shotgun

        WeaponTypes = new Weapon[] { Pistol, MachineGun, Shotgun };
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
