using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// holds all of the available rifle upgrades for the shop
public class RifleUpgrades : MonoBehaviour
{
    // fields
    public RifleUpgrade[] fireRateUpgrades;
    public RifleUpgrade[] damageUpgrades;
    public RifleUpgrade[] distanceUpgrades;
    public RifleUpgrade[] knockbackUpgrades;
    public RifleUpgrade[] speedUpgrades;
    public RifleUpgrade[] clipSizeUpgrades;
    public RifleUpgrade[] reloadTimeUpgrades;
    public RifleUpgrade[] collateralDepthUpgrades;

    // Start is called before the first frame update
    // instantiates all of the upgrade tiers
    public void Start()
    {
        fireRateUpgrades = new RifleUpgrade[3];
        fireRateUpgrades[0] = new RifleUpgrade("Fire Rate", 1, 10, 1, 0, 0, 0, 0, 0, 0, 0);
        fireRateUpgrades[1] = new RifleUpgrade("Fire Rate", 2, 30, 2, 0, 0, 0, 0, 0, 0, 0);
        fireRateUpgrades[2] = new RifleUpgrade("Fire Rate", 3, 50, 4, 0, 0, 0, 0, 0, 0, 0);

        damageUpgrades = new RifleUpgrade[3];
        damageUpgrades[0] = new RifleUpgrade("Damage", 1, 10, 0, 1, 0, 0, 0, 0, 0, 0);
        damageUpgrades[1] = new RifleUpgrade("Damage", 2, 30, 0, 1.5f, 0, 0, 0, 0, 0, 0);
        damageUpgrades[2] = new RifleUpgrade("Damage", 3, 50, 0, 2.6f, 0, 0, 0, 0, 0, 0);

        distanceUpgrades = new RifleUpgrade[3];
        distanceUpgrades[0] = new RifleUpgrade("Distance", 1, 10, 0, 0, 3, 0, 0, 0, 0, 0);
        distanceUpgrades[1] = new RifleUpgrade("Distance", 2, 30, 0, 0, 5, 0, 0, 0, 0, 0);
        distanceUpgrades[2] = new RifleUpgrade("Distance", 3, 50, 0, 0, 10, 0, 0, 0, 0, 0);

        knockbackUpgrades = new RifleUpgrade[3];
        knockbackUpgrades[0] = new RifleUpgrade("Knockback", 1, 10, 0, 0, 0, 0.2f, 0, 0, 0, 0);
        knockbackUpgrades[1] = new RifleUpgrade("Knockback", 2, 30, 0, 0, 0, 0.3f, 0, 0, 0, 0);
        knockbackUpgrades[2] = new RifleUpgrade("Knockback", 3, 50, 0, 0, 0, 0.7f, 0, 0, 0, 0);

        speedUpgrades = new RifleUpgrade[3];
        speedUpgrades[0] = new RifleUpgrade("Speed", 1, 10, 0, 0, 0, 0, 1, 0, 0, 0);
        speedUpgrades[1] = new RifleUpgrade("Speed", 2, 30, 0, 0, 0, 0, 2, 0, 0, 0);
        speedUpgrades[2] = new RifleUpgrade("Speed", 3, 50, 0, 0, 0, 0, 4, 0, 0, 0);

        clipSizeUpgrades = new RifleUpgrade[3];
        clipSizeUpgrades[0] = new RifleUpgrade("Clip Size", 1, 10, 0, 0, 0, 0, 0, 3, 0, 0);
        clipSizeUpgrades[1] = new RifleUpgrade("Clip Size", 2, 30, 0, 0, 0, 0, 0, 5, 0, 0);
        clipSizeUpgrades[2] = new RifleUpgrade("Clip Size", 3, 50, 0, 0, 0, 0, 0, 8, 0, 0);

        reloadTimeUpgrades = new RifleUpgrade[3];
        reloadTimeUpgrades[0] = new RifleUpgrade("Reload Time", 1, 10, 0, 0, 0, 0, 0, 0, -0.2f, 0);
        reloadTimeUpgrades[1] = new RifleUpgrade("Reload Time", 2, 30, 0, 0, 0, 0, 0, 0, -0.2f, 0);
        reloadTimeUpgrades[2] = new RifleUpgrade("Reload Time", 3, 50, 0, 0, 0, 0, 0, 0, -0.2f, 0);

        collateralDepthUpgrades = new RifleUpgrade[3];
        collateralDepthUpgrades[0] = new RifleUpgrade("Collateral Depth", 1, 10, 0, 0, 0, 0, 0, 0, 0, 1);
        collateralDepthUpgrades[1] = new RifleUpgrade("Collateral Depth", 2, 30, 0, 0, 0, 0, 0, 0, 0, 1);
        collateralDepthUpgrades[2] = new RifleUpgrade("Collateral Depth", 3, 50, 0, 0, 0, 0, 0, 0, 0, 1);
    }
}
