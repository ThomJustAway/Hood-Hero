using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpScript : MonoBehaviour
{
    public static PopUpScript instance;

    [SerializeField] private Animator animator;
    [SerializeField] private TextMeshProUGUI text;
    private bool activated = false;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            print("cant have more than one instance");
            Destroy(this);
        }
    }

    public void StartMessage(string message, int duration)
    {
        if(activated)
        {
            Debug.LogError("Cant open a message that is already open");
            return;
        }
        text.text = message;
        activated = true;
        animator.SetBool("activate" , activated);
        StartCoroutine(waitTimerBeforeStoping(duration));
    }

  
    IEnumerator waitTimerBeforeStoping(int duration)
    {
        yield return new WaitForSeconds(duration);
        activated = false;
        animator.SetBool("activate", activated);

    }
}
