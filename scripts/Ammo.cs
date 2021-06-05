using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ammo : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int ammoCount;
    public PlayerController pc;
    public AudioSource reload;

    // Start is called before the first frame update
    void Start()
    {
        text.SetText(ammoCount.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if (ammoCount > 0)
            {
                pc.Shoot();
                ammoCount--;
                text.SetText(ammoCount.ToString());
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            text.SetText(ammoCount.ToString());
            reload.PlayOneShot(reload.clip, 1f);
            ammoCount = 100;
        }
    }
}
