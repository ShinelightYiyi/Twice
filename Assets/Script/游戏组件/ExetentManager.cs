using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExetentManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            EventCenter.Instance.EventTrigger<bool>("��ת", true);
        }
    }
}
