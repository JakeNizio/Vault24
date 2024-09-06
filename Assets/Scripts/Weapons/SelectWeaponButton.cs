using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// handles equipping the character with a specific weapon
public class SelectWeaponButton : MonoBehaviour
{
    // fields
    public GameObject weaponPrefab;
    private GameObject character;
    private Button button;
    public int sceneBuildIndex;

    // Start is called before the first frame update
    public void Start()
    {
        button = GetComponent<Button>(); // sets the button
        character = GameObject.Find("char"); // sets the character
        button.onClick.AddListener(delegate { chooseWeapon(); }); // calles the chooseWeapon method when the button is pressed
    }

    // attaches the weapon to the character permenantly
    public void chooseWeapon()
    {
        Destroy(GameObject.FindGameObjectWithTag("weapon")); // destroy any assigned weapon

        GameObject weapon = Instantiate(weaponPrefab); // create the weapon
        weapon.transform.position = new Vector3(character.transform.position.x, character.transform.position.y); // move it to the player
        weapon.transform.rotation = character.transform.rotation; // align it with the player
        weapon.transform.SetParent(character.transform); // bind weapon movement to character movement
        character.GetComponent<Character>().selectWeapon(weapon.GetComponent<Weapon>()); // set the character weapon field

        // then move to next scene
        goToNextScene();
    }

    // transfers to scene lvl1
    public void goToNextScene()
    {
        SceneManager.LoadScene(sceneBuildIndex + 1 , LoadSceneMode.Single);
    }

}
