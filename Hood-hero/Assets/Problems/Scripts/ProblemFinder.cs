using System.Collections;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ProblemFinder : MonoBehaviour
    {
        public static ProblemFinder Instance;
        public ProblemSelector selectedProblem { get; private set; }
        [SerializeField] private GameObject button;
        [SerializeField] private GameObject buttonMoveLocation;
        [SerializeField] private float distanceToSense = 1f;
        private bool isButtonAway = true;
        private Vector3 buttonInitialPosition;
        private Vector3 buttonMoveToPosition;

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                print("cant have more than one instance of the game object");
                Destroy(Instance);
            }
            selectedProblem = null;
        }

        void Start()
        {


            buttonInitialPosition = button.transform.position;
            //Debug.Log("Initial Position = " + buttonInitialPosition);
            buttonMoveToPosition = buttonMoveLocation.transform.position;
            //Debug.Log("Move To Position = " + buttonMoveToPosition);
        }

        // Update is called once per frame
        void Update()
        {
            CheckingProblem();
            MovingButton();
        }

        private void MovingButton()
        {
            if (isButtonAway == false)
            {
                button.transform.position = Vector3.MoveTowards(button.transform.position, buttonInitialPosition, Time.deltaTime * 1500.0f);
            }
            else if (isButtonAway == true)
            {
                button.transform.position = Vector3.MoveTowards(button.transform.position, buttonMoveToPosition, Time.deltaTime * 1500.0f);
            }
        }

        private void CheckingProblem()
        {
            // add extra perimeter here to only do raycasting on problems only
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, distanceToSense);
            Debug.DrawRay(transform.position, transform.up * distanceToSense, Color.green);

            if (hit.collider == null)
            {
                //button.SetActive(false);
                //if (isButtonAway == true)
                //{
                //    button.transform.position = Vector3.MoveTowards(button.transform.position, buttonInitialPosition, Time.deltaTime * 2.0f);
                //    isButtonAway = false;
                //    //Debug.Log("Moving Back...");
                //}
                isButtonAway = false;
                selectedProblem = null; 
            }
            else
            {
                //button.SetActive(true);
                //if (isButtonAway == false)
                //{
                //    button.transform.position = Vector3.MoveTowards(button.transform.position, buttonMoveToPosition, Time.deltaTime * 2.0f);
                //    isButtonAway = true;
                //    //Debug.Log("Moving Towards...");
                //}
                isButtonAway = true;
                selectedProblem = hit.collider.GetComponent<ProblemSelector>();
            }
        }
    }
}