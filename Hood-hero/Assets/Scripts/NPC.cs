using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text npcDialogue;
    public string[] dialogue;
    private int index;

    public GameObject nextButton;
    public float wordSpeed;
    public bool playerIsClose;

    private void Start()
    {
        npcDialogue.text = "";
    }
    void Update()
    {
        print(playerIsClose);
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose)  
        { 

            if (dialogueBox.activeInHierarchy)  
            {   
                zeroText();
            } 
            else
            {
                dialogueBox.SetActive(true);
                StartCoroutine(Typing());
            }
        } 
        if(npcDialogue.text == dialogue[index])  
        {
            nextButton.SetActive(true);
        }
    }  
     
    public void zeroText()
    {
        npcDialogue.text = "";
        index = 0;
        dialogueBox.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            npcDialogue.text += letter; 
            yield return new WaitForSeconds(wordSpeed);
        }
    } 
     
    public void NextLine()
    { 
        nextButton.SetActive(false); 

        if(index < dialogue.Length - 1)  
        {
            index++;
            npcDialogue.text = ""; 
            StartCoroutine(Typing());
        } 
        else
        {
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = true; 
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}
