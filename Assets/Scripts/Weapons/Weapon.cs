using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// represents a weapon which the character can equip
public abstract class Weapon : MonoBehaviour
{
    // fields
    protected Ammo ammo;
    public float fireRate, damage, distance, knockback, speed;


    // Start is called before the first frame update
    public virtual void Start()
    {
        ammo = GetComponent<Ammo>(); // sets weapon ammo
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) { StartCoroutine(attack()); } // fires an attack routine if the left mouse button is pressed
    }

    // attack abstract
    public abstract IEnumerator attack();

    // upgrade abstract
    public abstract void upgrade(WeaponUpgrade upgrade);

}
