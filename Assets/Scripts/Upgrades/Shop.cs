using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

// represents the shop where a character can buy upgrades for their armor and weapons
public class Shop : MonoBehaviour
{

    // fields
    public Transform statContainer;
    public GameObject statItemPrefab;
    public Transform upgradeContainer;
    public GameObject upgradeItemPrefab;
    private GameObject character;
    public TextMeshProUGUI scrapCount;
    public Slider slider;
    private ArmorUpgrades armorUpgrades;
    private SwordUpgrades swordUpgrades;
    private RifleUpgrades rifleUpgrades;
    private ShotgunUpgrades shotgunUpgrades;
    private Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("char"); // sets character
        weapon = character.transform.GetChild(0).GetComponent<Weapon>(); // sets weapon

        armorUpgrades = GetComponent<ArmorUpgrades>(); // sets armor upgrades
        swordUpgrades = GetComponent<SwordUpgrades>(); // sets sword upgrades
        rifleUpgrades = GetComponent<RifleUpgrades>(); // sets rifle upgrades
        shotgunUpgrades = GetComponent<ShotgunUpgrades>(); // sets shotgun upgrades

        slider.onValueChanged.AddListener(delegate { changeShop(); }); // listener changes the shop when the slider is triggered

        populateWeaponItems(); // initializes the shop with weapon upgrades
    }

    // Update is called once per frame
    private void Update()
    {
        scrapCount.text = character.GetComponent<Scrap>().quantity.ToString(); // update scrap count
    }

    // changes the shop between armor and weapon modes
    public void changeShop()
    {
        if (slider.value == 0)
        {
            populateWeaponItems();
        }
        else
        {
            populateArmorStats();
            populateArmorUpgrades();
        }
    }

    // instatiates and sets a stat prefab
    public void generateStat(string name, string stat)
    {
        var shieldSizeItem = Instantiate(statItemPrefab);
        shieldSizeItem.transform.Find("name").GetComponent<TextMeshProUGUI>().text = name;
        shieldSizeItem.transform.Find("stat").GetComponent<TextMeshProUGUI>().text = stat;
        shieldSizeItem.transform.SetParent(statContainer);
        shieldSizeItem.transform.localScale = Vector2.one;
    }

    // empties the container of all items
    public void resetContainer(Transform container)
    {
        while (container.childCount > 0)
        {
            DestroyImmediate(container.GetChild(0).gameObject);
        }
    }

    // populates all of the armor stats
    public void populateArmorStats()
    {
        resetContainer(statContainer.transform);

        generateStat("Shield Size", character.GetComponent<Armor>().shieldSize.ToString());
        generateStat("Recharge Rate", character.GetComponent<Armor>().rechargeRate.ToString());
        generateStat("Damage Reduction", character.GetComponent<Armor>().damageReduction.ToString());
        generateStat("Radiation Resistance", character.GetComponent<Armor>().radiationResistance.ToString());
    }

    // instantiates and sets an armor upgrade item
    public void generateArmorUpgrade(ArmorUpgrade[] armorUpgrades)
    {
        ArmorUpgrade availableUpgrade = (ArmorUpgrade)findNextUpgrade(armorUpgrades); // gets available upgrade
        if (availableUpgrade != null)
        {
            // sets upgrade item
            var upgradeItem = Instantiate(upgradeItemPrefab);
            upgradeItem.transform.Find("name").GetComponent<TextMeshProUGUI>().text = availableUpgrade.title + " " + availableUpgrade.tier;
            upgradeItem.transform.Find("cost").GetComponent<TextMeshProUGUI>().text = availableUpgrade.cost.ToString();
            upgradeItem.transform.Find("button").GetComponent<Button>().onClick.AddListener(delegate { purchaseArmorUpgrade(armorUpgrades); });
            upgradeItem.transform.SetParent(upgradeContainer);
            upgradeItem.transform.localScale = Vector2.one;
        }
    }

    // populates all of the armor upgrades
    public void populateArmorUpgrades()
    {
        resetContainer(upgradeContainer.transform);

        generateArmorUpgrade(armorUpgrades.shieldSizeUpgrades);
        generateArmorUpgrade(armorUpgrades.rechargeRateUpgrades);
        generateArmorUpgrade(armorUpgrades.damageReductionUpgrades);
        generateArmorUpgrade(armorUpgrades.radiationResistanceUpgrades);
    }

    // identifies the players weapon and calls required populators
    public void populateWeaponItems()
    {
        switch (weapon.GetType().ToString())
        {
            case("Sword"):
                populateSwordStats();
                populateSwordUpgrades();
                break;
            case("Rifle"):
                populateRifleStats();
                populateRifleUpgrades();
                break;
            case ("Shotgun"):
                populateShotgunStats();
                populateShotgunUpgrades();
                break;
            default: break;
        }
    }

    // populates all of the sword stats
    public void populateSwordStats()
    {
        Sword weapon = (Sword) this.weapon;

        resetContainer(statContainer.transform);

        generateStat("Fire Rate", weapon.fireRate.ToString());
        generateStat("Damage", weapon.damage.ToString());
        generateStat("Distance", weapon.distance.ToString());
        generateStat("Knockback", weapon.knockback.ToString());
        generateStat("Speed", weapon.speed.ToString());
        generateStat("Slash Angle", weapon.slashAngle.ToString());
        generateStat("Ammo Damage Boost", weapon.ammoDamageBoost.ToString());

    }

    // instantiates and sets a sword upgrade item
    public void generateSwordUpgrade(SwordUpgrade[] swordUpgrades)
    {
        SwordUpgrade availableUpgrade = (SwordUpgrade)findNextUpgrade(swordUpgrades); // finds next upgrade
        if (availableUpgrade != null)
        {
            // sets upgrade item
            var upgradeItem = Instantiate(upgradeItemPrefab);
            upgradeItem.transform.Find("name").GetComponent<TextMeshProUGUI>().text = availableUpgrade.title + " " + availableUpgrade.tier;
            upgradeItem.transform.Find("cost").GetComponent<TextMeshProUGUI>().text = availableUpgrade.cost.ToString();
            upgradeItem.transform.Find("button").GetComponent<Button>().onClick.AddListener(delegate { purchaseSwordUpgrade(swordUpgrades); });
            upgradeItem.transform.SetParent(upgradeContainer);
            upgradeItem.transform.localScale = Vector2.one;
        }
    }

    // populates all of the sword upgrades
    public void populateSwordUpgrades()
    {
        resetContainer(upgradeContainer.transform);

        generateSwordUpgrade(swordUpgrades.fireRateUpgrades);
        generateSwordUpgrade(swordUpgrades.damageUpgrades);
        generateSwordUpgrade(swordUpgrades.distanceUpgrades);
        generateSwordUpgrade(swordUpgrades.knockbackUpgrades);
        generateSwordUpgrade(swordUpgrades.speedUpgrades);
        generateSwordUpgrade(swordUpgrades.slashAngleUpgrades);
        generateSwordUpgrade(swordUpgrades.ammoDamageBoostUpgrades);
    }

    // populates all of the rifle stats
    public void populateRifleStats()
    {
        Rifle weapon = (Rifle)this.weapon;

        resetContainer(statContainer.transform);

        generateStat("Fire Rate", weapon.fireRate.ToString());
        generateStat("Damage", weapon.damage.ToString());
        generateStat("Distance", weapon.distance.ToString());
        generateStat("Knockback", weapon.knockback.ToString());
        generateStat("Speed", weapon.speed.ToString());
        generateStat("Clip Size", weapon.clipSize.ToString());
        generateStat("Reload Time", weapon.reloadTime.ToString());
        generateStat("Collateral Depth", weapon.collateralDepth.ToString());

    }

    // generates a rifle upgrade item
    public void generateRifleUpgrade(RifleUpgrade[] rifleUpgrades)
    {
        RifleUpgrade availableUpgrade = (RifleUpgrade)findNextUpgrade(rifleUpgrades); // finds next available upgrade
        if (availableUpgrade != null)
        {
            // sets upgrade item
            var upgradeItem = Instantiate(upgradeItemPrefab);
            upgradeItem.transform.Find("name").GetComponent<TextMeshProUGUI>().text = availableUpgrade.title + " " + availableUpgrade.tier;
            upgradeItem.transform.Find("cost").GetComponent<TextMeshProUGUI>().text = availableUpgrade.cost.ToString();
            upgradeItem.transform.Find("button").GetComponent<Button>().onClick.AddListener(delegate { purchaseRifleUpgrade(rifleUpgrades); });
            upgradeItem.transform.SetParent(upgradeContainer);
            upgradeItem.transform.localScale = Vector2.one;
        }
    }

    // populates all of the rifle upgrades
    public void populateRifleUpgrades()
    {
        resetContainer(upgradeContainer.transform);

        generateRifleUpgrade(rifleUpgrades.fireRateUpgrades);
        generateRifleUpgrade(rifleUpgrades.damageUpgrades);
        generateRifleUpgrade(rifleUpgrades.distanceUpgrades);
        generateRifleUpgrade(rifleUpgrades.knockbackUpgrades);
        generateRifleUpgrade(rifleUpgrades.speedUpgrades);
        generateRifleUpgrade(rifleUpgrades.clipSizeUpgrades);
        generateRifleUpgrade(rifleUpgrades.reloadTimeUpgrades);
        generateRifleUpgrade(rifleUpgrades.collateralDepthUpgrades);
    }

    // populates all of the shotgun stats
    public void populateShotgunStats()
    {
        Shotgun weapon = (Shotgun)this.weapon;

        resetContainer(statContainer.transform);

        generateStat("Fire Rate", weapon.fireRate.ToString());
        generateStat("Damage", weapon.damage.ToString());
        generateStat("Distance", weapon.distance.ToString());
        generateStat("Knockback", weapon.knockback.ToString());
        generateStat("Speed", weapon.speed.ToString());
        generateStat("Clip Size", weapon.clipSize.ToString());
        generateStat("Reload Time", weapon.reloadTime.ToString());
        generateStat("Number of Projectiles", weapon.numProjectiles.ToString());
        generateStat("Spread Angle", weapon.spreadAngle.ToString());

    }

    // generates a shotgun upgrade item
    public void generateShotgunUpgrade(ShotgunUpgrade[] shotgunUpgrades)
    {
        ShotgunUpgrade availableUpgrade = (ShotgunUpgrade)findNextUpgrade(shotgunUpgrades); // finds next availble upgrade
        if (availableUpgrade != null)
        {
            // sets upgrade item
            var upgradeItem = Instantiate(upgradeItemPrefab);
            upgradeItem.transform.Find("name").GetComponent<TextMeshProUGUI>().text = availableUpgrade.title + " " + availableUpgrade.tier;
            upgradeItem.transform.Find("cost").GetComponent<TextMeshProUGUI>().text = availableUpgrade.cost.ToString();
            upgradeItem.transform.Find("button").GetComponent<Button>().onClick.AddListener(delegate { purchaseShotgunUpgrade(shotgunUpgrades); });
            upgradeItem.transform.SetParent(upgradeContainer);
            upgradeItem.transform.localScale = Vector2.one;
        }
    }

    // populates all shotgun upgrades
    public void populateShotgunUpgrades()
    {
        resetContainer(upgradeContainer.transform);

        generateShotgunUpgrade(shotgunUpgrades.fireRateUpgrades);
        generateShotgunUpgrade(shotgunUpgrades.damageUpgrades);
        generateShotgunUpgrade(shotgunUpgrades.distanceUpgrades);
        generateShotgunUpgrade(shotgunUpgrades.knockbackUpgrades);
        generateShotgunUpgrade(shotgunUpgrades.speedUpgrades);
        generateShotgunUpgrade(shotgunUpgrades.clipSizeUpgrades);
        generateShotgunUpgrade(shotgunUpgrades.reloadTimeUpgrades);
        generateShotgunUpgrade(shotgunUpgrades.numProjectilesUpgrades);
        generateShotgunUpgrade(shotgunUpgrades.spreadAngleUpgrades);
    }

    // finds the next available upgrade in the tier list
    public Upgrade findNextUpgrade(Upgrade[] upgrades)
    {
        for (int i = 0; i < upgrades.Length; i++)
        {
            if (upgrades[i] != null)
            {
                return upgrades[i];
            }
        }
        return null;
    }

    // removes the next available upgrade from the tier list
    public void removeNextUpgrade(Upgrade[] upgrades)
    {
        for (int i = 0; i < upgrades.Length; i++)
        {
            if (upgrades[i] != null)
            {
                upgrades[i] = null;
                break;
            }
        }
    }

    // purchases an armor upgrade
    public void purchaseArmorUpgrade(ArmorUpgrade[] upgrades)
    {
        ArmorUpgrade upgrade = (ArmorUpgrade)findNextUpgrade(upgrades); // checks that the upgrade is available
        if (upgrade != null) 
        {
            if (character.GetComponent<Scrap>().quantity >= upgrade.cost) // checks that the character has enough scrap to purchase the upgrade
            {
                character.GetComponent<Armor>().upgrade(upgrade); // upgrades the armor
                removeNextUpgrade(upgrades); // removes the upgrade from the shop
                character.GetComponent<Scrap>().quantity -= upgrade.cost; // removes the scrap from the character

                //refreshes the shop
                populateArmorStats();
                populateArmorUpgrades();
            }
        }
    }

    // purchases a sword upgrade
    public void purchaseSwordUpgrade(SwordUpgrade[] upgrades)
    {
        SwordUpgrade upgrade = (SwordUpgrade)findNextUpgrade(upgrades); // checks that the upgrade is available
        if (upgrade != null)
        {
            if (character.GetComponent<Scrap>().quantity >= upgrade.cost) // checks that the character has enough scrap to purchase the upgrade
            {
                weapon.upgrade(upgrade); // upgrades the sword
                removeNextUpgrade(upgrades); // removes the upgrade from the shop
                character.GetComponent<Scrap>().quantity -= upgrade.cost; // removes the scrap from the character
                populateWeaponItems(); // refreshes the shop
            }
        }
    }

    // purchases a rifle upgrade
    public void purchaseRifleUpgrade(RifleUpgrade[] upgrades)
    {
        RifleUpgrade upgrade = (RifleUpgrade)findNextUpgrade(upgrades); // checks that the upgrade is available
        if (upgrade != null)
        {
            if (character.GetComponent<Scrap>().quantity >= upgrade.cost) // checks that the character has enough scrap to purchase the upgrade
            {
                weapon.upgrade(upgrade); // upgrades the rifle
                removeNextUpgrade(upgrades); // removes the upgrade from the shop
                character.GetComponent<Scrap>().quantity -= upgrade.cost; // removes the scrap from the character
                populateWeaponItems(); // refreshes the shop
            }
        }
    }

    // purchases a shotgun upgrade
    public void purchaseShotgunUpgrade(ShotgunUpgrade[] upgrades)
    {
        ShotgunUpgrade upgrade = (ShotgunUpgrade)findNextUpgrade(upgrades); // checks that the upgrade is available
        if (upgrade != null)
        {
            if (character.GetComponent<Scrap>().quantity >= upgrade.cost) // checks that the character has enough scrap to purchase the upgrade
            {
                weapon.upgrade(upgrade); // upgrades the shotgun
                removeNextUpgrade(upgrades); // removes the upgrade from the shop
                character.GetComponent<Scrap>().quantity -= upgrade.cost; // removes the scrap from the character
                populateWeaponItems(); // refreshes the shop
            }
        }
    }

}
