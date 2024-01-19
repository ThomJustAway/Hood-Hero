using Assets.Scripts.one_service_Scripts.pattern;
using pattern;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    //will start message
    [SerializeField] private Message[] messages;
    [Header("Hints")]
    [SerializeField] private ProblemSelector problem;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform problemLocation;
    //martin improve on this and consider using button instead
    [SerializeField] private Vector2 offset = new Vector2(0 , 1f);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var speechButton = PrefabManager.instance.speechPopUp;
        speechButton.SetActive(true);
        speechButton.transform.position = transform.position + (Vector3) offset; //offset and make it appear at the npc head.
        var buttonComponent = speechButton.GetComponentInChildren<Button>();
        if (buttonComponent != null ) { Debug.LogError("Add a button component please"); }
        buttonComponent.onClick.RemoveAllListeners();
        buttonComponent.onClick.AddListener(OnClickCallBack);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //close the speech pop up.
        PrefabManager.instance.speechPopUp.SetActive(false);
    }

    private void OnClickCallBack()
    {
        DialogueManager.Instance.OpenDialogueSession(messages);
        EventManager.instance.AddListener(TypeOfEvent.DialogEndEvent, CreateArrow);
    }

    private void CreateArrow()
    {
        AssignArrow();

        EventManager.instance.RemoveListener(TypeOfEvent.DialogEndEvent, CreateArrow);
    }

    private void AssignArrow()
    {
        print(problemLocation.name);
        guidingArrow.instance.StartDatCoroutine(problemLocation);
    }
}
 
