using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedCollect : MonoBehaviour
{
    public PlayerHealth ph;

    void Start()
    {
        ph = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            ph.Heal(20);
            SpawnMeds.numMeds--;
            Destroy(gameObject);
        }
    }
}
