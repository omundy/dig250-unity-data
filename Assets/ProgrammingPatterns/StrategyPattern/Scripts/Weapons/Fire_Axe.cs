using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Axe : Weapon_Base
{
    public Fire_Axe()
    {
        damage = 20;
        damageType = new FireDamage();
    }
}

