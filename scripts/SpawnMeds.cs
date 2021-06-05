using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeds : MonoBehaviour
{
    public static int numMeds = 6;

    Vector3[] positionArray = new [] { new Vector3(-2.5f,18.5f,0f), new Vector3(21.5f,11.5f,0f), new Vector3(-23.5f,11.5f,0f), new Vector3(-17.5f,-12.5f,0f), new Vector3(9f,-4.5f,0f), new Vector3(13.5f,-16.5f,0f) };
    public GameObject med;

    // Update is called once per frame
    void Update()
    {
        if (numMeds == 0)
        {
            StartCoroutine(SpawnKits());
        }
    }

    IEnumerator SpawnKits()
    {
        int num = Random.Range(0, 7);
        for (int i = 0; i < num; ++i)
        {
            int rand = Random.Range(0, 6);
            Instantiate(med, positionArray[rand], Quaternion.identity);
            numMeds++;

            yield return new WaitForSeconds(3f);
        }
        
        yield break;
    }
}
