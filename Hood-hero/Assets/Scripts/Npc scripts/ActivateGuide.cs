using UnityEngine;

public class ActivateGuide : MonoBehaviour
{
    private DialogueManager dialogueManager;
    public GameObject problemChecker; // Assign in the Inspector
    private bool dialogueDone = false; // Tracks dialogue completion

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        if (dialogueManager != null)
        {
            dialogueManager.ResetDialogue(); // Reset dialogue progress
        }

        if (problemChecker != null)
        {
            problemChecker.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ProgressDialogue();
        }
        if (dialogueDone) // Activate ProblemChecker only after dialogue completion
        {
            ActivateProblemChecker();
        }
    }

    public void ProgressDialogue()
    {
        if (dialogueManager != null && dialogueManager.isActive)
        {
            dialogueManager.NextMessage();
        }
    }

    public void DialogueComplete()
    {
        dialogueDone = true; // Sets dialogue as complete
    }

    public void ActivateProblemChecker()
    {
        if (problemChecker != null)
        {
            problemChecker.SetActive(true); // Activate 'ProblemChecker' game object
        }
    }
}
