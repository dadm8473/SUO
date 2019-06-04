﻿using UnityEngine;

[System.Serializable]
public class PlayerWeapon{

    public string name = "Glock";

    public int damage = 10;
    public float range = 100f;

    public float fireRate = 0f;

    public int maxBullets = 20;
    [HideInInspector]
    public int bullets = 20;

    public float reloadTime = 1f;

    public GameObject graphics;

    public PlayerWeapon()
    {
        bullets = maxBullets;
    }
}
