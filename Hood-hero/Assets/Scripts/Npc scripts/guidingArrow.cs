using System.Collections;
using UnityEngine;

public class guidingArrow : MonoBehaviour
{
    public static guidingArrow instance;
    [SerializeField] private GameObject arrowContainer;
    [SerializeField] private GameObject arrow;
    [HideInInspector] public Transform Problem;
    public float timeBeforeDisappear;
    private bool arrowActive = true; // Controls guide arrow visibility

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        if (!arrowActive) return; // If guide arrow deactivated, does nothing

        //Debug.Log(Problem.position);

        //if (dir.magnitude < hideDist)
        //{
        //    arrowActive = false; // Deactivates guide arrow after finding problem game object
        //    SetChildrenActive(false);
        //}
        //else
        //{
        //    SetChildrenActive(true);

        //    var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //}
    }

    public void StartDatCoroutine(Transform Problem)
    {
        print("hello");
        this.Problem = Problem;
        StartCoroutine(TestShowArrow());
    }

    void SetArrowActive(bool value)
    {
        arrow.SetActive(value);
    }

    IEnumerator TestShowArrow()
    {
        Vector3 dir;
        SetArrowActive(true);

        float lapsedTime = 0;
        
        while (lapsedTime < timeBeforeDisappear)
        {
            dir = Problem.position - transform.position;
            lapsedTime += Time.deltaTime;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            arrowContainer.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            yield return null;
        }
        SetArrowActive(false);
    }
}
