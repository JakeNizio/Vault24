using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public int maximum;
    public int current;
    public Image mask;

    // Start is called before the first frame update
    void Start()
    {
        GetCurrentFill();
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
    }

    public void SetCurrentFill(float fillAmount)
    {
        this.current = Mathf.RoundToInt(fillAmount); // Explicitly convert float to int
    }
}
