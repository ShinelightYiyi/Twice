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
            EventCenter.Instance.EventTrigger<bool>("����", true);
          //  Debug.Log("����");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("����");
            EventCenter.Instance.EventTrigger<bool>("����", false);
        }
    }

    private void Open()
    {
       door.transform.DOMoveY(10,1f);
    }

    private void Start()
    {
        door = GameObject.FindGameObjectWithTag("Door");
        EventCenter.Instance.AddEventListener("����", () => Open());
    }

}
