using UnityEngine;

public class guidingArrow : MonoBehaviour
{
    public Transform Problem;
    public float hideDist;
    private bool arrowActive = true; // Controls guide arrow visibility

    void Update()
    {
        if (!arrowActive) return; // If guide arrow deactivated, does nothing

        var dir = Problem.position - transform.position;

        if (dir.magnitude < hideDist)
        {
            arrowActive = false; // Deactivates guide arrow after finding problem game object
            SetChildrenActive(false);
        }
        else
        {
            SetChildrenActive(true);

            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void SetChildrenActive(bool value)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);
        }
    }
}
