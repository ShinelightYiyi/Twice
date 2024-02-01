using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("切换世界");
            EventCenter.Instance.EventTrigger("切换世界");
        }
    }
}
