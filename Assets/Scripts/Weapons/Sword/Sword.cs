using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using static UnityEditor.FilePathAttribute;

// represents an equippable sword
public class Sword : Weapon
{
    // fields
    public float slashAngle;
    public float ammoDamageBoost;
    private bool firing = false;
    public GameObject bladePrefab;

    // creates a blade projectile and fires an attack
    public override IEnumerator attack()
    {
        // starts a new attack while not already firing
        if (!firing)
        {
            GameObject blade = Instantiate(bladePrefab); // instantiates blade
            // assigns parameters to the blade
            blade.GetComponent<Blade>().damage = damage;
            blade.GetComponent<Blade>().distance = distance;
            blade.GetComponent<Blade>().knockback = knockback;
            blade.GetComponent<Blade>().speed = speed;
            blade.GetComponent<Blade>().slashAngle = slashAngle;

            // gives bonus damage if the weapon has ammo
            if (ammo.quantity > 0)
            {
                ammo.use(1);
                blade.GetComponent<Blade>().damage = damage * ammoDamageBoost;
            }

            // aligns the blade with the weapon
            blade.transform.rotation = transform.rotation;

            // firing sequence
            firing = true;
            yield return new WaitForSeconds(1 / fireRate); // limits the firing rate
            firing = false;
            
        }
    }

    // upgrades the stats on the sword using a weapon upgrade
    public override void upgrade(WeaponUpgrade upgrade)
    {
        fireRate += upgrade.fireRate;
        damage += upgrade.damage;
        distance += upgrade.distance;
        knockback += upgrade.knockback;
        speed += upgrade.speed;
        slashAngle += ((SwordUpgrade)upgrade).slashAngle;
        ammoDamageBoost += ((SwordUpgrade)upgrade).ammoDamageBoost;
    }
}
