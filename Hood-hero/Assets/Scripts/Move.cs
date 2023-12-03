using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public CharacterController mCharacterController;
    public EManager mEManager;

    private float hInput;
    private float vInput;
    private float speed;


    [SerializeField]
    public float mWalkSpeed = 10f;
    public int compleated = 1;
    public int lives = 1;
    public int total_task = 10;
    // Start is called before the first frame update
    void Start()
    {
        mCharacterController = GetComponent<CharacterController>();
        mEManager = GetComponent<EManager>();
    }
    
    // Update is called once per frame
    void Update()
    {
        HandleInputs();
        Moves();
        mEManager.CompleatedTask(compleated , total_task);
        mEManager.CrossCount(lives);
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

    private void Moves()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");



        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        mCharacterController.Move(move * Time.deltaTime * mWalkSpeed);
    }
}
