using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public int sceneBuildIndex;


    

    void OnTriggerEnter(Collider other)
    {
        

        // Check if the name of the Collider2D component is "char"

         if (other.tag =="Player")
        //if (other.GetComponent<Collider2D>().name == "char")
        {
            print("Trigger Entered");

            // Load the next scene using SceneController (commented out for now)
            // SceneController.instance.LoadScene("lvl2");

            // Load the specified scene by build index
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }

    }
}
