using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Text dialogueText;

    [SerializeField] private Collider airBlockCollider;

    public string[] dialogue;
    private int index;
    public float wordSpeed;

    public GameObject upgradesPanel;
    public GameObject hud;

    private bool playerInRange;
    public GameObject visualObject; // Drag the Visual GameObject here in the Unity Editor
    private SpriteRenderer npcSpriteRenderer; // Reference to the NPC's Sprite Renderer

    private void Awake()
    {
        playerInRange = false;
        npcSpriteRenderer = visualObject.GetComponent<SpriteRenderer>();
        if (npcSpriteRenderer == null)
        {
            Debug.LogError("Sprite Renderer component not found on Visual GameObject!");
        }
    }

    private void Update()
    {
        if (playerInRange)
        {
            visualCue.SetActive(true);
            dialoguePanel.SetActive(true);
            // Rotate NPC's sprite to face the player
            Vector3 direction = transform.position - Camera.main.transform.position;
            direction.y = 0; // Make sure the rotation is only in the horizontal plane
            npcSpriteRenderer.flipX = (direction.x < 0); // Flip the sprite if necessary

            if (Input.GetKeyDown("b"))
            {
                upgradesPanel.SetActive(!upgradesPanel.activeSelf);
                Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
                hud.SetActive(!hud.activeSelf);
            }
        }
        else
        {
            visualCue.SetActive(false);
            dialoguePanel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "char" && !airBlockCollider.bounds.Intersects(collider.bounds))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "char")
        {
            playerInRange = false;
        }
    }

    public void ZeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            ZeroText();
        }
    }
}