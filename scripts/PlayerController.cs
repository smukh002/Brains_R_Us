using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;

    private Camera theCam;

    public Transform firePoint;
    public GameObject bulletToFire;
    public float force = 15f;

    public PlayerHealth ph;

    private float timer;

    public AudioSource riflesound;
    // Start is called before the first frame update
    void Start()
    {
        theCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (ph.currentHealth > 0)
        {
            theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;

            Vector3 mouse = Input.mousePosition;

            Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

            Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);

            float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);

            /* Now checking if ammo left in Ammo.cs and calling Shoot() if so
            if(Input.GetButtonDown("Fire1"))
            {
                riflesound.PlayOneShot(riflesound.clip, 1f);
                Instantiate(bulletToFire, firePoint.position, transform.rotation);

            }
            */
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            ph.TakeDamage(6);
            timer = 0;
        }
        else if (other.tag == "Fast Enemy")
        {
            ph.TakeDamage(8);
            timer = 0;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            timer += Time.deltaTime;
            //Debug.Log(timer);
            if (timer > 1) 
            {
                ph.TakeDamage(5);
                timer = 0;
            }
        }
        else if (other.tag == "Fast Enemy")
        {
            timer += Time.deltaTime;
            //Debug.Log(timer);
            if (timer > 1) 
            {
                ph.TakeDamage(4);
                timer = 0;
            }
        }

    }

    public void Shoot()
    {
        if (ph.currentHealth > 0)
        {
            riflesound.PlayOneShot(riflesound.clip, 1f);
            GameObject bullet = Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.right * force, ForceMode2D.Impulse);
        }
    }
}
