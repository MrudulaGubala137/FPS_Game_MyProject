using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameOverPanel.SetActive(false);
      

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
            }
        }
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ammo")
        {
            print("Ammo picked");
            ammo =Mathf.Clamp( ammo + 25,0,maxAmmo);
        }
        if (other.gameObject.tag == "Medical")
        {
            print("Medical picked");
            health =Mathf.Clamp( health + 3,0,maxHealth);
        }
    }
}