using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hud : MonoBehaviour
{

    private GameObject character;
    public TextMeshProUGUI healthCount;
    public TextMeshProUGUI armorCount;
    public TextMeshProUGUI scrapCount;
    public TextMeshProUGUI ammoCount;
    public GameObject reloadingText;


    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("char");
    }

    // Update is called once per frame
    void Update()
    {
        healthCount.text = character.GetComponent<Character>().health.ToString("0");
        armorCount.text = character.GetComponent<Armor>().shieldRemaining.ToString("0.0");
        scrapCount.text = character.GetComponent<Scrap>().quantity.ToString();

        ammoCount.text = character.transform.GetChild(0).GetComponent<Ammo>().quantity.ToString();
        reloadingText.SetActive(isReloading());
    }

    public bool isReloading()
    {
        Weapon weapon = character.transform.GetChild(0).GetComponent<Weapon>();
        if (weapon.GetType().ToString() != "Sword")
        {
            return ((Ranged)weapon).reloading;
        } 
        else
        {
            return false;
        }
    }
}
