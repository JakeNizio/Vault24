using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// holds all of the available shotgun upgrades for the shop
public class ShotgunUpgrades : MonoBehaviour
{
    // fields
    public ShotgunUpgrade[] fireRateUpgrades;
    public ShotgunUpgrade[] damageUpgrades;
    public ShotgunUpgrade[] distanceUpgrades;
    public ShotgunUpgrade[] knockbackUpgrades;
    public ShotgunUpgrade[] speedUpgrades;
    public ShotgunUpgrade[] clipSizeUpgrades;
    public ShotgunUpgrade[] reloadTimeUpgrades;
    public ShotgunUpgrade[] numProjectilesUpgrades;
    public ShotgunUpgrade[] spreadAngleUpgrades;

    // Start is called before the first frame update
    // instantiates all of the upgrade tiers
    public void Start()
    {
        fireRateUpgrades = new ShotgunUpgrade[3];
        fireRateUpgrades[0] = new ShotgunUpgrade("Fire Rate", 1, 10, 0.2f, 0, 0, 0, 0, 0, 0, 0, 0);
        fireRateUpgrades[1] = new ShotgunUpgrade("Fire Rate", 2, 30, 0.5f, 0, 0, 0, 0, 0, 0, 0, 0);
        fireRateUpgrades[2] = new ShotgunUpgrade("Fire Rate", 3, 50, 0.7f, 0, 0, 0, 0, 0, 0, 0, 0);

        damageUpgrades = new ShotgunUpgrade[3];
        damageUpgrades[0] = new ShotgunUpgrade("Damage", 1, 10, 0, 0.6f, 0, 0, 0, 0, 0, 0, 0);
        damageUpgrades[1] = new ShotgunUpgrade("Damage", 2, 30, 0, 1.3f, 0, 0, 0, 0, 0, 0, 0);
        damageUpgrades[2] = new ShotgunUpgrade("Damage", 3, 50, 0, 2, 0, 0, 0, 0, 0, 0, 0);

        distanceUpgrades = new ShotgunUpgrade[3];
        distanceUpgrades[0] = new ShotgunUpgrade("Distance", 1, 10, 0, 0, 2, 0, 0, 0, 0, 0, 0);
        distanceUpgrades[1] = new ShotgunUpgrade("Distance", 2, 30, 0, 0, 4, 0, 0, 0, 0, 0, 0);
        distanceUpgrades[2] = new ShotgunUpgrade("Distance", 3, 50, 0, 0, 6, 0, 0, 0, 0, 0, 0);

        knockbackUpgrades = new ShotgunUpgrade[3];
        knockbackUpgrades[0] = new ShotgunUpgrade("Knockback", 1, 10, 0, 0, 0, 1, 0, 0, 0, 0, 0);
        knockbackUpgrades[1] = new ShotgunUpgrade("Knockback", 2, 30, 0, 0, 0, 2, 0, 0, 0, 0, 0);
        knockbackUpgrades[2] = new ShotgunUpgrade("Knockback", 3, 50, 0, 0, 0, 4, 0, 0, 0, 0, 0);

        speedUpgrades = new ShotgunUpgrade[3];
        speedUpgrades[0] = new ShotgunUpgrade("Speed", 1, 10, 0, 0, 0, 0, 1, 0, 0, 0, 0);
        speedUpgrades[1] = new ShotgunUpgrade("Speed", 2, 30, 0, 0, 0, 0, 2, 0, 0, 0, 0);
        speedUpgrades[2] = new ShotgunUpgrade("Speed", 3, 50, 0, 0, 0, 0, 2, 0, 0, 0, 0);

        clipSizeUpgrades = new ShotgunUpgrade[3];
        clipSizeUpgrades[0] = new ShotgunUpgrade("Clip Size", 1, 10, 0, 0, 0, 0, 0, 3, 0, 0, 0);
        clipSizeUpgrades[1] = new ShotgunUpgrade("Clip Size", 2, 30, 0, 0, 0, 0, 0, 6, 0, 0, 0);
        clipSizeUpgrades[2] = new ShotgunUpgrade("Clip Size", 3, 50, 0, 0, 0, 0, 0, 12, 0, 0, 0);

        reloadTimeUpgrades = new ShotgunUpgrade[3];
        reloadTimeUpgrades[0] = new ShotgunUpgrade("Reload Time", 1, 10, 0, 0, 0, 0, 0, 0, -0.2f, 0, 0);
        reloadTimeUpgrades[1] = new ShotgunUpgrade("Reload Time", 2, 30, 0, 0, 0, 0, 0, 0, -0.3f, 0, 0);
        reloadTimeUpgrades[2] = new ShotgunUpgrade("Reload Time", 3, 50, 0, 0, 0, 0, 0, 0, -0.4f, 0, 0);

        numProjectilesUpgrades = new ShotgunUpgrade[3];
        numProjectilesUpgrades[0] = new ShotgunUpgrade("Number of Projectiles", 1, 10, 0, 0, 0, 0, 0, 0, 0, 2, 0);
        numProjectilesUpgrades[1] = new ShotgunUpgrade("Number of Projectiles", 2, 30, 0, 0, 0, 0, 0, 0, 0, 2, 0);
        numProjectilesUpgrades[2] = new ShotgunUpgrade("Number of Projectiles", 3, 50, 0, 0, 0, 0, 0, 0, 0, 2, 0);

        spreadAngleUpgrades = new ShotgunUpgrade[3];
        spreadAngleUpgrades[0] = new ShotgunUpgrade("Spread Angle", 1, 10, 0, 0, 0, 0, 0, 0, 0, 0, 4);
        spreadAngleUpgrades[1] = new ShotgunUpgrade("Spread Angle", 2, 30, 0, 0, 0, 0, 0, 0, 0, 0, 4);
        spreadAngleUpgrades[2] = new ShotgunUpgrade("Spread Angle", 3, 50, 0, 0, 0, 0, 0, 0, 0, 0, 4);
    }
}
