using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// represents a collectable object
public abstract class Collectable : MonoBehaviour
{
    // fields
    public int quantity;

    // uses some amount of the collectable
    public void use(int amountUsed)
    {
        quantity -= amountUsed;
    }

    // collects some amount of the collectable
    public void collect(int amountCollected)
    {
        quantity += amountCollected;
    }
}
