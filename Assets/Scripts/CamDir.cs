using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamDir : MonoBehaviour
{
     public Transform bodyMovement;
    private float moveDir = 100f;
    public float mouseX, mouseY, rotX = 0f, rotY = 0f;
    // Start is called before the first frame update
    void Start()
    {
     Cursor.lockState = CursorLockMode.Locked;   
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * moveDir * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * moveDir * Time.deltaTime;
        rotX -= mouseY;
        rotY -= mouseX;
        rotX = Mathf.Clamp(rotX, -90f, 90f);
        rotY = Mathf.Clamp(rotY, -360f, 360f);
        transform.localRotation = Quaternion.Euler(rotX, rotY, 0f);
       bodyMovement.Rotate(Vector3.up * mouseX);
  
    }
}
