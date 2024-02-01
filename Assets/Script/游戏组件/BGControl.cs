using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGControl : MonoBehaviour
{
    private bool isChange;
    private Animator ani;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        isChange = true;
        EventCenter.Instance.AddEventListener("ÇÐ»»ÊÀ½ç",()=>ChangeScene());
    }
    private void Update()
    {
        ChangeImage();
    }

    private void ChangeScene()
    {
        isChange = !isChange;
    }

    private void ChangeImage()
    {
        if(isChange)
        {
            ani.SetBool("changeScene", true);
        }
        if(!isChange)
        {
            ani.SetBool("changeScene", false);
        }
    }
}
