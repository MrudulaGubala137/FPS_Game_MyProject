using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerSpeed;
     float rotationSpeed=2.0f;
    
    float cameraPitch = 0.0f;
   public Transform playerCamera;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal") * playerSpeed;
        float inputZ = Input.GetAxis("Vertical") * playerSpeed;
        transform.Translate(inputX, 0f, inputZ);
        MouseLook();
    }
    void MouseLook()
    {
        Vector2 mouseLook = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        cameraPitch-=mouseLook.y* rotationSpeed;

        cameraPitch = Mathf.Clamp(cameraPitch, -60.0f, 60.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * mouseLook.x * rotationSpeed);

    }
}
