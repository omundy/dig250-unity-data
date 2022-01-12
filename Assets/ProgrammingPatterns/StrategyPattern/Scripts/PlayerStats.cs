using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats {
    public static int health;
    public static int Health {
        get { return health; }
        set {
            health = value;
            Debug.Log ($"Health is now {health}");
        }
    }
}
