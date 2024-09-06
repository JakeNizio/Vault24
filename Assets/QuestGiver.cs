// Importing necessary namespaces for UI and Unity game development
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Definition of the QuestGiver class, inheriting from MonoBehaviour (Inheritance)
public class QuestGiver : MonoBehaviour
{
    // Public variables are examples of Encapsulation, allowing other classes to interact with these properties.
    public Quest quest; // Association: QuestGiver has-a Quest
    public Character player; // Association: QuestGiver has-a Character
    public GameObject Window; // Association: QuestGiver has-a GameObject for the window
    public TextMeshProUGUI title; // Association: QuestGiver has-a TextMeshProUGUI for the title
    public TextMeshProUGUI description; // Association: QuestGiver has-a TextMeshProUGUI for the description
    public TextMeshProUGUI scrap; // Association: QuestGiver has-a TextMeshProUGUI for the scrap

    // Start is a MonoBehaviour method, utilized here to initialize the player object (Polymorphism through Unity's component system)
    void Start()
    {
        player = GameObject.Find("char").GetComponent<Character>();
    }

    // Method that demonstrates behavior encapsulation, manipulating object states (Encapsulation & Polymorphism)
    public void OpenPipBoy()
    {
        Window.SetActive(true); // Direct manipulation of GameObject state
        title.text = quest.title; // Accessing and modifying text properties (Encapsulation)
        description.text = quest.description;
        scrap.text = quest.scrapReward.ToString();
    }

    // Another method demonstrating behavior encapsulation and object state manipulation
    public void Accept()
    {
        Window.SetActive(false);
        quest.isActive = true; // Direct manipulation of Quest state
        player.quest = quest; // Establishing an association between player and quest
    }
}
