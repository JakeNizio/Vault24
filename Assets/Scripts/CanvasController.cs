using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvascontroller : MonoBehaviour
{

    public GameObject upgradesPanel;
    public GameObject hud;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("b"))
        {
            upgradesPanel.SetActive(!upgradesPanel.activeSelf);
            Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
            hud.SetActive(!hud.activeSelf);
        }
    }
}
