using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Strategy Pattern - Composition over Inheritance
// https://onewheelstudio.com/blog/2020/8/16/strategy-pattern-composition-over-inheritance

public interface IDODamage {
    void DoDamage (int damage);
}

public class Weapon_Base : MonoBehaviour {
    public int damage = 0;
    public IDODamage damageType;

    public void TryDoAttack ()
    {
        damageType?.DoDamage (damage);
    }
    public void OnTriggerEnter (Collider other)
    {
        TryDoAttack ();
    }
    public void SetDamageType (IDODamage damageType)
    {
        this.damageType = damageType;
    }
}

public class FireDamage : IDODamage {
    public void DoDamage (int damage)
    {
        PlayerStats.Health -= damage;
        // do fire bits
    }
}

public class IceDamage : IDODamage {
    public void DoDamage (int damage)
    {
        PlayerStats.Health -= damage;
        // do ice bits
    }
}

public class Sword : Weapon_Base {
    public Sword (int damage, IDODamage damageType)
    {
        this.damage = damage;
        this.damageType = damageType;
    }
}