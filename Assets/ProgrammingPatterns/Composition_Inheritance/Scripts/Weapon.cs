using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public enum Type {
        Bullet,
        Missile,
        GuidedMissile,
    }
    public Type type;


}
