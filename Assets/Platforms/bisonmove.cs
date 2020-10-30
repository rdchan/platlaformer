using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bisonmove : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 pos1;
    private Vector3 pos2;
    public float speed = 1.0f;
    private bool facingRight;
    private float lastVal;
    private float currVal;
    public float travelDistance = 8;
    void Start()
    {
        pos1 = new Vector3(transform.position.x-travelDistance/2, transform.position.y, 0);
        pos2 = new Vector3(transform.position.x+travelDistance/2, transform.position.y, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        currVal = Mathf.PingPong(Time.time * speed, 1.0f);


        transform.position = Vector3.Lerp(pos1, pos2, currVal);
        if (facingRight && (currVal < lastVal))
        {
            Flip();
        }
        else if(!facingRight && (currVal > lastVal))
        {
            Flip();
        }

            lastVal = currVal;
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }



}
