using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("TimerSettings")]
    public bool hasLimit;
    public float timerLimit;

    // Reference to the Character class
    public Character character;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the timer text
        SetTimerText();
        character = GameObject.Find("char").GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the timer based on the countDown flag
        currentTime = countDown ? currentTime - Time.deltaTime : currentTime + Time.deltaTime;

        // Check if the timer has reached the limit
        if (hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            // Set the timer to the limit
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;
        }

        // Update the timer text
        SetTimerText();

        // Check if the time has reached zero
        if (currentTime <= 0)
        {
            // Reduce character's health
            character.health=-0;
        }
    }
    //might need to manually add charachter to respawn
    private void SetTimerText()
    {
        // Check if the timerText component is not null
        if (timerText != null)
        {
            timerText.text = currentTime.ToString("0");
        }
    }
}
