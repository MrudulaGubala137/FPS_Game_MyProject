using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerSpeed;
     /*float playerRotationSpeed=2.0f;
    
    float cameraRotation = 0.0f;
   public Transform playerCamera;*/
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal") * playerSpeed;
        float inputZ = Input.GetAxis("Vertical") * playerSpeed;
        transform.Translate(inputX, 0f, inputZ);
     
    }
    /*void MouseLook()
    {
        Vector2 mouseLook = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        cameraRotation -=mouseLook.y* playerRotationSpeed;

        cameraRotation -= Mathf.Clamp(cameraRotation, -60.0f, 60.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraRotation;
        transform.Rotate(Vector3.up * mouseLook.x * playerRotationSpeed);

    }*/
}
