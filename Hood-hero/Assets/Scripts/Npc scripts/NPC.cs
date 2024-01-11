using pattern;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //will start message
    [SerializeField] private Message[] messages;
    [Header("Hints")]
    [SerializeField] private ProblemSelector problem;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform problemLocation;
    private bool hasCompleteConversation = false;
    //martin improve on this and consider using button instead


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasCompleteConversation) return;
        hasCompleteConversation = true;
        DialogueManager.Instance.OpenDialogueSession(messages);
      
        EventManager.instance.AddListener(TypeOfEvent.DialogEndEvent, CreateArrow);
    }

    private void CreateArrow()
    {
        AssignArrow();
        //Vector3 direction = problem.transform.position - transform.position;
        //float angle = Vector3.Angle(Vector3.up, direction);
        //Vector3 arrowPos = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);

        //arrowReference = Instantiate(arrowPrefab, arrowPos, Quaternion.identity, transform);
        //arrowReference.transform.Rotate(0, 0, angle); //keep it organise and putting it in the npc

        //make sure to remove the listener to prevent memory leakage
        EventManager.instance.RemoveListener(TypeOfEvent.DialogEndEvent, CreateArrow);
    }

    //private void DeleteArrow(ProblemSelector calledProblem)
    //{
    //    //check if the scored problem is the problem related to npc
    //    if (calledProblem == problem) 
    //    {
    //        arrowReference.SetActive(false); //dont show it
    //        EventManager.instance.RemovingScoringListener(DeleteArrow);
    //    }
    //}

    private void AssignArrow()
    {
        print(problemLocation.name);
        guidingArrow.instance.StartDatCoroutine(problemLocation);
    }
}
 
