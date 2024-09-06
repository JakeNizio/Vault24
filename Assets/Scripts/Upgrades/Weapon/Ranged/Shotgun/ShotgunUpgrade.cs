using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// represents an upgrade for the shotgun
public class ShotgunUpgrade : RangedUpgrade
{

    // fields
    public int numProjectiles;
    public float spreadAngle;

    // constructor
    public ShotgunUpgrade(string title, int tier, int cost, float fireRate, float damage, float distance, float knockback, float speed, int clipSize, float reloadTime, int numProjectiles, float spreadAngle) : base(title, tier, cost, fireRate, damage, distance, knockback, speed, clipSize, reloadTime)
    {
        this.numProjectiles = numProjectiles;
        this.spreadAngle = spreadAngle;
    }
}
