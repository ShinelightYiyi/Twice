using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelA : BasePanel
{
    private static string name = "PanelA";
    private static string path = "Panel/PanelA";
    public static readonly  UIType newUITpye = new UIType(name, path);
    public PanelA() : base(newUITpye)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        UIMethod.Instance.GetSpecificChildComponent<Button>(activeObj, "Change").onClick.AddListener(ChangeScene);
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    private void ChangeScene()
    {
        MonoManager.Instance.StartCroutine(ReallyChangeScene());
    }

    private IEnumerator ReallyChangeScene()
    {
        Debug.Log("µã»÷³É¹¦");
        GameRoot.Instance.rootUIManager.Pop(true);
        GameRoot.Instance.rootUIManager.Push(new PanelPass());
        yield return new WaitForSeconds(0.25f);
    }
}
