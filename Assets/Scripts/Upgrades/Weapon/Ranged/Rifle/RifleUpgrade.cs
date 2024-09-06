using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// represents a rifle upgrade
public class RifleUpgrade : RangedUpgrade
{
    // fields
    public int collateralDepth;

    // constructor
    public RifleUpgrade(string title, int tier, int cost, float fireRate, float damage, float distance, float knockback, float speed, int clipSize, float reloadTime, int collateralDepth) : base(title, tier, cost, fireRate, damage, distance, knockback, speed, clipSize, reloadTime)
    {
        this.collateralDepth = collateralDepth;
    }
}
