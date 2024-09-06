using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHandler : MonoBehaviour
{
    public Transform respawnPoint;

    public void Start()
    {
        transform.position = respawnPoint.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("respawn point"))
        {
            Debug.Log("Set Spawn");
            respawnPoint = other.gameObject.transform;
        }
    }
}
