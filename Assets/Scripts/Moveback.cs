using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveBack : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger Entered");

        if (collision.CompareTag("Player"))
        {
            // Player entered, so move level
            SceneController.instance.LastLevel();
        }
    }
}
