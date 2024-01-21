using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class BaseScene
{
    private string sceneName;
    public string SceneName { get => sceneName; }

    public BaseScene(string name)
    {
        sceneName = name;
    }
    public virtual void EnterScene()
    {
        Debug.Log("���볡��" + sceneName);
    }
    public virtual void ExitScene()
    {
        Debug.Log("�뿪" + sceneName + "����");
    }

}
