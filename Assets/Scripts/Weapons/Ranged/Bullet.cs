using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// represents the bullet that hits the enemy
public class Bullet : MonoBehaviour
{
    // fields
    public float speed;
    public float damage;
    public float distance;
    public float knockback;
    public int collateralDepth = 1; // default value of 1 for shotguns

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(deleteAfterDistance()); // starts the deletion routine
    }

    // deletes the bullet after a set distance
    IEnumerator deleteAfterDistance()
    {
        yield return new WaitForSeconds(distance/speed); // distance/speed converts distance to time
        Destroy(gameObject);
    }

    // handles deletion based on collisions
    private void OnTriggerEnter(Collider other)
    {
        // if the bullet hits enemy, collateralDepth is decremented and the bullet is destroyed once zero
        if (other.GetComponent<Chaser>())
        {
            collateralDepth--;
            if (collateralDepth <= 0)
            {
               Destroy(gameObject);
            }
        }
    }

}
