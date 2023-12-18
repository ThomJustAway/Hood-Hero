using movement;
using System.Collections;
using System.Linq.Expressions;
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
        [SerializeField] private LayerMask defaultLayerMask;

        private PlayerMovementScript playerMovement;

        private bool isButtonAway = false;
        private Vector3 buttonInitialPosition;
        private Vector3 buttonMoveToPosition;

        private OneServiceApp app;

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
            playerMovement = GetComponent<PlayerMovementScript>();  
            app = OneServiceApp.instance;
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
            //will need to change this transform.up later on
            Vector3 direction = Vector3.down;

            switch (playerMovement.playerFacing)
            {
                case DirectionType.Left:
                    direction = Vector3.left; 
                    break;
                case DirectionType.Right:
                    direction = Vector3.right;
                    break;
                case DirectionType.Up:
                    direction = Vector3.up;
                    break;
                case DirectionType.Down:
                    direction = Vector3.down;
                    break;
                default:
                    break;
            }


            RaycastHit2D hit = Physics2D.Raycast(transform.position, 
                direction, 
                distanceToSense,
                defaultLayerMask,
                - 3f,
                3f
                ); 
            Debug.DrawRay(transform.position, transform.up * distanceToSense, Color.green);

            if (hit.collider == null)
            {
                DeactivatedApp();
            }
            else
            {//if got hit object
                ActivateApp(hit);
            }
        }

        private void ActivateApp(RaycastHit2D hit)
        {
            if (hit.collider.TryGetComponent<ProblemSelector>(out var problemSelector))
            {//hit a problem
                print(problemSelector.ToString());
                isButtonAway = true;
                selectedProblem = problemSelector;
            }
        }

        private void DeactivatedApp()
        {
            isButtonAway = false;
            selectedProblem = null;
            try
            {
                if (app.isActiveAndEnabled)
                {
                    //make sure to close the app if it is open
                    app.CloseApp();
                }
            }
            catch { }//ignore the error
        }
    }
}