using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Runtime.CompilerServices;

public class RePanel : BasePanel
{
    private static string name = "RePanel";
    private static string path = "Panel/RePanel";
    public static readonly UIType newUIType = new UIType(name, path);
    public RePanel() : base(newUIType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        PassIn();
        EventCenter.Instance.AddEventListener<float>("¼ÓÔØ³¡¾°", (o) => PassOut(o));
    }

    private void PassIn()
    {
        GameObject go = GameObject.FindGameObjectWithTag("RePanel");
        DG.Tweening.Sequence sequence = DOTween.Sequence(go);
        sequence.Append(go.transform.DOMoveY(258.50f, 0.2f));
        Debug.Log(go.transform.position);
    }

    private void PassOut(float o)
    {
        if(o==1)
        {
          
            GameObject go = GameObject.FindGameObjectWithTag("RePanel");
            DG.Tweening.Sequence sequence = DOTween.Sequence(go);
            sequence.Append(go.transform.DOMoveY(780.50f, 0.2f));
            sequence.OnComplete(() => GameObject.Destroy(go));
            Debug.Log(go.transform.position);
        }
    }
}
