using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundControl : MonoBehaviour
{
    private Animator ani;
    private bool isChanging;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        isChanging = true;
        EventCenter.Instance.AddEventListener("ÇÐ»»ÊÀ½ç",()=> ChangeScene());
    }
    private void Update()
    {
        ChangeIamge();
    }


    private void ChangeScene()
    {
        isChanging = !isChanging;
    }

    private void ChangeIamge()
    {
        if(isChanging)
        {
            ani.SetBool("changeScene" , false);
        }
        if(!isChanging)
        {
            ani.SetBool("changeScene", true);
        }
    }
}
