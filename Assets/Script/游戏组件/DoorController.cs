using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorController : MonoBehaviour
{
    public GameObject door;
    public int XValue;
    public int YValue;
    public float duration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            EventCenter.Instance.EventTrigger<bool>("开门", true);
          //  Debug.Log("进入");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("进入");
            EventCenter.Instance.EventTrigger<bool>("开门", false);
        }
    }

    private void Open()
    {
       door.transform.DOMoveY(YValue,duration);
       door.transform.DOMoveX(XValue,duration);
    }
    
    private void Close()
    {
        door.transform.DOMoveY(-YValue,duration);
        door.transform.DOMoveX(-XValue,duration);
    }
    private void Start()
    {
        EventCenter.Instance.AddEventListener("打开门", () => Open());
        
    }


}
