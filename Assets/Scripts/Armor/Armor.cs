using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// represents a characters armor
public class Armor : MonoBehaviour
{
    // fields
    public float shieldSize, shieldRemaining, rechargeRate, damageReduction, radiationResistance;

    // Update is called once per frame
    void Update()
    {
        // regenerates shield if it has been depleted
        if (shieldRemaining < shieldSize)
        {
            shieldRemaining += Time.deltaTime * rechargeRate;
        }
    }

    // absorbs damage taken and returns remaining damage
    public float takeDamage(float damage)
    {
        damage /= damageReduction; // reduces incoming damage

        // checks if the shield will be depleted
        if (damage > shieldRemaining)
        {
            damage -= shieldRemaining; // reduce damage
            shieldRemaining = 0;
        }

        // otherwise the shield absorbs all of the damage
        else
        {
            shieldRemaining -= damage;
            damage = 0;
        }

        return damage;
    }

    // absorbs radiation
    public float takeRadiation(float radiation)
    {
        return radiation /= radiationResistance; // reduces incoming radiation
    }

    // allows the armors stats to be upgraded
    public void upgrade(ArmorUpgrade upgrade)
    {
        shieldSize += upgrade.shieldSize;
        rechargeRate += upgrade.rechargeRate;
        damageReduction += upgrade.damageReduction;
        radiationResistance += upgrade.radiationResistance;
    }
}
