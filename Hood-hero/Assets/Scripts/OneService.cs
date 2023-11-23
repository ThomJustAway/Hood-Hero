using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class OneService : MonoBehaviour
    {
        private ProblemSelector selectedProblem = null;
        [SerializeField] private GameObject button;
        [SerializeField] private float distanceToSense = 1f;

        // Update is called once per frame
        void Update()
        {
            CheckingProblem();
        }

        private void CheckingProblem()
        {
            // add extra perimeter here to only do raycasting on problems only
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, distanceToSense);
            //Debug.DrawRay(transform.position, transform.up * distanceToSense, Color.green);

            if (hit.collider == null)
            {
                button.SetActive(false);
                selectedProblem = null; 
            }
            else
            {
                button.SetActive(true);
                selectedProblem = hit.collider.GetComponent<ProblemSelector>();
            }
        }
    }
}