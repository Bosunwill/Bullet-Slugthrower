using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    private Rigidbody rb;
    private float movement;
    private float dirX, dirZ;
    
    // Start is called before the first frame update
    void Start()
    {
        movement = 3f;
        rb = GetComponent<Rigidbody>();
         
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal") * movement;
        dirZ = Input.GetAxis("Vertical") * movement;
       
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector3(dirX, rb.velocity.y, dirZ);
    }
}
