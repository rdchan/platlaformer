using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    private Vector3 levelStartPlace;
    //private GameObject PlayerGameObject;
    private float playery;
    void Start()
    {
     //   PlayerGameObject = GameObject.Find("Player");
        levelStartPlace = player.position;
    }
 
     void OnBecameInvisible() 
     {
         //Application.LoadLevel(Application.loadedLevel);
         //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         player.position = levelStartPlace;
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
