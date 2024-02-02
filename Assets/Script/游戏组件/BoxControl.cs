using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControl : MonoBehaviour
{

    private Rigidbody2D rg;
    private SpriteRenderer sp;
    private BoxCollider2D box;
    private GameObject player;
    [SerializeField] bool isDown, isHurt;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        box = GetComponent<BoxCollider2D>();
        sp = GetComponent<SpriteRenderer>();
        rg = GetComponent<Rigidbody2D>();
        EventCenter.Instance.AddEventListener("ÇÐ»»ÊÀ½ç", () => ChangeScene());    
    }

    private void Update()
    {
        ChangeGrivaty();
        CanHurt();
    }

    private void CanHurt()
    {
        if(isHurt)
        {
            box.isTrigger = true;
        }
        else if(!isHurt) 
        {
            box.isTrigger = false;
        }
    }
    private void ChangeGrivaty()
    {
        if(isDown && rg.gravityScale<0)
        {
            rg.gravityScale = -rg.gravityScale;
            sp.color = Color.red;
        }
        else if(!isDown && rg.gravityScale>0)
        {
            rg.gravityScale = -rg.gravityScale;
            sp.color = Color.yellow;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(player);
        }
    }
    private void ChangeScene()
    {
        isDown = !isDown;
        isHurt = !isHurt;
    }
}
