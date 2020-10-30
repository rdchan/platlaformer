using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlDoor : MonoBehaviour
{
    public Animator doorAnimator;
    public Animator playerAnimator;
    //public Animator transition;

    private int nextLevelIndex;
    public int overrideNextScene = -1;

    private bool doorOpen;
    public float transitionTime = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        doorOpen = false;
        doorAnimator.SetBool("DoorOpen", doorOpen);
        if(overrideNextScene == -1) { 
            nextLevelIndex = 1 + SceneManager.GetActiveScene().buildIndex;
        } else {
            nextLevelIndex = overrideNextScene;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "player") {
            doorOpen = true;
            //play door opening sound
            doorAnimator.SetBool("DoorOpen", doorOpen);
            LoadNextLevel();
            
        }
    }
     public void LoadNextLevel() {
         StartCoroutine(LoadLevel(nextLevelIndex));
     }

     IEnumerator LoadLevel(int levelIndex) {
         yield return new WaitForSeconds(transitionTime);
         //transition.SetTrigger("Open");
         yield return new WaitForSeconds(transitionTime);
         SceneManager.LoadScene(levelIndex);
     }

    void OnTriggerExit2D(Collider2D other)
    {
     //do nothing?   
        if(other.tag == "player") {
            doorOpen = false;
            //play door opening sound
            doorAnimator.SetBool("DoorOpen", doorOpen);
            //do some delay/fade??
        }
    }

}
