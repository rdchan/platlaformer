using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bisonmove : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 pos1;
    private Vector3 pos2;
    public float speed = 1.0f;
    private float lastVal;
    private float currVal;
    private bool facingRight;
    public float travelDistance = 8;

    private Vector3 originalLocalScale;
    public bool horizontal = true;
    private Vector3 flippedLocalScale;

    private Transform child; //could use array of children to expand. need to detach them before flipping and reattach after

    public Animator animator;
    
    void Start()
    {
        if(horizontal) {
            pos1 = new Vector3(transform.position.x-travelDistance/2, transform.position.y, 0);
            pos2 = new Vector3(transform.position.x+travelDistance/2, transform.position.y, 0);
        } else {
            pos1 = new Vector3(transform.position.x, transform.position.y-travelDistance/2, 0);
            pos2 = new Vector3(transform.position.x, transform.position.y+travelDistance/2, 0);
        }

        originalLocalScale = transform.localScale;
        flippedLocalScale = originalLocalScale;
        flippedLocalScale.x *= -1; 

        facingRight = true;
        lastVal = 0;
        animator.SetBool("FacingRight", true);
    }

    // Update is called once per frame
    void Update()
    {
        currVal = Mathf.PingPong(Time.time * speed, 1.0f);

        transform.position = Vector3.Lerp(pos1, pos2, currVal);
        facingRight = currVal > lastVal;
        animator.SetBool("FacingRight", facingRight);
        lastVal = currVal;
    }


}
