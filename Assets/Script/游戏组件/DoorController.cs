using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorController : MonoBehaviour
{
    [SerializeField] GameObject Door;
    [SerializeField] GameObject P1;
    [SerializeField] GameObject P2;
    [SerializeField] float duration;
    private bool isOpen;

    private void Awake()
    {
        EventCenter.Instance.AddEventListener("���", () => ControlDoor());
    }
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

    private void ControlDoor()
    {
        if (!isOpen)
        {
            Door.transform.DOMove(P2.transform.position, duration);
            isOpen = !isOpen;
        }
        else if(isOpen )
        {
            Door.transform.DOMove(P1.transform.position, duration);
            isOpen = !isOpen;
        }
    }
    




}
