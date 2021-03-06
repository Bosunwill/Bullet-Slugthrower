﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IItem
{
    public Rigidbody Projectile;
    bool shoot = true;    

   public void Pickup(Transform hand)
   {
       Debug.Log("I'm active");
       this.gameObject.transform.SetParent(hand);
       this.transform.localPosition = Vector3.zero;
       this.transform.localRotation = Quaternion.identity;
       this.GetComponent<Rigidbody>().useGravity = true;
       this.GetComponent<Rigidbody>().isKinematic = true;
       this.GetComponent<Collider>().enabled = false; 
   }
   public void Use()
   {
       Debug.Log("<color=red>Pow!</color>");
       if(shoot) {
       Rigidbody iProjectile = Instantiate(Projectile, transform.position, transform.rotation) as Rigidbody;
        iProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * 20, ForceMode.Impulse);
        shoot = false;
        StartCoroutine(Wait());
       //iProjectile .velocity = transform.TransformDirection(new Vector3(0, 0, speed + 20));
       }
   }
   public void Drop()
   {
       Debug.Log("Dropping our item!!");
       this.gameObject.transform.SetParent(null);
       //this.transform.localPosition = Vector3.forward;
       //this.transform.localRotation = Quaternion.identity;
       this.transform.Translate(0, -3, 7);
       this.GetComponent<Rigidbody>().useGravity = true;
       this.GetComponent<Rigidbody>().isKinematic = true;
       this.GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.Impulse);
       this.GetComponent<Collider>().enabled = true; 
   }
   IEnumerator Wait()
   {
       yield return new WaitForSeconds(0.2f);
       shoot = true;
   }
}
