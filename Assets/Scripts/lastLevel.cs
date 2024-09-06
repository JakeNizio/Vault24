using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lastLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger Entered");


        // Player entered, so move level
        SceneController.instance.LoadScene("lvl3");
        //SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);

    }
}
