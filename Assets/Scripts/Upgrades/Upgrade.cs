using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// represents an upgrade
public class Upgrade
{
    // fields
    public string title;
    public int tier, cost;

    // constructor
    public Upgrade(string title, int tier, int cost)
    {
        this.title = title;
        this.tier = tier;
        this.cost = cost;
    }
}
