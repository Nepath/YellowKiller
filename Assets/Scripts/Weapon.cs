﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public float FiringRate;
    public float Accurancy;
    public int MagSize;
    public int FiringMode; //1 - single, 2 - shotgun, 3 - fullauto

    public Weapon(float firingRate, float accurancy, int magSize, int firingMode)
    {
        FiringRate = firingRate;
        Accurancy = accurancy;
        MagSize = magSize;
        FiringMode = firingMode;
    }
}