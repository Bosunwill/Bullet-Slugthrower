using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
   [SerializeField]
    Transform hand;
     //This is a hand position empty child of Camera
     Gun heldItem;
  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)){
        if(heldItem != null)
        {
            Debug.Log("I've pressed left mouse Button");
            heldItem.Use();
        } else{
            Debug.Log("We aren't holding anything yet.");
        }
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (heldItem != null){
                heldItem.Drop();
                heldItem = null;
            } else
            {
                Debug.Log("We aren't holding anything");
            }
        }
    }
   private void OnTriggerEnter(Collider other){

     
         if(other.gameObject.CompareTag("Item")) 
         {
             Debug.Log("I have hit ");
             heldItem = other.GetComponent<Gun>();
             heldItem.Pickup(hand);
             
         }
        // if (other.gameObject.CompareTag("Pickup"))
         //{
           //  Destroy(other.gameObject);

         //}
        // if(other.gameObject.CompareTag("Coin")){
          //   Coin = +1;
            // Destroy(other.gameObject);
        //}
    }
}
