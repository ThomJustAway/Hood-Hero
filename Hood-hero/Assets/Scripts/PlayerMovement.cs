using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontal;
    float vertical;
    public float speed = 5f;
    public float rotationSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector3 movementVector = new Vector3(horizontal, vertical, 0);
        transform.position += movementVector.normalized * speed * Time.deltaTime; //move without rotation affecting
        RotatePlayer(movementVector);
    }

    private void RotatePlayer(Vector3 movementVector)
    {
        float angleToRotate = Vector3.Angle(transform.up, movementVector.normalized);
        transform.Rotate(Quaternion.AngleAxis(angleToRotate, Vector3.forward).eulerAngles);
    }

    //private void FixedUpdate()
    //{
    //    rb.velocity = new Vector3(horizontal * speed, vertical * speed, 0);
    //}
}
