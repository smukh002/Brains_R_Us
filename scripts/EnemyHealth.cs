using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    private int health = 6;
    public GameObject blood;
    public AudioSource pain;
    public AudioSource hit;

    void Start()
    {
        pain = GameObject.Find("bighit").GetComponent<AudioSource>();
        hit = GameObject.Find("fleshhit").GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet") {
            hit.PlayOneShot(hit.clip, 1f);
            health -= 2; // Bullet dmg: 2 pts
            if (health == 0)
            {
                pain.PlayOneShot(pain.clip, 1f);
                GameObject bloodsplosion = Instantiate(blood, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(bloodsplosion, 3.0f);
                PlayerHealth.kills++;
            }
        }
    }
}
