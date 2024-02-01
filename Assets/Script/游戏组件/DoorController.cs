using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorController : MonoBehaviour
{
    private GameObject door;
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
       door.transform.DOMoveY(10,1f);
    }

    private void Start()
    {
        door = GameObject.FindGameObjectWithTag("Door");
        EventCenter.Instance.AddEventListener("打开门", () => Open());
    }

}
