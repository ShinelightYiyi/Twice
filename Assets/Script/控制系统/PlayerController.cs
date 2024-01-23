using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D p_Rd;
    float input_x;
    private BoxCollider2D p_BX;
    bool isGround;
    bool canOpenDoor;
    [SerializeField] bool isUp;
    [SerializeField]
    LayerMask groundLayer;
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        p_BX = GetComponent<BoxCollider2D>();
        p_Rd = Player.GetComponent<Rigidbody2D>();
    }

    private void MoveX()
    {
        input_x = Input.GetAxisRaw("Horizontal");
        p_Rd.velocity = new Vector2(input_x*5, p_Rd.velocity.y);
        if (canOpenDoor)
        {
          //  Debug.Log("可以开门");
            if (Input.GetKeyDown(KeyCode.Space))
                EventCenter.Instance.EventTrigger("打开门");
        }
    }
    private void UpToDown(bool canDown)
    {
        if(canDown)
        {
            Player.transform.position = new Vector3(Player.transform.position.x, -Player.transform.position.y, 0);
            p_Rd.gravityScale *= -1;
            isUp = !isUp;
        }

    }
    private void RayCast()
    {
        if (isUp)
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
        else if (!isUp)
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
        if(isGround && Input.GetKeyDown(KeyCode.W) && isUp)
        {
            p_Rd.AddForce(new Vector2(0f, 200f));
        }
        if (isGround && Input.GetKeyDown(KeyCode.W) && !isUp)
        {
            p_Rd.AddForce(new Vector2(0f, -200f));
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

    private void Start()
    {
        EventCenter.Instance.AddEventListener<bool>("开门", (o) => CanOpenTheDoor(o));
        EventCenter.Instance.AddEventListener<bool>("翻转" , (o) => UpToDown(o));
        isUp = true;
        UnityAction myAction = null;
        myAction += Jump;
        myAction += MoveX;
        myAction += RayCast;
        MonoManager.Instance.AddUpdateListener(myAction);
    }


}
