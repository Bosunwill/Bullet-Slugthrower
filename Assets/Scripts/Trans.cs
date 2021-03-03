using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trans : MonoBehaviour, IItem
{
     [SerializeField]
    Transform destination;
     GameObject cube;
    public void Pickup(Transform hand)
    {
       this.gameObject.transform.SetParent(hand);
       this.transform.localPosition = Vector3.zero;
       this.transform.localRotation = Quaternion.identity;
       this.GetComponent<Rigidbody>().useGravity = true;
       this.GetComponent<Rigidbody>().isKinematic = true;
       this.GetComponent<Collider>().enabled = false; 
    }
    public void Use()
    {
        Debug.Log("I can create a Trans");
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = new Vector3(1f, 0.25f, 1f);
        cube.transform.localPosition = Vector3.zero;
        cube.GetComponent<Collider>().isTrigger = true;
        if (cube.GetComponent<Collider>().isTrigger == true)
        {
         destination.transform.position = new Vector3(0, 3, 2);
         cube.GetComponent<Collider>().isTrigger = false;   
        }

    }
    public void Drop()
    {
         Debug.Log("Dropping our item!!");
       this.gameObject.transform.SetParent(null);
       //this.transform.localPosition = Vector3.forward;
       //this.transform.localRotation = Quaternion.identity;
       this.transform.Translate(0, 0, 7);
       this.GetComponent<Rigidbody>().useGravity = true;
       this.GetComponent<Rigidbody>().isKinematic = true;
       this.GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.Impulse);
       this.GetComponent<Collider>().enabled = true; 
    }
 //    void OnTriggerEnter(Collider other)
    //{
   //     if (other.gameObject.CompareTag("Player") && other.gameObject.CompareTag("Item"))
     //   {
       //     Debug.Log("I hit the teleporter");
         //   other.transform.position = cube.transform.localPosition;
           // other.transform.Translate(Vector3.up);
        //}
    //}
}
