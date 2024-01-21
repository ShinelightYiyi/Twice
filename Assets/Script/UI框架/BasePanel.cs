using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePanel
{
    public UIType uiType;
    public GameObject activeObj;
    public BasePanel(UIType UIType)
    {
        uiType = UIType;
    }
    public virtual void OnStart() 
    {
        UIMethod.Instance.AddOrGetComponent<CanvasGroup>(activeObj).interactable = true;
    }
    public virtual void OnEnable() 
    {
        UIMethod.Instance.AddOrGetComponent<CanvasGroup>(activeObj).interactable = true;
    }
    public virtual void OnDisable() 
    {
        UIMethod.Instance.AddOrGetComponent<CanvasGroup>(activeObj).interactable = false;
    }
    public virtual void OnDestroy() 
    {
        UIMethod.Instance.AddOrGetComponent<CanvasGroup>(activeObj).interactable = false;
    }
}
