using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIMethod
{
    private static UIMethod instance;
    public static UIMethod Instance { get => instance ?? new UIMethod(); }
    //单例模式



    /// <summary>
    /// 获取场景中的Canvas
    /// </summary>
    /// <returns></returns>
    public GameObject FindCanvas()
    {
        GameObject go = GameObject.FindObjectOfType<Canvas>().gameObject;
        if(go == null)
        {
            Debug.LogWarning("无效的获取Canvas");
            return null;
        }
        return go;
    }


    /// <summary>
    /// 获得一个物体的子物体
    /// </summary>
    /// <param 父物体></param>
    /// <param 子物体名称></param>
    /// <returns></returns>
    public GameObject FindObjectInChild(GameObject panel , string childName)
    {
        Transform[] transforms = panel.GetComponentsInChildren<Transform>();
        foreach(var va in transforms) 
        {
            if(va.gameObject.name == childName)
            {
                return va.gameObject;
            }
        }
        Debug.LogWarning("未找到" + panel.gameObject.name + "的子物体" + childName);
        return null;
    }


    /// <summary>
    /// 为物体添加组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public T AddOrGetComponent<T>(GameObject obj) where T : Component
    {
        T component = obj.GetComponent<T>();
        if (component == null)
        {
            component = obj.AddComponent<T>();
        }
        return component;
    }

    /// <summary>
    /// 获得子物体上的组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="parentObject"></param>
    /// <param name="childObjectName"></param>
    /// <returns></returns>
    public T GetSpecificChildComponent<T>(GameObject parentObject, string childObjectName) where T : Component
    {
        // 查找指定名字的子物体
        Transform childTransform = parentObject.transform.Find(childObjectName);

        if (childTransform != null)
        {
            // 获取指定子物体上的指定组件
            T component = childTransform.GetComponent<T>();

            // 如果找到组件，返回该组件
            if (component != null)
            {
                return component;
            }
            else
            {
                component = childTransform.AddComponent<T>();
            }
        }
        else
        {
            Debug.LogWarning("Child object with name " + childObjectName + " not found.");
        }

        // 如果未找到组件或子物体，返回 null（或者你可以根据需要进行其他处理）
        return null;
    }


}