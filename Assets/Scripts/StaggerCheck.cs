using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaggerCheck : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject hips;
    //private Animator animator;

    private Rigidbody hipsRigidBody; 
    void Start()
    {
        hips = transform.gameObject; 
        hipsRigidBody = hips.gameObject.GetComponent<Rigidbody>(); 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Stagger(int time){
        hipsRigidBody.constraints = RigidbodyConstraints.None;
        Debug.Log("Stagger time");
        //animator.enabled = false;
        waitingForUnstaggerCoroutine(5); 
    }

    void Unstagger(){
        hipsRigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        //animator.enabled = true;
        Debug.Log("Unstagger time");
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "StaggerBox"){
            Debug.Log("Why");
            Stagger(5); 
        }
    }

    private IEnumerator waitingForUnstaggerCoroutine(int time){

        yield return new WaitForSeconds (time); 

        Unstagger(); 
    }
}
