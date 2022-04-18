using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerSpeed;
    public int jumpForce;
    Rigidbody rb;
    public Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       

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
        if(Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("IsFiring");
        }

    }
    
}
