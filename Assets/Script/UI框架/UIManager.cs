using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    private static UIManager instance;
    public static UIManager Instance { get => instance ?? (instance = new UIManager()); }
    public UIManager()
    {
        uiObjectDic = new Dictionary<string, GameObject>();
        uiStack = new Stack<BasePanel>();
    }

    ///<summary>
    ///存储UI信息
    /// </summary>
    public Dictionary<string, GameObject> uiObjectDic;

    ///<summary>
    ///通过栈类型，装入UI
    /// </summary>
    public Stack<BasePanel> uiStack;

    ///<summary>
    ///当前场景下的Canvas
    /// </summary>
    public GameObject canvasObj;

    /// <summary>
    /// 加载UI至场景的Canvas中
    /// </summary>
    /// <param name="uiType"></param>
    /// <returns></returns>
    public GameObject GetSingleObject(UIType uiType)
    {
        if (uiObjectDic.ContainsKey(uiType.Name))
        {
            return uiObjectDic[uiType.Name];
        }

        if (canvasObj == null)
        {
            canvasObj = UIMethod.Instance.FindCanvas();
        }

        GameObject gameObject = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(uiType.Path), canvasObj.transform);

        return gameObject;
    }

    /// <summary>
    /// 将UI推入场景
    /// </summary>
    /// <param name="basePanel"></param>
    public void Push(BasePanel basePanel)
    {
        if (uiStack.Count > 0)
        {
            uiStack.Peek().OnDisable();
        }

        GameObject uiObject = GetSingleObject(basePanel.uiType);

        uiObjectDic.Add(basePanel.uiType.Name, uiObject);

        basePanel.activeObj = uiObject;

        if (uiStack.Count == 0)
        {
            uiStack.Push(basePanel);
        }

        else if (uiStack.Peek().uiType.Name != basePanel.uiType.Name)
        {
            uiStack.Push(basePanel);
        }

        basePanel.OnStart();
    }

    /// <summary>
    /// 将UI推出场景,为ture时推出所有UI，为false时推出场景最顶端的UI
    /// </summary>
    /// <param name="isLoad"></param>
    public void Pop(bool isLoad)
    {
        if (isLoad)
        {
            if (uiStack.Count > 0)
            {
                uiStack.Peek().OnDisable();
                uiStack.Peek().OnDestroy();
                GameObject.Destroy(uiObjectDic[uiStack.Peek().uiType.Name]);
                uiObjectDic.Remove(uiStack.Peek().uiType.Name);
                uiStack.Pop();
                Pop(true);
            }
        }
        else
        {
            if (uiStack.Count > 0)
            {
                uiStack.Peek().OnDisable();
                uiStack.Peek().OnDestroy();

                // GameObject.Destroy(uiObjectDic[uiStack.Peek().uiType.Name]);
                uiObjectDic.Remove(uiStack.Peek().uiType.Name);
                uiStack.Pop();

                if (uiObjectDic.Count > 0)
                {
                    uiStack.Peek().OnEnable();
                }
            }
        }
    }

}
