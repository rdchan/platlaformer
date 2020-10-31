using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;

	private bool hasBeenTriggered = false;
	public void TriggerDialogue ()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "player" && !hasBeenTriggered) {
			TriggerDialogue();
			hasBeenTriggered = true;
        }
    }

}
