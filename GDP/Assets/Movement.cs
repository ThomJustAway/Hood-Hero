using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public CharacterController mCharacterController;

    private float hInput;
    private float vInput;
    private float speed;

    [SerializeField]
    public float mWalkSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        mCharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInputs();
        Move();
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

        

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        mCharacterController.Move(move * Time.deltaTime * mWalkSpeed);
    }

    
}
       

    
