using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// represents the blade that hits the enemy
public class Blade : MonoBehaviour
{
    // fields
    public float damage;
    public float distance;
    public float knockback;
    public float speed;
    public float slashAngle;
    private float angle;
    private float startingAngle;
    private float endingAngle;

    // Start is called before the first frame update
    void Start()
    {
        // sets the length of the blade
        transform.GetChild(0).localScale = new Vector3(distance, 0.15f, 1);
        transform.GetChild(0).localPosition = new Vector3(distance/2, 0, 0);

        // sets angle limits
        startingAngle = transform.rotation.eulerAngles.z - slashAngle/2; // sets starting angle as player forward rotation - half of slash angle
        endingAngle = transform.rotation.eulerAngles.z + slashAngle / 2; // sets ending angle as player forward rotation + half of slash angle
        angle = startingAngle;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GameObject.Find("char").transform.position; // sets the blade position to the player postion
        
        // rotates the blade while angle has not reached endingAngle
        if (angle < endingAngle)
        {
            angle += Time.deltaTime * speed;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        } 

        // destroys the blade otherwise
        else
        {
            Destroy(gameObject);
        }

    }
}
