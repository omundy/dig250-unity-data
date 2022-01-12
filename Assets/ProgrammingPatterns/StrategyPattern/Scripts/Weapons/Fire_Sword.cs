using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Sword : Weapon_Base {
    public Fire_Sword ()
    {
        damage = 10;
        damageType = new FireDamage ();
    }
}

