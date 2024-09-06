using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// represents and equippable rifle
public class Rifle : Ranged
{
    //fields
    public int collateralDepth;
    private bool firing = false;
    public GameObject bulletPrefab;

    // creates a bullet and fires an attack
    public override IEnumerator attack()
    {
        // starts a new attack while not already firing
        if (!firing)
        {
            // checks that ammo is available
            if (clipRemaining > 0 && ammo.quantity > 0)
            {
                // removes ammo from the clip and the total ammo count
                clipRemaining--;
                ammo.use(1);
                
                // generate projectile, assign it damage, distance, knockback and collateralDepth from weapon
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.GetComponent<Bullet>().damage = damage;
                bullet.GetComponent<Bullet>().distance = distance;
                bullet.GetComponent<Bullet>().speed = speed;
                bullet.GetComponent<Bullet>().knockback = knockback;
                bullet.GetComponent<Bullet>().collateralDepth = collateralDepth;
                // place it at the tip of the weapon
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                // addForce using speed from weapon
                bullet.GetComponent<Rigidbody>().AddForce(transform.right*speed, ForceMode.Impulse);

                // firing sequence
                firing = true;
                yield return new WaitForSeconds(1/fireRate); // limits the firing rate
                firing = false;
            }
        }

        // starts reload routine when the clip falls below the number of projectiles required
        if (clipRemaining <= 0 && ammo.quantity > 0 && !reloading) {
            StartCoroutine(reload());
        }
    }

    // upgrades the stats on the rifle using a weapon upgrade
    public override void upgrade(WeaponUpgrade upgrade)
    {
        fireRate += upgrade.fireRate;
        damage += upgrade.damage;
        distance += upgrade.distance;
        knockback += upgrade.knockback;
        speed += upgrade.speed;
        clipSize += ((RangedUpgrade)upgrade).clipSize;
        reloadTime += ((RangedUpgrade)upgrade).reloadTime;
        collateralDepth += ((RifleUpgrade)upgrade).collateralDepth;
    }
}
