using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoodHeroUI
{
    public class Movement : MonoBehaviour
    {
    

        public CharacterController mCharacterController;

        private float hInput;
        private float vInput;
        private float speed;
    
        public EventManager mEventManager;

        [SerializeField]
        public float mWalkSpeed = 10f;
        public int i;
        public int noOfCross;
        // Start is called before the first frame update
        void Start()
        {
            mCharacterController = GetComponent<CharacterController>();
            mEventManager = GetComponent<EventManager>();
        }

        // Update is called once per frame
        void Update()
        {
            //int i;
            HandleInputs();
            Move();
            mEventManager.CompletedTask(i);
            mEventManager.CrossCount(noOfCross);


        }

        private void HandleInputs()
        {
            // We shall handle our inputs here.
            hInput = Input.GetAxis("Horizontal");
            vInput = Input.GetAxis("Vertical");
        


            speed = mWalkSpeed;

           // if (Input.GetKey(KeyCode.LeftShift))
           // {
              //  speed = mWalkSpeed * 2.0f;
            //}
       
        }

        private void Move()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

        

            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0 );

            mCharacterController.Move(move * Time.deltaTime * mWalkSpeed);
        }
    
    
    }
}
       

    
