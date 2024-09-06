using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// represents a sword upgrade
public class SwordUpgrade : WeaponUpgrade
{
    // fields
    public float slashAngle;
    public float ammoDamageBoost;

    // constructor
    public SwordUpgrade(string title, int tier, int cost, float fireRate, float damage, float distance, float knockback, float speed, float slashAngle, float ammoDamageBoost) : base(title, tier, cost, fireRate, damage, distance, knockback, speed)   
    {
        this.slashAngle = slashAngle;
        this.ammoDamageBoost = ammoDamageBoost;
    }
}
