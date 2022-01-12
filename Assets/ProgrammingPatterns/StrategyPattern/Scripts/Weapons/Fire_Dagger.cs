using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Dagger : Weapon_Base {
    public Fire_Dagger ()
    {
        damage = 40;
        damageType = new FireDamage ();
    }
}

