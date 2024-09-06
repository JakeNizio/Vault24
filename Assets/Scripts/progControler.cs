using UnityEngine;

public class progControler : MonoBehaviour
{
    public static progControler Intsance;
    public float progress;
    public ProgressBar progressBar; // Reference to your ProgressBar component
    public Armor armor;


    // Start is called before the first frame update
    void Start()
    {
        progress = 0;
        progressBar = FindObjectOfType<ProgressBar>(); // Find the ProgressBar component in the scene
        armor = GameObject.Find("char").GetComponent<Armor>();

    }

        // Update is called once per frame
        void Update()
        {
            progress = ((armor.radiationResistance + armor.rechargeRate + armor.damageReduction) * 5) +armor.shieldSize;
            FindFill();
        }

         void FindFill()
        {
            int fillAmount = Mathf.RoundToInt(progress); // Explicitly convert float to int
            progressBar.SetCurrentFill(fillAmount);
        }
    
}
