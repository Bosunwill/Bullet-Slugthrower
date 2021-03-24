using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class fallingPlatForm : MonoBehaviour
{
    [SerializeField]
    float hangTime = 2f, resetTime = 4f, returnInterval = 1f;

    [SerializeField]
    AnimationCurve curve;

    [SerializeField]
    Color activeColor = Color.red;

    Rigidbody rb; //Reference to the rigidbody component on this platform
    Renderer rend;  // Reference to the renderer component on the plantform
    Vector3 startPosition; // Store x, y, z position
    Quaternion startRotation; // store w, x, y, z rotation
    Color startColor;          // stores r,g,b,a color
    bool platformIsActive = false;
    // Start is called before the first frame update
    void Start()
    {
     rb = this.GetComponent<Rigidbody>();
     rb.isKinematic = true;   // freeze the platform
     startPosition = this.transform.position; // set initial start position
     startRotation = this.transform.rotation;
     rend = this.GetComponent<Renderer>();
     startColor = rend.material.color;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player") && !platformIsActive){
            StartCoroutine(Fall());
        }
    }
    IEnumerator Fall() {
Debug.Log("Starting fall process");
platformIsActive = true;
StartCoroutine(LerpColor(startColor, activeColor, 0.2f));
yield return new WaitForSeconds(hangTime);
rb.isKinematic = false;

// Reset platform
yield return new WaitForSeconds(resetTime);
Debug.Log("Resetting platform.");
rb.isKinematic = true;
StartCoroutine(ReturnToStart());

    }
    IEnumerator ReturnToStart() {
        Vector3 endPosition = this.transform.position;
        Quaternion endRotation = this.transform.rotation;
        float elapsedTime = 0f;

        StartCoroutine(LerpColor(activeColor, startColor, returnInterval));

        while(elapsedTime < returnInterval) {
            this.transform.position = Vector3.Lerp(endPosition, startPosition, curve.Evaluate(elapsedTime / returnInterval));
             this.transform.rotation = Quaternion.Lerp(endRotation, startRotation, curve.Evaluate(elapsedTime / returnInterval));
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        this.transform.position = startPosition;
        this.transform.rotation = startRotation;
        platformIsActive = false;
    }
    IEnumerator LerpColor(Color startColor, Color endColor, float interval) {
        float elapsedTime = 0f;
        while(elapsedTime < interval) {
            rend.material.color = Color.Lerp(startColor, endColor, curve.Evaluate(elapsedTime / interval));
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        rend.material.color = endColor;
    }
}
