using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    // fields
    public GameObject player;
    public float speed;
    private float distance;
    public float health;
    public float damage;
    public GameObject ammoDropPrefab;
    public GameObject scrapDropPrefab;
    public Quest quest;
    public Scrap scrap;
    public float renderdistance;

    // Start is called when on first run
    void Start()
    {
        player = GameObject.Find("char"); // sets player
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(distance < renderdistance)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }

    // handles bullet collisions
    private void OnTriggerEnter(Collider other)
    {
        // deals bullet damage
        if (other.GetComponent<Bullet>())
        {
            health -= other.GetComponent<Bullet>().damage;
        } 
        // deals blade damage
        else if (other.transform.parent && other.transform.parent.GetComponent<Blade>())
        {
            health -= other.transform.parent.GetComponent<Blade>().damage;

        }

        // checks if the enemy has died
        if (health <= 0)
        {
            // drops ammo 60% of the time
            if (Random.Range(0, 2) > 0.4)
            {
                GameObject ammoDrop = Instantiate(ammoDropPrefab);
                ammoDrop.transform.position = transform.position;
            }
            // drops scrap the other 40%
            else
            {
                GameObject scrapDrop = Instantiate(scrapDropPrefab);
                scrapDrop.transform.position = transform.position;
            }
            Destroy(gameObject); // destroys the enemy

            if (quest.isActive)
            {
                quest.goal.EnemyKilled();
                if (quest.goal.IsReached())
                {
                    Debug.Log("Quest Award Awarded");
                    scrap.collect(50);
                    quest.Complete();
                }
            }

        }

    }
}
