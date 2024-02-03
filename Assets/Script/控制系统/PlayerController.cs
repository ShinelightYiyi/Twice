using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D p_Rd;
    private Animator ani;
    private float input_x;
    private BoxCollider2D p_BX;         
    bool isGround;
    public bool canOpenDoor;
    bool isChanging;
    [SerializeField] LayerMask groundLayer;
    private float high =8.2f;
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        p_BX = GetComponent<BoxCollider2D>();
        p_Rd = Player.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        isChanging = false;
        ani = GetComponent<Animator>();
        EventCenter.Instance.AddEventListener<bool>("开门", (o) => CanOpenTheDoor(o));
        EventCenter.Instance.AddEventListener("切换世界", () => ChangeScene());
    }
    private void Update()
    {
        Jump();
        MoveX();
        RayCast();
        PlayerImage();
    }

    private void MoveX()
    {
        input_x = Input.GetAxisRaw("Horizontal");
        if(input_x < 0)
        {
            ani.SetBool("isWalking", true);
           Player.transform.localScale = new Vector3(-0.15f,Player.transform.localScale.y, 0);
        }
        else if(input_x > 0)
        {
            ani.SetBool("isWalking", true);
            Player.transform.localScale = new Vector3(0.15f, Player.transform.localScale.y, 0);
        }
        else if(input_x == 0)
        {
            ani.SetBool("isWalking", false);
        }

          p_Rd.velocity = new Vector2(input_x*5, p_Rd.velocity.y);

        if (canOpenDoor)
        {
            //  Debug.Log("可以开门");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                EventCenter.Instance.EventTrigger("活动门"); 
            }
        }
    }


    private void RayCast()
    {
        if (isChanging)
        {
            RaycastHit2D hit = Physics2D.Raycast(p_BX.bounds.center - new Vector3(0, p_BX.bounds.extents.y, 0), Vector2.down, 0.1f, groundLayer);
            //Debug.DrawLine(transform.position, Vector2.down);
            if (hit.collider != null)
            {
                isGround = true;
            }
            else if (hit.collider == null)
            {
                isGround = false;
            }
        }
        else if (!isChanging)
        {
            RaycastHit2D hit = Physics2D.Raycast(p_BX.bounds.center + new Vector3(0, p_BX.bounds.extents.y, 0), Vector2.up, 0.1f, groundLayer);
            //Debug.DrawLine(transform.position, Vector2.down);
            if (hit.collider != null)
            {
                isGround = true;
            }
            else if (hit.collider == null)
            {
                isGround = false;
            }
        }
    }


    private void Jump()
    {
        if(isGround && Input.GetKeyDown(KeyCode.W) && isChanging)
        {          
            p_Rd.AddForce(new Vector2(0f, 1f*high),ForceMode2D.Impulse);
            ani.SetBool("isWalking", false);
        }
        if (isGround && Input.GetKeyDown(KeyCode.W) && !isChanging)
        {
            p_Rd.AddForce(new Vector2(0f, -50f*high));
            ani.SetBool("isWalking", false);
        }
    }


    private void CanOpenTheDoor(bool canOpen)
    {
        if(canOpen)
        {
            Debug.Log("A");
            canOpenDoor = true;
        }
        else 
        { 
            canOpenDoor = false; 
        }
    }

    private void ChangeScene()
    {
        isChanging = !isChanging;      
    }

    private void PlayerImage()
    {
        if(isChanging)
        {
            if(p_Rd.gravityScale<0)
            {
                p_Rd.gravityScale *= -1;
                Player.transform.localScale = new Vector3(Player.transform.localScale.x, -1 * Player.transform.localScale.y, Player.transform.localScale.z);
            }
            
            ani.SetBool("changeScene", false);
        }
        if(!isChanging)
        {
            if (p_Rd.gravityScale > 0)
            {
                p_Rd.gravityScale *= -1;
                Player.transform.localScale = new Vector3(Player.transform.localScale.x, -1 * Player.transform.localScale.y, Player.transform.localScale.z);
            }
            ani.SetBool("changeScene", true);
        }
    }


}
