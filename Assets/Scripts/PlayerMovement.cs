using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerSpeed;
    public int jumpForce;
    Rigidbody rb;
    public int health;
    public Animator animator;
    public Transform bulletDirection;
    public GameObject gameOverPanel;
    int maxAmmo = 25;
    int maxHealth = 10;
    public int ammo;
    public Text healthText;
    public Text ammoText;
    // public Transform gunPosition;
    public GameObject gun1;
    public GameObject gun2;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameOverPanel.SetActive(false);
        gun1.SetActive(true);
        gun2.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal") * playerSpeed;
        float inputZ = Input.GetAxis("Vertical") * playerSpeed;
        transform.Translate(inputX, 0f, inputZ);
        if (Input.GetKeyDown(KeyCode.J))
        {
            rb.AddForce(Vector3.up * jumpForce);

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger("IsReload");
        }
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("IsFiring");
            ammo--;
            ammoText.text = "Ammo:" + ammo;
           /* RaycastHit hitInfo;
            if (Physics.Raycast(bulletDirection.position, bulletDirection.forward, out hitInfo, 100f))
            {
                GameObject hitEnemy = hitInfo.collider.gameObject;
                print("Enemy got hit");
                if (hitEnemy.tag == "Enemy")
                {
                    print("Enemy got hit");
                    hitEnemy.GetComponent<EnemyController>().EnemyDead();
                }
            }*/
            HitEnemy();
        }
        if(Input.GetKeyDown(KeyCode.G))
        { 
            gun1.SetActive(false);
            gun2.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            gun1.SetActive(true) ;
            gun2.SetActive(false) ;
        }

    }
    private void HitEnemy()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(bulletDirection.position, bulletDirection.forward, out hitInfo, 1000f))
        {
            GameObject hitEnemy = hitInfo.collider.gameObject;
            if (hitEnemy.tag == "Enemy")
            {
                print("Enemy got hit");
               hitEnemy.GetComponent<EnemyController>().EnemyDead();
                Destroy(hitEnemy,4f);
            }
        }
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ammo"&& ammo<maxAmmo)
        {
            print("Ammo picked");
            ammo =Mathf.Clamp( ammo + 25,0,maxAmmo);
            ammoText.text = "Ammo:" + ammo;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Medical"&& health<maxHealth)
        {
            print("Medical picked");
            health =Mathf.Clamp( health + 10,0,maxHealth);
            healthText.text = "Health:"+ health;
            Destroy(other.gameObject);
        }
    }
}