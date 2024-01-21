using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PanelPass : BasePanel
{
    private static string name = "PanelPass";
    private static string path = "Panel/PanelPass";
    public static readonly UIType newUIType = new UIType(name, path);
    public PanelPass() : base(newUIType)
    {

    }

    public override void OnStart()
    {
        FadeIn();
        EventCenter.Instance.AddEventListener<float>("¼ÓÔØ³¡¾°" ,(o)=> FadeAway(o));
        base.OnStart();
    }

    private void FadeIn()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Pass");
        Image image = go.GetComponent<Image>();
        DG.Tweening.Sequence sequence = DOTween.Sequence(image);
        sequence.Append(image.DOFade(1f, 0.5f));
    }

    private void FadeAway(float o)
    {
        if(o == 1)
        {
            GameObject go = GameObject.FindGameObjectWithTag("Pass");
            Image image = go.GetComponent<Image>();
            DG.Tweening.Sequence sequence = DOTween.Sequence(image);
            sequence.Append(image.DOFade(0f, 0.5f));
            sequence.OnComplete(() => GameObject.Destroy(go));
        }
    }
}
