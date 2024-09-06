using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// holds all of the available sword upgrades for the shop
public class SwordUpgrades : MonoBehaviour
{
    // fields
    public SwordUpgrade[] fireRateUpgrades;
    public SwordUpgrade[] damageUpgrades;
    public SwordUpgrade[] distanceUpgrades;
    public SwordUpgrade[] knockbackUpgrades;
    public SwordUpgrade[] speedUpgrades;
    public SwordUpgrade[] slashAngleUpgrades;
    public SwordUpgrade[] ammoDamageBoostUpgrades;

    // Start is called before the first frame update
    // instantiates all of the upgrade tiers
    public void Start()
    {
        fireRateUpgrades = new SwordUpgrade[3];
        fireRateUpgrades[0] = new SwordUpgrade("Fire Rate", 1, 10, 0.2f, 0, 0, 0, 0, 0, 0);
        fireRateUpgrades[1] = new SwordUpgrade("Fire Rate", 2, 20, 0.5f, 0, 0, 0, 0, 0, 0);
        fireRateUpgrades[2] = new SwordUpgrade("Fire Rate", 3, 30, 0.7f, 0, 0, 0, 0, 0, 0);

        damageUpgrades = new SwordUpgrade[3];
        damageUpgrades[0] = new SwordUpgrade("Damage", 1, 10, 0, 1, 0, 0, 0, 0, 0);
        damageUpgrades[1] = new SwordUpgrade("Damage", 2, 30, 0, 2, 0, 0, 0, 0, 0);
        damageUpgrades[2] = new SwordUpgrade("Damage", 3, 50, 0, 3, 0, 0, 0, 0, 0);

        distanceUpgrades = new SwordUpgrade[3];
        distanceUpgrades[0] = new SwordUpgrade("Distance", 1, 10, 0, 0, 0.6f, 0, 0, 0, 0);
        distanceUpgrades[1] = new SwordUpgrade("Distance", 2, 30, 0, 0, 0.6f, 0, 0, 0, 0);
        distanceUpgrades[2] = new SwordUpgrade("Distance", 3, 50, 0, 0, 1.2f, 0, 0, 0, 0);

        knockbackUpgrades = new SwordUpgrade[3];
        knockbackUpgrades[0] = new SwordUpgrade("Knockback", 1, 10, 0, 0, 0, 1, 0, 0, 0);
        knockbackUpgrades[1] = new SwordUpgrade("Knockback", 2, 30, 0, 0, 0, 2, 0, 0, 0);
        knockbackUpgrades[2] = new SwordUpgrade("Knockback", 3, 50, 0, 0, 0, 4, 0, 0, 0);

        speedUpgrades = new SwordUpgrade[3];
        speedUpgrades[0] = new SwordUpgrade("Speed", 1, 10, 0, 0, 0, 0, 50, 0, 0);
        speedUpgrades[1] = new SwordUpgrade("Speed", 2, 30, 0, 0, 0, 0, 70, 0, 0);
        speedUpgrades[2] = new SwordUpgrade("Speed", 3, 50, 0, 0, 0, 0, 100, 0, 0);

        slashAngleUpgrades = new SwordUpgrade[3];
        slashAngleUpgrades[0] = new SwordUpgrade("Slash Angle", 1, 10, 0, 0, 0, 0, 0, 20, 0);
        slashAngleUpgrades[1] = new SwordUpgrade("Slash Angle", 2, 30, 0, 0, 0, 0, 0, 40, 0);
        slashAngleUpgrades[2] = new SwordUpgrade("Slash Angle", 3, 50, 0, 0, 0, 0, 0, 60, 0);

        ammoDamageBoostUpgrades = new SwordUpgrade[3];
        ammoDamageBoostUpgrades[0] = new SwordUpgrade("Ammo Damage Boost", 1, 10, 0, 0, 0, 0, 0, 0, 0.3f);
        ammoDamageBoostUpgrades[1] = new SwordUpgrade("Ammo Damage Boost", 2, 30, 0, 0, 0, 0, 0, 0, 0.9f);
        ammoDamageBoostUpgrades[2] = new SwordUpgrade("Ammo Damage Boost", 3, 50, 0, 0, 0, 0, 0, 0, 2);
    }
}
