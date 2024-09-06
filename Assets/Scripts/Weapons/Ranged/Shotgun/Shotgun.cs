using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

// represents and equippable shotgun
public class Shotgun : Ranged
{

    //fields
    public int numProjectiles;
    public float spreadAngle;
    private bool firing = false;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // creates a bullet with assigned parameters
    public GameObject bulletFactory()
    {
        // generate projectile, assign it damage, distance, knockback and collateralDepth from weapon
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.GetComponent<Bullet>().damage = damage;
        bullet.GetComponent<Bullet>().distance = distance;
        bullet.GetComponent<Bullet>().speed = speed;
        bullet.GetComponent<Bullet>().knockback = knockback;
        // place it at the tip of the weapon
        bullet.transform.position = transform.position;
        // addForce using speed from weapon
        return bullet;
    }

    // creates bullets and fires an attack
    public override IEnumerator attack()
    {
        // starts a new attack while not already firing
        if (!firing)
        {
            // checks that ammo is available
            if (clipRemaining >= numProjectiles && ammo.quantity >= numProjectiles)
            {
                // removes ammo from the clip and the total ammo count
                clipRemaining -= numProjectiles;
                ammo.use(numProjectiles);

                // calculate angles
                float totalAngle = (numProjectiles - 1) * spreadAngle; // calculates the total spread angle
                float currentAngle = -totalAngle / 2; // starting angle to be incremented

                // generates and fires bullets
                for (int i = 0; i < numProjectiles; i++)
                {
                    GameObject bullet = bulletFactory(); // create bullet
                    Vector3 forceVector = Quaternion.AngleAxis(currentAngle, Vector3.forward) * transform.right; // calcualtes force vector
                    bullet.transform.rotation = transform.rotation; // rotates sprite
                    bullet.GetComponent<Rigidbody>().AddForce(forceVector * speed, ForceMode.Impulse); // adds force
                    currentAngle += spreadAngle; // increments angle
                }

                // firing sequence
                firing = true;
                yield return new WaitForSeconds(1 / fireRate); // limits the firing rate
                firing = false;
            }
        }

        // starts reload routine when the clip falls below the number of projectiles required
        if (clipRemaining < numProjectiles && ammo.quantity >= numProjectiles && !reloading)
        {
            StartCoroutine(reload());
        }
    }

    // upgrades the stats on the shotgun using a weapon upgrade
    public override void upgrade(WeaponUpgrade upgrade)
    {
        fireRate += upgrade.fireRate;
        damage += upgrade.damage;
        distance += upgrade.distance;
        knockback += upgrade.knockback;
        speed += upgrade.speed;
        clipSize += ((RangedUpgrade)upgrade).clipSize;
        reloadTime += ((RangedUpgrade)upgrade).reloadTime;
        numProjectiles += ((ShotgunUpgrade)upgrade).numProjectiles;
        spreadAngle += ((ShotgunUpgrade)upgrade).spreadAngle;
    }
}
