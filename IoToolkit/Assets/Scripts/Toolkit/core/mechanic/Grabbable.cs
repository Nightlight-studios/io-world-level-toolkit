using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : Interactable
{
    public Transform holder;
    private bool isGrabbed = false;

    void Start() {

        if(executor == null) {
            return;
        }
        
        this.holder = executor.GetComponent<CharacterController>().holder;
    }

    public override void Interact() {
        
        if(executor == null) {
            return;
        }

        if(holder == null) {
            this.holder = executor.GetComponent<CharacterController>().holder;
        }

        if (isGrabbed) {
            Release();
        } else {
            Grab();
        }

        isGrabbed = !isGrabbed;
    }

    private void Grab() {

        if(executor == null) {
            return;
        }

        // Get holder from executor
        holder = executor.GetComponent<CharacterController>().holder;


        Debug.Log("Grab");
        isGrabbed = true;
        transform.SetParent(holder);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        this.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    private void Release() {
        isGrabbed = false;
        this.GetComponent<Rigidbody2D>().isKinematic = false;
        transform.SetParent(null);
    }

}
