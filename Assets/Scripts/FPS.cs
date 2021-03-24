using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
//    private Rigidbody rb;
public CharacterController controller;
    public float movement = 10f, gravity = -9.81f;
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f, jumpHeight = 20f;
    public LayerMask groundMask;
    private float dirX, dirZ;
    bool isGrounded;

    CamDir bodyT;
    
    // Start is called before the first frame update
   // void Start()
    //{
      //  movement = 5f;
  //      rb = GetComponent<Rigidbody>();
         
    //}

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        dirX = Input.GetAxis("Horizontal");
        dirZ = Input.GetAxis("Vertical");

       Vector3 move = transform.right * dirX  + transform.forward * dirZ;
        controller.Move(move * movement * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.J))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
      //  rb.velocity = new Vector3(dirX, rb.velocity.y, dirZ);
        
    }
}


///<summary>
// from 3D Unity 8 directional
//  public float velocity = 5;
//     public float TSpeed = 10;

//     Vector2 input; 
//     float angle;
//     Quaternion rotateTarget;
//     Transform cam;
    
//     // Start is called before the first frame update
//     void Start()
//     {
//         cam = Camera.main.transform;         
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         GetInput();

//         if (Mathf.Abs(input.x) < 1 && Mathf.Abs(input.y) < 1) return;

//         DirectionalCalculate();
//         Rotate();
//         Move();
//     }
//     // input based on Horizontal (a,d,leftarrow, rightarrow) and Vertical (w,s,uparrow,downarrow)
//     void GetInput() 
//     {
//         input.x = Input.GetAxisRaw("Horizontal");
//         input.y = Input.GetAxisRaw("Vertical");
//     }
//     // Direction relative to Camera's Rotation
//     void DirectionalCalculate()
//     {
//         angle = Mathf.Atan2(input.x, input.y);
//         angle = Mathf.Rad2Deg * angle;
//         angle += cam.eulerAngles.y;
//     }
//     void Rotate()
//     {
//         rotateTarget = Quaternion.Euler(0, angle, 0);
//         transform.rotation = Quaternion.Slerp(transform.rotation, rotateTarget, TSpeed * Time.deltaTime);
//     }
//     void Move()
//     {
//         transform.position += transform.forward * velocity * Time.deltaTime;
//     }

///</summary>