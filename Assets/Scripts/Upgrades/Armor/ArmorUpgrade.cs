using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// represents an armor upgrade
public class ArmorUpgrade : Upgrade
{
    // fields
    public float shieldSize, rechargeRate, damageReduction, radiationResistance;

    // constructor
    public ArmorUpgrade(string title, int tier, int cost, float shieldSize, float rechargeRate, float damageReduction, float radiationResistance) : base(title, tier, cost)
    {
        this.shieldSize = shieldSize;
        this.rechargeRate = rechargeRate;
        this.damageReduction = damageReduction;
        this.radiationResistance = radiationResistance;
    }

}
