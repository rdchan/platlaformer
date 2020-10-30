using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restart : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject PlayerGameObject;
    void Start()
    {
        PlayerGameObject = GameObject.Find("Player");
    }
 
     void OnBecameInvisible() 
     {
         Application.LoadLevel(Application.loadedLevel);
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
