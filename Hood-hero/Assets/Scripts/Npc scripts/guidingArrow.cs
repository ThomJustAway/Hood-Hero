using System.Collections;
using UnityEngine;

public class guidingArrow : MonoBehaviour
{
    [HideInInspector] public Transform Problem;
    public float hideDist;
    private bool arrowActive = true; // Controls guide arrow visibility

    void Update()
    {
        if (!arrowActive) return; // If guide arrow deactivated, does nothing

        //Debug.Log(Problem.position);

        var dir = Problem.position - transform.position;

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
        this.Problem = Problem;
        StartCoroutine(TestShowArrow());
    }

    void SetChildrenActive(bool value)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);
        }
    }

    IEnumerator TestShowArrow()
    {
        Vector3 dir;
        SetChildrenActive(true);

        yield return new WaitForSeconds(3);
        float lapsedTime = 0;
        while (lapsedTime < 3)
        {
            dir = Problem.position - transform.position;
            lapsedTime += Time.deltaTime;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Debug.Log("I AM RUNNINGNNNNGGG");
            yield return null;
        }
        SetChildrenActive(false);
    }
}
