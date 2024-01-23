using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IEventInfo
{
    //����۲���
}


//���͹۲���
public class EventInfo<T> : IEventInfo
{
    public UnityAction<T> actions;

    public EventInfo(UnityAction<T> action)
    {
        actions += action;
    }
}


//�����۲���
public class EventInfo : IEventInfo
{
    public UnityAction actions;

    public EventInfo(UnityAction action)
    {
        actions += action;
    }
}



public class EventCenter //֪ͨ��
{
    private static EventCenter instance;
    public static EventCenter Instance { get=> instance ?? new EventCenter(); }
    

    /// <summary>
    /// key �� �¼�����   IEventInfo:��Ӧ�¼�
    /// </summary>
    private static Dictionary<string, IEventInfo>  eventDic = new Dictionary<string, IEventInfo>();   


    /// <summary>
    /// ������Ҫ���ݲ������¼�
    /// </summary>
    /// <typeparam ��������></typeparam>
    /// <param �¼�����></param>
    /// <param ί�к�������></param>
    public void AddEventListener<T>(string name, UnityAction<T> action)
    {
        if(eventDic.ContainsKey(name)) 
        {
            Debug.Log("�����¼�" + name);
            (eventDic[name] as EventInfo<T>).actions += action;
        }
        else
        {
            Debug.Log("�����¼�" + name);
            eventDic.Add(name , new EventInfo<T>(action));
        }
    }

    /// <summary>
    /// ���Ĳ���Ҫ���ݲ������¼�
    /// </summary>
    /// <param �¼�����></param>
    /// <param ί�к�������></param>
    public void AddEventListener(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
        {
            Debug.Log("�����¼�" + name);
            (eventDic[name] as EventInfo).actions += action;
        }
        else
        {
            Debug.Log("�����¼�" + name);
            eventDic.Add(name, new EventInfo(action));
        }
    }


    /// <summary>
    /// �Ӻ��������¼����Ƴ�ί��
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
    /// �������������¼�
    /// </summary>
    /// <typeparam ����Ĳ���></typeparam>
    /// <param name="name"></param>
    /// <param name="info"></param>
    public void EventTrigger<T>(string name , T info)
    {
        if(eventDic.ContainsKey(name))
        {
            if ((eventDic[name] as EventInfo<T>).actions != null) 
            {
                (eventDic[name] as EventInfo<T>).actions.Invoke(info);
                Debug.Log("�����¼�" + name);
            }
            else
            {
                Debug.Log("�¼��޶�����");
            }
        }
        else
        {
            Debug.Log("�¼�������");
        }       
    }

    /// <summary>
    /// ���������������¼�
    /// </summary>
    /// <param name="name"></param>
    public void EventTrigger(string name)
    {
        if (eventDic.ContainsKey(name))
        {
            if ((eventDic[name] as EventInfo).actions != null)
            {
                (eventDic[name] as EventInfo).actions.Invoke();
                Debug.Log("�����¼�" + name);
            }
            else
            {
                Debug.Log("�¼��޶�����");
            }
        }
        else
        {
            Debug.Log("�¼�������");
        }
    }

    /// <summary>
    /// ����¼�����������ʱ����ʹ��
    /// </summary>
    public void Clear()
    {
        eventDic.Clear();
    }
}
