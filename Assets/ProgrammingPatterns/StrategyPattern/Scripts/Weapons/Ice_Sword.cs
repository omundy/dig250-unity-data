using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Sword : Weapon_Base
{
    public Ice_Sword()
    {
        damage = 12;
        damageType = new IceDamage();
    }
}

