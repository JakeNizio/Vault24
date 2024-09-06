using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// represents a ranged weapon
public abstract class Ranged : Weapon
{
    // fields
    public int clipSize;
    protected int clipRemaining;
    public float reloadTime;
    public bool reloading = false;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        clipRemaining = clipSize;
    }

    // handles reloading of the weapon
    public IEnumerator reload()
    {
        // creates a reloading period where the weapon cannot be fired
        reloading = true;
        yield return new WaitForSeconds(reloadTime);
        reloading = false;

        // reloads a full clip
        if (ammo.quantity >= clipSize)
        {
            clipRemaining = clipSize;
        }

        // reloads the remaining ammo
        else
        {
            clipRemaining = ammo.quantity;
        }
    }

}
