using System.Collections.Generic;
using System.Collections;
using UnityEngine;

// represents a hook projectile
public class Hook : MonoBehaviour
{
    // fields
    public int positionCount = 4; // Define positionCount property
    public float distance;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeleteAfterDistance()); // starts the deletion routine
    }

    // deletes the hook after a set distance
    IEnumerator DeleteAfterDistance()
    {
        yield return new WaitForSeconds(distance / speed); // distance/speed converts distance to time
        Destroy(gameObject);
    }
}
