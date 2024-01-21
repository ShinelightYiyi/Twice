using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonoManager
{
    private MonoManager instance;
    public MonoManager Instance { get=>instance ?? new MonoManager(); }
    //单例模式

    private MonoController controller;
    public MonoManager()
    {
        GameObject obj = new GameObject("MonoController");
        controller = obj.AddComponent<MonoController>();
    }

    /// <summary>
    ///添加帧更新事件 
    /// </summary>
    /// <param name="action"></param>
    public void AddUpdateListener(UnityAction action)
    {
        controller.AddUpdateListener(action);
    }

    /// <summary>
    /// 移除帧更新事件
    /// </summary>
    /// <param name="action"></param>

    public void RemoveUpdateListener(UnityAction action) 
    {
        controller.RemoveUpdateListener(action);
    }

    public Coroutine StartCroutine(IEnumerator routine)
    {
        return controller.StartCoroutine(routine);
    }

    public Coroutine StartCroutine(string methodName)
    {
        return controller.StartCoroutine(methodName);
    }

    public Coroutine StartCroutine(string methodName, object value)
    {
        return controller.StartCoroutine(methodName, value);
    }

}
