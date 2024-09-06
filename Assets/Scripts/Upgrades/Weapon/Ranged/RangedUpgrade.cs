using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// represents a ranged weapon upgrade
public class RangedUpgrade : WeaponUpgrade
{
    // fields
    public int clipSize;
    public float reloadTime;

    // constructor
    public RangedUpgrade(string title, int tier, int cost, float fireRate, float damage, float distance, float knockback, float speed, int clipSize, float reloadTime) : base(title, tier, cost, fireRate, damage, distance, knockback, speed)
    {
        this.clipSize = clipSize;
        this.reloadTime = reloadTime;
    }
}
