using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{

    public int energy = 0;
    public int maxEnergy = 20;
    
    public int rechargeRate = 1;


    private void FixedUpdate()
    {
        if (energy <= maxEnergy)
        {
            energy += rechargeRate;
            if (energy > maxEnergy)
            {
                energy = maxEnergy;
            }
        }

    }
    
}
