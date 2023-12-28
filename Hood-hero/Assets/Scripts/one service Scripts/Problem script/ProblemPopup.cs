using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemPopup : MonoBehaviour
{
    public ProblemFinder problemFinder;
    [SerializeField] private Transform problemPosition;
    [SerializeField] private GameObject popupImage;
    private Vector3 popupImageInitialPosition;
    private Vector3 popupImageAboveProblemPosition;
    [SerializeField] private GameObject ReportUI;
    // Start is called before the first frame update
    void Start()
    {
        popupImageInitialPosition = popupImage.transform.position;
        Debug.Log(popupImageInitialPosition);
        popupImageAboveProblemPosition = new Vector3(problemPosition.transform.position.x,
            problemPosition.transform.position.y + 1.3f,
            problemPosition.transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        ProblemChecking();
    }

    void ProblemChecking()
    {
        if (problemFinder.isButtonAway == false) 
        {
            ProblemPopupMoveToInitPosition();
        }
        else if (problemFinder.isButtonAway == true)
        {
            ProblemPopupMoveToGameObject();
        }
    }

    public void ProblemPopupMoveToGameObject()
    {
        popupImage.transform.position = problemPosition.position + new Vector3(0f, 1.3f, 0f);
        Debug.Log(popupImage.transform.position);
    }

    public void ProblemPopupMoveToInitPosition()
    {
        popupImage.transform.position = popupImageInitialPosition;
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("PRESSED!");
        if (ReportUI != null)
        {
            ReportUI.SetActive(true);
        }
    }
}
