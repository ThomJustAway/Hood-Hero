using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using 


public class Move : MonoBehaviour
{
    
    //public EManager mEManager;
    public Rigidbody2D rb;
    //public Sprite playerSprite;
    public Animator player;




    [SerializeField]
    public float mWalkSpeed = 10f;
    public int compleated = 1;
    public int lives = 1;
    public int total_task = 10;
    // Start is called before the first frame update

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //mEManager = GetComponent<EManager>();
        //playerSprite = GetComponent<Sprite>();
    }
    
    // Update is called once per frame
    //void Update()
    //{
    //    mEManager.CompleatedTask(compleated , total_task);
    //    mEManager.CrossCount(lives);
    //}
   

   

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

