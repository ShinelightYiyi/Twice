using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            EventCenter.Instance.EventTrigger<bool>("Õ®πÿ«∞÷√", true);
        }
    }
}
