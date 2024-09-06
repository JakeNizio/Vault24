using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// holds all of the available armor upgrades for the shop
public class ArmorUpgrades : MonoBehaviour
{
    // fields
    public ArmorUpgrade[] shieldSizeUpgrades;
    public ArmorUpgrade[] rechargeRateUpgrades;
    public ArmorUpgrade[] damageReductionUpgrades;
    public ArmorUpgrade[] radiationResistanceUpgrades;

    // Start is called before the first frame update
    // instantiates all of the upgrade tiers
    public void Start()
    {
        shieldSizeUpgrades = new ArmorUpgrade[3];
        shieldSizeUpgrades[0] = new ArmorUpgrade("Shield Size", 1, 10, 4, 0, 0, 0);
        shieldSizeUpgrades[1] = new ArmorUpgrade("Shield Size", 2, 30, 8, 0, 0, 0);
        shieldSizeUpgrades[2] = new ArmorUpgrade("Shield Size", 3, 50, 10, 0, 0, 0);

        rechargeRateUpgrades = new ArmorUpgrade[3];
        rechargeRateUpgrades[0] = new ArmorUpgrade("Recharge Rate", 1, 10, 0, 0.2f, 0, 0);
        rechargeRateUpgrades[1] = new ArmorUpgrade("Recharge Rate", 2, 30, 0, 0.3f, 0, 0);
        rechargeRateUpgrades[2] = new ArmorUpgrade("Recharge Rate", 3, 50, 0, 0.5f, 0, 0);

        damageReductionUpgrades = new ArmorUpgrade[3];
        damageReductionUpgrades[0] = new ArmorUpgrade("Damage Reduction", 1, 10, 0, 0, 0.2f, 0);
        damageReductionUpgrades[1] = new ArmorUpgrade("Damage Reduction", 2, 30, 0, 0, 0.4f, 0);
        damageReductionUpgrades[2] = new ArmorUpgrade("Damage Reduction", 3, 50, 0, 0, 1, 0);

        radiationResistanceUpgrades = new ArmorUpgrade[3];
        radiationResistanceUpgrades[0] = new ArmorUpgrade("Radiation Resistance", 1, 10, 0, 0, 0, 0.2f);
        radiationResistanceUpgrades[1] = new ArmorUpgrade("Radiation Resistance", 2, 30, 0, 0, 0, 0.4f);
        radiationResistanceUpgrades[2] = new ArmorUpgrade("Radiation Resistance", 3, 50, 0, 0, 0, 1);
    }
}
