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

        if (movementVector != Vector3.zero)
        {
            Quaternion rotation = Quaternion.FromToRotation(transform.rotation.eulerAngles, movementVector);
            transform.Rotate(rotation.eulerAngles);
        }

        transform.position += movementVector.normalized * speed * Time.deltaTime; //move without rotation affecting
        Debug.DrawRay(transform.position, transform.up * 10 , Color.green);
    }

    //private void FixedUpdate()
    //{
    //    rb.velocity = new Vector3(horizontal * speed, vertical * speed, 0);
    //}
}
