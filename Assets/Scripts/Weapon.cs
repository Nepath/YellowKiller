using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    float FiringRate;
    float Accurancy;
    int MagSize;
    int FiringMode; //1 - single, 2 - shotgun, 3 - fullauto

    public Weapon(float firingRate, float accurancy, int magSize, int firingMode)
    {
        FiringRate = firingRate;
        Accurancy = accurancy;
        MagSize = magSize;
        FiringMode = firingMode;
    }
}