using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Move : MonoBehaviour
{
    
    public EManager mEManager;
    public Rigidbody2D rb;
    public Sprite playerSprite;




    [SerializeField]
    public float mWalkSpeed = 10f;
    public int compleated = 1;
    public int lives = 1;
    public int total_task = 10;
    // Start is called before the first frame update

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mEManager = GetComponent<EManager>();
        playerSprite = GetComponent<Sprite>();
    }
    
    // Update is called once per frame
    void Update()
    {
        mEManager.CompleatedTask(compleated , total_task);
        mEManager.CrossCount(lives);
    }
   

   

    public void Stop()
    {

        rb.velocity = Vector2.zero;
        
    }
    public void MoveUp()
    {
        rb.velocity = Vector2.up * mWalkSpeed;
    }

    public void MoveDown()
    {
        rb.velocity = Vector2.down * mWalkSpeed;
    }

    public void MoveLeft()
    {
        rb.velocity = Vector2.left * mWalkSpeed;
    }

    public void MoveRight()
    {
        rb.velocity = Vector2.right * mWalkSpeed;
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

