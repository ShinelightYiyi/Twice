using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IEventInfo
{
    //抽象观察者
}


//泛型观察者
public class EventInfo<T> : IEventInfo
{
    public UnityAction<T> actions;

    public EventInfo(UnityAction<T> action)
    {
        actions += action;
    }
}


//基本观察者
public class EventInfo : IEventInfo
{
    public UnityAction actions;

    public EventInfo(UnityAction action)
    {
        actions += action;
    }
}



public class EventCenter //通知者
{
    private static EventCenter instance;
    public static EventCenter Instance { get=> instance ?? new EventCenter(); }
    

    /// <summary>
    /// key ： 事件名称   IEventInfo:对应事件
    /// </summary>
    private static Dictionary<string, IEventInfo>  eventDic = new Dictionary<string, IEventInfo>();   


    /// <summary>
    /// 订阅需要传递参数的事件
    /// </summary>
    /// <typeparam 参数类型></typeparam>
    /// <param 事件名称></param>
    /// <param 委托函数名称></param>
    public void AddEventListener<T>(string name, UnityAction<T> action)
    {
        if(eventDic.ContainsKey(name)) 
        {
            Debug.Log("加入事件" + name);
            (eventDic[name] as EventInfo<T>).actions += action;
        }
        else
        {
            Debug.Log("加入事件" + name);
            eventDic.Add(name , new EventInfo<T>(action));
        }
    }

    /// <summary>
    /// 订阅不需要传递参数的事件
    /// </summary>
    /// <param 事件名称></param>
    /// <param 委托函数名称></param>
    public void AddEventListener(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
        {
            Debug.Log("加入事件" + name);
            (eventDic[name] as EventInfo).actions += action;
        }
        else
        {
            Debug.Log("加入事件" + name);
            eventDic.Add(name, new EventInfo(action));
        }
    }


    /// <summary>
    /// 从含参数的事件中移除委托
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public void RemoveEventListener<T>(string name,UnityAction<T> action)
    {
        if(!eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).actions -= action;
        }
    }

    public void RemoveEventListener(string name, UnityAction action)
    {
        if (!eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).actions -= action;
        }
    }

    /// <summary>
    /// 触发含参数的事件
    /// </summary>
    /// <typeparam 传入的参数></typeparam>
    /// <param name="name"></param>
    /// <param name="info"></param>
    public void EventTrigger<T>(string name , T info)
    {
        if(eventDic.ContainsKey(name))
        {
            if ((eventDic[name] as EventInfo<T>).actions != null) 
            {
                (eventDic[name] as EventInfo<T>).actions.Invoke(info);
                Debug.Log("触发事件" + name);
            }
            else
            {
                Debug.Log("事件无订阅者");
            }
        }
        else
        {
            Debug.Log("事件不存在");
        }       
    }

    /// <summary>
    /// 触发不含参数的事件
    /// </summary>
    /// <param name="name"></param>
    public void EventTrigger(string name)
    {
        if (eventDic.ContainsKey(name))
        {
            if ((eventDic[name] as EventInfo).actions != null)
            {
                (eventDic[name] as EventInfo).actions.Invoke();
                Debug.Log("触发事件" + name);
            }
            else
            {
                Debug.Log("事件无订阅者");
            }
        }
        else
        {
            Debug.Log("事件不存在");
        }
    }

    /// <summary>
    /// 清空事件，场景加载时可能使用
    /// </summary>
    public void Clear()
    {
        eventDic.Clear();
    }
}
