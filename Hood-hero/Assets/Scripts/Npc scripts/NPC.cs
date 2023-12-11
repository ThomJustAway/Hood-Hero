using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //will start message
    public Message[] messages;
    [Header("Hints")]
    public GameObject problem;
    //add something here to trigger the message instead of using on 
    //trigger enter

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DialogueManager.Instance.OpenDialogueSession(messages);
    }


}
 
