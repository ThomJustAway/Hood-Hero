using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace movement{
    public class PlayerMovementScript : MonoBehaviour
    {
        [SerializeField] private Grid gridForReference;

        #region movement
        [SerializeField] private float timeToMove;
        public DirectionType movementState { get; private set; } = DirectionType.None;

        private Vector3Int cellPlayerIsIn;
        #endregion
        [Header("Animation related")]
        [SerializeField] private Animator animator;
        #region sprite

        //i put it as sprite since the only thing this override is the base idle animation
        [SerializeField] private AnimatorOverrideController spriteLeft;
        [SerializeField] private AnimatorOverrideController spriteRight;
        [SerializeField] private AnimatorOverrideController spriteUp;
        [SerializeField] private AnimatorOverrideController spriteDown;
        #endregion
        public DirectionType playerFacing { get; private set; } = DirectionType.None;

        void Start()
        {
            cellPlayerIsIn = gridForReference.WorldToCell(transform.position);
            transform.position = gridForReference.GetCellCenterWorld(cellPlayerIsIn);
        }

        private void Update()
        {
            HandleInputForTesting();

        }


        #region movement
        private void HandleInputForTesting()
        {
            if (Input.GetKeyDown(KeyCode.W)) Move(DirectionType.Up);
            else if (Input.GetKeyDown(KeyCode.A)) Move(DirectionType.Left);
            else if (Input.GetKeyDown(KeyCode.S)) Move(DirectionType.Down);
            else if (Input.GetKeyDown(KeyCode.D)) Move(DirectionType.Right);
        }
        public void Move(DirectionType TypeOfMovement)
        {
            if (TypeOfMovement == DirectionType.None) {
                UnityEngine.Debug.LogError("cant have movement None!");
                return;
            }
            // make sure that players cant call more than one coroutine at a time.
            if (movementState != DirectionType.None) return;
            movementState = TypeOfMovement;
            Vector3Int nextCell = cellPlayerIsIn;

            //will determine which cell to go to next
            switch(TypeOfMovement)
            {
                case DirectionType.Up:
                    nextCell.y += 1;
                    break;
                case DirectionType.Down:
                    nextCell.y -= 1;
                    break;
                case DirectionType.Left:
                    nextCell.x -= 1;
                    break;
                case DirectionType.Right:
                    nextCell.x += 1;
                    break;
                default: break;
            }

            StartCoroutine(StartMovingToNextCell(nextCell , TypeOfMovement));
        }

        private IEnumerator StartMovingToNextCell(Vector3Int nextCellToMove , DirectionType TypeOfMovement)
        {
            Vector3 currentPosition = gridForReference.GetCellCenterWorld(cellPlayerIsIn);
            Vector3 nextPositionToMove = gridForReference.GetCellCenterWorld(nextCellToMove);
            //calculate the next position of for the character to move to

            float elapseTime = 0f;
            string parameterKeyForAnimation = "";
            switch (TypeOfMovement)
            {
                case DirectionType.Up:
                    parameterKeyForAnimation = "up";
                    break;
                case DirectionType.Down:
                    parameterKeyForAnimation = "down";
                    break; 
                case DirectionType.Left:
                    parameterKeyForAnimation = "left";
                    break;
                case DirectionType.Right:
                    parameterKeyForAnimation = "right";
                    break;
                default: break;
            }

            animator.SetBool(parameterKeyForAnimation, true);

            while(elapseTime < timeToMove)
            {
                transform.position = Vector3.Lerp(currentPosition,
                    nextPositionToMove,
                    (elapseTime / timeToMove)
                    );
                elapseTime += Time.deltaTime;
                yield return null;
            }
            //now make sure the player is at this grid
            transform.position = nextPositionToMove;

            //make sure the script know there is no more movement
            //and prepare to listen for the next movement
            movementState = DirectionType.None; 
            cellPlayerIsIn = nextCellToMove;


            animator.SetBool(parameterKeyForAnimation, false);
            //make sure the sprite of the player is facing at a 
            //certain direction afterwards
            playerFacing = TypeOfMovement;
            switch (playerFacing)
            {
                case DirectionType.Up:
                    animator.runtimeAnimatorController = spriteUp;
                    break;
                case DirectionType.Down:
                    animator.runtimeAnimatorController = spriteDown;
                    break;
                case DirectionType.Left:
                    animator.runtimeAnimatorController = spriteLeft;
                    break;
                case DirectionType.Right:
                    animator.runtimeAnimatorController = spriteRight;
                    break;
                default:
                    animator.runtimeAnimatorController = spriteDown;
                    break;
            }

        }
        #endregion
    }

    public enum DirectionType
    {
        Right,
        Left,
        Up,
        Down,
        None //down is usually the normal position
    }
}
