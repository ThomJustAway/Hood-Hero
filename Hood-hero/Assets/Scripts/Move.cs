using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using 


public class Move : MonoBehaviour
{
    
    public SliderManager mEManager;
    public Rigidbody2D rb;
    public Animator player;

    [SerializeField]
    public float mWalkSpeed = 10f;


    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mEManager = GetComponent<SliderManager>();
        //playerSprite = GetComponent<Sprite>();
    }
    
    // Update is called once per frame
    void Update()
    {
        //why call this here????
        //mEManager.CompleteTask();
    }

    public void Stop()
    {

        rb.velocity = Vector2.zero;
        //playerSprite.
    }
    public void MoveUp()
    {
        rb.velocity = Vector2.up * mWalkSpeed;
        player.SetBool("up",true);
        player.SetBool("right", false);
        player.SetBool("down", false);
        player.SetBool("left", false);

    }

    public void MoveDown()
    {
        rb.velocity = Vector2.down * mWalkSpeed;
        player.SetBool("down", true);
        player.SetBool("up", false);
        player.SetBool("right", false);
        player.SetBool("left", false);
    }

    public void MoveLeft()
    {
        rb.velocity = Vector2.left * mWalkSpeed;
        player.SetBool("left", true);
        player.SetBool("up", false);
        player.SetBool("right", false);
        player.SetBool("down", false);
    }

    public void MoveRight()
    {
        rb.velocity = Vector2.right * mWalkSpeed;
        player.SetBool("right", true);
        player.SetBool("up", false);
        player.SetBool("down", false);
        player.SetBool("left", false);
    }
    

    public void OnPointerDown(PointerEventData eventData)
    {
        //buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //buttonPressed = false;
    }
}

