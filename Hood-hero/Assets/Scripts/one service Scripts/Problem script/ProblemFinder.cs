using movement;
using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
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

        public bool isButtonAway = false;
        private Vector3 buttonInitialPosition;
        private Vector3 buttonMoveToPosition;

        private OneServiceApp app;

        [SerializeField] private GameObject popupImage;
        [SerializeField] private Vector2 offset;
        private Vector3 popupImageInitialPosition;

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
            buttonMoveToPosition = buttonMoveLocation.transform.position;
            playerMovement = GetComponent<PlayerMovementScript>();
            app = OneServiceApp.instance;
            popupImageInitialPosition = popupImage.transform.position;
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
                //button.transform.position = Vector3.MoveTowards(button.transform.position, buttonInitialPosition, Time.deltaTime * 1500.0f);
                ProblemPopupMoveToInitPosition();
            }
            else if (isButtonAway == true)
            {
                //button.transform.position = Vector3.MoveTowards(button.transform.position, buttonMoveToPosition, Time.deltaTime * 1500.0f);
                ProblemPopupMoveToGameObject();
            }
        }

        void ProblemPopupMoveToInitPosition()
        {
            popupImage.transform.position = popupImageInitialPosition;
        }

        void ProblemPopupMoveToGameObject()
        {
            popupImage.transform.position = transform.position + (Vector3)offset;
        }
        private void CheckingProblem()
        {
            var directions = Enum.GetValues(typeof(DirectionType)).Cast<DirectionType>().ToArray();

            // add extra perimeter here to only do raycasting on problems only
            //will need to change this transform.up later on
            foreach(var directionValue in directions)
            {
                Vector3 direction = GetValueFromDirection(directionValue);

                RaycastHit2D hit = Physics2D.Raycast(
                    transform.position,
                    direction,
                    distanceToSense,
                    defaultLayerMask,
                    -3f,
                    3f
                    );

                if (hit.collider == null)
                {
                    DeactivatedApp();
                }
                else
                {//if got hit object
                    ActivateApp(hit);
                    break;
                }

            }
        }

        private Vector3 GetValueFromDirection(DirectionType directionEnum)
        {
            Vector3 direction = Vector3.down;

            switch (directionEnum)
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

            return direction;
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