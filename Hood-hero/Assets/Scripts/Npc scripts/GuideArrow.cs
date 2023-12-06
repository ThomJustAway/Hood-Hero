using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideArrow : MonoBehaviour
{
    public GameObject arrow; // Reference to arrow prefab 
    public GameObject problem;
    private GameObject arrowInstance; // Reference to the instantiated arrow 
    private DialogueManager dialogueManager;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>(); // Find the DialogueManager in the scene
    }

    public void CreateArrow()
    {
        if (arrow != null && arrowInstance == null)
        {
            Vector3 direction = problem.transform.position - transform.position;
            float angle = Vector3.Angle(Vector3.up, direction);
            Vector3 arrowPos = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);

            arrowInstance = Instantiate(arrow, arrowPos, Quaternion.identity);
            arrowInstance.transform.Rotate(0, 0, angle);
            Debug.Log("Arrow created");
        }
    }

    public void NextMessage()
    {
        if (dialogueManager != null)
        {
            dialogueManager.activeMessage++;

            if (dialogueManager.activeMessage < dialogueManager.currentMessages.Length)
            {
                dialogueManager.DisplayMessage();
            }
            else
            {
                dialogueManager.backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInExpo();
                DialogueManager.isActive = false;
                CreateArrow();
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextMessage();
        }
    }
}
