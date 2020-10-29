using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2d : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float horizontalMove = 0f;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed; 
        Vector3 movement = new Vector3(horizontalMove, 0f, 0f);
        transform.position += movement * Time.deltaTime;
        animator.SetFloat("Speed", -1*(horizontalMove));
    }
    
    void Jump() {
        if(Input.GetButtonDown("Jump")) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 10f), ForceMode2D.Impulse);
        } 
    }
}
