using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// represents a weapon upgrade
public class WeaponUpgrade : Upgrade
{
    // fields
    public float fireRate, damage, distance, knockback, speed;

    // constructor
    public WeaponUpgrade(string title, int tier, int cost, float fireRate, float damage, float distance, float knockback, float speed) : base(title, tier, cost)
    {
        this.fireRate = fireRate;
        this.damage = damage;
        this.distance = distance;
        this.knockback = knockback;
        this.speed = speed;
    }
}
