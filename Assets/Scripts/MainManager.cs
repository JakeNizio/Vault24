using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public int AB;
    public float shieldSize2, shieldRemaining2, rechargeRate2, damageReduction2, radiationResistance2;
  //  public int scrap2;
    public Weapon weapon2;
        private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}


/*
  Script Armor myScript;
        Script Scrap myScrap;
        Script Weapon myWeapon;
        //myScript.saved;
        //myScrap.saved;
        //myWeapon.saved;
 */