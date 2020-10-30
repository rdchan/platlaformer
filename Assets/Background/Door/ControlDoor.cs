using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDoor : MonoBehaviour
{
    public Animator animator;

    private bool doorOpen;
    // Start is called before the first frame update
    void Start()
    {
        doorOpen = false;
        animator.SetBool("DoorOpen", doorOpen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger enter door");
        if(other.tag == "player") {
            doorOpen = true;
            //play door opening sound
            animator.SetBool("DoorOpen", doorOpen);
            //do some delay/fade??
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
     //do nothing?   
        if(other.tag == "player") {
            doorOpen = false;
            //play door opening sound
            animator.SetBool("DoorOpen", doorOpen);
            //do some delay/fade??
        }
    }

}
