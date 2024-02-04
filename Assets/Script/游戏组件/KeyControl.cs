using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KeyControl : MonoBehaviour
{
    private bool canGet;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D bx;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        bx = GetComponent<BoxCollider2D>();
        EventCenter.Instance.AddEventListener("切换世界", () => ChangeScene());
    }
    private void Update()
    {
        CanGet();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            EventCenter.Instance.EventTrigger<bool>("通关前置", true);
            AuidoMag.Instance.PlayOneShot("Music/放置道具");
            GetThis();
        }
    }

    private void ChangeScene()
    {
        canGet=!canGet;
    }

    private void CanGet()
    {
        if (canGet)
        {
            bx.isTrigger = true;
            spriteRenderer.DOFade(1f, 0.2f);
        }
        else
        {
            bx.isTrigger = false;
            spriteRenderer.DOFade(0.5f, 0.2f);
        }
    }

    private void GetThis()
    {
        DG.Tweening.Sequence sequence = DOTween.Sequence(this.gameObject);
        sequence.Append(this.gameObject.transform.DOMoveY(this.transform.position.y + 0.5f, 0.2f));
        sequence.OnComplete(()=>Destroy(this.gameObject));
    }
}
