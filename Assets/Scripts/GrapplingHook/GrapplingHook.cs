using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// represents a grappling hook gun
public class GrapplingHook : MonoBehaviour
{
    // fields
    LineRenderer line;
    [SerializeField] public float distance;
    private bool firing = false;
    public float reloadTime;
    public bool reloading = false;
    public GameObject hookPrefab;
    [SerializeField] public float speed;

    [SerializeField] LayerMask grappleableMask;
    [SerializeField] public float shootspeed;

    bool isGrappling = false;
    [HideInInspector] public bool retracting = false;

    Vector3 target; // Changed to Vector3 for 3D
    GameObject hook; // Define hook as a class-level variable

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // fires the grappling hook if the right mouse button is pressed and the gun is not already firing
        if (Input.GetMouseButton(1))
        {
            if (!firing)
            {
                StartCoroutine(FireHook());
            }
        }
        if (retracting)
        {
            Vector3 grapplePos = Vector3.Lerp(transform.position, target, speed * Time.deltaTime); // Changed reloadTime to Time.deltaTime
            transform.position = grapplePos;

            line.SetPosition(0, transform.position); // Corrected SetPosition typo

            if (Vector3.Distance(transform.position, target) < 0.5f)
            {
                retracting = false;
                isGrappling = false;
                line.enabled = false;
            }
        }
    }

    // fires the hook
    public IEnumerator FireHook()
    {
        // generate projectile, assign it distance and speed
        hook = Instantiate(hookPrefab);
        hook.GetComponent<Hook>().distance = distance;
        hook.GetComponent<Hook>().speed = speed;

        // place it at the tip of the weapon
        hook.transform.position = transform.position;
        hook.transform.rotation = transform.rotation;

        // addForce using speed from weapon
        hook.GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);

        StartGrapple();

        // firing sequence
        firing = true;
        yield return new WaitForSeconds(reloadTime); // limits firing rate
        firing = false;
    }

    private void StartGrapple()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance, grappleableMask)) // Changed to Physics.Raycast for 3D
        {
            isGrappling = true;
            target = hit.point;
            hook.GetComponent<Hook>().positionCount = 2;

            StartCoroutine(Grapple());
        }
    }

    IEnumerator Grapple()
    {
        float t = 0;
        float time = 10;

        line.SetPosition(0, transform.position); // Corrected SetPosition typo
        line.SetPosition(1, transform.position); // Corrected SetPosition typo

        Vector3 newPos;
        for (; t < time; t += shootspeed * Time.deltaTime) // Changed grappleShootSpeed to shootspeed
        {
            newPos = Vector3.Lerp(transform.position, target, t / time);
            line.SetPosition(0, transform.position); // Corrected SetPosition typo
            line.SetPosition(1, newPos); // Corrected SetPosition typo
            yield return null;
        }
        line.SetPosition(1, target); // Corrected SetPosition typo
        retracting = true;
    }
}
