using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    // Start is called before the first frame update
    float yRotation = 0.0f;
    float xRotation = 0.0f;
    public float rotationSpeed;
   
    public Camera cam;
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        yRotation += mouseInput.x * rotationSpeed; 
        xRotation -= mouseInput.y * rotationSpeed;
        xRotation = Mathf.Clamp(xRotation, -60.0f, 30.0f);
        cam.transform.localRotation=Quaternion.Euler(xRotation,0,0);
        transform.rotation = Quaternion.Euler(0,yRotation,0);
        
        
        
    }
}
